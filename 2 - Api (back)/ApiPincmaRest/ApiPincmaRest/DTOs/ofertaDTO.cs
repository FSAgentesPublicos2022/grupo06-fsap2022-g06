namespace ApiPincmaRest.DTOs
{
    public class ofertaDTO
    {
        public int idOferta { get; set; }
        public int idBilletera { get; set; }
        public int idCrypto { get; set; }
        public string nombreCrypto { get; set; }
        public string nombreCorto { get; set; }
        public string nombreUsuario { get; set; }
        public int cantidad { get; set; }
        public decimal precioU { get; set; }
        public decimal precioP { get; set; }
        public int idEstado { get; set; }
        public string descripcion { get; set; }
        public string ? comentario { get; set; }
    }
}
