namespace DDD.Presentation.Dtos
{
    public class LocalDto
    {
        public string LOCNOME { get; set; } = string.Empty;
        public string LOCDESCRICAO { get; set; } = string.Empty;
        public string LOCENDERECO { get; set; } = string.Empty;
        public int LOCCID { get; set; }
        public int LOCUF { get; set; }
        public char LOCSITUACAO { get; set; }
        public DateTime LOCDATACRIACAO { get; set; }
    }
}
