using GenialSchedule.Domain.Entities;
using GenialSchedule.Domain.Entities.ValueObjects;

public class User : Person
{
    public string Password { get; }

    private readonly List<Appointment> _appointments = new List<Appointment>();
    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();

    public User(Guid tenantId,
        string name,
        DateOnly birthDate,
        string email,
        string password)
    {
        Name = new Name(name);
        Birthday = birthDate;
        Email = new Email(email);
        Password = password;
        SetTenant(tenantId);
    }

    public void AddAppointment(Appointment appointment)
    {
        if (_appointments.Any(a => a.ConflictsWith(appointment)))
            throw new InvalidOperationException("This appointment conflicts with an existing one.");

        _appointments.Add(appointment);
    }
}