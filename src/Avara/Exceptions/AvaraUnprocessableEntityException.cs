using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraUnprocessableEntityException : Avara4xxException
{
    public AvaraUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
