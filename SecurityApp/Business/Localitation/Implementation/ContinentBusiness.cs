using Business.Localitation.Interface;
using Data.Localitation.Interface;
using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Entity.Model.Localitation;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Localitation.Implementation
{
    public class ContinentBusiness : IContinentBusiness
    {

        private readonly IContinentData data;

        public ContinentBusiness(IContinentData data)
        {
            this.data = data; 
        }

        public async Task Delete(int id)
        {
            await data.Delete(id); 
        }

        public async Task<ContinentDto> GetById(int id)
        {
           
            Continent continent = await data.GetById(id);

            ContinentDto continentDto = new ContinentDto();

            continentDto.Id = continent.Id;
            continentDto.Name = continent.Name; 
            continentDto.Description = continent.Description;

            return continentDto; 
        }

        private Continent mapearDatos(Continent continent, ContinentDto entity)
        {
            continent.Id = entity.Id; 
            continent.Name = entity.Name;
            continent.Description = entity.Description;

            return continent; 
        }

        public async Task<Continent> Save(ContinentDto entity)
        {
            Continent continent = new Continent();

            continent = mapearDatos(continent, entity);

            return await data.Save(continent); 



        }

        public async Task Update(int id, ContinentDto entity)
        {
            Continent continent = await data.GetById(id); 

            if(continent == null)
            {
                throw new Exception("No existe");
            }

            continent = mapearDatos(continent, entity); 

            await data.Update(continent);
        }


    }
}
