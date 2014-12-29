using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuvrayMonmertNetEdu.Models
{
    public class UserModel 
    {
        public System.Guid id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }

        public List<EstablishmentModel> etablissements;
        public List<ClassroomModel> classrooms;

    }
}
