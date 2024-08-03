using Data.Implementation;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Interface
{
    public class PersonData : IPersonData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public PersonData(AplicationDbContext context, IConfiguration configuration)
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
            context.personas.Update(entity);
            await context.SaveChangesAsync();
        }
        //public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        //{
        //    var sql = @"SELECT 
        //                Id,
        //                first_name AS Nombre 
        //            FROM 
        //                Person
        //            WHERE deleted_by IS NULL AND state = 1
        //            ORDER BY Id ASC";
        //    return await context.QueryAsync<DataSelectDto>(sql);
        //}
        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM Person WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }


        //public async Task<PagedListDto<PersonDto>> GetDataTable(QueryFilterDto filter)
        //{
        //    int pageNumber = filter.PageNumber == 0 ? int.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
        //    int pageSize = filter.PageSize == 0 ? int.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

        //    var sql = @"SELECT
        //        p.Id,
        //        p.first_name AS FirstName,
        //        p.last_name AS LastName,
        //        p.email AS Email,
        //        p.gender AS Gender,
        //        p.document AS Document,
        //        p.type_document AS TypeDocument,
        //        p.direction AS Direction,
        //        p.phone AS Phone,
        //        p.birthday AS Birthday,
        //        p.created_at AS CreatedAt,
        //        p.updated_at AS UpdatedAt,
        //        p.state AS State,
        //        CONCAT(p.first_name, ' ', p.last_name) AS FullName
        //    FROM Persons p
        //    WHERE p.deleted_at IS NULL AND
        //        (UPPER(CONCAT(p.first_name, p.last_name)) LIKE UPPER(CONCAT('%', @filter, '%')))
        //    ORDER BY " + (filter.ColumnOrder ?? "p.Id") + " " + (filter.DirectionOrder ?? "asc");

        //    IEnumerable<PersonDto> items = await context.QueryAsync<PersonDto>(sql, new { filter.Filter });

        //    var pagedItems = PagedListDto<PersonDto>.Create(items, pageNumber, pageSize);

        //    return pagedItems;
        //}


        public async Task<Person> Save(Person entity)
        {
            context.personas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Person entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
    