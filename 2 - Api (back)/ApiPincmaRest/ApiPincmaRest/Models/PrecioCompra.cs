using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class PrecioCompra
    {
        [Key]
        public int idPrecioCompra { get; set; }
        public int idCrypto { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
    }
}
