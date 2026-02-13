using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BiotokkaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController(IViaCepService viaCepService) : ControllerBase
    {
        //private readonly IViaCepService _viaCepService;

        //public CepController(IViaCepService viaCepService)
        //{
        //    _viaCepService = viaCepService;
        //}

        /// <summary>
        /// Consulta endereço por CEP usando ViaCEP
        /// </summary>
        /// <param name="cep">CEP com ou sem hífen (ex: 01001000 ou 01001-000)</param>
        [HttpGet("{cep}")]
        
        public async Task<IActionResult> ConsultarCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                return BadRequest(new { Message = "CEP não informado." });
            }

            // Cria o DTO a partir da string recebida
            var request = new ViaCepRequestDTO(cep);

            var endereco = await viaCepService.ObterEnderecoAsync(request);

            if (endereco == null)
            {
                return NotFound(new { Message = "CEP não encontrado ou inválido." });
            }

            return Ok(new { Cep = cep, Endereco = endereco });
        }
    }
}
