using GastosResidenciais.Application.Models;
using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Enums;

namespace GastosResidenciais.Application.Validations
{
    public static class TransacaoValidation
    {
        public static void ValidateExists(Transacao? transacao, List<string> messages)
        {
            if (transacao == null)
                messages.Add("Transação não encontrada.");
        }

        public static void ValidateCreate(TransacaoCreateViewModel model, Pessoa? pessoa, Categoria? categoria, List<string> messages)
        {
            ValidatePessoa(pessoa, model.Tipo, messages);
            ValidateTipo(model.Tipo, messages);
            ValidateCategoria(categoria, model.Tipo, messages);
            ValidateDescricao(model.Descricao, messages);
            ValidateValor(model.Valor, messages);
        }

        public static void ValidateUpdate(TransacaoUpdateViewModel model, Pessoa? pessoa, Categoria? categoria, List<string> messages)
        {
            ValidatePessoa(pessoa, model.Tipo, messages);
            ValidateTipo(model.Tipo, messages);
            ValidateCategoria(categoria, model.Tipo, messages);
            ValidateDescricao(model.Descricao, messages);
            ValidateValor(model.Valor, messages);
        }

        public static void ValidatePessoa(Pessoa? pessoa, int tipoTransacao, List<string> messages)
        {
            PessoaValidation.ValidateExists(pessoa, messages);

            if (pessoa?.Idade < 18 && tipoTransacao != (int)TipoTransacao.Despesa)
                messages.Add("Pessoa menor de idade só pode realizar transações do tipo despesa.");
        }

        private static void ValidateTipo(int tipo, List<string> messages)
        {
            if (!Enum.IsDefined(typeof(TipoTransacao), tipo))
                messages.Add("Tipo inválido.");
        }

        public static void ValidateCategoria(Categoria? categoria, int tipoTransacao, List<string> messages)
        {
            CategoriaValidation.ValidateExists(categoria, messages);

            if (!Enum.IsDefined(typeof(TipoTransacao), tipoTransacao))
                messages.Add("Categoria inválida para o tipo informado.");
        }

        private static void ValidateDescricao(string descricao, List<string> messages)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                messages.Add("Descrição é obrigatória.");
            else if (descricao.Length > 400)
                messages.Add("Descrição não pode ter mais de 400 caracteres.");
        }

        private static void ValidateValor(decimal valor, List<string> messages)
        {
            if (valor < 0)
                messages.Add("Valor deve ser maior que zero.");
        }
    }
}
