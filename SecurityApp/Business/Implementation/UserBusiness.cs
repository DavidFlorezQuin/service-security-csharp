using Business.Interfaces;
using Data.Dto;
using Data.Implementation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.Implementation.UserBusiness;

namespace Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {

        private readonly IUserData data;

        public UserBusiness(IUserData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await this.data.GetById(id);           

            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.UserName = user.UserName;

            return userDto;
           
        }
        public async Task Update(int id, UserDto entity)
        {
            User user = await this.data.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }

            user = this.mapearDatos(user, entity);

            await this.data.Update(user);

        }

        private User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.UserName = entity.UserName;


            return user;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();

            user = this.mapearDatos(user,entity);

            return await this.data.Save(user);
        }

    }
}
