using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraForbiddenException : Avara4xxException
{
    public AvaraForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
