using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/tipooperacion")]
    public class TipoOperacionController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public TipoOperacionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoOperacion>>> Get()
        {
            return await context.TipoOperacion.ToListAsync();
        }
    }
}
