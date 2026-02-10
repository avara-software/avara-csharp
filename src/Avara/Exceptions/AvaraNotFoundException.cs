using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraNotFoundException : Avara4xxException
{
    public AvaraNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
