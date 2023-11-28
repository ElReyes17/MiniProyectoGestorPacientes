
using GestorPacientes.Core.Application.Interfaces.Repositories.Generics;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GestorPacientes.Infrastructure.Persistence.Repositories.Generics
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly ApplicationContext _contexto;

        private readonly DbSet<T> _dbSet;
        public RepositorioGenerico(ApplicationContext context) 
        {
            _contexto = context;
            _dbSet =  _contexto.Set<T>();
        }


        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllWithInclude(List<string> propierties)
        {
            var query = _dbSet.AsQueryable();
            foreach (string propiedad in propierties)
            {
                query.Include(propiedad);
            }

             return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {

            var busqueda = await _dbSet.FindAsync(id);
            if (busqueda != null)
            {
                return busqueda;
            }

            throw new Exception("El ID INGRESADO no existe en la base de datos");
        }
        public virtual async Task<T> Add(T objeto)
        {
            await _dbSet.AddAsync(objeto);
            await _contexto.SaveChangesAsync();
            return objeto;
        }
        public async Task Update(T objeto)
        {
            _dbSet.Entry(objeto).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var delete = await _dbSet.FindAsync(id);

            if (delete != null)

            {
                _dbSet.Remove(delete);
                await _contexto.SaveChangesAsync();
            }
        }

       

       
    }
}
