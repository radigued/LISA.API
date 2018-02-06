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
    
    public partial class Catalog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalog()
        {
            this.LimitDateShop = new HashSet<LimitDateShop>();
            this.Page = new HashSet<Page>();
            this.PriceProduct = new HashSet<PriceProduct>();
        }
    
        public int Id { get; set; }
        public int ImportIdCatalog { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Speed { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Id_Operation { get; set; }
    
        public virtual Operation Operation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LimitDateShop> LimitDateShop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Page> Page { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceProduct> PriceProduct { get; set; }
    }
}