using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class PeriodModel
    {
            public PeriodModel()
            {}

            public System.Guid id { get; set; }
            public System.DateTime begin { get; set; }
            public System.DateTime end { get; set; }
            public int year { get; set; }
            public System.Guid yearId { get; set; }

            public List<EvaluationModel> evaluations { get; set; }
    }
}