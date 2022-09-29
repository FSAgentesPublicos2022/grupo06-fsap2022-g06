using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/precioventa")]
    public class PrecioVentaController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PrecioVentaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrecioVenta>>> Get()
        {
            return await context.PrecioVenta.ToListAsync();
        }
    }
}
