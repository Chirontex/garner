namespace Garner.Interfaces;

public interface IContainer
{
    protected static IContainer _instance;

    public dynamic Get(string id);
}
