using FullContact.Domain.Enum;
using FullContact.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.Service.Interfaces
{
    public interface IFullContactAppService<T> where T : class
    {
        void Initializer(string url, string apiKey);

        IResponseSerializer<T> ResponseSerializer { get; set; }

        Task<T> GetAsync(Lookup lookup, string parameter);
    }
}
