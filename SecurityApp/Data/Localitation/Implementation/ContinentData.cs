using Data.Localitation.Interface;
using Entity.Context;
using Entity.Model.Localitation;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Implementation
{
    public class ContinentData : IContinentData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ContinentData(AplicationDbContext context, IConfiguration configuration)
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
            context.Continent.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Continent> GetById(int id)
        {
            var sql = @"SELECT * FROM Continent WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Continent>(sql, new { Id = id });
        }

        public async Task<Continent> Save(Continent entity)
        {
            context.Continent.Add(entity);
            await context.SaveChangesAsync();
            return entity; 
        }

        public async Task Update(Continent entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        
    }
}
