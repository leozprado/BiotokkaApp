using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiotokkaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {            
            return Ok(new { Message = "todas as vendas" });
        }
    }
}
