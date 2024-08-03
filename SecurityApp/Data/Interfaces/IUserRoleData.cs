using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public interface IUserRoleData
    {

        Task<user_role> Save(user_role entity);
        Task<user_role> GetById(int id);
        Task Update(user_role entity);
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        // Task<PagedListDto<UserRoleDto>> GetDataTable(QueryFilterDto filter);
    }
}
