using Garner.Exceptions;
using Garner.Interfaces;
using System.Collections.Generic;

namespace Garner;

public class Container : IContainer
{
    protected Dictionary<string, dynamic> _servicesDictionary;

    protected Container(Dictionary<string, dynamic> servicesDictionary)
    {
        this._servicesDictionary = servicesDictionary;
    }

    public dynamic Get(string id)
    {
        foreach (var item in this._servicesDictionary)
        {
            if (item.Key == id)
            {
                return item.Value;
            }
        }

        throw new NotFoundException($"Service {id} not found.");
    }
}
