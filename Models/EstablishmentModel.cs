using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class EstablishmentModel
    {
        public System.Guid id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postCode { get; set; }
        public string town { get; set; }
        public string userName { get; set; }
        public string academyName { get; set; }
        public List<ClassroomModel> classrooms {get; set;}
        public Guid userId {get; set;}
        public Guid academyId { get; set; }
    }
}