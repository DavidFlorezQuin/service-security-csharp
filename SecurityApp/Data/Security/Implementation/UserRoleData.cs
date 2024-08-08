using Data.Security.Interfaces;
using Entity.Context;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Security.Implementation
{
    public class UserRoleData : IUserRoleData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UserRoleData(AplicationDbContext context, IConfiguration configuration)
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
            context.UserRole.Update(entity);
            await context.SaveChangesAsync();
        }
       

        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM userRole WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<UserRole>(sql, new { Id = id });
        }


        public async Task<UserRole> Save(UserRole entity)
        {
            context.UserRole.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(UserRole entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<RoleDto>> GetRoleByUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
