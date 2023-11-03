using DominioApi.Entidades;
using DominioApi.Interfaces;
using InfraApi.Contexto;
using Microsoft.EntityFrameworkCore;

namespace InfraApi.Repositorio
{
    public class BoletoRepositorio : RepositorioBase, IBoletoRepositorio
    {
        private readonly DbContexto _contexto;
        public BoletoRepositorio(DbContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Boleto> ObterBoletoPorId(int id)
        {
            return await _contexto.Boleto.Include(b => b.Banco).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<bool> SalvarBoleto(Boleto boleto)
        {
            Add(boleto);
            return SaveChangesAsync();
        }
    }
}
