using Domain.Entities;
using Domain.Specifications.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests.Specification
{
    [TestClass]
    public class ValidCpfSpecificationTests
    {
        [TestMethod]
        public void CpfSpecification_IsSatisfied_True()
        {
            // Arrange
            var client = new Client
            {
                CPF = "93436755427"
            };

            // Act
            var specificationResult = new ClientMustHaveValidCpfSpecification().IsSatisfiedBy(client);

            // Assert
            Assert.IsTrue(specificationResult);
        }

        [TestMethod]
        public void CpfSpecification_IsSatisfied_False()
        {
            // Arrange
            var client = new Client
            {
                CPF = "12345678901"
            };

            // Act
            var specificationResult = new ClientMustHaveValidCpfSpecification().IsSatisfiedBy(client);

            // Assert
            Assert.IsFalse(specificationResult);
        }
    }
}
