using GastosResidenciais.Application.Enums;
using GastosResidenciais.Application.Interfaces;
using GastosResidenciais.Application.Models;
using GastosResidenciais.Application.Validations;
using GastosResidenciais.Domain.Enums;
using GastosResidenciais.Domain.Repositories;

namespace GastosResidenciais.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public ResultViewModel<List<CategoriaViewModel>> GetAll()
        {
            var categorias = _categoriaRepository.GetAll();

            var model = categorias.Select(CategoriaViewModel.FromEntity).ToList();

            return ResultViewModel<List<CategoriaViewModel>>.Success(model);
        }

        public ResultViewModel<CategoriaViewModel?> GetById(int id)
        {
            var messages = new List<string>();

            var categoria = _categoriaRepository.GetById(id);

            CategoriaValidation.ValidateExists(categoria, messages);

            if (messages.Any())
                return ResultViewModel<CategoriaViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            return ResultViewModel<CategoriaViewModel?>.Success(CategoriaViewModel.FromEntity(categoria!));
        }

        public ResultViewModel<CategoriaViewModel> Create(CategoriaCreateViewModel model)
        {
            var messages = new List<string>();

            CategoriaValidation.ValidateCreate(model, messages);

            if (messages.Any())
                return ResultViewModel<CategoriaViewModel>.Error(ErrorType.Validation, messages.ToArray());

            var categoria = _categoriaRepository.Create(model.ToEntity());

            return ResultViewModel<CategoriaViewModel>.Success(CategoriaViewModel.FromEntity(categoria));
        }

        public ResultViewModel Update(int id, CategoriaUpdateViewModel model)
        {
            var messages = new List<string>();

            var categoria = _categoriaRepository.GetById(id);

            CategoriaValidation.ValidateExists(categoria, messages);

            if (messages.Any())
                return ResultViewModel<CategoriaViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            CategoriaValidation.ValidateUpdate(model, messages);

            if (messages.Any())
                return ResultViewModel<CategoriaViewModel?>.Error(ErrorType.Validation, messages.ToArray());

            categoria!.Descricao = model.Descricao;

            _categoriaRepository.Update(categoria);

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var messages = new List<string>();

            var categoria = _categoriaRepository.GetById(id);

            CategoriaValidation.ValidateExists(categoria, messages);

            if (messages.Any())
                return ResultViewModel<CategoriaViewModel?>.Error(ErrorType.NotFound, messages.ToArray());

            // TODO: validar transações antes de excluir categoria

            _categoriaRepository.Delete(categoria!);

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<EnumViewModel>> GetFinalidades()
        {
            var finalidades = Enum
                .GetValues<FinalidadeCategoria>()
                .Select(x => new EnumViewModel
                {
                    Id = (int)x,
                    Descricao = x.ToString()
                })
                .ToList();

            return ResultViewModel<List<EnumViewModel>>.Success(finalidades);
        }

        public ResultViewModel<List<CategoriaViewModel>> GetByFinalidade(int finalidade)
        {
            var messages = new List<string>();

            CategoriaValidation.ValidateFinalidade(finalidade, messages);

            if (messages.Any())
                return ResultViewModel<List<CategoriaViewModel>>.Error(ErrorType.Validation, messages.ToArray());

            var finalidades = new List<FinalidadeCategoria>()
            {
                (FinalidadeCategoria)finalidade,
                FinalidadeCategoria.Ambas
            };

            var categorias = _categoriaRepository.GetByFinalidades(finalidades);

            var model = categorias.Select(CategoriaViewModel.FromEntity).ToList();

            return ResultViewModel<List<CategoriaViewModel>>.Success(model);
        }
    }
}
