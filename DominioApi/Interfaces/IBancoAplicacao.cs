using DominioApi.Entidades;
using DominioApi.ModelosDtos;
using FluentValidation.Results;

namespace DominioApi.Interfaces
{
    public interface IBancoAplicacao
    {
        Task<ValidationResult> ValidarBanco(BancoDto banco);
        Task<bool> GravarBanco(BancoDto bancoDto);
        Task<List<BancoDto>> ObterBancos();
        Task<BancoDto> ObterBancoPorCodigo(string codigo);
        Task<Banco> ObterBancoPorId(int id);
    }
}
