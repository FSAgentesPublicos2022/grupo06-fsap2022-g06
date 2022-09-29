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

        [HttpGet]
        public async Task<ActionResult<List<Operacion>>> Get()
        {
            return await context.Operacion.ToListAsync();
        }
    }
}
