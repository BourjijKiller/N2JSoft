namespace DomainServices.Exceptions
{
    public class BusinessException : Exception
    {
        public int ErrorCode => 422;

        public List<string> Errors { get; }

        public BusinessException(IEnumerable<string> errors)
            : base("One or more errors have occurred.")
        {
            Errors = [.. errors];
        }

        public BusinessException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
            Errors = new List<string> { message };
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nError details :\n- {string.Join("\n- ", Errors)}";
        }
    }
}
