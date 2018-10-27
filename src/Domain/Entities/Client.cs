using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client
    {
        public Client()
        {
            ClientId = Guid.NewGuid();
            Addresses = new List<Address>();
        }

        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime BirthOfDate { get; set; }
        public DateTime RegistryDate { get; set; }
        public bool Active { get; set; }

        public ICollection<Address> Addresses { get; set; }
        //public virtual ICollection<Address> Addresses { get; set; }
    }
}
