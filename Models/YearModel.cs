using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class YearModel
    {
        public YearModel()
        {
            this.classrooms = new List<ClassroomModel>();
            this.periods = new List<PeriodModel>();
        }

        [DisplayName("Id de l'année")]
        public System.Guid id { get; set; }

        [DisplayName("Année")]
        public int year { get; set; }

        [DisplayName("Ensemble des classes de l'année")]
        public List<ClassroomModel> classrooms { get; set; }

        [DisplayName("Ensemble des périodes de l'année")]
        public List<PeriodModel> periods { get; set; }

    }
}