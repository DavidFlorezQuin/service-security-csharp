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
    public class ViewBusiness : IViewBusiness
    {
        private readonly IViewData data; 

        public ViewBusiness(IViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await this.data.GetById(id);

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

            return view;
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view = this.mapearDatos(view, entity);

            return await this.data.Save(view);
        }

        public async Task Update(int id, ViewDto entity)
        {
            View view = await this.data.GetById(id); 

            if (view == null )
            {
                throw new Exception("Registro noencontrado"); 
            }

            view = this.mapearDatos(view,entity);
            await this.data.Update(view);
        }
    }
}
