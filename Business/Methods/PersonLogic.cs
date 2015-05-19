using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Interfaces;
using Business.Models;
using DataAccess.PersonDb;
using SharpRepository.Repository;

namespace Business.Methods
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IRepository<Person> _person;
        
        public PersonLogic(IRepository<Person> person)
        {
            _person = person;

            Mapper.CreateMap<Person, PersonModel>();
            Mapper.CreateMap<IPersonModel, Person>();
            Mapper.Engine.CreateMapExpression<IPersonModel, Person>();            
        }

        public IEnumerable<IPersonModel> GetAll()
        {
            using (_person)
            {
                var result = _person.GetAll();

                return Mapper.Map<IEnumerable<PersonModel>>(result);
            }
        }

        public IPersonModel GetById(Guid personId)
        {
            using (_person)
            {
                var result = _person.Find(x => x.PersonId == personId);

                return Mapper.Map<PersonModel>(result);
            }
        }

        public IEnumerable<IPersonModel> Find(Expression<Func<IPersonModel, bool>> predicate)
        {
            using (_person)
            {
                var selector = Mapper.Map<Expression<Func<Person, bool>>>(predicate);

                var result = _person.Find(selector);

                return Mapper.Map<IEnumerable<PersonModel>>(result);
            }
        }

        public IPersonModel Create(IPersonModel person)
        {
            using (_person)
            {
                var map = Mapper.Map<Person>(person);

                _person.Add(map);

                return person;
            }
        }

        public IPersonModel Update(IPersonModel person)
        {
            var map = Mapper.Map<Person>(person);

            _person.Update(map);

            return person;
        }

        public void Delete(IPersonModel person)
        {
            _person.Delete(x => x.PersonId == person.PersonId);
        }
    }
}
