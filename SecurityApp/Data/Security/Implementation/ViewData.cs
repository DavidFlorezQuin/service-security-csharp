﻿using Data.Security.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Security.Implementation
{
    public class ViewData : IViewData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ViewData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }


        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.View.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM View WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }


        public async Task<View> Save(View entity)
        {
            context.View.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(View entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
