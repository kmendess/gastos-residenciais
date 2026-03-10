using GastosResidenciais.Application.Enums;
using System.Text.Json.Serialization;

namespace GastosResidenciais.Application.Models
{
    public class ResultViewModel
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> Messages { get; set; } = new List<string>();
        
        [JsonIgnore]
        public ErrorType ErrorType { get; set; } = ErrorType.None;

        public static ResultViewModel Success() => new();
        public static ResultViewModel Error(ErrorType errorType, params string[] messages)
            => new() 
            {
                IsSuccess = false,
                ErrorType = errorType,
                Messages = messages.ToList()
            };
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T data) => new() { Data = data };
        public static new ResultViewModel<T> Error(ErrorType errorType, params string[] messages)
            => new()
            {
                IsSuccess = false,
                ErrorType = errorType,
                Messages = messages.ToList()
            };
    }
}
