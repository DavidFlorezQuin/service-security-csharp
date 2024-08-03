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
    public class ModuleBusiness : IModuleBusiness
    {

        private readonly IModuleData data; 

        public ModuleBusiness(IModuleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo module = await this.data.GetById(id);

            ModuloDto moduloDto = new ModuloDto();

            moduloDto.Id = module.Id;
            moduloDto.Name = module.Name;
            moduloDto.Description = module.Description;

            return moduloDto;
        }

        private Modulo mapearDatos(Modulo module, ModuloDto entity) 
        {
            module.Id = entity.Id;
            module.Name = entity.Name;
            module.Description = entity.Description;

            return module;
        }


        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();

            modulo = this.mapearDatos(modulo, entity);

            return await this.data.Save(modulo);
        }

        public async Task Update(int id, ModuloDto entity)
        {
            Modulo module = await this.data.GetById(id);

            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }

            module = this.mapearDatos(module, entity);
            await this.data.Update(module);
        }
    }
}
