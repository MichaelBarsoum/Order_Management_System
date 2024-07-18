
namespace OrderManagementSystem.API.Errors
{
    public class ApiErrorResponse
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        //public ApiErrorResponse(){}
        public ApiErrorResponse(int? statusCode , string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDafaultErrorResponse(StatusCode);
        }
        private string? GetDafaultErrorResponse(int? statusCode)
        {
            return statusCode switch
            {
                400 => " BadRequest ",
                401 => " You're Not Authorized ",
                404 => " Not found Resource ",
                500 => " internal Server Error "
            };
        }
    }
}
