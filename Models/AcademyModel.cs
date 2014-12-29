using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class AcademyModel
    {
        public AcademyModel()
        {
            establishments = new List<EstablishmentModel>();
        }
        
        public System.Guid id { get; set; }
        public string name { get; set; }
        public List<EstablishmentModel> establishments;
    }
}