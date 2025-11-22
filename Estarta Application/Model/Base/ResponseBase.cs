namespace Estarta_Application.Model.Base
{
    public record class ResponseBase<T> : ResponseBase
    {
        public T? Data { get; set; }
        public static ResponseBase<T> Success(T data)
        {
            return new ResponseBase<T>()
            {
                Data = data,
                IsSuccess = true,
                StatusCode = 200,
                Message = "Success"
            };
        }
    }
    public record class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public static ResponseBase Success()
        {
            return new ResponseBase()
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Success"
            };
        }
    }
}
