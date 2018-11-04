namespace Domain.ValueObjects
{
    public class CPF
    {
        public string Number { get; set; }

        public bool IsValid()
        {
            int[] multiplier_01 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier_02 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string temporaryCpfNumber;
            string digit;
            int sum;
            int rest;
            Number = Number.Trim();
            Number = Number.Replace(".", "").Replace("-", "");
            if (Number.Length != 11)
                return false;
            temporaryCpfNumber = Number.Substring(0, 9);
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
            return Number.EndsWith(digit);
        }
    }
}
