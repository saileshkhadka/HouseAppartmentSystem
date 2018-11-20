using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartments
{
    public partial class RolesViewModel
    {
        public int? UserRolesId { get; set; }
        public int? UserID { get; set; }
        public int? RoleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsEmailVerified { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }

    }

    public partial class RoleNamesViewModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public partial class UpdateRolesViewModel
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
