using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    public interface IRegistryRepository : IRepository<Client>
    {
        Client GetByCPF(string cpf);
        Client GetByEmail(string email);
        IEnumerable<Client> GetActives();
    }
}
