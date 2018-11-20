using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartments.Services
{
    public interface INoticeServices
    {
        List<NoticeViewModel> ListNotice();
        void AddNotice(NoticeViewModel model);
        void UpdateNotice(NoticeViewModel model);
        NoticeViewModel GetNotice(Guid id);
        void DeleteNotice(Guid id);
    }
}
