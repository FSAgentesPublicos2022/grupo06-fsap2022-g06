using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Operacion
    {
        [Key]
        public int idOperacion { get; set; }
        public DateTime fechaOperacion { get; set; }
        public int idTipoOperacion { get; set; }
        public int idEstado { get; set; }
        public int idCuentaOrigen { get; set; }
        public int idCuentaDestino { get; set; }
        public int idCrypto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public bool operacionFinalizada { get; set; }
    }
}
