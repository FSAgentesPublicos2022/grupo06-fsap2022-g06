using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Provincia
    {
        [Key]
        public int idProvincia { get; set; }
        public int idPais { get; set; }
        public string nombreProvincia { get; set; }
    }
}
