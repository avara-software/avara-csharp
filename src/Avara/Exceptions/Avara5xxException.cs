using System.Net.Http;

namespace Avara.Exceptions;

public class Avara5xxException : AvaraApiException
{
    public Avara5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
