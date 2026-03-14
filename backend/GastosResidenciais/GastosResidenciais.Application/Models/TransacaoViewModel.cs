using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Models
{
    public class TransacaoViewModel
    {
        public int Id { get; set; }
        public PessoaViewModel Pessoa { get; set; } = null!;
        public EnumViewModel Tipo { get; set; } = null!;
        public CategoriaViewModel Categoria { get; set; } = null!;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }

        public static TransacaoViewModel FromEntity(Transacao entity)
        {
            return new TransacaoViewModel
            {
                Id = entity.Id,
                Pessoa = new PessoaViewModel()
                {
                    Id = entity.Pessoa.Id,
                    Nome = entity.Pessoa.Nome,
                    Idade = entity.Pessoa.Idade,
                },
                Tipo = new EnumViewModel()
                {
                    Id = (int)entity.Tipo,
                    Descricao = entity.Tipo.ToString()
                },
                Categoria = new CategoriaViewModel()
                {
                    Id = entity.Categoria.Id,
                    Descricao = entity.Categoria.Descricao,
                    Finalidade = new EnumViewModel()
                    {
                        Id = (int)entity.Categoria.Finalidade,
                        Descricao = entity.Categoria.Finalidade.ToString()
                    }
                },
                Descricao = entity.Descricao,
                Valor = entity.Valor
            };
        }
    }
}
