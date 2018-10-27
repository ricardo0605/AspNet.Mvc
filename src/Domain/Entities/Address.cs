using System;

namespace Domain.Entities
{
    public class Address
    {
        public Address()
        {
            AddressId = Guid.NewGuid();
        }

        public Guid AddressId { get; set; }
        public Guid ClientId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Client Client { get; set; }
        //public virtual Client Client { get; set; }
    }
}
