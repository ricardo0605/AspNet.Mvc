using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Tests.Entity
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void Client_SelfValidation_IsValid()
        {
            // Arrange
            var client = new Client()
            {
                CPF = "93436755427",
                Email = "93436755427@client.com",
                DateOfBirth = new DateTime(1980, 01, 01)
            };


            // Act
            var result = client.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Client_SelfValidation_IsNotValid()
        {
            // Arrange
            var client = new Client()
            {
                CPF = "12345678901",
                Email = "93436755427client.com",
                DateOfBirth = new DateTime(2018, 01, 01)
            };


            // Act
            var result = client.IsValid();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(client.ValidationResult.Erros.Any(e => e.Message == "Please provide a valid CPF"));
            Assert.IsTrue(client.ValidationResult.Erros.Any(e => e.Message == "Please provide a valid e-mail"));
            Assert.IsTrue(client.ValidationResult.Erros.Any(e => e.Message == "Sorry, you don't have age enough to registry"));
        }
    }
}
