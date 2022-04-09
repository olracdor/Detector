namespace Common.Models
{
    public class BadRequestResponse
    {
        public BadRequestResponse(string code, string message)
        {
            ErrorCode = code;
            ErrorMessage = message;
        }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
