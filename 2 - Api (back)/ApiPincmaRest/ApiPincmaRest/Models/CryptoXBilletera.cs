using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPincmaRest.Models
{
    public class CryptoXBilletera
    {
        
        public int idBilletera { get; set; }
        [Key]
        public int idCrypto { get; set; }
        public int cantidad { get; set; }

    }
}
