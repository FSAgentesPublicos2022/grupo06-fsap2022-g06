using ApiPincmaRest.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/tipodocumento")]
    public class TipoDocumentoController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        public TipoDocumentoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumento>>> Get()
        {
            return await context.TipoDocumento.ToListAsync();
        }
    }
}
