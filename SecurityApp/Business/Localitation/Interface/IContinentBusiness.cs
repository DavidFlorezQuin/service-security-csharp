using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Entity.Model.Localitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Localitation.Interface
{
    public interface IContinentBusiness
    {
        Task Delete(int id);

        Task<Continent> Save(ContinentDto entity);
        Task<ContinentDto> GetById(int id);

        Task Update(int id, ContinentDto entity);
    }
}
