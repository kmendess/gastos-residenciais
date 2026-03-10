using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public int Idade { get; set; }

        public static PessoaViewModel FromEntity(Pessoa entity)
        {
            return new PessoaViewModel() {
                Id = entity.Id,
                Nome = entity.Nome,
                Idade = entity.Idade
            };
        }
    }
}
