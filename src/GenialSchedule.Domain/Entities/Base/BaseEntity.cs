namespace GenialSchedule.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}