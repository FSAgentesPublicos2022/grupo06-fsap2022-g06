using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Billetera
    {
        [Key]
        public int idBilletera { get; set; }
        public int idCuenta { get; set; }
    }
}
