using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Models
{
    public class UpdatePessoaViewModel
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }

        public static Pessoa ToEntity(UpdatePessoaViewModel model)
        {
            return new Pessoa()
            {
                Nome = model.Nome,
                Idade = model.Idade
            };
        }
    }
}
