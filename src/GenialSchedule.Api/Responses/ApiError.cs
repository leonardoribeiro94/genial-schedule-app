namespace GenialSchedule.Api.Responses
{
    public class ApiError
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public ApiError(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}