namespace GenialSchedule.Domain.Entities.ValueObjects
{
    public sealed class ServiceType : BaseEntity
    {
        public ServiceType(string name,
            string description,
            decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public static bool IsPriceValid(decimal price)
        {
            return price >= 1.00m;
        }
    }
}