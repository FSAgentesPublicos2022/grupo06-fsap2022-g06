using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string mail { get; set; }
        [Required(ErrorMessage = "El campo {1} es requerido")]
        public string clave { get; set; }
        [Required(ErrorMessage = "El campo {2} es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {3} es requerido")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "El campo {4} es requerido")]
        public string documento { get; set; }
        [Required(ErrorMessage = "El campo {5} es requerido")]
        public int idEstado { get; set; }
        [Required(ErrorMessage = "El campo {6} es requerido")]
        public int idTipoDocumento { get; set; }

    }
}
