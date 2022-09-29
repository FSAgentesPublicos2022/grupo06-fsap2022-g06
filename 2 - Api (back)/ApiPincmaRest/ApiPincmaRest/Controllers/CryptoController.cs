using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/crypto")]
    public class CryptoController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CryptoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Crypto>>> Get()
        {
            return await context.Crypto.ToListAsync();
        }
    }
}
