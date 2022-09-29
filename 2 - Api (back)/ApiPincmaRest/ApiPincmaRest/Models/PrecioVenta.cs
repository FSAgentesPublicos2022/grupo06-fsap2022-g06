using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class PrecioVenta
    {
        [Key]
        public int idPrecioVenta { get; set; }
        public int idCrypto { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
    }
}
