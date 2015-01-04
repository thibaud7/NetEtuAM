using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuvrayMonmertNetEdu.Models
{
    public class EstablishmentModel
    {
        public EstablishmentModel()
        {
            this.classrooms = new List<ClassroomModel>();
        }

        [DisplayName("Id de l'Etablissement")]
        public System.Guid id { get; set; }

        [DisplayName("Nom de l'Etablissement")]
        [Required(ErrorMessage="Le nom est requis")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Nom invalide")]
        public string name { get; set; }

        [DisplayName("Adresse de l'Etablissement")]
        [Required(ErrorMessage = "L'adresse est requise")]
        [RegularExpression("[0-9A-Za-zàâçéèêëîïôûùüÿñæœ '.-]+", ErrorMessage = "Adresse invalide")]
        public string address { get; set; }

        [DisplayName("Code postal de l'Etablissement")]
        [Required(ErrorMessage = "Le code postal est requis")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Code postal invalide")]
        public string postCode { get; set; }

        [DisplayName("Ville de l'Etablissement")]
        [Required(ErrorMessage = "La ville est requise")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Ville invalide")]
        public string town { get; set; }

        [DisplayName("Utilisateur de l'Etablissement")]
        public string userName { get; set; }

        [DisplayName("Académie de l'Etablissement")]
        public string academyName { get; set; }

        [DisplayName("Ensemble des classes de l'Etablissement")]
        public List<ClassroomModel> classrooms {get; set;}

        [DisplayName("Id de l'utilisateur de l'Etablissement")]
        public Guid userId {get; set;}

        [DisplayName("Id de l'académie de l'Etablissement")]
        [Required]
        public Guid academyId { get; set; }
    }
}