//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Easy_Shopping
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSize
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSize()
        {
            this.tblProductSizeQuantities = new HashSet<tblProductSizeQuantity>();
        }
    
        public long SizeID { get; set; }
        public string SizeName { get; set; }
        public Nullable<long> BrandID { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> SubCategoryID { get; set; }
        public Nullable<long> GenderID { get; set; }
    
        public virtual tblBrand tblBrand { get; set; }
        public virtual tblCategory tblCategory { get; set; }
        public virtual tblGender tblGender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductSizeQuantity> tblProductSizeQuantities { get; set; }
        public virtual tblSubCategory tblSubCategory { get; set; }
    }
}
