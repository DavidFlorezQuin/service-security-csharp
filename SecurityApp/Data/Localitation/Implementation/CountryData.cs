using Data.Localitation.Interface;
using Entity.Context;
using Entity.Model.Localitation;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Implementation
{
    public class CountryData : ICountryData
    {
        private readonly AplicationDbContext context;

        private readonly IConfiguration configuration; 

        public CountryData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration; 
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

        if(entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.Country.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task<Country> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Country> Save(Country entity)
        {
            context.Country.Add(entity);
            await context.SaveChangesAsync();
            return entity; 
        }

        public async Task Update(Country entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
