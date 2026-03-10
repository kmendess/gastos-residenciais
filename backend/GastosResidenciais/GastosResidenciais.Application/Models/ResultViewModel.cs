namespace GastosResidenciais.Application.Models
{
    public class ResultViewModel
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        //public int StatusCode { get; set; }

        public static ResultViewModel Success() => new();
        public static ResultViewModel Error(string message) => new() { IsSuccess = false, Message = message };
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T data) => new() { Data = data };
        public static new ResultViewModel<T> Error(string message) => new() { IsSuccess = false, Message = message };
    }
}
