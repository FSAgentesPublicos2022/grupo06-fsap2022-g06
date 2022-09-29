using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.DTOs
{
    public class CredencialesUsuario
    {
        [Required]
        [EmailAddress]
        public string mail { get; set; }
        [Required]
        public string clave { get; set; }
    }
}
