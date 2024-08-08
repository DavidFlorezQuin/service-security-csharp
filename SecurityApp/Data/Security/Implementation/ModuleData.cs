using Data.Security.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Security.Implementation
{
    public class ModuleData : IModuleData
    {


        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ModuleData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task UpdateModuloOrder(int id1, int id2)
        {
            var modulo1 = await GetById(id1);
            var modulo2 = await GetById(id2);

            if (modulo1 == null || modulo2 == null)
            {
                throw new Exception("Uno o ambos módulos no fueron encontrados");
            }

            // Intercambiar los valores de la propiedad Order
            int tempOrder = modulo1.Order;
            modulo1.Order = modulo2.Order;
            modulo2.Order = tempOrder;

            context.Modulo.Update(modulo1);
            context.Modulo.Update(modulo2);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.Modulo.Update(entity);
            await context.SaveChangesAsync();
        }


        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM Modulo WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Modulo>(sql, new { Id = id });
        }



        public async Task<Modulo> Save(Modulo entity)
        {
            context.Modulo.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
