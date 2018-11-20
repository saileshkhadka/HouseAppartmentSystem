using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HouseApartment.Tables;
using HouseApartment.Crypto;
using HouseApartment.ViewModel;

namespace HouseApartment.Services
{
    public class UserServices : IUserServices
    {
        protected DataContext db;
        public UserServices()
        {
            db = new DataContext();
        }
        public UserViewModel Insert(UserViewModel model)
        {
            var emailExist = IsExistEmail(model.EmailID);
            if (!emailExist)
            {
               
                var user = new User()
                {
                    Username=model.Username,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    EmailID=model.EmailID,
                    DateOfBirth=model.DateOfBirth,
                    Password = CryptoMethod.Hash(model.Password),
                };
                db.Users.Add(user);
                db.SaveChanges();
            }

            return model;
            // model.ActivationCode = Guid.NewGuid();
            // model.IsEmailVerified = true; //TODO
            //verify.SendVerificationLinkEmail("ok", "ok");

        }

        public bool IsExistEmail(string EmailID)
        {
            var hasEmail = db.Users.Where(x => x.EmailID == EmailID).FirstOrDefault();
            return hasEmail != null;
        }
    }
    
}