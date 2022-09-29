using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.DTOs
{
    public class LogCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string descripcion { get; set; }
    }
}
