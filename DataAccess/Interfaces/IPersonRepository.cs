using DataAccess.PersonDb;
using SharpRepository.Repository;

namespace DataAccess.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}