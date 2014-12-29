using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class ResultModel
    {
        public System.Guid id { get; set; }
        public System.Guid evaluationId { get; set; }
        public string pupilFirstName { get; set; }
        public string pupilLastName { get; set; }
        public double note { get; set; }
        public Guid pupilId { get; set; }
        public int totalNote { get; set; }

    }
}