using ApiPincmaRest.DTOs;
using ApiPincmaRest.Models;
using AutoMapper;

namespace ApiPincmaRest.Utilidades
{
    public class AutomaperProfiles:Profile
    {
        public AutomaperProfiles()
        {
            CreateMap<LogCreacionDTO, Logs>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
