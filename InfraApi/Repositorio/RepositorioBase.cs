using DominioApi.Interfaces;
using InfraApi.Contexto;

namespace InfraApi.Repositorio
{
    public class RepositorioBase : IRepositorioBase
    {
        private readonly DbContexto _contexto;

        public RepositorioBase(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }
    }
}
