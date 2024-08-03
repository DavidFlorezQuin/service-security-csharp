using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public interface IUserData
    {
        Task Delete(int id);
        Task<IEnumerable<User>> GetAllSelect();
        Task<User> Save(User entity);
        Task Update(User entity);
        Task<User> GetByCode(int id);

        Task<User> GetById(int id);

        //nTask<PagedListDto<UserDto>> GetDataTable(QueryFilterDto filter);


    }
}
