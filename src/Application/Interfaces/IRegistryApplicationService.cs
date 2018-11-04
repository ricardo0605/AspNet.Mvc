using Application.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRegistryApplicationService : IDisposable
    {
        ClientDto Add(ClientDto client);
        ClientDto GetById(Guid id);
        IEnumerable<ClientDto> GetAll();
        IEnumerable<ClientDto> GetAllActives();
        ClientDto GetByCPF(string cpf);
        ClientDto GetByEmail(string email);
        ClientDto Update(ClientDto client);
        void Remove(Guid id);
    }
}
