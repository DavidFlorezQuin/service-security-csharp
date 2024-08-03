using Data.Dto;
using Data.Implementation;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Interface
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
            context.views.Update(entity);
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

        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM View WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }


        //public async Task<PagedListDto<ViewDto>> GetDataTable(QueryFilterDto filter)
        //{
        //    int pageNumber = filter.PageNumber == 0 ? int.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
        //    int pageSize = filter.PageSize == 0 ? int.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

        //    var sql = @"SELECT
        //        v.Id,
        //        v.name AS Name,
        //        v.description AS Description
        //        v.route AS Route
        //    FROM View v

        //    WHERE 
        //    v.deleted_at IS NULL" + (filter.ColumnOrder ?? "v.Id") + " " + (filter.DirectionOrder ?? "asc");

        //    IEnumerable<ViewDto> items = await context.QueryAsync<ViewDto>(sql, new { filter.Filter });

        //    var pagedItems = PagedListDto<ViewDto>.Create(items, pageNumber, pageSize);

        //    return pagedItems;
        //}


        public async Task<View> Save(View entity)
        {
            context.views.Add(entity);
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
