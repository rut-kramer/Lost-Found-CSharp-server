//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Found
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Found()
        {
            this.Colors = new HashSet<Color>();
            this.Losts = new HashSet<Lost>();
        }
    
        public decimal FoundId { get; set; }
        public string FoundName { get; set; }
        public decimal CategoryId { get; set; }
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> MaterialId { get; set; }
        public string FoundDescription { get; set; }
        public System.DateTime FoundDate { get; set; }
        public Nullable<double> FoundLat { get; set; }
        public Nullable<double> FoundLng { get; set; }
        public string FoundImage { get; set; }
        public decimal UserId { get; set; }
        public Nullable<decimal> color1 { get; set; }
        public Nullable<decimal> color2 { get; set; }
        public Nullable<decimal> color3 { get; set; }
        public string FoundAddress { get; set; }
        public Nullable<bool> FoundStatus { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual Color Color4 { get; set; }
        public virtual Color Color5 { get; set; }
        public virtual Item Item { get; set; }
        public virtual Material Material { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Color> Colors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lost> Losts { get; set; }
    }
}
