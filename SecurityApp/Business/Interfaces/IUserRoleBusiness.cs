using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserRoleBusiness
    {
        Task Update(int id, UserRoleDto entity); 
        Task Delete(int id);
        //Task<List<UserRoleDto>> GetAll();
        Task<user_role> Save(UserRoleDto entity);

        Task<UserRoleDto> GetById(int id);
    }
}
