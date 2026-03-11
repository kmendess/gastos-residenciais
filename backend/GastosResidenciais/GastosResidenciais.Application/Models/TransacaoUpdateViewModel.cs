namespace GastosResidenciais.Application.Models
{
    public class TransacaoUpdateViewModel
    {
        public int PessoaId { get; set; }
        public int Tipo { get; set; }
        public int CategoriaId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
