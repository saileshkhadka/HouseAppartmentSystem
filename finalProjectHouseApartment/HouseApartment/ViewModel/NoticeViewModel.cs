using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartments
{
    public class NoticeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public virtual List<NoticeAttachmentViewModel> NoticeAttachments { get; set; }
    }

    public class NoticeAttachmentViewModel
    {
        public Guid Id { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentUrl { get; set; }
        public Guid NoticeId { get; set; }
    }
}
