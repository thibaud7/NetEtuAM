using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuvrayMonmertNetEdu.Models
{
    public class TutorModel
    {
        public TutorModel()
        {
            this.pupils = new List<PupilModel>();
        }

        [DisplayName("Id du Tuteur")]
        public System.Guid id { get; set; }

        [DisplayName("Nom du Tuteur")]
        [Required(ErrorMessage = "Le nom est requis")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Nom invalide")]
        public string lastName { get; set; }

        [DisplayName("Prénom du Tuteur")]
        [Required(ErrorMessage = "Le prénom est requis")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Prénom invalide")]
        public string firstName { get; set; }

        [DisplayName("Id du Tuteur")]
        [Required(ErrorMessage = "L'adresse est requise")]
        [RegularExpression("[0-9A-Za-zàâçéèêëîïôûùüÿñæœ '.-]+", ErrorMessage = "Adresse invalide")]
        public string address { get; set; }

        [DisplayName("Code postal du Tuteur")]
        [Required(ErrorMessage = "Le code postal est requis")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Code postal invalide")]
        public string postCode { get; set; }

        [DisplayName("Ville du Tuteur")]
        [Required(ErrorMessage = "La ville est requise")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Ville invalide")]
        public string town { get; set; }

        [DisplayName("Téléphone du Tuteur")]
        [Required(ErrorMessage = "Le téléphone est requise")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Téléphone invalide")]
        public string tel { get; set; }

        [DisplayName("Email du Tuteur")]
        [Required(ErrorMessage = "L'email est requise")]
        [RegularExpression("[0-9A-Za-z]+@[A-Za-z]+\\.[a-z]{2,4}", ErrorMessage = "Email invalide")]
        public string mail { get; set; }

        [DisplayName("Commentaires sur Tuteur")]
        public string comment { get; set; }

        [DisplayName("Ensemble des élèves du Tuteur")]
        public List<PupilModel> pupils { get; set; }
    }
}