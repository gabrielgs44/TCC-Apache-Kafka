using Domain.DTOs;

namespace Domain.Entities
{
    public class InvoiceDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public PaymentDto Payment { get; set; }

        public InvoiceDto(string name, string email, Payment payment)
        {
            Name = name;
            Email = email;
            Payment = new PaymentDto()
            {
                PaymentId = payment.PaymentId.ToString(),
                CardNumber = payment.CardNumber,
                Parceled = payment.Parceled,
                PurchaseDate = payment.PurchaseDate.ToString(),
                TotalValue = payment.TotalValue
            };
        }
    }
}