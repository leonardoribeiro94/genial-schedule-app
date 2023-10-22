using System.Text.RegularExpressions;

namespace GenialSchedule.Domain.Entities.ValueObjects
{
    public sealed class PhoneNumber
    {
        public PhoneNumber(string phone)
        {
            Phone = phone;
        }

        public string Phone { get; private set; }

        public bool Validate()
        {
            // Padrão regex para validar números de celular genéricos.
            var pattern = @"^\d{2}\d{9}$";
            return Regex.IsMatch(Phone, pattern);
        }
    }
}