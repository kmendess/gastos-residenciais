using GastosResidenciais.Application.Enums;
using GastosResidenciais.Application.Interfaces;
using GastosResidenciais.Application.Models;
using GastosResidenciais.Application.Validations;
using GastosResidenciais.Domain.Enums;
using GastosResidenciais.Domain.Repositories;

namespace GastosResidenciais.Application.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository,
            IPessoaRepository pessoaRepository,
            ICategoriaRepository categoriaRepository)
        {
            _transacaoRepository = transacaoRepository;
            _pessoaRepository = pessoaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public ResultViewModel<List<TransacaoViewModel>> GetAll()
        {
            var transacoes = _transacaoRepository.GetAll();

            var model = transacoes.Select(TransacaoViewModel.FromEntity).ToList();

            return ResultViewModel<List<TransacaoViewModel>>.Success(model);
        }

        public ResultViewModel<TransacaoViewModel?> GetById(int id)
        {
            var messages = new List<string>();

            var transacao = _transacaoRepository.GetById(id);

            TransacaoValidation.ValidateExists(transacao, messages);

            if (messages.Any())
                return ResultViewModel<TransacaoViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            return ResultViewModel<TransacaoViewModel?>.Success(TransacaoViewModel.FromEntity(transacao!));
        }

        public ResultViewModel<TransacaoViewModel> Create(TransacaoCreateViewModel model)
        {
            var messages = new List<string>();

            var pessoa = _pessoaRepository.GetById(model.PessoaId);

            var categoria = _categoriaRepository.GetById(model.CategoriaId);

            TransacaoValidation.ValidateCreate(model, pessoa, categoria, messages);

            if (messages.Any())
                return ResultViewModel<TransacaoViewModel>.Error(ErrorType.Validation, messages.ToArray());

            var transacao = _transacaoRepository.Create(model.ToEntity());

            return ResultViewModel<TransacaoViewModel>.Success(TransacaoViewModel.FromEntity(transacao));
        }

        public ResultViewModel Update(int id, TransacaoUpdateViewModel model)
        {
            var messages = new List<string>();

            var transacao = _transacaoRepository.GetById(id);

            TransacaoValidation.ValidateExists(transacao, messages);

            if (messages.Any())
                return ResultViewModel<TransacaoViewModel?>.Error(ErrorType.NotFound, messages.ToArray());


            var pessoa = _pessoaRepository.GetById(model.PessoaId);

            var categoria = _categoriaRepository.GetById(model.CategoriaId);

            TransacaoValidation.ValidateUpdate(model, pessoa, categoria, messages);

            if (messages.Any())
                return ResultViewModel<TransacaoViewModel?>.Error(ErrorType.Validation, messages.ToArray());

            transacao!.Descricao = model.Descricao;

            _transacaoRepository.Update(transacao);

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var messages = new List<string>();

            var transacao = _transacaoRepository.GetById(id);

            TransacaoValidation.ValidateExists(transacao, messages);

            if (messages.Any())
                return ResultViewModel<TransacaoViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            // TODO: validar transações antes de excluir transacao

            _transacaoRepository.Delete(transacao!);

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<EnumViewModel>> GetTipos()
        {
            var finalidades = Enum
                .GetValues<TipoTransacao>()
                .Select(x => new EnumViewModel
                {
                    Id = (int)x,
                    Descricao = x.ToString()
                })
                .ToList();

            return ResultViewModel<List<EnumViewModel>>.Success(finalidades);
        }
    }
}
