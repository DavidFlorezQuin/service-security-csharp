using Data.Localitation.Interface;
using Entity.Context;
using Entity.Model.Localitation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Implementation
{
    public class CityData : ICityData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration; 

        public CityData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration; 
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if(entity == null)
            {
                throw new Exception("Registro no encuntrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.City.Update(entity);
            await context.SaveChangesAsync();

        }

        public Task<City> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<City> Save(City entity)
        {
            context.City.Add(entity);
            await context.SaveChangesAsync();
            return entity; 
        }

        public async Task Update(City entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
