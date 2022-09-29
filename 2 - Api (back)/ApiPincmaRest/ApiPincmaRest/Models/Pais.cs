using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Pais
    {
        [Key]
        public int idPais { get; set; }
        public string nombrePais { get; set; }
    }
}
