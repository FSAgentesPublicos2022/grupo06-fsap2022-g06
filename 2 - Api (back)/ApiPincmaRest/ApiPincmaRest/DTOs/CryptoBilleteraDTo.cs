namespace ApiPincmaRest.DTOs
{
    public class CryptoBilleteraDTo
    {
        public int idCrypto { get; set; }
        public string crypto { get; set; }
        public string nombreCorto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
