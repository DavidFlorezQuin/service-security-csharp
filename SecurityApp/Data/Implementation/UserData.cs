using Data.Dto;
using Data.Implementation;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Interface
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
            context.users.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        UserName AS Nombre 
                    FROM 
                        Users
                    WHERE DeletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM Users WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }


        //public async Task<PagedListDto<UserDto>> GetDataTable(QueryFilterDto filter)
        //  {
        //      int pageNumber = filter.PageNumber == 0 ? int.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
        //      int pageSize = filter.PageSize == 0 ? int.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

        //      var sql = @"SELECT
        //                  u.Id,
        //                  u.UserName,
        //                  u.state AS State,
        //                  CONCAT(p.FirstName, ' ', p.LastName) AS PersonFullName
        //              FROM User u
        //                  INNER JOIN Person p ON u.PersonId = p.Id
        //              WHERE u.deleted_at IS NULL AND
        //                  (UPPER(u.UserName) LIKE UPPER(CONCAT('%', @filter, '%')))
        //              ORDER BY " + (filter.ColumnOrder ?? "u.Id") + " " + (filter.DirectionOrder ?? "asc");

        //      IEnumerable<UserDto> items = await context.QueryAsync<UserDto>(sql, new { filter.Filter });

        //      var pagedItems = PagedListDto<UserDto>.Create(items, pageNumber, pageSize);

        //      return pagedItems;
        //  }


        public async Task<User> Save(User entity)
        {
            context.users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<User> GetByCode(int id)
        {
            return await context.users.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        async Task<IEnumerable<User>> IUserData.GetAllSelect()
        {
            return await context.users.ToListAsync();
        }
    }
}
