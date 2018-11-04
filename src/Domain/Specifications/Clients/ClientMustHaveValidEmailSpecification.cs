using Domain.Entities;
using DomainValidation.Interfaces.Specification;
using System.Text.RegularExpressions;

namespace Domain.Specifications.Clients
{
    public class ClientMustHaveValidEmailSpecification : ISpecification<Client>
    {
        public bool IsSatisfiedBy(Client client)
        {
            return Regex.IsMatch(client.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
        }
    }
}
