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
    
    public partial class Cycle
    {
        public Cycle()
        {
            this.Levels = new HashSet<Level>();
        }
    
        public System.Guid Id { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<Level> Levels { get; set; }
    }
}
