using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interfaces
{
    public interface IUserData
    {
        Task Delete(int id);
        Task<User> Save(User entity);
        Task Update(User entity);
        Task<User> GetById(int id);
        Task<UserDto> Login(LoginDto loginDto);
        Task<IEnumerable<RoleDto>> GetUserRolesAsync(int userId);
        Task<IEnumerable<ViewDto>> GetRoleViewsAsync(int roleId);

    }
}
