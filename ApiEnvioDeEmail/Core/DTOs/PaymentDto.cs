namespace Core.DTOs
{
    public class PaymentDto
    {
        public string PaymentId { get; set; }
        public double TotalValue { get; set; }
        public int Parceled { get; set; }
        public string CardNumber { get; set; }
        public string PurchaseDate { get; set; }
    }
}
