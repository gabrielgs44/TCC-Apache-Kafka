namespace Domain.DTOs
{
    public class CardDto
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string ValidDate { get; set; }
        public int SecurityCode { get; set; }
        public int CardType { get; set; }
    }
}
