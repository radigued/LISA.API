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
    
    public partial class LimitDateShop
    {
        public int Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime DisplayStartDate { get; set; }
        public System.DateTime DisplayEndDate { get; set; }
        public int Id_Catalog { get; set; }
        public int Id_Shop { get; set; }
    
        public virtual Catalog Catalog { get; set; }
        public virtual Shop Shop { get; set; }
    }
}