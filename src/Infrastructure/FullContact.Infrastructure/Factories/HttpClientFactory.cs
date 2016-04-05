using FullContact.Domain.Service.Factories;
using FullContact.Domain.Service.Interfaces;
using FullContact.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Infrastructure.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        #region Private Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion

        public HttpClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region IDispatcherFactory Members

        public IHttpClient Create()
        {
            return _serviceProvider.GetService(typeof(CustomHttpClient)) as IHttpClient;
        }

        #endregion

    }


}
