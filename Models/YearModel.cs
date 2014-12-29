using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class YearModel
    {
        [DisplayName("Id de l'année")]
        public System.Guid id { get; set; }
        [DisplayName("Anée")]
        public int year { get; set; }

        public List<ClassroomModel> classrooms { get; set; }
        public List<PeriodModel> periods { get; set; }

    }
}