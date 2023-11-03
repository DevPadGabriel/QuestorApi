using Microsoft.EntityFrameworkCore;
using InfraApi.Contexto;
using DominioApi.Interfaces;
using DominioApi.Entidades;

namespace InfraApi.Repositorio
{
    public class BancoRepositorio : RepositorioBase, IBancoRepositorio
    {
        private readonly DbContexto _contexto;

        public BancoRepositorio(DbContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Banco> ObterBancoPorId(int id)
        {
            return await _contexto.Banco.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Banco>> ObterBancos()
        {
            return await _contexto.Banco.ToListAsync();
        }

        public async Task<Banco> ObterBancoPorCodigo(string codigoBanco)
        {
            return await _contexto.Banco.Where(x => x.CodigoBanco == codigoBanco).FirstOrDefaultAsync();
        }

        public async Task<bool> SalvarBanco(Banco banco)
        {
            Add(banco);
            return await SaveChangesAsync();
        }
    }
}
