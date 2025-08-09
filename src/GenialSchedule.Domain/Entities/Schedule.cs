namespace GenialSchedule.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Schedule(Guid tenantId, DayOfWeek dayOfWeek,
        int month,
        TimeSpan startTime,
        TimeSpan endTime,
        Employee employee)
        {
            SetTenant(tenantId);
            DayOfWeek = dayOfWeek;
            Month = month;
            StartTime = startTime;
            EndTime = endTime;
            Employee = employee;
        }

        public DayOfWeek DayOfWeek { get; }
        public int Month { get; }
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }

        public Guid EmployeeId { get; }
        public Employee Employee { get; }

        public bool IsValidFor(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek &&
                   dateTime.Month == Month &&
                   dateTime.TimeOfDay >= StartTime &&
                   dateTime.TimeOfDay < EndTime;
        }
    }
}