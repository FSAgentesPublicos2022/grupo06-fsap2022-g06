using ApiPincmaRest.Models;
using ApiPincmaRest.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiPincmaRest.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public LogsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Logs>>> Get()
        {
            return await context.Logs.ToListAsync();
        }

        [HttpGet("{idLog:int}")]
        public async Task<Logs> Get(int idLog)
        {
            return await context.Logs.FindAsync(idLog);
        }

        [HttpPost]
        public async Task<ActionResult> Post(LogCreacionDTO logCreacionDTO)
        {
            var logs = mapper.Map<Logs>(logCreacionDTO);
            context.Add(logs);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{idLog:int}")]
        public async Task<ActionResult> Put(Logs log, int idLog)
        {
            if (log.idLog != idLog)
            {
                return BadRequest("El id del log  no coincide con el id de la url");
            }
            context.Update(log);
            await context.SaveChangesAsync();
            return Ok();
        }

        //[HttpDelete("idLog:int")]
        //public async Task<ActionResult> Delete(int idLog)
        //{
        //    var existe = await context.Logs.AnyAsync(x => x.idLog == idLog);
        //    if (!existe)
        //    {
        //        return NotFound();
        //    }
            //var logs = Get(idLog);
            //if (logs == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    Logs l = new Logs
            //    {
            //        idLog = idLog,
            //        descripcion = "actualizado"
            //    };
            //    context.Update(l);
            //    await context.SaveChangesAsync();
                //return Ok();
            //}
        //}
    }
}
