using DominioApi.ModelosDtos;
using FluentValidation.Results;

namespace DominioApi.Interfaces
{
    public interface IBoletoAplicacao
    {
        Task<ValidationResult> ValidarBoleto(BoletoDto boleto);
        Task<bool> GravarBoleto(BoletoDto boletoDto);
        Task<BoletoDto> ObterBoletoPorId(int id);
    }
}
