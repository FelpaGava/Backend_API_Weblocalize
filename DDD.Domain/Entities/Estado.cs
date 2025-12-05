namespace DDD.Domain.Entities
{
    public class Estado
    {
        public int UFID { get; set; }
        public string UFNOME { get; set; } = string.Empty;
        public string UFSIGLA { get; set; } = string.Empty;
        public char UFSITUACAO { get; set; }
        public DateTime UFDATACRIACAO { get; set; }
        public ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
        public ICollection<Local> Locais { get; set; } = new List<Local>();
    }
}
