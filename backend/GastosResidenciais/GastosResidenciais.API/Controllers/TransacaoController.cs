using GastosResidenciais.Application.Enums;
using GastosResidenciais.Application.Interfaces;
using GastosResidenciais.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace GastosResidenciais.API.Controllers
{
    [ApiController]
    [Route("transacoes")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _transacaoService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _transacaoService.GetById(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(TransacaoCreateViewModel model)
        {
            var result = _transacaoService.Create(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { result.Data?.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TransacaoUpdateViewModel model)
        {
            var result = _transacaoService.Update(id, model);

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
            var result = _transacaoService.Delete(id);

            switch (result.ErrorType)
            {
                case ErrorType.NotFound:
                    return NotFound(result);
                case ErrorType.Validation:
                    return BadRequest(result);
            }

            return NoContent();
        }

        [HttpGet("tipos")]
        public IActionResult GetTipos()
        {
            var result = _transacaoService.GetTipos();

            return Ok(result);
        }
    }
}
