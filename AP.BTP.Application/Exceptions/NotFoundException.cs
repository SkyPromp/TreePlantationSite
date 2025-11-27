namespace AP.BTP.Application.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when a requested entity cannot be found in the system.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message describing the reason why the entity was not found.</param>
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
