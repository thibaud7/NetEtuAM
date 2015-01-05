using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AuvrayMonmertNetEdu.Models
{
    public class ResultModel
    {
        [DisplayName("Id du Résultat")]
        public System.Guid id { get; set; }

        [DisplayName("Id de l'évaluation liée au Résultat")]
        public System.Guid evaluationId { get; set; }

        [DisplayName("Prénom de l'élève lié au Résultat")]
        public string pupilFirstName { get; set; }

        [DisplayName("Nom de l'élève lié au Résultat")]
        public string pupilLastName { get; set; }

        [DisplayName("Note")]
        public double note { get; set; }

        [DisplayName("TotalNote")]
        public int totalNote { get; set; }

        [DisplayName("Id de l'élève lié au Résultat")]
        public Guid pupilId { get; set; }


    }
}