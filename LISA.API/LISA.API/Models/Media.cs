//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LISA.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Media
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int Id_Product { get; set; }
        public int Id_TypeMedia { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual TypeMedia TypeMedia { get; set; }
    }
}
