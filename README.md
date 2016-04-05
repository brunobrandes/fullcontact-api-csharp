# FullContact Api C`#`

A C# wrapper for the <a href="https://www.fullcontact.com/" rel="Fullcontact Api">Full Contact API </a>

## Getting Started

Install FullContact.Api.Csharp <a href="https://www.nuget.org/packages/FullContact.Api.Csharp/" rel="nuget">nuget</a>.</br>
Run the following command in the Package Manager Console.

Solution (.sln) is based in <a href="http://jeffreypalermo.com/blog/the-onion-architecture-part-1/" rel="Onion Architecture">The Onion Architecture </a>

### Example 

```c#

var container = new Container();
 
#region Dependency Injection (DI) using Simple Injector

container.RegisterSingleton<IServiceProvider>(container);
ontainer.Register<IFullContactAppServiceFactory, FullContactAppServiceFactory>();
container.Register<IHttpClientFactory, HttpClientFactory>();

#endregion

///Get container full contact app service factory  
var fullContactAppServiceFactory = container.GetInstance<IFullContactAppServiceFactory>();

///Create full contact app service  
var fullContactAppService = fullContactAppServiceFactory.Create<Person>("https://api.fullcontact.com/v2", 
	"xxxx", Serializer.Json);

/// Call full contact api by http get method 
var person = await fullContactAppService.GetAsync(Lookup.Email, "bart@fullcontact.com");

///Person contains all properties. Sample:
var fullName = person.ContactInfo.FullName;

```
Using lookup enum to get other's query to call the Person API

```c#
public enum Lookup
{
   Phone = 0,
   Email = 1,
   Twitter = 2,
   Domain = 3
}
```


### Contributions

This release only implements the person api.
For other, simply create the DataTranferObject and change GetApi method in FullContactAppService.

```c#

private Api GetApi(Type type)
{
    switch (type.Name)
    {
        case "Person":
            return Api.Person;
			
	/// Insert new cases

        default:
            throw new NotImplementedException($"Api type {type.Name} not implemented.");
    }
}

```

