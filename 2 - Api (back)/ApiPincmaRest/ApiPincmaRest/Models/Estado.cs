using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        public string descripcion { get; set; }
    }
}
