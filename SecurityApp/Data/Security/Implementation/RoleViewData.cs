using Data.Security.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Security.Implementation
{
    public class RoleViewData : IRoleViewData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RoleViewData(AplicationDbContext context, IConfiguration configuration)
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
            context.RoleView.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<RoleView> Save(RoleView entity)
        {
            context.RoleView.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RoleView entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM role_view WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
        }
    }
}
