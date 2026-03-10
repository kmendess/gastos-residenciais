namespace GastosResidenciais.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
