using System.Net.Http;

namespace Avara.Exceptions;

public class Avara4xxException : AvaraApiException
{
    public Avara4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
