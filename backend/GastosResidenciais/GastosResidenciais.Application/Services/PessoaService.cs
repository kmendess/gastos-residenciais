using GastosResidenciais.Application.Enums;
using GastosResidenciais.Application.Interfaces;
using GastosResidenciais.Application.Models;
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
            var pessoa = _pessoaRepository.GetById(id);

            if (pessoa == null)
                return ResultViewModel<PessoaViewModel?>.Error(ErrorType.NotFound, "Pessoa não encontrada.");

            return ResultViewModel<PessoaViewModel?>.Success(PessoaViewModel.FromEntity(pessoa));
        }

        public ResultViewModel<PessoaViewModel> Create(CreatePessoaViewModel model)
        {
            var pessoa = _pessoaRepository.Create(CreatePessoaViewModel.ToEntity(model));

            return ResultViewModel<PessoaViewModel>.Success(PessoaViewModel.FromEntity(pessoa));
        }

        public ResultViewModel Update(int id, UpdatePessoaViewModel model)
        {
            var pessoa = _pessoaRepository.GetById(id);

            if (pessoa == null)
                return ResultViewModel.Error(ErrorType.NotFound, "Pessoa não encontrada.");

            pessoa.Nome = model.Nome;
            pessoa.Idade = model.Idade;

            _pessoaRepository.Update(pessoa);

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var pessoa = _pessoaRepository.GetById(id);

            if (pessoa == null)
                return ResultViewModel.Error(ErrorType.NotFound, "Pessoa não encontrada");

            _pessoaRepository.Delete(pessoa);

            return ResultViewModel.Success();
        }
    }
}
