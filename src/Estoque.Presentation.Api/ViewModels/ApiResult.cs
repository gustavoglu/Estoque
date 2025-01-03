namespace Estoque.Presentation.Api.ViewModels
{
    public class ApiResult
    {
        public static ApiResult SuccessResult(object? data = null) => new ApiResult(true, data, null);
        public static ApiResult ErrorResult(object? data = null, params string[] errors) => new ApiResult(false, data, errors.ToList());
        public ApiResult(bool success, object? data = null, List<string>? errors = null)
        {
            Success = success;
            Errors = errors ?? new List<string>();
            Data = data;
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public object? Data { get; set; }
    }
}
