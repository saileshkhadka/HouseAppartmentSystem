using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseApartment.ViewModel;
using HouseApartment.Tables;

namespace HouseApartment.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        protected readonly DataContext db;
       

        public DepartmentServices()
        {
            db = new DataContext();
        }

        

        public bool AddDepartment(DepartmentViewModel model)
        {
            var data = new Department()
            {

                DepartmentID = model.DepartmentID,
                DepartmentName = model.DepartmentName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                ModifiedBy = model.ModifiedBy,
                ModifiedDate=model.ModifiedDate,
                Description=model.Description,
                Status = model.Status,
              
            };
            db.Department.Add(data);
            db.SaveChanges();
            return true;
        }

        public bool DeleteDepartment(int id)
        {
            var IsExistData = db.Department.Where(x => x.DepartmentID == id).FirstOrDefault();
            db.Department.Remove(IsExistData);
            db.SaveChanges();
            return true;
        }

        public DepartmentViewModel GetDepartmentByID(int id)
        {
            var data = db.Department.Where(x => x.DepartmentID == id).Select(x => new DepartmentViewModel
            {
                DepartmentID = x.DepartmentID,
                DepartmentName = x.DepartmentName,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                Description=x.Description,
                Status = x.Status,
                
            }).FirstOrDefault();
            return data;
        }

        public List<DepartmentViewModel> ListDepartment()
        {
            //var result = (from x in db.Department
            //              join y in db.Employee on x.DepartmentID equals y.DepartmentId into employee
            //              select new DepartmentViewModel()
            //              {
            //                  DepartmentID = x.DepartmentID,
            //                  DepartmentName = x.DepartmentName,
            //                  CreatedBy = x.CreatedBy,
            //                  CreatedDate = x.CreatedDate,
            //                  ModifiedBy = x.ModifiedBy,
            //                  ModifiedDate = x.ModifiedDate,
            //                  Description = x.Description,
            //                  Status = x.Status,
            //              });

                var result = (from x in db.Department
                              join y in db.Employee on x.DepartmentID equals y.DepartmentId into employee
                              select new DepartmentViewModel()
                              {
                DepartmentID = x.DepartmentID,
                DepartmentName = x.DepartmentName,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                Description = x.Description,
                Status = x.Status,
                EmployeeNumber=(int?)0,
                
            }).ToList();
            foreach(var item in result)
            {
                var count = (from x in db.Employee
                             where x.DepartmentId == item.DepartmentID
                             group x by new
                             {
                                 y_Id = x.Id
                             } into z
                             select new
                             {
                                 dID = z.Key.y_Id,
                                 cnt = z.Count()
                             }).FirstOrDefault();
                item.EmployeeNumber = count == null ? 0 :(int?)count.cnt;
                          
            }
            return result.ToList();

        }

        public bool UpdateDepartment(DepartmentViewModel model)
        {
            //var data = GetDepartmentByID(model.DepartmentID);
            ////var data = new Department();
            //if (data != null)
            //{
                var isExist = db.Department.Where(x => x.DepartmentName == model.DepartmentName).FirstOrDefault();
                if (isExist != null)
                {
                    isExist.DepartmentName = model.DepartmentName;
                    isExist.CreatedBy = model.CreatedBy;
                    isExist.CreatedDate = model.CreatedDate;
                    isExist.ModifiedBy = model.ModifiedBy;
                    isExist.ModifiedDate = model.ModifiedDate;
                    isExist.Description = model.Description;
                    isExist.Status = model.Status;
                   
                }

                //db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            //}
             return true;
        }
    }


}
