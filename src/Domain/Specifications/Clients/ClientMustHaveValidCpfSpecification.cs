using Domain.Entities;
using DomainValidation.Interfaces.Specification;

namespace Domain.Specifications.Clients
{
    public class ClientMustHaveValidCpfSpecification : ISpecification<Client>
    {
        public bool IsSatisfiedBy(Client client)
        {
            int[] multiplier_01 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier_02 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string temporaryCpfNumber;
            string digit;
            int sum;
            int rest;
            client.CPF = client.CPF.Trim();
            client.CPF = client.CPF.Replace(".", "").Replace("-", "");
            if (client.CPF.Length != 11)
                return false;
            temporaryCpfNumber = client.CPF.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(temporaryCpfNumber[i].ToString()) * multiplier_01[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            temporaryCpfNumber = temporaryCpfNumber + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(temporaryCpfNumber[i].ToString()) * multiplier_02[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();

            return client.CPF.EndsWith(digit);
        }
    }
}
