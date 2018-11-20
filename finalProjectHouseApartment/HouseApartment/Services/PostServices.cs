using HouseApartment.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartments.Services
{
   public class PostServices:IPostService
    {
      protected DataContext db;
      public PostServices()
      {
          db = new DataContext();
      }
        public List<ListingViewModel> ListListing()
        {
            var query = db.Listing.Select(x=>new ListingViewModel(){
              Id=x.ID,
              Name=x.Name,
              Description=x.Description,
              RentId=x.RentID,
              SquareFeet=x.SquareFeet,
              AvailabilityDate=x.AvailabilityDate
            }).ToList();
            return query;
        }

        public void AddListing(ListingViewModel model)
        {
            model.Id = Guid.NewGuid();
            var data = new Listing()
            {
                ID = model.Id,
                Name = model.Name,
                Description = model.Description,
                RentID = model.RentId,
                SquareFeet = model.SquareFeet,
                AvailabilityDate = model.AvailabilityDate
            };
            db.Listing.Add(data);
            db.SaveChanges();
        }

        public void UpdateListing(ListingViewModel model)
        {
            var findData = GetListing(model.Id);
            findData.Id=model.Id;
             findData.Name=model.Name;
            findData.Description = model.Description;
             findData.RentId=model.RentId;
             findData.SquareFeet=model.SquareFeet;
             findData.AvailabilityDate = model.AvailabilityDate;
             db.Entry(model).State = System.Data.Entity.EntityState.Modified;
             db.SaveChanges();
        }                             

        public ListingViewModel GetListing(Guid id)
        {
            var getData = db.Listing.FirstOrDefault(x => x.ID == id);
            var result = new ListingViewModel()
            {
                Id = getData.ID,
                Name = getData.Name,
                Description = getData.Description,
                RentId = getData.RentID,
                SquareFeet = getData.SquareFeet,
                AvailabilityDate = getData.AvailabilityDate
            };
            return result;
        }

        public void DeleteListing(Guid id)
        {
            var IsExistData = db.Listing.Where(x => x.ID==id).FirstOrDefault();
            db.Listing.Remove(IsExistData);
            db.SaveChanges();
        }
    }
}
