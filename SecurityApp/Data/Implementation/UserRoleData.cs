using Data.Dto;
using Data.Implementation;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Interface
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
            context.user_Roles.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        name AS Nombre 
                    FROM 
                        View
                    WHERE DeletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<user_role> GetById(int id)
        {
            var sql = @"SELECT * FROM user_role WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<user_role>(sql, new { Id = id });
        }


        //public async Task<PagedListDto<UserRoleDto>> GetDataTable(QueryFilterDto filter)
        //{
        //    int pageNumber = filter.PageNumber == 0 ? int.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
        //    int pageSize = filter.PageSize == 0 ? int.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

        //    var sql = @"SELECT
        //        rv.Id,
        //        v.name AS NameView,
        //        r.name AS NameRole
        //    FROM role_view rv
        //    JOIN view v ON rv.IdView = v.Id
        //    JOIN role r ON rv.IdRole = r.Id
        //    WHERE 
        //    rv.deleted_at IS NULL" + (filter.ColumnOrder ?? "rv.Id") + " " + (filter.DirectionOrder ?? "asc");

        //    IEnumerable<UserRoleDto> items = await context.QueryAsync<UserRoleDto>(sql, new { filter.Filter });

        //    var pagedItems = PagedListDto<UserRoleDto>.Create(items, pageNumber, pageSize);

        //    return pagedItems;
        //}


        public async Task<user_role> Save(user_role entity)
        {
            context.user_Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(user_role entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
