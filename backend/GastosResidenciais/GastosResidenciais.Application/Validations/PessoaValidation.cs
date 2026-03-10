using GastosResidenciais.Application.Models;
using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Validations
{
    public class PessoaValidation
    {
        public static void ValidateExists(Pessoa? pessoa, List<string> messages)
        {
            if (pessoa == null)
                messages.Add("Pessoa não encontrada.");
        }

        public static void ValidateCreate(PessoaCreateViewModel model, List<string> messages)
        {
            ValidateNome(model.Nome, messages);
            ValidateIdade(model.Idade, messages);
        }

        public static void ValidateUpdate(PessoaUpdateViewModel model, List<string> messages)
        {
            ValidateNome(model.Nome, messages);
            ValidateIdade(model.Idade, messages);
        }

        private static void ValidateNome(string nome, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(nome))
                messages.Add("Nome é obrigatório.");
            else if (nome.Length > 200)
                messages.Add("Nome não pode ter mais de 200 caracteres.");
        }

        private static void ValidateIdade(int idade, List<string> messages)
        {
            if (idade < 0 || idade > 130)
                messages.Add("Idade deve estar entre 0 e 130.");
        }
    }
}
