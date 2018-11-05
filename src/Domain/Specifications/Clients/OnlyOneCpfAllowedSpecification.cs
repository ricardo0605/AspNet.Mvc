using Domain.Entities;
using Domain.Interfaces.Repository;
using DomainValidation.Interfaces.Specification;

namespace Domain.Specifications.Clients
{
    public class OnlyOneCpfAllowedSpecification : ISpecification<Client>
    {
        private readonly IRegistryRepository _repository;

        public OnlyOneCpfAllowedSpecification(IRegistryRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Client client)
        {
            return _repository.GetByCPF(client.CPF) == null;
        }
    }
}
