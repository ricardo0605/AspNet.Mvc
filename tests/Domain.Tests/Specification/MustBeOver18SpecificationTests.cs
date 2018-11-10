using Domain.Entities;
using Domain.Specifications.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Tests.Specification
{
    [TestClass]
    public class MustBeOver18SpecificationTests
    {
        public void MustBeOver18Year_IsSatisfied_True()
        {
            // Arrange
            var client = new Client()
            {
                DateOfBirth = new DateTime(1980, 01, 01)
            };

            // Act
            var specificationResult = new ClientMustBeOver18YearSpecification().IsSatisfiedBy(client);

            // Assert
            Assert.IsTrue(specificationResult);
        }

        public void MustBeOver18Year_IsSatisfied_False()
        {
            // Arrange
            var client = new Client()
            {
                DateOfBirth = new DateTime(2018, 01, 01)
            };

            // Act
            var specificationResult = new ClientMustBeOver18YearSpecification().IsSatisfiedBy(client);

            // Assert
            Assert.IsFalse(specificationResult);
        }
    }
}
