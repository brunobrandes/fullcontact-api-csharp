using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullContact.Domain.Enum;
using FullContact.Domain.Service.Interfaces;
using FullContact.Domain.Service.Factories;
using System.Net.Http;

namespace FullContact.Application.Service
{
    public class FullContactAppService<T> : IFullContactAppService<T> where T : class
    {
        #region Private Filds

        private readonly IHttpClientFactory _httpClientFactory;
        private IResponseSerializer<T> _serializer;
        private string _url;
        private string _apiKey;

        #endregion

        #region Constructor

        public FullContactAppService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #endregion

        #region Private methods

        private Api GetApi(Type type)
        {
            switch (type.Name)
            {
                case "Person":
                    return Api.Person;

                default:
                    throw new NotImplementedException($"Api type {type.Name} not implemented.");
            }
        }

        private string GetFullUrl(string url, Api api, Serializer serializer, Lookup lookup, string parameter, Style style)
        {
            return $"{url}/{api.ToString().ToLower()}.{serializer.ToString().ToLower()}?{lookup.ToString().ToLower()}={parameter}&style={style.ToString().ToLower()}";
        }

        #endregion

        #region IFullContactAppService Members

        public IResponseSerializer<T> ResponseSerializer
        {
            get
            {
                return _serializer;
            }

            set
            {
                _serializer = value;
            }
        }

        public async Task<T> GetAsync(Lookup lookup, string parameter)
        {
            var api = GetApi(typeof(T));

            var url = GetFullUrl(_url, Api.Person, _serializer.Serializer, lookup, parameter, Style.List);

            using (var httpClient = _httpClientFactory.Create())
            {
                httpClient.DefaultRequestHeaders.Add("X-fullcontact-apiKey", _apiKey);

                var httpMessageResponse = await httpClient.GetAsync(new Uri(url));

                if (httpMessageResponse != null)
                {
                    var content = string.Empty;

                    if (httpMessageResponse.Content != null)
                    {
                        content = await httpMessageResponse.Content.ReadAsStringAsync();
                    }

                    if (!httpMessageResponse.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(!string.IsNullOrEmpty(content) ? $"Status: {httpMessageResponse.StatusCode} Response: {content}" :
                            "Unexpected error call full contact api.");
                    }

                    if (string.IsNullOrEmpty(content))
                    {
                        throw new HttpRequestException("Unexpected error call full contact api - Error: Content response is null or empty.");
                    }

                    return await ResponseSerializer.Deserialize(content);
                }
                else
                {
                    throw new HttpRequestException("Unexpected error call full contact api - Error: HttpMessageResponse is null or empty.");
                }
            }
        }

        public void Initializer(string url, string apiKey)
        {
            _url = url;
            _apiKey = apiKey;
        }

        #endregion
    }
}
