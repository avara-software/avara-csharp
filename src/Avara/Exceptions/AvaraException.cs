using System;
using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraException : Exception
{
    public AvaraException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected AvaraException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
