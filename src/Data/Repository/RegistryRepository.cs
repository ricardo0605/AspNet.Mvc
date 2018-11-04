using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class RegistryRepository : Repository<Client>, IRegistryRepository
    {
        public IEnumerable<Client> GetActives()
        {
            return Find(c => c.Active);
        }

        public Client GetByCPF(string cpf)
        {
            return Find(c => c.CPF == cpf).FirstOrDefault();
        }

        public Client GetByEmail(string email)
        {
            return Find(c => c.Email == email).FirstOrDefault();
        }

        /// <summary>
        /// Logical exclusion
        /// </summary>
        /// <param name="id">Client id</param>
        public override void Remove(Guid id)
        {
            var client = GetById(id);

            client.Active = false;

            Update(client);
        }
    }
}
