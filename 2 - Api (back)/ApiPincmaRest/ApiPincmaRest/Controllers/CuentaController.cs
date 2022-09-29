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
    }
}
