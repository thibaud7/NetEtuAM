using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuvrayMonmertNetEdu.Models
{
    public class AcademyModel
    {
        public AcademyModel()
        {
            this.establishments = new List<EstablishmentModel>();
        }

        [DisplayName("Id de l'Académie")]
        public System.Guid id { get; set; }

        [DisplayName("Nom de l'Académie")]
        [Required(ErrorMessage="Le nom de l'Académie est requis")]
        [RegularExpression("[A-Za-zàâçéèêëîïôûùüÿñæœ .-]+", ErrorMessage = "Nom invalide")]
        public string name { get; set; }

        [DisplayName("Ensemble des établissements de l'Académie")]
        public List<EstablishmentModel> establishments;
    }
}