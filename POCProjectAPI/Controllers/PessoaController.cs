using Microsoft.AspNetCore.Mvc;
using POCProjectAPI.Services.Interfaces;
using POCProjectAPI.Services.ViewModels;

namespace POCProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IAsyncEnumerable<PessoaViewModel>>> GetPessoaById(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoa(id);

                if (pessoa == null)
                    return NotFound($"Pessoa co id: {id} não encontrada");

                return Ok(pessoa);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema com a solicitação");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<PessoaViewModel>>> GetPessoas()
        {
            try
            {
                var pessoas = await _pessoaService.GetPessoasContatos();
                return Ok(pessoas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema com a solicitação");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(PessoaViewModel pessoa)
        {
            try
            {
                if (pessoa is null)
                    return BadRequest("Dados inválidos");

                await _pessoaService.CreatePessoa(pessoa);

                return RedirectToAction(nameof(GetPessoas));
            }
            catch (Exception)
            {
                return BadRequest("Solicitação inválida");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PessoaViewModel>> Edit(int id, PessoaViewModel pessoa)
        {
            try
            {
                if (id != pessoa.PessoaId)
                    return BadRequest("Dados inválidos");

                await _pessoaService.UpdatePessoa(pessoa);

                return Ok($"Pessoa com id: {id} foi atualizada com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Solicitação inválida");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoa(id);

                if (pessoa is null)
                    return NotFound($"Pessoa com id: {id} não encontrada");

                await _pessoaService.DeletePessoa(pessoa);

                return Ok($"Pessoa com id: {id} foi excluída com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Solicitação inválida");
            }
        }
    }
}