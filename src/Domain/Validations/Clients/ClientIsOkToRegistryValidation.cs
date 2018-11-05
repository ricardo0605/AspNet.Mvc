using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Specifications.Clients;
using DomainValidation.Validation;

namespace Domain.Validations.Clients
{
    public class ClientIsOkToRegistryValidation : Validator<Client>
    {
        public ClientIsOkToRegistryValidation(IRegistryRepository repository)
        {
            var cpfExists = new OnlyOneCpfAllowedSpecification(repository);
            var emailExists = new OnlyOneEmailAllowedSpecification(repository);

            base.Add("cpfExists", new Rule<Client>(cpfExists, "This CPF is registred. Do you forgot your password?"));
            base.Add("emailExists", new Rule<Client>(emailExists, "This E-mail is registred. Do you forgot your password?"));
        }
    }
}
