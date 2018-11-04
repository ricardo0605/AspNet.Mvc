using Domain.Entities;
using DomainValidation.Interfaces.Specification;
using System;

namespace Domain.Specifications.Clients
{
    public class ClientMustBeOver18YearSpecification : ISpecification<Client>
    {
        public bool IsSatisfiedBy(Client entity)
        {
            var dateToAchieve = entity.DateOfBirth.AddYears(18);

            return DateTime.Now > dateToAchieve;
        }
    }
}
