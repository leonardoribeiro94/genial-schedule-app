using System.Net.Mail;

namespace GenialSchedule.Domain.Entities.ValueObjects
{
    public sealed class Email
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;
        }

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