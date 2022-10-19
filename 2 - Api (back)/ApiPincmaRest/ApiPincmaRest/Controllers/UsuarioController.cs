using ApiPincmaRest.DTOs;
using ApiPincmaRest.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;
        private readonly IDataProtector dataProtector;

        public UsuarioController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            SignInManager<IdentityUser> signInManager,
            IMapper mapper,
            IDataProtectionProvider dataProtectionProvider)
        {
            this.context = context;
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.mapper = mapper;
            dataProtector = dataProtectionProvider.CreateProtector("Encriptar_Claves_Con_Palabras_Secreta_Y_Segura");
        }

        [HttpGet("Obtener/{mail}")]
        public async Task<Usuario> Get(string mail)
        {
            
            Usuario U = null;
            var user = (from Usuario in context.Usuario
                        join TipoDoc in context.TipoDocumento on Usuario.idTipoDocumento equals TipoDoc.idTipoDocumento
                        where Usuario.mail == mail
                        select new
                        {
                            Usuario.mail,
                            Usuario.nombre,
                            Usuario.apellido,
                            Usuario.documento,
                            TipoDoc.nombreTipoDocumento
                        }).FirstOrDefault();
            if (user != null)
            {
                U = new Usuario
                {
                    mail = user.mail,
                    nombre = user.nombre,
                    apellido = user.apellido,
                    documento = user.documento,
                    //nombreTipoDocumento = user.nombreTipoDocumento
                };
            }
            return U;
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi"); // La clave debe ser de 8 caracteres
                byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
                byte[] buffer = Encoding.UTF8.GetBytes(usuarioDTO.clave);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Key = EncryptionKey;
                des.IV = IV;

                usuarioDTO.clave = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
                var usuario = mapper.Map<Usuario>(usuarioDTO);
                context.Add(usuario);
                await context.SaveChangesAsync();
                return Ok(usuario);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<RespuestaAutenticacion>> Login([FromBody] CredencialesUsuario credencialesUsuario)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi"); // La clave debe ser de 8 caracteres
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
            byte[] buffer = Encoding.UTF8.GetBytes(credencialesUsuario.clave);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;

            credencialesUsuario.clave = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            
            int resultado = (from u in context.Usuario
                             where u.mail == credencialesUsuario.mail &&
                             u.clave == credencialesUsuario.clave
                             select u).Count();
            if (resultado!=0)
            {
                var usuario = (from u in context.Usuario
                                               where u.mail == credencialesUsuario.mail &&
                                               u.clave == credencialesUsuario.clave
                                               select u).FirstOrDefault();
                return ConstruirToken(credencialesUsuario, usuario.nombre);
            }
            else
            {
                return Ok();
            }
        }

        private RespuestaAutenticacion ConstruirToken(CredencialesUsuario credencialesUsuario, string nombre)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credencialesUsuario.mail),
                new Claim("nombre", nombre)
            };
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);
            var securityToken = new JwtSecurityToken(issuer: null, claims: claims, expires: expiration, signingCredentials: creds);

            return new RespuestaAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiration
            };
        }

    }
}
