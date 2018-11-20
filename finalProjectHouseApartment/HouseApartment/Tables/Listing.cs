using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
   public partial class Listing
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SquareFeet { get; set; }
        public DateTime AvailabilityDate { get; set; }
        public string Description { get; set; }
        public Guid RentID { get; set; }
    }
}
