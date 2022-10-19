using ApiPincmaRest.DTOs;
using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/cryptoxbilletera")]
    public class CryptoXBilleteraController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CryptoXBilleteraController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("ver/{mail}")]
        public async Task<ActionResult<List<CryptoBilleteraDTo>>> Get(string mail)
        {
            List<CryptoBilleteraDTo> cryptoBilleteraDTos = new List<CryptoBilleteraDTo>();
            CryptoBilleteraDTo c = new CryptoBilleteraDTo();
            var res = (from bxc in context.cryptoXBilletera
                       join bi in context.Billetera on bxc.idBilletera equals bi.idBilletera
                       join cu in context.Cuenta on bi.idCuenta equals cu.idCuenta
                       join us in context.Usuario on cu.mail equals us.mail
                       join crtp in context.Crypto on bxc.idCrypto equals crtp.idCrypto
                       join pre in context.PrecioVenta on crtp.idCrypto equals pre.idCrypto
                       where us.mail == mail
                       select new
                       {
                           idCrypto = crtp.idCrypto,
                           crypto = crtp.nombreCrypto,
                           nombreCorto = crtp.nombreCorto,
                           cantidad = bxc.cantidad,
                           valor = pre.precio
                       }).ToList();
            foreach (var cr in res)
            {
                c = new CryptoBilleteraDTo
                {
                    idCrypto = cr.idCrypto,
                    crypto = cr.crypto,
                    nombreCorto =cr.nombreCorto,
                    cantidad = cr.cantidad,
                    precio = cr.cantidad*cr.valor

                };
                cryptoBilleteraDTos.Add(c);
            }
            return  cryptoBilleteraDTos;
        }

        [HttpGet("verall/{mail}")]
        public async Task<IActionResult> GetAll(string mail)
        {
            try
            {
                List<CryptoBilletera> cryptoBilleteraDTos = new List<CryptoBilletera>();
                CryptoBilletera c = new CryptoBilletera();
                var listaCryptos = await (from bxc in context.cryptoXBilletera
                                          join bi in context.Billetera on bxc.idBilletera equals bi.idBilletera
                                          join cu in context.Cuenta on bi.idCuenta equals cu.idCuenta
                                          join us in context.Usuario on cu.mail equals us.mail
                                          join crtp in context.Crypto on bxc.idCrypto equals crtp.idCrypto
                                          join pre in context.PrecioVenta on crtp.idCrypto equals pre.idCrypto
                                          where us.mail == mail
                                          select new
                                          {
                                              bi.idBilletera,
                                              us.nombre,
                                              idCrypto = bxc.idCrypto,
                                              crypto = crtp.nombreCrypto,
                                              nombreCorto = crtp.nombreCorto,
                                              nombreUsuario = us.nombre,
                                              cantidad = bxc.cantidad,
                                              valor = pre.precio
                                          }).ToListAsync();
                foreach (var cr in listaCryptos)
                {
                    c = new CryptoBilletera
                    {
                        idBilletera = cr.idBilletera,
                        idCrypto = cr.idCrypto,
                        crypto = cr.crypto,
                        nombreUsuario= cr.nombreUsuario,
                        nombreCorto = cr.nombreCorto,
                        cantidad = cr.cantidad,
                        valor = cr.valor,
                        precioU = cr.cantidad * cr.valor                       
                    };
                    cryptoBilleteraDTos.Add(c);
                }
                return Ok(cryptoBilleteraDTos);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
 