using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/cryptoxbilletera")]
    public class CryptoXBilleteraController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CryptoXBilleteraController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CryptoXBilletera>>> Get()
        {
            return await context.cryptoXBilletera.ToListAsync();
        }
    }
}
