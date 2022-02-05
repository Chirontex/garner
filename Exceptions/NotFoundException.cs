using System;

namespace Garner.Exceptions;

public class NotFoundException : SystemException
{
    public NotFoundException() : base()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}
