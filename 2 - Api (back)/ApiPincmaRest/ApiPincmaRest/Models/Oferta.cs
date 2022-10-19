using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Oferta
    {
        [Key]
        public int idOferta { get; set; }
        public int idBilletera { get; set; }
        public int idCrypto { get; set; }
        public string nombreCrypto { get; set; }
        public string nombreUsuario { get; set; }
        public int cantidad { get; set; }
        public decimal precioU { get; set; }
        public decimal precioP { get; set; }
        public int idEstado { get; set; }
    }
}
