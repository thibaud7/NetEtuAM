using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class ClassroomModel
    {

        public ClassroomModel()
        {
            pupils = new List<PupilModel>();
            evaluations = new List<EvaluationModel>();
        }
        
        public System.Guid id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string establishmentName { get; set; }
        public string userName { get; set; }
        public Guid establishmentId { get; set; }
        public Guid userId { get; set; }
        public Guid yearId { get; set; }
        public List<PupilModel> pupils { get; set; }
        public List<EvaluationModel> evaluations { get; set; }
    }
}