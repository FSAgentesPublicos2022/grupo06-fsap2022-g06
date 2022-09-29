using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/pais")]
    public class PaisController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PaisController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pais>>> Get()
        {
            return await context.Pais.ToListAsync();
        }
    }
}
