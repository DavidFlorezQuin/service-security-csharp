using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public interface IRoleData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task<Role> GetById(int id);

      //  Task<PagedListDto<RoleDto>> GetDataTable(QueryFilterDto filter);
    }
}
