using FullContact.Domain.Enum;
using FullContact.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.Service.Factories
{
    public interface IFullContactAppServiceFactory
    {
        IFullContactAppService<T> Create<T>(string url, string apiKey, Serializer serializer) where T : class;
    }

    public abstract class AbstractFullContactAppServiceFactory : IFullContactAppServiceFactory
    {
        #region IFullContactAppServiceFactory

        public abstract IFullContactAppService<T> Create<T>(string url, string apiKey, Serializer serializer) where T : class;

        #endregion

    }
}
