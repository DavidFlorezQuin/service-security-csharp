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
    public class ModuleBusiness : IModuleBusiness
    {

        private readonly IModuleData data;

        public ModuleBusiness(IModuleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo module = await data.GetById(id);

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

            modulo = mapearDatos(modulo, entity);

            return await data.Save(modulo);
        }

        public async Task Update(int id, ModuloDto entity)
        {
            Modulo module = await data.GetById(id);

            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }

            module = mapearDatos(module, entity);
            await data.Update(module);
        }
    }
}
