using System.Collections.Generic;
using System.Threading.Tasks;
using Codestellar.DotnetAzure.Api.Models;

namespace Codestellar.DotnetAzure.Api.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> Get(int id);

        Task<Person> Add(Person person);

        Task Update(int id, Person person);
        Task Delete(int id);
    }
}
