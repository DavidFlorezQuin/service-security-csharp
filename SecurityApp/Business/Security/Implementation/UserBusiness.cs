using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.Security.Implementation.UserBusiness;

namespace Business.Security.Implementation
{
    public class UserBusiness : IUserBusiness
    {

        private readonly IUserData data;


        public UserBusiness(IUserData data)
        {
            this.data = data;
        }


        public async Task<menuDto> LoginAsync(LoginDto loginDto)
        {
            var user = await data.Login(loginDto);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var roles = await data.GetUserRolesAsync(user.Id);

            var roleViews = new List<ViewDto>();
            foreach (var role in roles)
            {
                var views = await data.GetRoleViewsAsync(role.Id);
                roleViews.AddRange(views);
            }

            return new menuDto
            {
                User = new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    state = user.state,
                    password = user.password,
                    PersonId = user.PersonId
                },
                Roles = roles.ToList(),
                Views = roleViews.Distinct().ToList()
            };
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await data.GetById(id);

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        public async Task Update(int id, UserDto entity)
        {
            var user = await data.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }

            user = MapearDatos(user, entity);
            await data.Update(user);
        }

        private User MapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.UserName = entity.UserName;
            user.passsword = entity.password;
            user.PersonId = entity.PersonId;
            user.state = entity.state;

            return user;
        }

        public async Task<User> Save(UserDto entity)
        {
            var user = new User();
            user = MapearDatos(user, entity);
            user.Person = null;

            return await data.Save(user);
        }
    }
}
