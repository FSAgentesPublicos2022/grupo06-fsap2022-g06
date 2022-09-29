using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/registroingreso")]
    public class RegistroIngresoController
    {
        private readonly ApplicationDbContext context;
        public RegistroIngresoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistroIngresos>>> Get()
        {
            return await context.RegistroIngresos.ToListAsync();
        }
    }
}
