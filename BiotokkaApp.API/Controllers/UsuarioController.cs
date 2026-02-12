using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiotokkaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        [HttpPost("autenticar")]
        public IActionResult Autenticar([FromBody] AutenticarRequest request)
        {
            try
            {
                var response = usuarioService.AutenticarConta(request);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Ocorreu um erro inesperado. Tente novamente mais tarde." });
            }
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] CriarContaRequest request)
        {
            try
            {
                var response = usuarioService.CriarConta(request);

                return StatusCode(201, response);

            }
            catch (ValidationException e)
            {
                return StatusCode(400, new { e.Errors });
            }
            catch (ApplicationException e)
            {
                return StatusCode(409, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}