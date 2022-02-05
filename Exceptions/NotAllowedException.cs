using System;

namespace Garner.Exceptions;

public class NotAllowedException : SystemException
{
    public NotAllowedException() : base()
    {
    }

    public NotAllowedException(string message) : base(message)
    {
    }
}
