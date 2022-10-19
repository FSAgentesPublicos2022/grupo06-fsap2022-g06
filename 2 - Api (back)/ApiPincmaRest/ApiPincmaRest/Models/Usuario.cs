using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Usuario
    {
        [Key]
        public string mail { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public int idEstado { get; set; }
        public DateTime ? fechaCreacion { get; set; }
        public int idTipoDocumento { get; set; }
    }
}
