namespace GenialSchedule.Api.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<ApiError>? Errors { get; set; }

        public ApiResponse(T data)
        {
            Success = true;
            Data = data;
            Errors = null;
        }

        public ApiResponse(List<ApiError> errors)
        {
            Success = false;
            Data = default;
            Errors = errors;
        }
    }
}