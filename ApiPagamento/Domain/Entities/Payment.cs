using System;

namespace Domain.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; private set; }
        public double TotalValue { get; set; }
        public int Parceled { get; set; }
        public string CardNumber { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Payment(double totalValue, int parceled, string cardNumber)
        {
            PaymentId = Guid.NewGuid();
            TotalValue = totalValue;
            Parceled = parceled;
            CardNumber = cardNumber;
            PurchaseDate = DateTime.Now;
        }
    }
}
