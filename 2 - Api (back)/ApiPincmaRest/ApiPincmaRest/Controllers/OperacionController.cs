using ApiPincmaRest.Migrations;
using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/operacion")]
    public class OperacionController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public OperacionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("ver")]
        public async Task<ActionResult<List<Operacion>>> Get()
        {
            return await context.Operacion.ToListAsync();
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Post([FromBody] Operacion operacion)
        {
            try
            {
                context.Add(operacion);
                await context.SaveChangesAsync();
                return Ok(operacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("actualizar/{idOperacion:int}")]
        public async Task<ActionResult> Put(int idOperacion, [FromBody] Operacion operacion)
        {
            try
            {
                if (idOperacion != operacion.idOperacion)
                {
                    return NotFound();
                }
                Operacion pf = new Operacion
                {
                    idOperacion = operacion.idOperacion,
                    fechaOperacion = operacion.fechaOperacion,
                    idTipoOperacion = operacion.idTipoOperacion,
                    idEstado = operacion.idEstado,
                    idBilleteraOrigen = operacion.idBilleteraOrigen,
                    idBilleteraDestino = operacion.idBilleteraDestino,
                    idCrypto = operacion.idCrypto,
                    cantidad = operacion.cantidad,
                    precio = operacion.precio,
                    operacionFinalizada = operacion.operacionFinalizada,

    };
                context.Update(pf);
                await context.SaveChangesAsync();
                return Ok(new { message = "La operacion fue actualizada con éxito" });

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
