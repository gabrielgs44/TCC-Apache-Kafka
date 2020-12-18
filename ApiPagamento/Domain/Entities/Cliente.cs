using System;

namespace Domain.Entities
{
    public class Cliente
    {
        public string Name { get; set; }
        public DateTime BithDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Card Card { get; set; }

        public Cliente(string name, DateTime bithDate, string phoneNumber, string email, Card card)
        {
            Name = name;
            BithDate = bithDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Card = card;
        }
    }
}
