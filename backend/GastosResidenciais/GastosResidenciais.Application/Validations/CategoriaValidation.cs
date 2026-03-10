using GastosResidenciais.Application.Models;
using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Enums;

namespace GastosResidenciais.Application.Validations
{
    public static class CategoriaValidation
    {
        public static void ValidateExists(Categoria? categoria, List<string> messages)
        {
            if (categoria == null)
                messages.Add("Categoria não encontrada.");
        }

        public static void ValidateCreate(CategoriaCreateViewModel model, List<string> messages)
        {
            ValidateDescricao(model.Descricao, messages);
            ValidateFinalidade(model.Finalidade, messages);
        }

        public static void ValidateUpdate(CategoriaUpdateViewModel model, List<string> messages)
        {
            ValidateDescricao(model.Descricao, messages);
        }

        private static void ValidateDescricao(string descricao, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                messages.Add("Descrição é obrigatória.");
            else if (descricao.Length > 400)
                messages.Add("Descrição não pode ter mais de 400 caracteres.");
        }

        public static void ValidateFinalidade(int finalidade, List<string> messages)
        {
            if (!Enum.IsDefined(typeof(FinalidadeCategoria), finalidade))
                messages.Add("Finalidade inválida.");
        }
    }
}
