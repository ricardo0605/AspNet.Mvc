using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IRegistryService : IDisposable
    {
        Client Add(Client client);
        Client GetById(Guid id);
        IEnumerable<Client> GetAll();
        Client GetByCPF(string cpf);
        Client GetByEmail(string email);
        Client Update(Client client);
        void Remove(Guid id);
    }
}
