using FullContact.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Infrastructure.Http
{
    public class CustomHttpClient : IHttpClient
    {
        #region Private Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructor

        public CustomHttpClient()
        {
            _httpClient = new HttpClient();
        }

        #endregion

        #region IHttpClient Members

        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return _httpClient.DefaultRequestHeaders;
            }
        }

        public TimeSpan Timeout
        {
            get
            {
                return _httpClient.Timeout;
            }
            set
            {
                _httpClient.Timeout = value;
            }
        }
        
        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return _httpClient.GetAsync(uri);
        }

        public Task<HttpResponseMessage> PostAsync(HttpRequestMessage requestMessage)
        {
            return _httpClient.SendAsync(requestMessage);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
        
        #endregion
    }
}
