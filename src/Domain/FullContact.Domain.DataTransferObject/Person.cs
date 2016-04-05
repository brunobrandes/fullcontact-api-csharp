using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.DataTransferObject
{
    public class Person
    {
        #region Public Properties

        public int Status { get; set; }

        public Guid RequestId { get; set; }

        public decimal Likelihood { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public Demographics Demographics { get; set; }

        public List<SocialProfile> SocialProfiles { get; set; }

        public List<Organization> Organizations { get; set; }

        public DigitalFootprint DigitalFootprint { get; set; }

        public List<Photo> Photos { get; set; }

        #endregion
    }
}
