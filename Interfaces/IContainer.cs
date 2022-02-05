namespace Garner.Interfaces;

public interface IContainer
{
    public static IContainer? Instance { get; }

    public dynamic Get(string id);
}
