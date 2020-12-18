namespace Core.DTOs
{
    public class InvoiceDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public PaymentDto Payment { get; set; }
    }
}
