using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/cuenta")]
    public class CuentaController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CuentaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> Get()
        {
            return await context.Cuenta.ToListAsync();
        }

        [HttpGet("obtener/{mail}")]
        public async Task<int> GetId(string mail)
        {
            int res = 0;
            res = (from c in context.Cuenta
                   join u in context.Usuario on c.mail equals u.mail
                   where u.mail == mail
                   select c.idCuenta).Single();
            return res;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Post([FromBody] Cuenta cuenta)
        {
            try
            {

                context.Add(cuenta);
                await context.SaveChangesAsync();
                return Ok(cuenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
