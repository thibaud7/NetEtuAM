//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuvrayMonmertNetEdu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Year
    {
        public Year()
        {
            this.Classrooms = new HashSet<Classroom>();
            this.Periods = new HashSet<Period>();
        }
    
        public System.Guid Id { get; set; }
        public int Year1 { get; set; }
    
        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual ICollection<Period> Periods { get; set; }
    }
}
