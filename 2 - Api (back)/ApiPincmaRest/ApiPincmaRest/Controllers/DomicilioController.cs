using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/domicilio")]
    public class DomicilioController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DomicilioController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domicilio>>> Get()
        {
            return await context.Domicilio.ToListAsync();
        }
    }
}
