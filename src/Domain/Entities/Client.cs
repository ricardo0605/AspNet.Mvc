using Domain.Validations.Clients;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client
    {
        public Client()
        {
            ClientId = Guid.NewGuid();
            RegistryDate = DateTime.Now;
            Active = true;

            Addresses = new List<Address>();
        }

        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistryDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClientIsValidValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
