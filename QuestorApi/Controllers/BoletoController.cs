using Microsoft.AspNetCore.Mvc;
using System.Text;
using DominioApi.ModelosDtos;
using DominioApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace QuestorApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BoletoController : Controller
    {        
        private readonly IBoletoAplicacao _IboletoAplicacao;

        public BoletoController(IBoletoAplicacao IboletoAplicacao)
        {            
            _IboletoAplicacao = IboletoAplicacao;
        }

        /// <summary>
        /// Cadastra boleto na base
        /// </summary>
        /// <returns>Resultado de cadastro do boleto</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /CadastrarBoleto
        ///     {
        ///         "nomePagador": "NomePagador",
        ///         "cpfCnpjPagador": "000.000.000-00",
        ///         "nomeBeneficiario": "NomeBeneficiario",
        ///         "cpfCnpjBeneficiario": "000.000.000-00",
        ///         "valor": 50,
        ///         "dataVencimento": "2023-11-01",
        ///         "observacao": "qualquer informacao",
        ///         "bancoId": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Boleto registrado</response>
        /// <response code="400">Alguma informação incorreta ou não informada</response>
        [HttpPost("CadastrarBoleto")]
        public async Task<IActionResult> CadastrarBoleto(BoletoDto boletoDto)
        {
            var boletoValido = await _IboletoAplicacao.ValidarBoleto(boletoDto);

            if (!boletoValido.IsValid || boletoValido.Errors.Any())
            {
                var Erros = new StringBuilder();
                foreach (var erro in boletoValido.Errors)
                {
                    Erros.AppendLine(erro.ToString());
                }
                return BadRequest(Erros.ToString());
            }
            return Ok(await _IboletoAplicacao.GravarBoleto(boletoDto));
        }

        /// <summary>
        /// Obter boleto pelo Id
        /// </summary>
        /// <returns>Informações do boleto com Id informado</returns>
        /// <response code="200">Informações do boleto com Id informado</response>
        /// <response code="404">Boleto não encontrado</response>
        [HttpGet("ObterBoletoPorId")]
        public async Task<IActionResult> ObterBoletoPorId(int id)
        {
            var boleto = await _IboletoAplicacao.ObterBoletoPorId(id);            

            return boleto != null ? Ok(boleto) : NotFound("Boleto não encontrado");
        }      
    }
}
