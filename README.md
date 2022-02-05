# Garner v1.0.0
__Garner__ is a simple DI container implementation for .NET.

![](https://img.shields.io/badge/.NET-6%2B-blue) ![](https://img.shields.io/badge/C%23-10%2B-yellow)

## How to use

##### Create your services:

```csharp
using System;

namespace SampleApp;

public class ConsoleSayingService
{
	public void Say(string phrase)
	{
		Console.WriteLine(phrase);
	}
}

public class Tom
{
	protected ConsoleSayingService _consoleSayingService;
	
	public Tom(ConsoleSayingService consoleSayingService)
	{
		this._consoleSayingService = consoleSayingService;
	}

	public void SayName()
	{
		this._consoleSayingService.Say("My name is Tom.");
	}
}

```

##### Implement __Garner.Interfaces.IServicesDictionaryFactory__:

```csharp
using Garner.Interfaces;
using SampleApp;
using System.Collections.Generic;

namespace SampleApp.Factory;

public class ServicesDictionaryFactory : IServicesDictionaryFactory
{
	public Dictionary<string, dynamic> createServicesDictionary()
	{
		var dictionary = new Dictionary<string, dynamic>()
			{
				["console_saying_service"] = new ConsoleSayingService(),
			};
		
		dictionary.Add("Tom", new Tom(dictionary["console_saying_service"]));
		
		return dictionary;
	}
}

```

##### Create container and use it:

```csharp
use Garner;
use SampleApp.Factory;

namespace SampleApp;

class Program
{
	public static void Main(string[] args)
	{
		Container.ServicesDictionaryFactory = new ServicesDictionaryFactory();
		Container container = Container.GetInstance();
		
		Tom tom = container.Get("Tom");
		tom.SayName(); // output "My name is Tom." in the console
	}
}
```
