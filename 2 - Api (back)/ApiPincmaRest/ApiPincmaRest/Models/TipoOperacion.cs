using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class TipoOperacion
    {
        [Key]
        public int idTipoOperacion { get; set; }
        public string nombreTipoOperacion { get; set; }
    }
}
