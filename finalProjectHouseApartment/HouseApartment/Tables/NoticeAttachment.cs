using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
   public partial class NoticeAttachment
    {
       [Key]
       public Guid ID { get; set; }
       public Guid NoticeID { get; set; }
       public string AttachmentName { get; set; }
       public string AttachmentUrl { get; set; }
   }
}
