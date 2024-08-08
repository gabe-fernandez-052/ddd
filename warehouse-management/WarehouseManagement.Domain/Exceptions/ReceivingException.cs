namespace WarehouseManagement.Domain.Exceptions
{
    public class ReceivingException : Exception
    {
        public ReceivingException()
        {
        }

        public ReceivingException(string message) : base(message)
        {
        }

        public ReceivingException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
