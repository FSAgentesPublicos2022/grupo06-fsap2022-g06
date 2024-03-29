﻿using System.ComponentModel.DataAnnotations;

namespace ApiPincmaRest.Models
{
    public class Operacion
    {
        [Key]
        public int idOperacion { get; set; }
        public DateTime ? fechaOperacion { get; set; }
        public int idTipoOperacion { get; set; }
        public int idEstado { get; set; }
        public int idBilleteraOrigen { get; set; }
        public int ? idBilleteraDestino { get; set; }
        public int idCrypto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public bool operacionFinalizada { get; set; }
        public string comentario { get; set; }
        public int idOferta { get; set; }
    }
}
