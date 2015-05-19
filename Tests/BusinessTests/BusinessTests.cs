using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Methods;
using Business.Models;
using DataAccess.PersonDb;
using Moq;
using SharpRepository.Repository;
using Tests.Utilities;
using Xunit;

namespace Tests.BusinessTests
{
    public class BusinessTests
    {
        private Mock<IRepository<Person>> mock;
        
        public BusinessTests()
        {
            mock = new Mock<IRepository<Person>>();
            mock.Setup(x => x.GetAll()).Returns(new List<Person>());
            mock.Setup(x => x.Find(It.IsAny<Expression<Func<Person, bool>>>(), null)).Returns(new Person());
            mock.Setup(x => x.Add(It.IsAny<Person>()));
            mock.Setup(x => x.Update(It.IsAny<Person>()));
            mock.Setup(x => x.Delete(It.IsAny<Expression<Func<Person, bool>>>()));
        }

        [Fact]
        public void CanGetAll()
        {
            // Arrange
            //-----------
            var module = new PersonLogic(mock.Object);

            // Act
            //-----------
            var result = module.GetAll();

            // Assert
            //-----------
            result.ShouldNotBeNull();
            result.ShouldBeInstanceOf<List<PersonModel>>();
        }

        [Fact]
        public void CanGetById()
        {
            // Arrange
            //-----------
            var module   = new PersonLogic(mock.Object);
            var testGuid = new Guid();

            // Act
            //-----------
            var result = module.GetById(testGuid);

            // Assert
            //-----------
            result.ShouldNotBeNull();
            result.ShouldBeInstanceOf<PersonModel>();            
        }

        [Fact]
        public void CanCreatePerson()
        {
            // Arrange
            //-----------
            var module = new PersonLogic(mock.Object);
            
            // Act
            //-----------
            var result = module.Create(new PersonModel());

            // Assert
            //-----------
            result.ShouldNotBeNull();
            result.ShouldBeInstanceOf<PersonModel>();        
        }

        [Fact]
        public void CanUpdatePerson()
        {
            // Arrange
            //-----------
            var module = new PersonLogic(mock.Object);

            // Act
            //-----------
            var result = module.Update(new PersonModel());

            // Assert
            //-----------
            result.ShouldNotBeNull();
            result.ShouldBeInstanceOf<PersonModel>();        
        }

        [Fact]
        public void CanDeletePerson()
        {
            // Arrange
            //-----------
            var module = new PersonLogic(mock.Object);

            // Act
            //-----------
            module.Delete(new PersonModel());

            // Assert
            //-----------
            // No errors should be thrown...
        }
    }
}