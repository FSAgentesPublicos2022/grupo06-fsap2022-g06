using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/billetera")]
    public class BilleteraController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BilleteraController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Billetera>>> Get()
        {
            return await context.Billetera.ToListAsync();
        }
    }
}
