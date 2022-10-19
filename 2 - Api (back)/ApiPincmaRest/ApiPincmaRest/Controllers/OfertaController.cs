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
            List<ofertaDTO> cryptoBilleteraDTos = new List<ofertaDTO>();
            ofertaDTO o = new ofertaDTO();
            var res = (from of in context.Ofertas
                       join cy in context.Crypto on of.idCrypto equals cy.idCrypto
                       join es in context.Estado on of.idEstado equals es.idEstado
                       where of.idBilletera == idBilletera
                       select new { 
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
                           es.descripcion
                       }).ToList();
            foreach (var cr in res)
            {
                o = new ofertaDTO
                {
                    idOferta= cr.idOferta,
                    idCrypto = cr.idCrypto,
                    idBilletera = cr.idBilletera,
                    nombreCrypto= cr.nombreCrypto,
                    nombreCorto = cr.nombreCorto,
                    nombreUsuario = cr.nombreUsuario,
                    cantidad = cr.cantidad,
                    precioU = cr.precioU,
                    precioP = cr.precioP,
                    idEstado = cr.idEstado,
                    descripcion = cr.descripcion
                };
                cryptoBilleteraDTos.Add(o);
            }
            return cryptoBilleteraDTos;
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

        [HttpPut("editar/{idOferta:int}")]
        public async Task<ActionResult> Put(int idOferta, [FromBody] Oferta oferta)
        {
            try
            {
                if(idOferta != oferta.idOferta)
                {
                    return NotFound();
                }
                Oferta of = new Oferta
                {
                    idOferta = oferta.idOferta,
                    idBilletera = oferta.idBilletera,
                    idCrypto = oferta.idCrypto,
                    nombreCrypto = oferta.nombreCrypto,
                    nombreUsuario = oferta.nombreUsuario,
                    cantidad = oferta.cantidad,
                    precioU = oferta.precioU,
                    precioP = oferta.precioP,
                    idEstado = oferta.idEstado 

                };
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
