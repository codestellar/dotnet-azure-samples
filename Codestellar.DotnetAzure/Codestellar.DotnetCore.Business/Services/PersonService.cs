using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codestellar.DotnetAzure.Api.Models;
using GenFu;

namespace Codestellar.DotnetAzure.Api.Services
{
    public class PersonService : IPersonService
    {
        private List<Person> Persons { get; set; }

        public PersonService()
        {
            var i = 0;
            Persons = GenFu.GenFu.ListOf<Person>(50);
            Persons.ForEach(person =>
            {
                i++;
                person.Id = i;
            });
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await Task.Run(() => Persons);
        }

        public async Task<Person> Get(int id)
        {
            return await Task.Run(() => Persons.First(_ => _.Id == id));
        }

        public async Task<Person> Add(Person person)
        {
            var newid = Persons.OrderBy(_ => _.Id).Last().Id + 1;
            person.Id = newid;

            Persons.Add(person);

            return await Task.Run(() => person);
        }

        public async Task Update(int id, Person person)
        {
            await Task.Run(() =>
            {
                var existing = Persons.First(_ => _.Id == id);
                existing.FirstName = person.FirstName;
                existing.LastName = person.LastName;
                existing.Address = person.Address;
                existing.Age = person.Age;
                existing.City = person.City;
                existing.Email = person.Email;
                existing.Phone = person.Phone;
                existing.Title = person.Title;
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() =>
            {
                var existing = Persons.First(_ => _.Id == id);
                Persons.Remove(existing);
            });
        }
    }
}
