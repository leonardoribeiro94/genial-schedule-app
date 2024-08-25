using GenialSchedule.Domain.Entities.Base;
using GenialSchedule.Domain.Enums;

namespace GenialSchedule.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Appointment(int userId,
            int employeeId,
            int serviceId,
            DateTime apointmentDateTime)
        {
            UserId = userId;
            EmployeeId = employeeId;
            ServiceTypeId = serviceId;
            AppointmentDateTime = apointmentDateTime;
        }

        public int UserId { get; private set; }
        public User User { get; private set; }
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public int ServiceTypeId { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public EAppointmentStatus AppointmentStatus { get; private set; }
        public DateTime AppointmentDateTime { get; private set; }

        public void ActiveAppointment() => AppointmentStatus = EAppointmentStatus.Active;

        public void CancelAppointment() => AppointmentStatus = EAppointmentStatus.Canceled;

        public bool ConflictsWith(Appointment other)
        {
            return AppointmentDateTime == other.AppointmentDateTime && EmployeeId == other.EmployeeId;
        }
    }
}