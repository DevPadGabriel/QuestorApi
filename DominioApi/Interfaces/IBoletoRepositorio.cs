using DominioApi.Entidades;

namespace DominioApi.Interfaces
{
    public interface IBoletoRepositorio : IRepositorioBase
    {
        Task<Boleto> ObterBoletoPorId(int id);
        Task<bool> SalvarBoleto(Boleto boleto);
    }
}
