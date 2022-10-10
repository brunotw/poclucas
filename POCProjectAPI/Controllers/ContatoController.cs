using Microsoft.AspNetCore.Mvc;
using POCProjectAPI.Services.Interfaces;
using POCProjectAPI.Services.ViewModels;

namespace POCProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet("{pessoaId:int}")]
        public async Task<ActionResult<IAsyncEnumerable<ContatoViewModel>>> GetContatos(int pessoaId)
        {
            try
            {
                var contatos = await _contatoService.GetContatos(pessoaId);
                return Ok(contatos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema com a solicitação");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContatoViewModel contato)
        {
            try
            {
                if (contato is null)
                    return BadRequest("Dados inválidos");

                await _contatoService.CreateContato(contato);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Solicitação inválida");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ContatoViewModel>> Edit(int id, ContatoViewModel contato)
        {
            try
            {
                if (id != contato.ContatoId)
                    return BadRequest("Dados inválidos");

                await _contatoService.UpdateContato(contato);

                return Ok($"Contato com id: {id} foi atualizado com sucesso");
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
                var contato = await _contatoService.GetContato(id);

                if (contato is null)
                    return NotFound($"Contato com id: {id} não encontrada");

                await _contatoService.DeleteContato(contato);

                return Ok($"Contato com id: {id} foi excluído com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Solicitação inválida");
            }
        }
    }
}