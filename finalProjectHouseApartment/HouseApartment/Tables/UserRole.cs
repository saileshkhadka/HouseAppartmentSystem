using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
    public partial class UserRole
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserRolesId { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
    }
}
