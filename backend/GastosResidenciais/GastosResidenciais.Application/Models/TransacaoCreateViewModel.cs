using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Enums;

namespace GastosResidenciais.Application.Models
{
    public class TransacaoCreateViewModel
    {
        public int PessoaId { get; set; }
        public int Tipo { get; set; }
        public int CategoriaId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }

        public Transacao ToEntity()
        {
            return new Transacao
            {
                PessoaId = PessoaId,
                Tipo = (TipoTransacao)Tipo,
                CategoriaId = CategoriaId,
                Descricao = Descricao,
                Valor = Valor
            };
        }
    }
}
