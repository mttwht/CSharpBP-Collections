namespace Acme.Common
{
    /// <summary>
    /// Provides a success flag and message 
    /// useful as a method return type.
    /// </summary>
    public class OperationResult
    {
        public OperationResult()
        {
        }

        public OperationResult(bool success, string message) : this()
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Provides a decimal amount and message 
    /// useful as a method return type. 
    /// </summary>
    public class OperationResultDecimal
    {
        public OperationResultDecimal()
        {
        }

        public OperationResultDecimal(decimal result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }

        public decimal Result { get; set; }
        public string Message { get; set; }
    }

}
