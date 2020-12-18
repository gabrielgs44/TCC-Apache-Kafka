namespace Domain.DTOs
{
    public class MakePagamentDto
    {
        public double PagamentValue { get; set; }
        public int Parceled { get; set; }
        public CardDto Card { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}
