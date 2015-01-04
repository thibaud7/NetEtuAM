using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AuvrayMonmertNetEdu.Models
{
    public class CycleModel
    {
        public CycleModel()
        {
            this.levels = new List<LevelModel>();
        }
        
        [DisplayName("Id du Cycle")]
        public System.Guid id { get; set; }

        [DisplayName("Titre du Cycle")]
        public string title { get; set; }

        [DisplayName("Ensemble des niveaux du cycle")]
        public List<LevelModel> levels { get; set; }
    }
}