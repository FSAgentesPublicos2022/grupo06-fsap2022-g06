using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/localidad")]
    public class LocalidadController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public LocalidadController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Localidad>>> Get()
        {
            return await context.Localidad.ToListAsync();
        }
    }
}
