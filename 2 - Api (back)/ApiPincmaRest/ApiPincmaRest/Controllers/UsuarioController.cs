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

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController:ControllerBase
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
            IDataProtectionProvider dataProtectionProvider )
        {
            this.context = context;
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.mapper = mapper;
            dataProtector= dataProtectionProvider.CreateProtector("Encriptar_Claves_Con_Palabras_Secreta_Y_Segura");
        }

        //public Encriptacion Encriptar(string texto)
        //{
        //    return new Encriptacion
        //    {
        //        claveEncriptada = dataProtector.Protect(texto)
        //    };
        //}

        [HttpPost("registrar")]
        public async Task<ActionResult> Post(UsuarioDTO usuarioDTO)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi"); // La clave debe ser de 8 caracteres
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
            byte[] buffer = Encoding.UTF8.GetBytes(usuarioDTO.clave);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;

            //    return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            //var res = Encriptar(usuarioDTO.clave);
            usuarioDTO.clave = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            var usuario = mapper.Map<Usuario>(usuarioDTO);
            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login(CredencialesUsuario credencialesUsuario)
        {
            int resultado = (from u in context.Usuario
                             where u.mail == credencialesUsuario.mail &&
                             u.clave == credencialesUsuario.clave
                             select u).Count();
            //var resultado= await signInManager.PasswordSignInAsync(credencialesUsuario.mail,credencialesUsuario.clave,isPersistent:false,lockoutOnFailure:false);
            if (resultado!=0)
            {
                return ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest("Login Incorrecto");
            }
        }

        private RespuestaAutenticacion ConstruirToken(CredencialesUsuario credencialesUsuario)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credencialesUsuario.mail),
                new Claim("alguna otra cosa", "algun dato")
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

        //public string Encriptar(string Input)
        //{
        //    byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi"); // La clave debe ser de 8 caracteres
        //    byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
        //    byte[] buffer = Encoding.UTF8.GetBytes(Input);
        //    TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        //    des.Key = EncryptionKey;
        //    des.IV = IV;

        //    return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        //}

    }
}
