namespace DDD.Infrastructure.Entities
{
    public class Cidade
    {
        public int CIDID { get; set; }
        public string CIDNOME { get; set; } = string.Empty;
        public int CIDUF { get; set; }
        public char CIDSITUACAO { get; set; }
        public Estado Estado { get; set; } = null!;
        public ICollection<Local> Locais { get; set; } = new List<Local>();
    }
}
