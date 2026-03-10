using GastosResidenciais.Domain.Enums;

namespace GastosResidenciais.Domain.Entities
{
    public class Transacao : BaseEntity
    {
        public Pessoa Pessoa { get; set; } = null!;
        public int PessoaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
        public int CategoriaId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
    }
}
