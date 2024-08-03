using Business.Interfaces;
using Data.Dto;
using Data.Implementation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class UserRoleBusiness : IUserRoleBusiness
    {
        private readonly IUserRoleData data;

        public UserRoleBusiness(IUserRoleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            user_role userRole = await this.data.GetById(id);

            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.Id = userRole.Id;

            userRoleDto.RoleId = userRole.IdRole;
            userRoleDto.UserId = userRole.IdUser; 


            return userRoleDto;

        }

        private user_role mapearDatos(user_role userRole, UserRoleDto entity)
        {
            userRole.Id = entity.Id;
            userRole.IdRole = entity.RoleId; 
            userRole.IdUser = entity.UserId;

            return userRole;
        }

        public async Task<user_role> Save(UserRoleDto entity)
        {
            user_role userRole = new user_role();

            userRole = this.mapearDatos(userRole, entity);

            return await this.data.Save(userRole);
        }

        public async Task Update(int id, UserRoleDto entity)
        {
            user_role userRole = await this.data.GetById(id);

            if (userRole == null)
            {
                throw new Exception("Registro no encontrado");
            }

            userRole = this.mapearDatos(userRole, entity); 
            await this.data.Update(userRole);
        }
    }
}
