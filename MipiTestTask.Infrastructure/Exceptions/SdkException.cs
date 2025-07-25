namespace MipiTestTask.Infrastructure.Exceptions;

public class SdkException : Exception
{
    public SdkException(Exception exception) : base(exception.Message, exception) { }
}
