using Data.Dto;
using Data.Implementation;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Interface
{
    public class RoleData : IRoleData
    {


        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RoleData(AplicationDbContext context, IConfiguration configuration)
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
            context.roles.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        name AS Nombre 
                            FROM 
                        User
                    WHERE deleted_at IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM Role WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }


        //public async Task<PagedListDto<RoleDto>> GetDataTable(QueryFilterDto filter)
        //{
        //    int pageNumber = filter.PageNumber == 0 ? int.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
        //    int pageSize = filter.PageSize == 0 ? int.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

        //    var sql = @"SELECT
        //        r.Id,
        //        r.name AS Name,
        //        r.description AS Description
        //            FROM Role r
        //            WHERE 
        //        r.deleted_at IS NULL AND
        //        (UPPER(r.name) LIKE UPPER(CONCAT('%', @filter, '%')))
        //    ORDER BY " + (filter.ColumnOrder ?? "r.Id") + " " + (filter.DirectionOrder ?? "asc");

        //    IEnumerable<RoleDto> items = await context.QueryAsync<RoleDto>(sql, new { filter.Filter });

        //    var pagedItems = PagedListDto<RoleDto>.Create(items, pageNumber, pageSize);

        //    return pagedItems;
        //}


        public async Task<Role> Save(Role entity)
        {
            context.roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Role entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
