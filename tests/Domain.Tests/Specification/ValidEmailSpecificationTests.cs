using Domain.Entities;
using Domain.Specifications.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests.Specification
{
    [TestClass]
    public class ValidEmailSpecificationTests
    {
        [TestMethod]
        public void ValidEmailSpecification_IsSatisfied_True()
        {
            // Arrange
            var client = new Client()
            {
                Email = "93436755427@client.com"
            };

            // Act
            var specificationResult = new ClientMustHaveValidEmailSpecification().IsSatisfiedBy(client);

            // Assert
            Assert.IsTrue(specificationResult);
        }

        [TestMethod]
        public void ValidEmailSpecification_IsSatisfied_False()
        {
            // Arrange
            var client = new Client()
            {
                Email = "93436755427client.com"
            };

            // Act
            var specificationResult = new ClientMustHaveValidEmailSpecification().IsSatisfiedBy(client);

            // Assert
            Assert.IsFalse(specificationResult);
        }
    }
}
