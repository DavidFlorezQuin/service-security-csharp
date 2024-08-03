using Business.Interfaces;
using Data.Dto;
using Data.Implementation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {

        private readonly IPersonData data;

        public PersonBusiness(IPersonData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person person = await this.data.GetById(id);

            PersonDto personDto = new PersonDto();

            personDto.Id = person.Id;
            personDto.Gender = person.gender;
            personDto.Birthday = person.birthday;
            personDto.Phone = person.phone;
            personDto.Email = person.email;
            personDto.Document = person.document;
            personDto.FirstName = person.first_name;
            personDto.LastName = person.last_name;

            return personDto;

        }

        private Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.first_name = entity.FirstName;
            person.last_name = entity.LastName;
            person.gender = entity.Gender;
            person.birthday = entity.Birthday;
            person.phone = entity.Phone;
            person.email = entity.Email;
            person.document = entity.Document;

            return person;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();

            person = this.mapearDatos(person, entity);

            return await this.data.Save(person);
        }

        public async Task Update(int id, PersonDto entity)
        {
            Person person = await this.data.GetById(id);

            if (person == null)
            {
                    throw new Exception("Registro no encontrado");
            }

            person = this.mapearDatos(person, entity);
            await this.data.Update(person);

        }
    }
}
