using FullContact.Application.Service.Factories;
using FullContact.Domain.DataTransferObject;
using FullContact.Domain.Enum;
using FullContact.Domain.Service.Factories;
using FullContact.Infrastructure.Factories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            try
            {
                #region Dependency Injection (DI) using Simple Injector

                container.RegisterSingleton<IServiceProvider>(container);
                container.Register<IFullContactAppServiceFactory, FullContactAppServiceFactory>();
                container.Register<IHttpClientFactory, HttpClientFactory>();

                #endregion

                ///Get container full contact app service factory  
                var fullContactAppServiceFactory = container.GetInstance<IFullContactAppServiceFactory>();
                
                ///Create full contact app service  
                var fullContactAppService = fullContactAppServiceFactory.Create<Person>("https://api.fullcontact.com/v2", "xxxx", Serializer.Json);

                /// Call full contact api by get 
                var person = fullContactAppService.GetAsync(Lookup.Email, "bart@fullcontact.com").Result;

                System.Console.Write(fullContactAppService.ResponseSerializer.Serialize(person).Result);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Unexpected error: " + ex.Message);
                System.Console.ReadLine();
            }

            System.Console.ReadLine();
        }
    }
}
