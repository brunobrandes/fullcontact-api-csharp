using FullContact.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.DataTransferObject
{
    public class SocialProfile
    {
        public SocialProfileType TypeId { get; set; }
        public string TypeName { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string Followers { get; set; }
        public string Following { get; set; }
        public string Rss { get; set; }
    }
}
