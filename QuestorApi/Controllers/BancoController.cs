using Microsoft.AspNetCore.Mvc;
using System.Text;
using DominioApi.ModelosDtos;
using DominioApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using QuestorApi;

namespace QuestorApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BancoController : ControllerBase
    {        
        private readonly IBancoAplicacao _IbancoAplicacao;

        public BancoController(IBancoAplicacao IbancoAplicacao)
        {
            _IbancoAplicacao = IbancoAplicacao;
        }

        /// <summary>
        /// Registrar banco
        /// </summary>
        /// <returns>Resultado de registro no banco</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /CadastrarBanco
        ///     {
        ///        "nome": "NomeBanco",
        ///        "codigo": 1,
        ///        "percentualJuros": 5
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Banco registrado</response>
        /// <response code="400">Alguma informação do banco incorreta ou não foi informada</response>
        [HttpPost("CadastrarBanco")]
        public async Task<IActionResult> GravarBanco(BancoDto bancoDto)
        {
            var bancoValido = await _IbancoAplicacao.ValidarBanco(bancoDto);

            if (!bancoValido.IsValid || bancoValido.Errors.Any())
            {
                var Erros = new StringBuilder();
                foreach (var erro in bancoValido.Errors)
                {
                    Erros.AppendLine(erro.ToString());
                }
                return BadRequest(Erros.ToString());
            }

            return Ok(await _IbancoAplicacao.GravarBanco(bancoDto));
        }


        /// <summary>
        /// Obter todos os bancos cadastrados na base de dados
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Listagem e informação dos bancos</response>
        /// <response code="404">Nenhum banco encontrado</response>
        [HttpGet("ObterBancos")]
        public async Task<IActionResult> ObterBancos()
        {    
            var bancos = await _IbancoAplicacao.ObterBancos();
            return bancos.Any() ? Ok(bancos) : NotFound("Nenhum banco encontrado");
        }

        /// <summary>
        /// Busca informações do banco pelo código
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Informações do banco buscado pelo código</response>
        /// <response code="404">Banco não encontrado</response>
        [HttpGet("ObterBancoPorCodigo")]
        public async Task<IActionResult> ObterBancoPorCodigo(string codigoBanco)
        {
            var banco = await _IbancoAplicacao.ObterBancoPorCodigo(codigoBanco);
            return banco != null ? Ok(banco) : NotFound("Banco não encontrado");
        }
    }
}
