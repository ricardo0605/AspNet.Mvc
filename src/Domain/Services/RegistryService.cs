using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
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

            // If CPF or Email registred

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
            return _repository.Update(client);
        }
    }
}
