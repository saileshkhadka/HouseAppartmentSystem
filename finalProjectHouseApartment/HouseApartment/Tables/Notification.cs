using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
   public partial class Notification
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NotifyID { get; set; }
        public int SourceID { get; set; }
        public string SourceType { get; set; }
        public string Message { get; set; }
        public int? ModifiedByID { get; set; }
        public DateTime? ModifiedTS { get; set; }
    }
}
