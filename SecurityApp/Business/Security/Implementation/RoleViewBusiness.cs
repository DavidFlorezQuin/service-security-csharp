using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementation
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
            await data.GetById(id);
        }

        public async Task<RoleViewDto> GetById(int id)
        {
            RoleView roleView = await data.GetById(id);

            RoleViewDto roleViewDto = new RoleViewDto();

            roleViewDto.Id = roleView.Id;
            roleViewDto.IdRole = roleView.RoleId;
            roleViewDto.IdView = roleView.ViewId;

            return roleViewDto;

        }

        private RoleView mapearDatos(RoleView roleView, RoleViewDto entity)
        {
            roleView.Id = entity.Id;
            roleView.RoleId = entity.IdRole;
            roleView.ViewId = entity.IdView;

            return roleView;
        }

        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleView = new RoleView();

            roleView = mapearDatos(roleView, entity); ;

            return await data.Save(roleView);
        }

        public async Task Update(int id, RoleViewDto entity)
        {
            RoleView roleView = await data.GetById(id);

            if (roleView == null)
            {
                throw new Exception("Registro no encontrado");

            }

            roleView = mapearDatos(roleView, entity);

            await data.Update(roleView);
        }
    }
}
