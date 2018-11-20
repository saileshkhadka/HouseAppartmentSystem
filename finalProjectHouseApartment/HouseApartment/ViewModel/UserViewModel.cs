using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseApartment.ViewModel
{
    public partial class UserViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string Username { get; set; }
        public string ConfirmPassword { get; set; }
 	    public bool? IsChecked { get; set; }
        public string RoleName { get; set; }
    }
}