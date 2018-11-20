using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartments
{
    public partial class ListingViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SquareFeet { get; set; }
        public string Price { get; set; }
        public DateTime AvailabilityDate { get; set; }
        public Guid RentId { get; set; }
        public virtual List<ListingAttachmentViewModel> ListingAttachments { get; set; }
    }

    public partial class ListingAttachmentViewModel
    {
        public Guid Id { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentUrl { get; set; }
        public Guid ListingId { get; set; }
    }

}
