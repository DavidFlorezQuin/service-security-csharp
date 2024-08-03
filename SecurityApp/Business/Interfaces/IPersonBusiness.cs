using Data.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonBusiness
    {
        Task Delete(int id);

        Task<Person> Save(PersonDto entity);

        Task<PersonDto> GetById(int id);

        Task Update(int id, PersonDto entity);

    }
}
