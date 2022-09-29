using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/preciocompra")]
    public class PrecioCompraController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PrecioCompraController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrecioCompra>>> Get()
        {
            return await context.PrecioCompra.ToListAsync();
        }
    }
}
