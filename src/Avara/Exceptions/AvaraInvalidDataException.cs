using System;

namespace Avara.Exceptions;

public class AvaraInvalidDataException : AvaraException
{
    public AvaraInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
