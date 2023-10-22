namespace GenialSchedule.Domain.Entities.ValueObjects
{
    public sealed class PersonDocument
    {
        public PersonDocument(string documentNumber)
        {
            Number = documentNumber;
        }

        public string Number { get; private set; }

        public bool Validate()
        {
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Number = Number.Trim();
            Number = Number.Replace(".", "").Replace("-", "");

            if (Number.Length != 11)
                return false;

            var tempCpf = Number[..9];
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto;

            return Number.EndsWith(digito);
        }
    }
}