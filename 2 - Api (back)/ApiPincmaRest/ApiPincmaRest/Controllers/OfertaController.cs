using ApiPincmaRest.DTOs;
using ApiPincmaRest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/oferta")]
    public class OfertaController : Controller
    {
        private readonly ApplicationDbContext context;
        public OfertaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("ver/{idBilletera:int}")]
        public async Task<ActionResult<List<ofertaDTO>>> Get(int idBilletera)
        {
            try
            {
                List<ofertaDTO> cryptoBilleteraDTos = new List<ofertaDTO>();
                ofertaDTO o = new ofertaDTO();
                var res = (from of in context.Ofertas
                           join cy in context.Crypto on of.idCrypto equals cy.idCrypto
                           join es in context.Estado on of.idEstado equals es.idEstado
                           where of.idBilletera == idBilletera
                           select new
                           {
                               of.idOferta,
                               of.idCrypto,
                               of.idBilletera,
                               of.nombreCrypto,
                               cy.nombreCorto,
                               of.nombreUsuario,
                               of.cantidad,
                               of.precioU,
                               of.precioP,
                               of.idEstado,
                               es.descripcion,
                               of.comentario
                           }).ToList();
                if (cryptoBilleteraDTos != null)
                {
                    foreach (var cr in res)
                    {
                        o = new ofertaDTO
                        {
                            idOferta = cr.idOferta,
                            idCrypto = cr.idCrypto,
                            idBilletera = cr.idBilletera,
                            nombreCrypto = cr.nombreCrypto,
                            nombreCorto = cr.nombreCorto,
                            nombreUsuario = cr.nombreUsuario,
                            cantidad = cr.cantidad,
                            precioU = cr.precioU,
                            precioP = cr.precioP,
                            idEstado = cr.idEstado,
                            descripcion = cr.descripcion,
                            comentario = cr.comentario!=null ? cr.comentario:""
                        };
                        cryptoBilleteraDTos.Add(o);
                    }
                }
                return cryptoBilleteraDTos;

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Post([FromBody] Oferta oferta)
        {
            try
            {

                context.Add(oferta);
                await context.SaveChangesAsync();
                return Ok(oferta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cantidad/{idBilletera}/{idCrypto}")]
        public async Task<int> GetId(int idBilletera, int idCrypto)
        {
            int res = 0;
            res = (from o in context.Ofertas                   
                   where o.idBilletera == idBilletera &&
                   o.idCrypto == idCrypto &&
                   o.idEstado != 9 && o.idEstado!=10
                   select o.cantidad).Sum();
            return res;
        }

        [HttpPut("editar/{idOferta:int}/{usuario}")]
        public async Task<ActionResult> Put(int idOferta, string usuario, [FromBody] Oferta oferta)
        {
            try
            {
                if(idOferta != oferta.idOferta)
                {
                    return NotFound();
                }
                Oferta of = new Oferta();
                if (oferta.idEstado == 11)
                {
                    of = new Oferta
                    {
                        idOferta = oferta.idOferta,
                        idBilletera = oferta.idBilletera,
                        idCrypto = oferta.idCrypto,
                        nombreCrypto = oferta.nombreCrypto,
                        nombreUsuario = oferta.nombreUsuario,
                        cantidad = oferta.cantidad,
                        precioU = oferta.precioU,
                        precioP = oferta.precioP,
                        idEstado = oferta.idEstado,
                        comentario = ""
                    };
                }

                if (oferta.idEstado == 10)
                {
                    of = new Oferta
                    {
                        idOferta = oferta.idOferta,
                        idBilletera = oferta.idBilletera,
                        idCrypto = oferta.idCrypto,
                        nombreCrypto = oferta.nombreCrypto,
                        nombreUsuario = oferta.nombreUsuario,
                        cantidad = oferta.cantidad,
                        precioU = oferta.precioU,
                        precioP = oferta.precioP,
                        idEstado = oferta.idEstado,
                        comentario = "Cancelada el " + DateTime.Now.ToString()
                    };
                }

                if (oferta.idEstado == 8)
                {
                    of = new Oferta
                    {
                        idOferta = oferta.idOferta,
                        idBilletera = oferta.idBilletera,
                        idCrypto = oferta.idCrypto,
                        nombreCrypto = oferta.nombreCrypto,
                        nombreUsuario = oferta.nombreUsuario,
                        cantidad = oferta.cantidad,
                        precioU = oferta.precioU,
                        precioP = oferta.precioP,
                        idEstado = oferta.idEstado,
                        comentario = "El usuario " + usuario + ", ha efectuado la compra el " + DateTime.Now.ToString() + ". Precisamos confirme la operación para liberar las cryptos."
                    };
                }

                if (oferta.idEstado == 9)
                {
                    of = new Oferta
                    {
                        idOferta = oferta.idOferta,
                        idBilletera = oferta.idBilletera,
                        idCrypto = oferta.idCrypto,
                        nombreCrypto = oferta.nombreCrypto,
                        nombreUsuario = oferta.nombreUsuario,
                        cantidad = oferta.cantidad,
                        precioU = oferta.precioU,
                        precioP = oferta.precioP,
                        idEstado = oferta.idEstado,
                        comentario = "La operacion finalizó el " + DateTime.Now.ToString() + "."
                    };
                }
                context.Update(of);
                await context.SaveChangesAsync();
                return Ok(new { message = "La oferta fue actualizada con éxito" });

            }catch(Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete("eliminar/{idOferta:int}")]
        public async Task<ActionResult> Delete(int idOferta)
        {
            try
            {
                var oferta = await context.Ofertas.FindAsync(idOferta);

                if(oferta == null)
                {
                    return NotFound();
                }
                context.Ofertas.Remove(oferta);
                await context.SaveChangesAsync();
                return Ok(new {message = "La oferta fue eliminada con exito"});
                
            } catch(Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
