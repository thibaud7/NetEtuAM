using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace AuvrayMonmertNetEdu.Models
{
    public class UserModel 
    {
        public UserModel()
        {
            this.etablissements = new List<EstablishmentModel>();
            this.classrooms = new List<ClassroomModel>();
            this.evaluations = new List<EvaluationModel>(); 
        }

        [DisplayName("Id de l'Utilisateur")]
        public System.Guid id { get; set; }

        [DisplayName("Nom de l'Utilisateur")]
        public string userName { get; set; }

        [DisplayName("Mot de passe de l'Utilisateur")]
        public string password { get; set; }

        [DisplayName("Prénom de l'Utilisateur")]
        public string firstName { get; set; }

        [DisplayName("Nom de l'Utilisateur")]
        public string lastName { get; set; }

        [DisplayName("Email de l'Utilisateur")]
        public string mail { get; set; }

        [DisplayName("Ensemble des établissements de l'Utilisateur")]
        public List<EstablishmentModel> etablissements { get; set; }

        [DisplayName("Ensemble des classes de l'Utilisateur")]
        public List<ClassroomModel> classrooms { get; set; }

        [DisplayName("Ensemble des évaluations de l'Utilisateur")]
        public List<EvaluationModel> evaluations { get; set; }
    }
}
