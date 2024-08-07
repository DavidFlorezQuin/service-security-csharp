using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IUserBusiness
    {
        Task Delete(int id);

        //Task<IEnumerable<UserDto>> GetAllSelect();

        Task<UserDto> GetById(int id);

        Task<User> Save(UserDto entity);

        Task<menuDto> LoginAsync(LoginDto loginDto);

        Task Update(int id, UserDto entity);


    }
}
