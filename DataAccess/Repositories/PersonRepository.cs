using DataAccess.Interfaces;
using DataAccess.PersonDb;
using SharpRepository.Repository;

namespace DataAccess.Repositories
{
    public class PersonRepository : ConfigurationBasedRepository<Person, int>, IPersonRepository
    {        
    }
}