using Domain.Entities;
using Domain.Specifications.Clients;
using DomainValidation.Validation;

namespace Domain.Validations.Clients
{
    public class ClientIsValidValidation : Validator<Client>
    {
        public ClientIsValidValidation()
        {
            var clientCpf = new ClientMustHaveValidCpfSpecification();
            var clientEmail = new ClientMustHaveValidEmailSpecification();
            var clientAge = new ClientMustBeOver18YearSpecification();

            base.Add("clientCpf", new Rule<Client>(clientCpf, "Please provide a valid CPF"));
            base.Add("clientEmail", new Rule<Client>(clientEmail, "Please provide a valid e-mail"));
            base.Add("clientAge", new Rule<Client>(clientAge, "Sorry, you don't have age enough to registry"));
        }
    }
}
