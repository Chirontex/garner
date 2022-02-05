using Garner.Exceptions;

namespace Garner.Interfaces;

public interface IContainer
{
    public dynamic Get(string id);
}
