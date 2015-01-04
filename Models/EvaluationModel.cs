using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AuvrayMonmertNetEdu.Models
{
    public class EvaluationModel
    {
        public EvaluationModel()
        {
            this.resultats = new List<ResultModel>();
        }

        [DisplayName("Id de l'Evaluation")]
        public System.Guid id { get; set; }

        [DisplayName("Classe de l'Evaluation")]
        public string classroomTitle { get; set; }

        [DisplayName("Utilisateur de l'Evaluation")]
        public string userName { get; set; }

        [DisplayName("Début de la période de l'Evaluation")]
        public System.DateTime periodBegin { get; set; }

        [DisplayName("Fin de la période de l'Evaluation")]
        public System.DateTime periodEnd { get; set; }

        [DisplayName("Date de l'Evaluation")]
        public System.DateTime date { get; set; }

        [DisplayName("Total des points de l'Evaluation")]
        public int totalPoint { get; set; }

        [DisplayName("Ensemble des résultats de l'Evaluation")]
        public List<ResultModel> resultats { get; set; }

        [DisplayName("Id de l'utilisateur de l'Evaluation")]
        public Guid idUser { get; set; }

        [DisplayName("Id de la période de l'Evaluation")]
        public Guid idPeriod { get; set; }

        [DisplayName("Id de la classe de l'Evaluation")]
        public Guid idClassroom { get; set; }
    }
}