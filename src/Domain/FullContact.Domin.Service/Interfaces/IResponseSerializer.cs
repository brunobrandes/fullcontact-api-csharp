using FullContact.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.Service.Interfaces
{
    public interface IResponseSerializer<T> where T : class
    {
        Serializer Serializer { get; set; }

        Task<string> Serialize(T t);

        Task<T> Deserialize(string message);
    }
}
