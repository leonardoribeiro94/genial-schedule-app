namespace GenialSchedule.Domain.Entities
{
    public class Schedule(DayOfWeek dayOfWeek,
        int month,
        TimeSpan startTime,
        TimeSpan endTime,
        Employee employee) : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; } = dayOfWeek;
        public int Month { get; } = month;
        public TimeSpan StartTime { get; } = startTime;
        public TimeSpan EndTime { get; } = endTime;

        public int EmployeeId { get; }
        public Employee Employee { get; } = employee;

        public bool IsValidFor(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek &&
                   dateTime.Month == Month &&
                   dateTime.TimeOfDay >= StartTime &&
                   dateTime.TimeOfDay < EndTime;
        }
    }
}