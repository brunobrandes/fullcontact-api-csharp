using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.DataTransferObject
{
    public class ContactInfo
    {
        #region Public Properties

        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string FullName { get; set; }
        public List<string> MiddleNames { get; set; }
        public List<WebSite> WebSites { get; set; }
        public List<Chat> Chats { get; set; }

        #endregion
    }
}
