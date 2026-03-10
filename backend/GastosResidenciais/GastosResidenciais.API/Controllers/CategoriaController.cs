using GastosResidenciais.Application.Enums;
using GastosResidenciais.Application.Interfaces;
using GastosResidenciais.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace GastosResidenciais.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoriaService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoriaService.GetById(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CategoriaCreateViewModel model)
        {
            var result = _categoriaService.Create(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { result.Data?.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoriaUpdateViewModel model)
        {
            var result = _categoriaService.Update(id, model);

            if (!result.IsSuccess)
            {
                switch (result.ErrorType)
                {
                    case ErrorType.NotFound:
                        return NotFound(result);
                    case ErrorType.Validation:
                        return BadRequest(result);
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoriaService.Delete(id);

            switch (result.ErrorType)
            {
                case ErrorType.NotFound:
                    return NotFound(result);
                case ErrorType.Validation:
                    return BadRequest(result);
            }

            return NoContent();
        }

        [HttpGet("finalidades")]
        public IActionResult GetFinalidades()
        {
            var result = _categoriaService.GetFinalidades();

            return Ok(result);
        }

        [HttpGet("finalidade/{finalidade}")]
        public IActionResult GetByFinalidade(int finalidade)
        {
            var result = _categoriaService.GetByFinalidade(finalidade);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}
