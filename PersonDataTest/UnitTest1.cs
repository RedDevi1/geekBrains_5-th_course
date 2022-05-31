using Moq;
using Xunit;
using SOLIDWebApplication.DAL.Repositories;
using SOLIDWebApplication.DAL.Interfaces;
using SOLIDWebApplication.DAL.Services;
using SOLIDWebApplication.Models;
using System.Collections.Generic;
using AutoMapper;

namespace PersonDataTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Mock<PersonsRepository> personsRepositoryMock = new Mock<PersonsRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            personsRepositoryMock.Setup(p => p.GetAll()).Returns(new List<Person>()
            {
                new Person(personsRepositoryMock.Object) { Id = 1, IsDeleted = false, FirstName = "Nikita", LastName = "Dernov", Age = 34 },
                new Person(personsRepositoryMock.Object) { Id = 2, IsDeleted = false, FirstName = "Roman", LastName = "Dernov", Age = 1 },
            });
            IPersonsService personsService = new PersonsService(personsRepositoryMock.Object, mapperMock.Object);
            IReadOnlyList<PersonDTO> data_one = personsService.GetAll();
            IReadOnlyList<PersonDTO> data_two = personsService.GetAll();
            Assert.NotEmpty(data_one);
            Assert.Equal(2, data_one.Count);
            Assert.Equal(data_one, data_two);
        }
    }
}