using Domain.Common.Enums;

namespace Domain.Entities
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string ValidDate { get; set; }
        public int SecurityCode { get; set; }
        public CardType CardType { get; set; }

        public Card(string cardNumber, string validDate, int securityCode, CardType cardType)
        {
            CardNumber = cardNumber;
            ValidDate = validDate;
            SecurityCode = securityCode;
            CardType = cardType;
        }
    }
}
