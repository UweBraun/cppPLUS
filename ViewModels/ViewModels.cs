using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace cppPLUS_2407.Models
{
    public class CorporateMasterViewModel
    {

        public int Corporate_ID { get; set; }

        [Required, StringLength(10)]
        [DisplayName("Corporation Short")]
        public string CorporateShort { get; set; }

        [Required]
        [DisplayName("Corporate Entity Name")]
        public string CorporateEntityName { get; set; }

        [DisplayName("Country")]
        public Nullable<int> C_Country { get; set; }

        [DisplayName("City")]
        public string C_Location { get; set; }

        //public int UserUpdate { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Modify Date")]
        //public Nullable<System.DateTime> DateModified { get; set; }

        //[DataType(DataType.Date)]
        //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //    [Display(Name = "Add Date")]
        //    public System.DateTime DateAdded { get; set; }

        public virtual CountryList CountryList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntityMaster> EntityMasters { get; set; }

    }

    public class PersonalMasterCreateViewModel
    {
        public int UserID { get; set; }
        //public string ASPID { get; set; }
        //public Nullable<int> RoleID { get; set; }
        //public string UserStatus { get; set; }
        //public string UserBackground { get; set; }
        //public int UserVerification { get; set; }

        [Required(ErrorMessage = "Please enter First Name, max 20 char.")]
        [StringLength(20)]
        [DisplayName("First Name*")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name, max 50 char.")]
        [StringLength(50)]
        [DisplayName("Last Name*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Short Name, max 10 char.")]
        [StringLength(10)]
        [DisplayName("Short Name*")]
        public string ShortName { get; set; }

        //public string SystemName { get; set; }

        [Required]
        [Range(4, 1000, ErrorMessage = "Please select country")]
        [DisplayName("Residence Country*")]
        public Nullable<int> Nationality { get; set; }

        [StringLength(10)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(50)]
        [DisplayName("Street")]
        public string Street { get; set; }

        [StringLength(10)]
        [DisplayName("Add. Addressfield")]
        public string AddAddressFld { get; set; }

        [StringLength(50)]
        [DisplayName("City")]
        public string City { get; set; }

        [StringLength(15)]
        [DisplayName("Mobile Phone Number")]
        public string MobilePhone { get; set; }

        //public string Email { get; set; }

        [DisplayName("Linkedin")]
        public string Linkedin { get; set; }

        [DisplayName("Xing")]
        public string Xing { get; set; }

        [DisplayName("Other Profile-Link")]
        public string Hyperlink1 { get; set; }

        //public byte[] ProfilePic { get; set; }

        [DisplayName("Comments")]
        [StringLength(256)]
        public string UserCmntPub { get; set; }

        //public string UserCmntHid { get; set; }

        //public int UserID_AddMod { get; set; }
        //public Nullable<System.DateTime> DateModified { get; set; }
        //public System.DateTime DateAdded { get; set; }
        //public int ClientID { get; set; }


        public virtual CountryList CountryList { get; set; }
        public virtual ClientMaster ClientMaster { get; set; }
    }

    public class PersonalMasterEditViewModel
    {
        public int UserID { get; set; }
        public string ASPID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string UserStatus { get; set; }
        public string UserBackground { get; set; }
        public int UserVerification { get; set; }

        [Required(ErrorMessage = "Please enter First Name, max 20 char.")]
        [StringLength(20)]
        [DisplayName("First Name*")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name, max 50 char.")]
        [StringLength(50)]
        [DisplayName("Last Name*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Short Name, max 10 char.")]
        [StringLength(10)]
        [DisplayName("Short Name*")]
        public string ShortName { get; set; }

        public string SystemName { get; set; }

        [Required]
        [Range(4, 1000, ErrorMessage = "Please select country")]
        [DisplayName("Residence Country*")]
        public Nullable<int> Nationality { get; set; }

        [StringLength(10)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(50)]
        [DisplayName("Street")]
        public string Street { get; set; }

        [StringLength(10)]
        [DisplayName("Add. Addressfield")]
        public string AddAddressFld { get; set; }

        [StringLength(50)]
        [DisplayName("City")]
        public string City { get; set; }

        [StringLength(15)]
        [DisplayName("Mobile Phone Number")]
        public string MobilePhone { get; set; }

        public string Email { get; set; }

        [DisplayName("Linkedin")]
        public string Linkedin { get; set; }

        [DisplayName("Xing")]
        public string Xing { get; set; }

        [DisplayName("Other Profile-Link")]
        public string Hyperlink1 { get; set; }

        //public byte[] ProfilePic { get; set; }

        [DisplayName("Comments")]
        [StringLength(256)]
        public string UserCmntPub { get; set; }

        public string UserCmntHid { get; set; }

        public int UserID_AddMod { get; set; }

        public Nullable<System.DateTime> DateModified { get; set; }

        public System.DateTime DateAdded { get; set; }
        public int ClientID { get; set; }


        public virtual CountryList CountryList { get; set; }
        public virtual ClientMaster ClientMaster { get; set; }
    }


    public class ClientMasterEditModel
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

        //public virtual ICollection<PersonalMaster> PersonalMasters { get; set; }
    }
}