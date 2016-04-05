using FullContact.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.DataTransferObject
{
    public class Photo
    {
        public bool IsPrimary { get; set; }
        public SocialProfileType TypeId { get; set; }
        public string TypeName { get; set; }
        public string Url { get; set; }
    }
}
