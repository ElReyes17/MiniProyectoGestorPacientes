using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Services.Generics
{
    public interface IServiciosGenericos<SaveViewModel, ViewModel, Model>
        where SaveViewModel : class
        where ViewModel : class
        where Model : class
    {
        Task<List<ViewModel>> GetAll();

        Task<List<ViewModel>> GetAllWithInclude();

        Task<SaveViewModel> GetById(int id);

        Task<SaveViewModel> Add(SaveViewModel objeto);

        Task Update(SaveViewModel objeto);

        Task Delete(int id);
    }
}
