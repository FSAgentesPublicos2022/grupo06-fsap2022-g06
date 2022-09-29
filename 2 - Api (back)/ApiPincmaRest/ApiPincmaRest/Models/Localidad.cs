using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Localidad
    {
        [Key]
        public int idLocalidad { get; set; }
        public int idProvincia { get; set; }
        public string nombreLocalidad { get; set; }
    }
}
