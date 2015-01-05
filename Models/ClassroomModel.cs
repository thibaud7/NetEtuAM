using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuvrayMonmertNetEdu.Models
{
    public class ClassroomModel
    {
        public ClassroomModel()
        {
            this.pupils = new List<PupilModel>();
            this.evaluations = new List<EvaluationModel>();
        }

        [DisplayName("Id  ")]
        public System.Guid id { get; set; }

        [DisplayName("Titre  ")]
        [Required(ErrorMessage="Le titre est requis")]
        [RegularExpression("[0-9A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Titre invalide")]
        public string title { get; set; }

        [DisplayName("Année  ")]
        public int year { get; set; }

        [DisplayName("Etablissement  ")]
        public string establishmentName { get; set; }

        [DisplayName("Utilisateur  ")]
        public string userName { get; set; }

        [DisplayName("Etablissement  ")]
        [Required]
        public Guid establishmentId { get; set; }

        [DisplayName("Id de l'utilisateur  ")]
        public Guid userId { get; set; }

        [DisplayName("Id de l'année  ")]
        [Required]
        public Guid yearId { get; set; }

        [DisplayName("Ensemble des élèves  ")]
        public List<PupilModel> pupils { get; set; }

        [DisplayName("Ensemble des évaluations  ")]
        public List<EvaluationModel> evaluations { get; set; }
    }
}