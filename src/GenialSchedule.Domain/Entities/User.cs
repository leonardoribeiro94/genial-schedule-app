using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Entities.Base
{
    public class User : Person
    {
        public User(string name, string emailAddress)
        {
            Name = new Name(name);
            Email = new Email(emailAddress);
            Status = true;
        }

        public bool Status { get; private set; }

        private readonly List<Appointment> _appointments = new List<Appointment>();
        public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();

        public int GetId() => Id;

        public void StatusInactvate() => Status = false;

        public void StatusActivate() => Status = true;

        public void AddAppointment(Appointment appointment)
        {
            if (Appointments.Any(a => a.ConflictsWith(appointment)))
                throw new InvalidOperationException("This appointment conflicts with an existing one.");

            _appointments.Add(appointment);
        }
    }
}