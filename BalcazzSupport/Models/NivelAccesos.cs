//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalcazzSupport.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NivelAccesos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NivelAccesos()
        {
            this.Autorizaciones = new HashSet<Autorizaciones>();
        }
    
        public short IdNivelAcceso { get; set; }
        public string NivelAcceso { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autorizaciones> Autorizaciones { get; set; }
    }
}
