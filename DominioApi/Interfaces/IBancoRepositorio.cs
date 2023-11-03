using DominioApi.Entidades;

namespace DominioApi.Interfaces
{
    public interface IBancoRepositorio : IRepositorioBase
    {
        Task<List<Banco>> ObterBancos();
        Task<Banco> ObterBancoPorId(int id);
        Task<Banco> ObterBancoPorCodigo(string codigoBanco);
        Task<bool> SalvarBanco(Banco banco);
    }
}
