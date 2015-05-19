using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IPersonLogic
    {
        IEnumerable<IPersonModel> GetAll();
        IPersonModel GetById(Guid personId);
        IEnumerable<IPersonModel> Find(Expression<Func<IPersonModel, bool>> predicate);
        IPersonModel Create(IPersonModel person);
        IPersonModel Update(IPersonModel person);
        void Delete(IPersonModel person);
    }
}