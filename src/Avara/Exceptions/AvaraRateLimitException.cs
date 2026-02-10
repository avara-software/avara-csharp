using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraRateLimitException : Avara4xxException
{
    public AvaraRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
