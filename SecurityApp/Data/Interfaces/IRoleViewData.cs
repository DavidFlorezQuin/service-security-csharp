using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public interface IRoleViewData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<role_view> Save(role_view entity);
        Task Update(role_view entity);

        Task<role_view> GetById(int id);

        // Task<PagedListDto<RoleViewDto>> GetDataTable(QueryFilterDto filter);

    }
}
