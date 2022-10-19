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

        [HttpGet ("obtener/{mail}")]
        public async Task<int> Get(string mail)
        {
            int res = 0;
            res =(from b in context.Billetera
                          join c in context.Cuenta on b.idCuenta equals c.idCuenta
                          join u in context.Usuario on c.mail equals u.mail
                          where u.mail == mail
                          select b.idBilletera).Single();
            return res;
        }
    }
}
