using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class TipoDocumento
    {
        [Key]
        public int idTipoDocumento { get; set; }
        public string nombreTipoDocumento { get; set; }
    }
}
