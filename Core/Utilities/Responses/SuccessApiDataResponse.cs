namespace Core.Utilities.Responses
{
    public class SuccessApiDataResponse<T> : ApiDataResponse<T>
    {
        public SuccessApiDataResponse(T data) : base(success:true)
        {
            Data = data;
        }
        public SuccessApiDataResponse(T data,String message) : base(success: true, message: message)
        {
            Data = Data;
        }
    }
}
