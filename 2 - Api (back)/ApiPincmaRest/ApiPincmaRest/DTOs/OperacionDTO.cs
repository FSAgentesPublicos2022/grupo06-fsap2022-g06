namespace ApiPincmaRest.DTOs
{
    public class OperacionDTO
    {
        public int idOperacion { get; set; }
        public DateTime? fechaOperacion { get; set; }
        public int idTipoOperacion { get; set; }
        public int idEstado { get; set; }
        public int idBilleteraOrigen { get; set; }
        public int? idBilleteraDestino { get; set; }
        public int idCrypto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public bool operacionFinalizada { get; set; }
        public string comentario { get; set; }
        public int idOferta { get; set; }
        public string descripcion { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string nombreCrypto { get; set; }
        public string nombreCorto { get; set; }
    }
}
