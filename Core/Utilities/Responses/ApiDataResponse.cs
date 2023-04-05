namespace Core.Utilities.Responses
{
    public class ApiDataResponse<T> : ApiResponse
    {
        public ApiDataResponse()
        {

        }

        public ApiDataResponse(bool success) : base(success)
        {
            Success = success;
        }

        public ApiDataResponse(bool success, string message) : base(success)
        {
        }

        public T Data { get; set; }
    }
}

