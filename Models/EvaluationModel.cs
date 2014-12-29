using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class EvaluationModel
    {
        public EvaluationModel()
        {
            resultats = new List<ResultModel>();
        }
        
        public System.Guid id { get; set; }
        public string classroomTitle { get; set; }
        public string userName { get; set; }
        public System.DateTime periodBegin { get; set; }
        public System.DateTime periodEnd { get; set; }
        public System.DateTime date { get; set; }
        public int totalPoint { get; set; }

        public List<ResultModel> resultats { get; set; }
        public Guid idUser { get; set; }
        public Guid idPeriod { get; set; }
        public Guid idClassroom { get; set; }
    }
}