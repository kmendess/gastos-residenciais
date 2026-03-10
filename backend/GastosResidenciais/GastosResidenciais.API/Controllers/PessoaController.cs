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
                return NotFound(result.Messages);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreatePessoaViewModel model)
        {
            var result = _pessoaService.Create(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { result.Data?.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdatePessoaViewModel model)
        {
            var result = _pessoaService.Update(id, model);

            if (!result.IsSuccess)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _pessoaService.Delete(id);

            if(!result.IsSuccess)
                return NotFound();

            return NoContent();
        }
    }
}
