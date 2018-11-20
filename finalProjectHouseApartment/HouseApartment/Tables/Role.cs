using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
   public partial class Role
    {
       [Key]
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public int RoleID { get; set; }
       public string RoleName { get; set; }
    }
}
