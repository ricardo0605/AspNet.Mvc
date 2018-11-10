using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Validations.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Linq;

namespace Domain.Tests.Validation
{
    [TestClass]
    public class ClientIsValidValidationTests
    {
        [TestMethod]
        public void ClientIsValid_IsValid_True()
        {
            // Arrange
            var client = new Client()
            {
                CPF = "93436755427",
                Email = "93436755427@client.com",
                DateOfBirth = new DateTime(1980, 01, 01)
            };

            // Act
            var repository = MockRepository.GenerateStub<IRegistryRepository>();
            repository.Stub(s => s.Add(client)).Return(client);

            var validationReturn = new ClientIsValidValidation().Validate(client);

            // Assert
            Assert.IsTrue(validationReturn.IsValid);
        }

        [TestMethod]
        public void ClientIsValid_IsValid_False()
        {
            // Arrange
            var client = new Client()
            {
                CPF = "12345678901",
                Email = "12345678901client.com",
                DateOfBirth = new DateTime(2018, 01, 01)
            };

            // Act
            var repository = MockRepository.GenerateStub<IRegistryRepository>();
            repository.Stub(s => s.Add(client)).Return(client);

            var validationReturn = new ClientIsValidValidation().Validate(client);

            // Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "Please provide a valid CPF"));
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "Please provide a valid e-mail"));
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "Sorry, you don't have age enough to registry"));
        }
    }
}
