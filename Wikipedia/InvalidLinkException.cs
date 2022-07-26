namespace Wikipedia
{
    public class InvalidLinkException : Exception
    {
        public InvalidLinkException(string message) : base(message)
        {
        }
    }
}
