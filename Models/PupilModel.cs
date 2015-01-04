using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuvrayMonmertNetEdu.Models
{
    public class PupilModel
    {
        public PupilModel()
        {
            results = new List<ResultModel>();
        }

        [DisplayName("Id de l'Elève")]
        public System.Guid id { get; set; }

        [DisplayName("Prénom de l'Elève")]
        [Required(ErrorMessage="Le prénom est requis")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Prénom invalide")]
        public string firstName { get; set; }

        [DisplayName("Nom de l'Elève")]
        [Required(ErrorMessage = "Le nom est requis")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Nom invalide")]
        public string lastName { get; set; }

        [DisplayName("Sexe de l'Elève")]
        public short sex { get; set; }

        [DisplayName("Date de naissance de l'Elève")]
        [Required(ErrorMessage = "La date de naissance est requise")]
        [RegularExpression("[0-9]{2}/[0-9]{2}/[0-9]{4}", ErrorMessage = "Date de naissance invalide")]
        public System.DateTime birthdayDate { get; set; }

        [DisplayName("Etat de l'Elève")]
        public short state { get; set; }

        [DisplayName("Tuteur de l'Elève")]
        public string tutorLastName { get; set; }

        [DisplayName("Classe de l'Elève")]
        public string classroomTitle { get; set; }

        [DisplayName("Niveau de l'Elève")]
        public string levelTitle { get; set; }

        [DisplayName("Id du niveau de l'Elève")]
        public Guid levelId { get; set; }

        [DisplayName("Id du tuteur de l'Elève")]
        public Guid tutorId { get; set; }

        [DisplayName("Id de la classe de l'Elève")]
        public Guid classroomId { get; set; }

        [DisplayName("Ensemble des résultats de l'Elève")]
        public List<ResultModel> results { get; set; }
    }
}