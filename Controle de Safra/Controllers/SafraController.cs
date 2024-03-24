using Controle_de_Safra.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Safra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafraController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<CarregamentoModel>> ObtenhaCarregamentos()
        {
            return Ok();
        }
    }
}