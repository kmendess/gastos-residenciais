using GastosResidenciais.Application.Enums;
using GastosResidenciais.Application.Interfaces;
using GastosResidenciais.Application.Models;
using GastosResidenciais.Application.Validations;
using GastosResidenciais.Domain.Repositories;

namespace GastosResidenciais.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public ResultViewModel<List<PessoaViewModel>> GetAll()
        {
            var pessoas = _pessoaRepository.GetAll();

            var model = pessoas.Select(PessoaViewModel.FromEntity).ToList();

            return ResultViewModel<List<PessoaViewModel>>.Success(model);
        }

        public ResultViewModel<PessoaViewModel?> GetById(int id)
        {
            var messages = new List<string>();

            var pessoa = _pessoaRepository.GetById(id);

            PessoaValidation.ValidateExists(pessoa, messages);

            if (messages.Any())
                return ResultViewModel<PessoaViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            return ResultViewModel<PessoaViewModel?>.Success(PessoaViewModel.FromEntity(pessoa!));
        }

        public ResultViewModel<PessoaViewModel> Create(PessoaCreateViewModel model)
        {
            var messages = new List<string>();

            PessoaValidation.ValidateCreate(model, messages);

            if (messages.Any())
                return ResultViewModel<PessoaViewModel>.Error(ErrorType.Validation, messages.ToArray());

            var pessoa = _pessoaRepository.Create(model.ToEntity());

            return ResultViewModel<PessoaViewModel>.Success(PessoaViewModel.FromEntity(pessoa));
        }

        public ResultViewModel Update(int id, PessoaUpdateViewModel model)
        {
            var messages = new List<string>();

            var pessoa = _pessoaRepository.GetById(id);

            PessoaValidation.ValidateExists(pessoa, messages);

            if (messages.Any())
                return ResultViewModel<PessoaViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            PessoaValidation.ValidateUpdate(model, messages);

            if (messages.Any())
                return ResultViewModel<PessoaViewModel?>.Error(ErrorType.Validation, messages.ToArray());

            pessoa!.Nome = model.Nome;
            pessoa.Idade = model.Idade;

            _pessoaRepository.Update(pessoa);

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var messages = new List<string>();

            var pessoa = _pessoaRepository.GetById(id);

            PessoaValidation.ValidateExists(pessoa, messages);

            if (messages.Any())
                return ResultViewModel<PessoaViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            _pessoaRepository.Delete(pessoa!);

            return ResultViewModel.Success();
        }
    }
}
