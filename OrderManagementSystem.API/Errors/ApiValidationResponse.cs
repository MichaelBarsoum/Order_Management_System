namespace OrderManagementSystem.API.Errors
{
    public class ApiValidationResponse : ApiErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationResponse():base(400)
        {
            Errors = new List<string>();    
        }
    }
}
