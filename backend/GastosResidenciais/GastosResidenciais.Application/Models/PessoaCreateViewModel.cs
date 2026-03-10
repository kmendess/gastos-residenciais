using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Models
{
    public class PessoaCreateViewModel
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }

        public Pessoa ToEntity()
        {
            return new Pessoa
            {
                Nome = Nome,
                Idade = Idade
            };
        }
    }
}
