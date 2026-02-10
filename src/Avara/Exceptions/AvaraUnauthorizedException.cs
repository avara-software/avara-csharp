using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraUnauthorizedException : Avara4xxException
{
    public AvaraUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
