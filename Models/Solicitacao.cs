namespace FichaCompras.Models
{
    public class Solicitacao
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Status { get; set; }
    }
}