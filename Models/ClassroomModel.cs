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

        [DisplayName("Id de le Classe")]
        public System.Guid id { get; set; }

        [DisplayName("Titre de le Classe")]
        [Required(ErrorMessage="Le titre est requis")]
        [RegularExpression("[0-9A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Titre invalide")]
        public string title { get; set; }

        [DisplayName("Année de le Classe")]
        public int year { get; set; }

        [DisplayName("Etablissement de le Classe")]
        public string establishmentName { get; set; }

        [DisplayName("Utilisateur de le Classe")]
        public string userName { get; set; }

        [DisplayName("Etablissement de le Classe")]
        [Required]
        public Guid establishmentId { get; set; }

        [DisplayName("Id de l'utilisateur de le Classe")]
        public Guid userId { get; set; }

        [DisplayName("Id de l'année de le Classe")]
        [Required]
        public Guid yearId { get; set; }

        [DisplayName("Ensemble des élèves de le Classe")]
        public List<PupilModel> pupils { get; set; }

        [DisplayName("Ensemble des évaluations de le Classe")]
        public List<EvaluationModel> evaluations { get; set; }
    }
}