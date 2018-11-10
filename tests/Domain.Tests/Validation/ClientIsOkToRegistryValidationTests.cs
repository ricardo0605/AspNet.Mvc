using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Validations.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Linq;

namespace Domain.Tests.Validation
{
    [TestClass]
    public class ClientIsOkToRegistryValidationTests
    {
        [TestMethod]
        public void ClientIsOkToRegitry_IsValid_True()
        {
            // Arrange
            var client = new Client()
            {
                CPF = "93436755427",
                Email = "93436755427@client.com"
            };

            // Act
            var repository = MockRepository.GenerateStub<IRegistryRepository>();
            repository.Stub(s => s.GetByCPF(client.CPF)).Return(null);
            repository.Stub(s => s.GetByEmail(client.Email)).Return(null);

            var validationReturn = new ClientIsOkToRegistryValidation(repository).Validate(client);

            // Assert
            Assert.IsTrue(validationReturn.IsValid);

        }
        [TestMethod]
        public void ClientIsOkToRegitry_IsValid_False()
        {
            // Arrange
            var client = new Client()
            {
                CPF = "12345678901",
                Email = "12345678901client.com"
            };

            // Act
            var repository = MockRepository.GenerateStub<IRegistryRepository>();
            repository.Stub(s => s.GetByCPF(client.CPF)).Return(client);
            repository.Stub(s => s.GetByEmail(client.Email)).Return(client);

            var validationReturn = new ClientIsOkToRegistryValidation(repository).Validate(client);

            // Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "This CPF is registred. Do you forgot your password?"));
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "This E-mail is registred. Do you forgot your password?"));
        }
    }
}
