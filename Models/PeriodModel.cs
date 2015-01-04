using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AuvrayMonmertNetEdu.Models
{
    public class PeriodModel
    {
        public PeriodModel()
        {
            this.evaluations = new List<EvaluationModel>();
        }
        
        [DisplayName("Id de la Période")]
        public System.Guid id { get; set; }

        [DisplayName("Date de début de la Période")]
        public System.DateTime begin { get; set; }

        [DisplayName("Date de fin de la Période")]
        public System.DateTime begin { get; set; }

        [DisplayName("Année de la Période")]
        public int year { get; set; }

        [DisplayName("Id de l'année de la Période")]
        public System.Guid yearId { get; set; }

        [DisplayName("Ensemble des évaluations de la Période")]
        public List<EvaluationModel> evaluations { get; set; }
    }
}