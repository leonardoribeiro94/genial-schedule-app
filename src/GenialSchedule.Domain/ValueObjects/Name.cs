namespace GenialSchedule.Domain.Entities.ValueObjects
{
    public class Name
    {
        public Name(string name)
        {
            CompleteName = name;
        }

        public string CompleteName { get; private set; }

        public bool Validate() => CompleteName?.Length > 5;
    }
}