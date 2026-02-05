using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiotokkaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {            
            return Ok(new { Message = "todos os produtos" });
        }
    }
}
