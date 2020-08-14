using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace cppPLUS_2407.Models
{
    [MetadataType(typeof(PersonalMasterMeta))]
    public partial class PersonalMaster
    {
    }

    public partial class PersonalMasterMeta
    {
        [DisplayName("User ID")]
        public int UserID { get; set; }
        [DisplayName("ASP ID")]
        public string ASPID { get; set; }
        [DisplayName("Role")]
        public Nullable<int> RoleID { get; set; }
        [DisplayName("Status")]
        public string UserStatus { get; set; }
        [DisplayName("Background")]
        public string UserBackground { get; set; }
        [DisplayName("Verified")]
        public int UserVerification { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Name Short")]
        public string ShortName { get; set; }
        [DisplayName("System Name")]
        public string SystemName { get; set; }
        [DisplayName("Nationality")]
        public Nullable<int> Nationality { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public string Street { get; set; }
        [DisplayName("Add. Addressline")]
        public string AddAddressFld { get; set; }
        public string City { get; set; }
        public virtual CountryList CountryList { get; set; }
        [DisplayName("Mobile Phone")]
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Linkedin { get; set; }
        public string Xing { get; set; }
        [DisplayName("Other Network")]
        public string Hyperlink1 { get; set; }
        public byte[] ProfilePic { get; set; }
        [DisplayName("Comment")]
        public string UserCmntPub { get; set; }
        [DisplayName("Hidden Comment")]
        public string UserCmntHid { get; set; }
        [DisplayName("User Mod")]
        public int UserID_AddMod { get; set; }
        [DisplayName("Date Mod")]
        public Nullable<System.DateTime> DateModified { get; set; }
        [DisplayName("Date Added")]
        public System.DateTime DateAdded { get; set; }
        public virtual ClientMaster ClientMaster { get; set; }
        [DisplayName("Client ID")]
        public Nullable<int> ClientID { get; set; }
    }

    [MetadataType(typeof(ClientMasterMeta))]
    public partial class ClientMaster
    {
    }
    public partial class ClientMasterMeta
    { 
    public int ClientID { get; set; }
       
    [Required(ErrorMessage = "Please enter Client Name, max 20 char.")]
    [DisplayName("Client Name")]
    public string ClientName { get; set; }
    [DisplayName("Description")]
    public string ClientDescr { get; set; }
    [DisplayName("Status")]
    public string ClientStatus { get; set; }
    [DisplayName("User")]
    public int UserMod { get; set; }
    [DisplayName("Modified")]
    public Nullable<System.DateTime> DateModified { get; set; }
    [DisplayName("Added")]
    public System.DateTime DateAdded { get; set; }

}

    [MetadataType(typeof(CorporateMasterMeta))]
    public partial class CorporateMaster
    {
    }

    public class CorporateMasterMeta
    {
        public int Corporate_ID { get; set; }

        [DisplayName("Corp Short")]
        public string CorporateShort { get; set; }
        [DisplayName("Entity")]
        public string CorporateEntityName { get; set; }
        [DisplayName("Country")]
        public Nullable<int> C_Country { get; set; }
        [DisplayName("City")]
        public string C_Location { get; set; }
        [DisplayName("User")]
        public int UserID { get; set; }
        [DisplayName("Modified")]
        public Nullable<System.DateTime> DateModified { get; set; }
        [DisplayName("Added")]
        public System.DateTime DateAdded { get; set; }
    }
}