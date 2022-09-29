using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Domicilio
    {
        [Key]
        public int idDomicilio { get; set; }
        public int idLocalidad { get; set; }
        public string calle { get; set; }
        public string altura { get; set; }
        public string mail { get; set; }

    }
}
