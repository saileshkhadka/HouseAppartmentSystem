using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartments.Services
{
    public interface IPostService
    {
        #region Listing
        List<ListingViewModel> ListListing();
        void AddListing(ListingViewModel model);
        void UpdateListing(ListingViewModel model);
        ListingViewModel GetListing(Guid id);
        void DeleteListing(Guid id);
        #endregion Listing
    }
}
