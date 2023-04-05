using Core.Utilities.Messages;

namespace Core.Utilities.Responses
{
    public class ErrorApiDataResponse<T> : ApiDataResponse<T>
    {
        public ErrorApiDataResponse(T data) : base(success: false)
        {
            Data = data;
        }
        public ErrorApiDataResponse(T data,String message) : base(success: false,message:message)
        {
            Data = Data;
        }
    }
}
