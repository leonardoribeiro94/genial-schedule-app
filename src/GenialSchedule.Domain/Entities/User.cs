using GenialSchedule.Domain.Entities;
using GenialSchedule.Domain.Entities.ValueObjects;

public class User : Person
{
    public DateTime BirthDate { get; }
    public string Password { get; }

    private readonly List<Appointment> _appointments = new List<Appointment>();
    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();

    public User(string name,
        DateTime birthDate,
        string email,
        string password)
    {
        Name = new Name(name);
        BirthDate = birthDate;
        Email = new Email(email);
        Password = password;
    }

    public void AddAppointment(Appointment appointment)
    {
        if (_appointments.Any(a => a.ConflictsWith(appointment)))
            throw new InvalidOperationException("This appointment conflicts with an existing one.");

        _appointments.Add(appointment);
    }
}