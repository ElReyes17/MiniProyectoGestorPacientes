using GestorPacientes.Core.Application.Interfaces.Repositories.Generics;
using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.Interfaces.Repositories
{
    public interface IRepositorioResultadosLaboratorio : IRepositorioGenerico<ResultadosLaboratorio>
    {
        Task AddAll(List<ResultadosLaboratorio> T);
    }
}
