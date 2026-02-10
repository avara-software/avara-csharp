using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraUnexpectedStatusCodeException : AvaraApiException
{
    public AvaraUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
