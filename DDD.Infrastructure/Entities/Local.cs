namespace DDD.Infrastructure.Entities
{
    public class Local
    {
        public int LOCID { get; set; }
        public string LOCNOME { get; set; } = string.Empty;
        public string LOCDESCRICAO { get; set; } = string.Empty;
        public string LOCENDERECO { get; set; } = string.Empty;
        public int LOCCID { get; set; }
        public char LOCSITUACAO { get; set; }
        public DateTime LOCDATACRIACAO { get; set; }
        public Cidade Cidade { get; set; } = null!;
        public int LOCUF { get; set; }
        public Estado Estado { get; set; } = null!;
    }
}
