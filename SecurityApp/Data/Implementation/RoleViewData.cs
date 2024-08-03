using Data.Dto;
using Data.Implementation;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Interface
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
            context.role_Views.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        name AS Nombre 
                    FROM 
                        View
                    WHERE deleted_at IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<role_view> GetById(int id)
        {
            var sql = @"SELECT * FROM role_view WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<role_view>(sql, new { Id = id });
        }


        //public async Task<PagedListDto<RoleViewDto>> GetDataTable(QueryFilterDto filter)
        //{
        //    int pageNumber = filter.PageNumber == 0 ? int.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
        //    int pageSize = filter.PageSize == 0 ? int.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

        //    var sql = @"
        //        SELECT
        //            rv.Id,
        //            v.name AS NameView,
        //            r.name AS NameRole
        //        FROM role_view rv
        //        JOIN view v ON rv.IdView = v.id
        //        JOIN role r ON rv.IdRole = r.id
        //        WHERE 
        //            rv.deleted_at IS NULL
        //        (UPPER(r.name) LIKE UPPER(CONCAT('%', @filter, '%')))
        //        ORDER BY " + (filter.ColumnOrder ?? "rv.Id") + " " + (filter.DirectionOrder ?? "asc");


        //    IEnumerable<RoleViewDto> items = await context.QueryAsync<RoleViewDto>(sql, new { filter.Filter });

        //    var pagedItems = PagedListDto<RoleViewDto>.Create(items, pageNumber, pageSize);

        //    return pagedItems;
        //}


        public async Task<role_view> Save(role_view entity)
        {
            context.role_Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(role_view entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
