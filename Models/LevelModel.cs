using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AuvrayMonmertNetEdu.Models
{
    public class LevelModel
    {
        public LevelModel()
        {
            this.pupils = new List<PupilModel>();
        }
    
        [DisplayName("Id du level")]
        public System.Guid id { get; set; }

        [DisplayName("Titre du level")]
        public string title { get; set; }

        [DisplayName("Cycle du level")]
        public String nomCycle { get; set; }

        [DisplayName("Id du cycle lié")]
        public System.Guid idCycle { get; set; }

        [DisplayName("Ensemble des élèces du level")]
        public List<PupilModel> pupils { get; set; }
        
    }
}