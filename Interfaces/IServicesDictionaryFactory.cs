using System.Collections.Generic;

namespace Garner.Interfaces;

public interface IServicesDictionaryFactory
{
    public Dictionary<string, dynamic> createServicesDictionary();
}
