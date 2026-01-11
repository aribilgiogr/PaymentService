namespace Application.DTOs.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public ErrorResponse? Error { get; set; }

        public static ApiResponse<T> SuccessResponse(T? data, string? message = null) => new() { Success = true, Data = data, Message = message };

        public static ApiResponse<T> ErrorResponse(int errorCode, string message, Dictionary<string, string>? validationErrors = null)
        {
            return new()
            {
                Success = false,
                Error = new ErrorResponse
                {
                    ErrorCode = errorCode,
                    Message = message,
                    ValidationErrors = validationErrors
                }
            };
        }
    }
}
