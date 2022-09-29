using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Cuenta
    {
        [Key]
        public int idCuenta { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public bool cuentaValidada { get; set; }
        public string hashRecuperacion { get; set; }
        public int idEstado { get; set; }
    }
}
