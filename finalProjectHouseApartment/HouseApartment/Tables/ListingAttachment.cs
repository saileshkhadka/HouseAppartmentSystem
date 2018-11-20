using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
   public partial class ListingAttachment
    {
      [Key]
       public Guid ID { get; set; }
       public Guid ListingID { get; set; }
       public string AttachmentName { get; set; }
       public string AttachmentUrl { get; set; }
    }
}
