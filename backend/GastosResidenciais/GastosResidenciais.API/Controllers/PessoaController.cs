using GastosResidenciais.Application.Enums;
using GastosResidenciais.Application.Interfaces;
using GastosResidenciais.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace GastosResidenciais.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _pessoaService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _pessoaService.GetById(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(PessoaCreateViewModel model)
        {
            var result = _pessoaService.Create(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { result.Data?.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PessoaUpdateViewModel model)
        {
            var result = _pessoaService.Update(id, model);

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
            var result = _pessoaService.Delete(id);

            switch (result.ErrorType)
            {
                case ErrorType.NotFound:
                    return NotFound(result);
                case ErrorType.Validation:
                    return BadRequest(result);
            }

            return NoContent();
        }
    }
}
