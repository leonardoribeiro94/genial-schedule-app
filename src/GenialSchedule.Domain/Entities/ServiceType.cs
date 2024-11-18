namespace GenialSchedule.Domain.Entities

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

        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        public static bool IsPriceValid(decimal price) => price >= 1.00m;
    }
}