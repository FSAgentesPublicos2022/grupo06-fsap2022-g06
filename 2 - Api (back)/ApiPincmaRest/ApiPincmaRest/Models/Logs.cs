using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Logs
    {
        [Key]
        public int idLog { get; set; }
        public string descripcion { get; set; }
        //public DateTime fechaRegistro { get; set; }
    }
}
