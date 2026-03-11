using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Models
{
    public class TransacaoViewModel
    {
        public int Id { get; set; }
        public PessoaViewModel Pessoa { get; set; } = null!;
        public int Tipo { get; set; }
        public CategoriaViewModel Categoria { get; set; } = null!;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }

        public static TransacaoViewModel FromEntity(Transacao entity)
        {
            return new TransacaoViewModel
            {
                Id = entity.Id,
                Pessoa = new PessoaViewModel() { 
                    Id= entity.Pessoa.Id,
                    Nome = entity.Pessoa.Nome,
                    Idade = entity.Pessoa.Idade,
                },
                Tipo = (int)entity.Tipo,
                Categoria = new CategoriaViewModel()
                {
                    Id= entity.Categoria.Id,
                    Descricao = entity.Categoria.Descricao,
                    Finalidade = (int)entity.Categoria.Finalidade
                },
                Descricao = entity.Descricao,
                Valor = entity.Valor
            };
        }
    }
}
