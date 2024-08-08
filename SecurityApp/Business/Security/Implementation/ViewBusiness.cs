using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementation
{
    public class ViewBusiness : IViewBusiness
    {
        private readonly IViewData data;

        public ViewBusiness(IViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await data.GetById(id);

            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.Name = view.name;
            viewDto.Route = view.route;
            viewDto.Description = view.description;

            return viewDto;

        }

        private View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.name = entity.Name;
            view.route = entity.Route;
            view.description = entity.Description;
            view.ModuloId = entity.ModuleId;

            return view;
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view = mapearDatos(view, entity);

            return await data.Save(view);
        }

        public async Task Update(int id, ViewDto entity)
        {
            View view = await data.GetById(id);

            if (view == null)
            {
                throw new Exception("Registro noencontrado");
            }

            view = mapearDatos(view, entity);
            await data.Update(view);
        }
    }
}
