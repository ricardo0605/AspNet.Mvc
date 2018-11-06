using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Validations.Clients;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public class RegistryService : IRegistryService
    {
        private readonly IRegistryRepository _repository;

        public RegistryService(IRegistryRepository repository)
        {
            _repository = repository;
        }

        public Client Add(Client client)
        {
            if (!client.IsValid())
                return client;

            client.ValidationResult = new ClientIsOkToRegistryValidation(_repository).Validate(client);

            if (!client.ValidationResult.IsValid)
                return client;

            return _repository.Add(client);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        public Client GetByCPF(string cpf)
        {
            return _repository.GetByCPF(cpf);
        }

        public Client GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public Client GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public Client Update(Client client)
        {
            if (!client.IsValid())
                return client;

            // TODO: Implement validation that also checks the Id. In that case, as we're editing this registry
            // it won't check itself.
            // client.ValidationResult = new ClientIsOkToRegistryValidation(_repository).Validate(client);

            if (!client.ValidationResult.IsValid)
                return client;

            return _repository.Update(client);
        }
    }
}
