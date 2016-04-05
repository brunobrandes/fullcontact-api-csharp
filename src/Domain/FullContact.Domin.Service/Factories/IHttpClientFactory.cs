using FullContact.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.Service.Factories
{
    public interface IHttpClientFactory
    {
        IHttpClient Create();
    }
}
