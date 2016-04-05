using FullContact.Domain.Service.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullContact.Domain.Enum;

namespace FullContact.Infrastructure.Serializers
{
    public class JsonSerializer<T> : IResponseSerializer<T> where T : class
    {
        #region Private Fields

        private readonly JsonSerializerSettings _settings;
        private Serializer _serializer;

        #endregion

        #region Constructor

        public JsonSerializer()
        {
            _settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            _settings.Converters.Add(new StringEnumConverter());
        }

        #endregion

        public Serializer Serializer
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

        public Task<T> Deserialize(string message)
        {
            return Task.FromResult<T>(JsonConvert.DeserializeObject<T>(message, _settings));
        }

        public Task<string> Serialize(T t)
        {
            return Task.FromResult<string>(JsonConvert.SerializeObject(t, _settings));
        }
    }
}
