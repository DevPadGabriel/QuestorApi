using AplicacaoApi;
using DominioApi.ModelosDtos;
using Microsoft.AspNetCore.Mvc;

namespace QuestorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private IConfiguration configuration;
        public AutenticacaoController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpPost("ObterToken")]
        public async Task<IActionResult> ObterToken()
        {
            var token = new TokenServico().GerarToken(configuration["Secret"]);

            if (token == null)
                throw new ArgumentNullException("Não foi possível gerar um token.");

            return Ok(token);
        }
    }
}