using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleViewBusiness
    {
        Task Delete(int id);
        Task<role_view> Save(RoleViewDto entity);

        Task<RoleViewDto> GetById(int id);

        Task Update(int id, RoleViewDto entity);
    }
}
