using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POCProjectAPI.Services.Interfaces;
using POCProjectAPI.Services.ViewModels;

namespace POCProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly ILogger<ContatoController> _logger;

        public ContatoController(ILogger<ContatoController> logger, IContatoService contatoService)
        {
            _logger = logger;
            _contatoService = contatoService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IAsyncEnumerable<ContatoViewModel>>> GetContatos(int id)
        {
            try
            {
                var contatos = await _contatoService.GetContatos(id);
                return Ok(contatos);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Request Uri: {UriHelper.GetDisplayUrl(Request)}");
                _logger.LogError(ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogInformation($"Request Uri: {UriHelper.GetDisplayUrl(Request)}");
                _logger.LogInformation($"Payload: {JsonConvert.SerializeObject(contato)}");
                _logger.LogError(ex.Message);
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
            catch (Exception ex)
            {
                _logger.LogInformation($"Request Uri: {UriHelper.GetDisplayUrl(Request)}");
                _logger.LogInformation($"Payload: {JsonConvert.SerializeObject(contato)}");
                _logger.LogError(ex.Message);

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
            catch (Exception ex)
            {
                _logger.LogInformation($"Request Uri: {UriHelper.GetDisplayUrl(Request)}");
                _logger.LogError(ex.Message);
                return BadRequest("Solicitação inválida");
            }
        }
    }
}