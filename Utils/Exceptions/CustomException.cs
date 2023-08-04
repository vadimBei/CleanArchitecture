using Utils.Enums;

namespace Utils.Exceptions
{
    public abstract class CustomException : Exception
    {
        public int StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public CustomException(string message, ErrorStatusCode errorStatusCode)
        {
            this.StatusCode = (int)errorStatusCode;
            this.ErrorMessage = message;
        }
    }
}
