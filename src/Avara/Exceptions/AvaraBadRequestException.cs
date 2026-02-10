using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraBadRequestException : Avara4xxException
{
    public AvaraBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
