using Domain.Entities;
using Domain.Interfaces.Repository;
using DomainValidation.Interfaces.Specification;

namespace Domain.Specifications.Clients
{
    public class OnlyOneEmailAllowedSpecification : ISpecification<Client>
    {
        private readonly IRegistryRepository _repository;

        public OnlyOneEmailAllowedSpecification(IRegistryRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Client client)
        {
            return _repository.GetByEmail(client.Email) == null;
        }
    }
}
