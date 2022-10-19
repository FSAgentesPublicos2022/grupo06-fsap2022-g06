namespace ApiPincmaRest.DTOs
{
    public class CryptoBilletera
    {
        public int idBilletera { get; set; }
        public int idCrypto { get; set; }
        public string crypto { get; set; }
        public string nombreCorto { get; set; }
        public string nombreUsuario { get; set; }
        public int cantidad { get; set; }
        public decimal valor { get; set; }
        public decimal precioU { get; set; }
    }
}
