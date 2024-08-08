using Data.Security.Interfaces;
using Entity.Context;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Security.Implementation
{
    public class UserData : IUserData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UserData(AplicationDbContext context, IConfiguration configuration)
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
            context.User.Update(entity);
            await context.SaveChangesAsync();
        }


        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM Users WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.UserName == loginDto.username && u.passsword == loginDto.password);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                state = user.state,
                password = user.passsword,
                PersonId = user.PersonId
            };

            return userDto;
        }


        public async Task<IEnumerable<RoleDto>> GetUserRolesAsync(int userId)
        {
            return await context.UserRole
                                .Where(ur => ur.UserId == userId)
                                .Select(ur => new RoleDto { Id = ur.Role.Id, Name = ur.Role.Name })
                                .ToListAsync();
        }

        public async Task<IEnumerable<ViewDto>> GetRoleViewsAsync(int roleId)
        {
            return await context.RoleView
                                .Where(rv => rv.RoleId == roleId)
                                .Select(rv => new ViewDto { Id = rv.View.Id, Name = rv.View.name, Description = rv.View.description, Route = rv.View.route, ModuleId = rv.View.ModuloId})
                                .ToListAsync();
        }

        public async Task<User> Save(User entity)
        {
            context.User.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }



    }
}
