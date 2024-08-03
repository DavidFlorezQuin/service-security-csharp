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
    public class RoleViewBusiness : IRoleViewBusiness
    {
        private readonly IRoleViewData data; 

        public RoleViewBusiness(IRoleViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.GetById(id);
        }

        public async Task<RoleViewDto> GetById(int id)
        {
            role_view roleView = await this.data.GetById(id);

            RoleViewDto roleViewDto = new RoleViewDto();

            roleViewDto.Id = roleView.Id;
            roleViewDto.IdRole = roleView.IdRole;
            roleViewDto.IdView = roleView.IdView;

            return roleViewDto;

        }

        private role_view mapearDatos(role_view  roleView, RoleViewDto entity)
        {
            roleView.Id = entity.Id;
            roleView.IdRole = entity.IdRole;
            roleView.IdView = entity.IdView;

            return roleView;
        }

        public async Task<role_view> Save(RoleViewDto entity)
        {
            role_view roleView = new role_view();

            roleView = this.mapearDatos(roleView, entity); ;

            return await this.data.Save(roleView);
        }

        public async Task Update(int id, RoleViewDto entity)
        {
            role_view roleView = await this.data.GetById(id);

            if (roleView == null)
            {
                throw new Exception("Registro no encontrado");

            }

            roleView = this.mapearDatos(roleView, entity); 

            await this.data.Update(roleView);
        }
    }
}
