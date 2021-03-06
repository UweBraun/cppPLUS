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
    
    public partial class EntityMaster
    {
        public int EntityID { get; set; }
        public string EntityShort { get; set; }
        public string EntityLegalName { get; set; }
        public int Corporation { get; set; }
        public string Location { get; set; }
        public Nullable<int> Country { get; set; }
        public string Comment { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        public virtual CorporateMaster CorporateMaster { get; set; }
        public virtual CountryList CountryList { get; set; }
    }
}
