using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class TutorModel
    {
        public System.Guid id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string address { get; set; }
        public string postCode { get; set; }
        public string town { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }
        public string comment { get; set; }
    }
}