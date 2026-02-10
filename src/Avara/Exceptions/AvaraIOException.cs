using System;
using System.Net.Http;

namespace Avara.Exceptions;

public class AvaraIOException : AvaraException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public AvaraIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
