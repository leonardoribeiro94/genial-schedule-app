using GenialSchedule.Domain.Entities.Base;
using GenialSchedule.Domain.Enums;

namespace GenialSchedule.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Appointment(int userId,
            int providerId,
            int serviceId,
            DateTime apointmentDateTime)
        {
            UserId = userId;
            ProviderId = providerId;
            ServiceTypeId = serviceId;
            ApointmentDateTime = apointmentDateTime;
        }

        public int UserId { get; private set; }
        public User User { get; private set; }
        public int ProviderId { get; private set; }
        public Employee Provider { get; private set; }
        public int ServiceTypeId { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public EAppointmentStatus AppointmentStatus { get; private set; }
        public DateTime ApointmentDateTime { get; private set; }

        public void ActiveAppointment() => AppointmentStatus = EAppointmentStatus.Active;

        public void CancelAppointment() => AppointmentStatus = EAppointmentStatus.Canceled;
    }
}