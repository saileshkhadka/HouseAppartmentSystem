using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HouseApartment.Tables
{
   public partial class NotificationPerson
    {
        [Key]
        public int NotificationPersonID { get; set; }
        public int? NotifyID { get; set; }
        public int? UserID { get; set; }
        public bool? Viewed { get; set; }
        public int? SourceID { get; set; }
        public string Type { get; set; }

        [ForeignKey("NotifyID")]
        [ScriptIgnore]
        [JsonIgnore]
        public Notification Notification { get; set; }

        [ForeignKey("UserID")]
        [ScriptIgnore]
        [JsonIgnore]
        public User User { get; set; }
    }
}
