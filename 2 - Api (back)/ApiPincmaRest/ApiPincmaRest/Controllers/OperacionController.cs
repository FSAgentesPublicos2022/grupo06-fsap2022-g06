using ApiPincmaRest.DTOs;
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

        [HttpGet("veraops/{idBilletera:int}")]
        public async Task<ActionResult<List<OperacionDTO>>> GetOpe(int idBilletera)
        {
            List<OperacionDTO> Operaciones = new List<OperacionDTO>();
            OperacionDTO op = new OperacionDTO();

            var res = (from o in context.Operacion
                       join bo in context.Billetera on o.idBilleteraOrigen equals bo.idBilletera
                       join co in context.Cuenta on bo.idCuenta equals co.idCuenta
                       join uo in context.Usuario on co.mail equals uo.mail
                       join c in context.Crypto on o.idCrypto equals c.idCrypto
                       join e in context.Estado on o.idEstado equals e.idEstado
                       where o.idBilleteraOrigen == idBilletera ||
                       o.idBilleteraDestino == idBilletera
                       select new
                       {
                           o.idOperacion,
                           o.fechaOperacion,
                           o.idTipoOperacion,
                           o.idEstado,
                           o.idBilleteraOrigen,
                           o.idBilleteraDestino,
                           o.idCrypto,
                           o.cantidad,
                           o.precio,
                           o.operacionFinalizada,
                           o.comentario,
                           o.idOferta,
                           e.descripcion,
                           origen = uo.nombre,
                           destino = (from op2 in context.Operacion
                                      join bd in context.Billetera on op2.idBilleteraDestino equals bd.idBilletera
                                      join cd in context.Cuenta on bd.idCuenta equals cd.idCuenta
                                      join u in context.Usuario on cd.mail equals u.mail
                                      where o.idBilleteraDestino == op2.idBilleteraDestino
                                      select u.nombre
                            ).Single(),
                           c.nombreCrypto,
                           c.nombreCorto
                       }).ToList();
            if (res.Count > 0)
            {
                foreach (var item in res)
                {
                    if (item.idBilleteraOrigen != idBilletera)
                    {
                        op = new OperacionDTO
                        {
                            idOperacion = item.idOperacion,
                            fechaOperacion = item.fechaOperacion,
                            idTipoOperacion = item.idTipoOperacion,
                            idEstado = item.idEstado,
                            idBilleteraOrigen = item.idBilleteraOrigen,
                            idBilleteraDestino = item.idBilleteraDestino,
                            idCrypto = item.idCrypto,
                            cantidad = item.cantidad,
                            precio = item.precio,
                            operacionFinalizada = item.operacionFinalizada,
                            comentario = item.comentario,
                            idOferta = item.idOferta,
                            descripcion = item.descripcion,
                            origen = item.origen,
                            destino = item.destino,
                            nombreCrypto = item.nombreCrypto,
                            nombreCorto = item.nombreCorto
                        };
                        Operaciones.Add(op);
                    }
                }
            }
            return Operaciones;
        }

        [HttpGet("verall/{idBilletera:int}")]
        public async Task<ActionResult<List<OperacionDTO>>> Get(int idBilletera)
        {
            List<OperacionDTO> Operaciones = new List<OperacionDTO>();
            OperacionDTO op = new OperacionDTO();

            var res = (from o in context.Operacion
                       join bo in context.Billetera on o.idBilleteraOrigen equals bo.idBilletera
                       join co in context.Cuenta on bo.idCuenta equals co.idCuenta
                       join uo in context.Usuario on co.mail equals uo.mail
                       join c in context.Crypto on o.idCrypto equals c.idCrypto
                       join e in context.Estado on o.idEstado equals e.idEstado
                       where o.idBilleteraOrigen != idBilletera &&
                       o.idEstado == 11
                       select new
                       {
                           o.idOperacion,
                           o.fechaOperacion,
                           o.idTipoOperacion,
                           o.idEstado,
                           o.idBilleteraOrigen,
                           o.idBilleteraDestino,
                           o.idCrypto,
                           o.cantidad,
                           o.precio,
                           o.operacionFinalizada,
                           o.comentario,
                           o.idOferta,
                           e.descripcion,
                           origen = uo.nombre,
                           destino = (from op2 in context.Operacion
                            join bd in context.Billetera on op2.idBilleteraDestino equals bd.idBilletera
                            join cd in context.Cuenta on bd.idCuenta equals cd.idCuenta
                            join u in context.Usuario on cd.mail equals u.mail
                            where o.idBilleteraDestino == op2.idBilleteraDestino
                            select u.nombre
                            ).Single(),
                           c.nombreCrypto,
                           c.nombreCorto
                       }).ToList();
            if (res.Count > 0)
            {
                foreach (var item in res)
                {
                    if (item.idBilleteraOrigen != idBilletera)
                    {
                        op = new OperacionDTO
                        {
                            idOperacion = item.idOperacion,
                            fechaOperacion = item.fechaOperacion,
                            idTipoOperacion = item.idTipoOperacion,
                            idEstado = item.idEstado,
                            idBilleteraOrigen = item.idBilleteraOrigen,
                            idBilleteraDestino = item.idBilleteraDestino,
                            idCrypto = item.idCrypto,
                            cantidad = item.cantidad,
                            precio = item.precio,
                            operacionFinalizada = item.operacionFinalizada,
                            comentario = item.comentario,
                            idOferta = item.idOferta,
                            descripcion = item.descripcion,
                            origen = item.origen,
                            destino = item.destino,
                            nombreCrypto = item.nombreCrypto,
                            nombreCorto = item.nombreCorto
                        };
                        Operaciones.Add(op);
                    }
                }
            }
            return Operaciones;
        }

        [HttpGet("verallc/{idBilletera:int}")]
        public async Task<ActionResult<List<OperacionDTO>>> Getc(int idBilletera)
        {
            List<OperacionDTO> Operaciones = new List<OperacionDTO>();
            OperacionDTO op = new OperacionDTO();

            var res = (from o in context.Operacion
                       join bo in context.Billetera on o.idBilleteraOrigen equals bo.idBilletera
                       join co in context.Cuenta on bo.idCuenta equals co.idCuenta
                       join uo in context.Usuario on co.mail equals uo.mail
                       join c in context.Crypto on o.idCrypto equals c.idCrypto
                       join e in context.Estado on o.idEstado equals e.idEstado
                       where o.idBilleteraDestino == idBilletera
                       select new
                       {
                           o.idOperacion,
                           o.fechaOperacion,
                           o.idTipoOperacion,
                           o.idEstado,
                           o.idBilleteraOrigen,
                           o.idBilleteraDestino,
                           o.idCrypto,
                           o.cantidad,
                           o.precio,
                           o.operacionFinalizada,
                           o.comentario,
                           o.idOferta,
                           e.descripcion,
                           origen = uo.nombre,
                           destino = (from op2 in context.Operacion
                                      join bd in context.Billetera on op2.idBilleteraDestino equals bd.idBilletera
                                      join cd in context.Cuenta on bd.idCuenta equals cd.idCuenta
                                      join u in context.Usuario on cd.mail equals u.mail
                                      where o.idBilleteraDestino == op2.idBilleteraDestino
                                      select u.nombre
                            ).Single(),
                           c.nombreCrypto,
                           c.nombreCorto
                       }).ToList();
            if (res.Count > 0)
            {
                foreach (var item in res)
                {
                    if (item.idBilleteraOrigen != idBilletera)
                    {
                        op = new OperacionDTO
                        {
                            idOperacion = item.idOperacion,
                            fechaOperacion = item.fechaOperacion,
                            idTipoOperacion = item.idTipoOperacion,
                            idEstado = item.idEstado,
                            idBilleteraOrigen = item.idBilleteraOrigen,
                            idBilleteraDestino = item.idBilleteraDestino,
                            idCrypto = item.idCrypto,
                            cantidad = item.cantidad,
                            precio = item.precio,
                            operacionFinalizada = item.operacionFinalizada,
                            comentario = item.comentario,
                            idOferta = item.idOferta,
                            descripcion = item.descripcion,
                            origen = item.origen,
                            destino = item.destino,
                            nombreCrypto = item.nombreCrypto,
                            nombreCorto = item.nombreCorto
                        };
                        Operaciones.Add(op);
                    }
                }
            }
            return Operaciones;
        }

        [HttpGet("obtener/{idOferta:int}")]
        public async Task<ActionResult<Operacion>> Obtener(int idOferta)
        {
            Operacion op = new Operacion();
            var res = (from o in context.Operacion
                       where o.idOferta == idOferta
                       select o).FirstOrDefault();
            if (res != null)
            {
                op = new Operacion
                {
                    idOperacion = res.idOperacion,
                    fechaOperacion = res.fechaOperacion,
                    idTipoOperacion = res.idTipoOperacion,
                    idEstado = res.idEstado,
                    idBilleteraOrigen = res.idBilleteraOrigen,
                    idBilleteraDestino = res.idBilleteraDestino,
                    idCrypto = res.idCrypto,
                    cantidad = res.cantidad,
                    precio = res.precio,
                    operacionFinalizada = res.operacionFinalizada,
                    comentario = res.comentario,
                    idOferta = res.idOferta
                };
            }
            return op;
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

        [HttpPut("actualizar/{idOperacion:int}/{usuario}")]
        public async Task<ActionResult> Put(int idOperacion,string usuario, [FromBody] Operacion operacion)
        {
            try
            {
                if (idOperacion != operacion.idOperacion)
                {
                    return NotFound();
                }
                Operacion pf = new Operacion();
                if (operacion.idEstado == 11)
                {
                    pf = new Operacion
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
                        idOferta = operacion.idOferta,
                        comentario = "",

                    };
                }
                if (operacion.idEstado == 10)
                {
                    pf = new Operacion
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
                        idOferta = operacion.idOferta,
                        comentario = "Cancelada el " + DateTime.Now.ToString(),

                    };
                }
                if (operacion.idEstado == 8)
                {
                    pf = new Operacion
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
                        idOferta = operacion.idOferta,
                        comentario = "Esperando la confirmación del vendedor para finalizar la operación",

                    };
                }

                if (operacion.idEstado == 9)
                {
                    pf = new Operacion
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
                        operacionFinalizada = true,
                        idOferta = operacion.idOferta,
                        comentario = "La operacion finalizó el " + DateTime.Now.ToString() + ".",                        
                    };
                }

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
