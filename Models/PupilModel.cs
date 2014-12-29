using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuvrayMonmertNetEdu.Models
{
    public class PupilModel
    {
        public PupilModel()
        {
            results = new List<ResultModel>();
        }
        
        public System.Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public short sex { get; set; }
        public System.DateTime birthdayDate { get; set; }
        public short state { get; set; }
        public string tutorLastName { get; set; }
        public string classroomTitle { get; set; }
        public string levelTitle { get; set; }
        public Guid levelId { get; set; }
        public Guid tutorId { get; set; }
        public Guid classroomId { get; set; }

        public List<ResultModel> results { get; set; }
    }
}