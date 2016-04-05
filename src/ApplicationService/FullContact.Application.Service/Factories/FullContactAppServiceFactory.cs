using FullContact.Domain.Enum;
using FullContact.Domain.Service.Factories;
using FullContact.Domain.Service.Interfaces;
using FullContact.Infrastructure.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Application.Service.Factories
{
    public class FullContactAppServiceFactory : AbstractFullContactAppServiceFactory
    {
        #region Private Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Constructor

        public FullContactAppServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region IMessageQueueFactory Members

        public override IFullContactAppService<T> Create<T>(string url, string apiKey, Serializer serializer)
        {
            var fullContactAppService = _serviceProvider.GetService(typeof(FullContactAppService<T>)) as IFullContactAppService<T>;

            if (fullContactAppService == null)
            {
                throw new Exception("ServiceProvider get 'IFullContactAppService<T>' service error.");
            }

            switch (serializer)
            {
                case Serializer.Json:
                    fullContactAppService.ResponseSerializer = _serviceProvider.GetService(typeof(JsonSerializer<T>)) as IResponseSerializer<T>;
                    fullContactAppService.ResponseSerializer.Serializer = serializer;
                    break;

                default:
                    throw new Exception("ServiceProvider get 'IResponseSerializer<T>' service error.");
            }

            fullContactAppService.Initializer(url, apiKey);

            return fullContactAppService;
        }

        #endregion
    }
}
