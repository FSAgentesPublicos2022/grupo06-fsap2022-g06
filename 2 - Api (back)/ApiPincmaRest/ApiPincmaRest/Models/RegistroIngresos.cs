using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class RegistroIngresos
    {
        [Key]
        public int idIngreso { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int idCuenta { get; set; }
    }
}
