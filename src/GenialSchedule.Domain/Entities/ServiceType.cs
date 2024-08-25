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

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public static bool IsPriceValid(decimal price) => price >= 1.00m;
    }
}