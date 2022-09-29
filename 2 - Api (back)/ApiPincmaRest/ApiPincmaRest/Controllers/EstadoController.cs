using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/estado")]
    public class EstadoController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public EstadoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estado>>> Get()
        {
            return await context.Estado.ToListAsync();
        }
    }
}
