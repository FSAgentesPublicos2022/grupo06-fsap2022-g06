using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Crypto
    {
        [Key]
        public int idCrypto { get; set; }
        public string nombreCrypto { get; set; }
        public int idEstado { get; set; }
        public string nombreCorto { get; set; }
    }
}
