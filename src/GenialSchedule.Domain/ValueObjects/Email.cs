using System.Net.Mail;

namespace GenialSchedule.Domain.Entities.ValueObjects
{
    public sealed class Email(string address)
    {
        public string Address { get; } = address;

        public bool Validate()
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(Address);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}