//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cppPLUS_2407.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientMaster()
        {
            this.PersonalMasters = new HashSet<PersonalMaster>();
        }
    
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientDescr { get; set; }
        public string ClientStatus { get; set; }
        public int UserMod { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalMaster> PersonalMasters { get; set; }
    }
}
