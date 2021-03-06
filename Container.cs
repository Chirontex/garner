using Garner.Exceptions;
using Garner.Interfaces;
using System.Collections.Generic;

namespace Garner;

public class Container : IContainer
{
    protected static Container? s_instance;

    protected static IServicesDictionaryFactory? s_servicesDictionaryFactory;

    public static IServicesDictionaryFactory? ServicesDictionaryFactory
    {
        get
        {
            return Container.s_servicesDictionaryFactory;
        }

        set
        {
            if (Container.s_servicesDictionaryFactory == null)
            {
                Container.s_servicesDictionaryFactory = value;
            }
            else
            {
                throw new NotAllowedException(
                    "Service dictionary factory redefining is meaningless. Create a new container with a new factory instead."
                );
            }
        }
    }

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

    public static Container GetInstance()
    {
        if (Container.s_instance != null)
        {
            return Container.s_instance;
        }

        if (Container.ServicesDictionaryFactory == null)
        {
            throw new NotFoundException(
                "Services dictionary factory not found."
            );
        }

        return Container.s_instance = new Container(
            Container.ServicesDictionaryFactory.createServicesDictionary()
        );
    }
}
