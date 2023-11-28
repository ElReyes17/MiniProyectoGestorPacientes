

namespace GestorPacientes.Core.Application.Interfaces.Repositories.Generics
{
    public interface IRepositorioGenerico<T> 
    {
        Task<List<T>> GetAll();

        Task<List<T>> GetAllWithInclude(List<string> propierties);

        Task<T> GetById(int id);

        Task <T> Add(T objeto);
     
        Task Update(T objeto);

        Task Delete(int id);

    }
}
