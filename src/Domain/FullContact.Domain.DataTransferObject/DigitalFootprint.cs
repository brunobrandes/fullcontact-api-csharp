using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.DataTransferObject
{
    public class DigitalFootprint
    {
        public List<Topic> Topics { get; set; }
        public List<Score> Scores { get; set; }
    }

    public class Topic
    {
        public string Provider { get; set; }
        public string Value { get; set; }        
    }

    public class Score
    {
        public string Provider { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        
    }
}
