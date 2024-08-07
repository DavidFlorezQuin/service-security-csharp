using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IModuleBusiness
    {
        Task Delete(int id);

        Task<Modulo> Save(ModuloDto entity);

        Task Update(int id, ModuloDto entity);

        Task<ModuloDto> GetById(int id);
    }
}
