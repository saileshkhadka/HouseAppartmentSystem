using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseApartment.Tables;
using HouseApartment.ViewModel;

namespace HouseApartment.Services
{
    
    public class EmployeeServices : IEmployeeServices
    {
        
        protected readonly DataContext db;
        public EmployeeServices()
        {
            db = new DataContext();
        }

        public bool AddEmployee(EmployeeViewModel model)
        {
            var data = new Employee()
            {

                EmployeeName = model.EmployeeName,
                DepartmentId = model.DepartmentId,
                Address = model.Address,
                ContactNumber = model.ContactNumber,
                Status = model.Status,

            };
            db.Employee.Add(data);
            db.SaveChanges();
            return true;
        }

        //public bool DeleteEmployee(string id)
        //{
        //    throw new NotImplementedException();
        //}

        public bool DeleteEmployee(int id)
        {
            var IsExistData = db.Employee.Where(x => x.Id == id).FirstOrDefault();
            db.Employee.Remove(IsExistData);
            db.SaveChanges();
            return true;
        }

        //public bool DeleteEmployee(string ID)
        //{
        //    //int[] arrayId; 
        //    var arrayId = ID.Split(',');
        //    int[] intarray = new int[arrayId.Length];
        //    for (int i = 0; i < arrayId.Length; i++)
        //    {
        //        intarray[i] = int.Parse(arrayId[i]);
        //    }
        //    for (int i = 0; i < intarray.Length; i++)
        //    {
        //        int EmpId = intarray[i];
        //        //var IsExistData = db.Employees.Where(x => x.Id == intarray[i]).FirstOrDefault();
        //        var IsExistData = (from e in db.Employee where e.Id == EmpId select e).FirstOrDefault();
        //        db.Employee.Remove(IsExistData);
        //        db.SaveChanges();

        //    }
        //    return true;
        //}

        public EmployeeViewModel GetEmployeeById(int id)
        {
            var query = db.Employee.Where(x => x.Id == id).Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                EmployeeName = x.EmployeeName,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                Address = x.Address,
                ContactNumber = x.ContactNumber,
                Status = x.Status,

            }).FirstOrDefault();

            return query;
        }

        public List<EmployeeViewModel> ListEmployee()
        {
            var data = from x in db.Employee
                       join y in db.Department on x.DepartmentId equals y.DepartmentID into lftjoins
                       from y in    lftjoins.DefaultIfEmpty()
                       select new EmployeeViewModel
                       {
                Id = x.Id,
                EmployeeName = x.EmployeeName,
                DepartmentName = y.DepartmentName,
                Address = x.Address,
                ContactNumber = x.ContactNumber,
                Status = x.Status,
                
            };
            return data.ToList();
        }

        public bool UpdateEmployee(EmployeeViewModel model)
        {
         //   var data = new Employee();
         //   if (data != null)
          //  {
                var isExist = db.Employee.Where(x => x.Id == model.Id).FirstOrDefault();
                if (isExist != null)
                {
                    isExist.EmployeeName = model.EmployeeName;
                    isExist.DepartmentId = model.DepartmentId;
                    isExist.Address = model.Address;
                    isExist.ContactNumber = model.ContactNumber;
                    isExist.Status = model.Status;

                }

                db.SaveChanges();
           // }
            return true;
        }
    }
            


    //    public bool AddEmployee(EmployeeViewModel model)
    //    {
    //        var data = new Employee()
    //        {

    //            EmployeeName = model.EmployeeName,
    //            DepartmentId = model.DepartmentId,
    //            DepartmentName = model.DepartmentName,
    //            Address = model.Address,
    //            ContactNumber = model.ContactNumber,
    //            Status = model.Status,

    //        };
    //        db.Employee.Add(data);
    //        db.SaveChanges();
    //        return true;
    //    }

    //    public bool DeleteEmployee(string id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool DeleteEmployee(int id)
    //    { 
    //        var IsExistData = db.Employee.Where(x => x.Id == id).FirstOrDefault();
    //        db.Employee.Remove(IsExistData);
    //        db.SaveChanges();
    //        return true;
    //    }

    //    public EmployeeViewModel GetEmployeeById(int id)
    //    {
    //        var query = db.Employee.Where(x => x.Id == id).Select(x => new EmployeeViewModel
    //        {
    //            Id = x.Id,
    //            EmployeeName = x.EmployeeName,
    //            DepartmentId = x.DepartmentId,
    //            DepartmentName = x.DepartmentName,
    //            Address = x.Address,
    //            ContactNumber = x.ContactNumber,
    //            Status = x.Status,
    //        }).FirstOrDefault();

    //        return query;
    //    }

    //    public List<EmployeeViewModel> ListEmployee()
    //    {
    //        //var query = db.Employee.Select(x => new EmployeeViewModel()
    //        //{
    //        //    Id = x.Id,
    //        //    EmployeeName = x.EmployeeName,
    //        //    DepartmentId = x.DepartmentId,
    //        //    DepartmentName = x.DepartmentName,
    //        //    Address = x.Address,
    //        //    ContactNumber = x.ContactNumber,
    //        //    Status = x.Status,

    //        //}).ToList();
    //        //return query;
    //        var data = db.Employee.Select(x => new EmployeeViewModel
    //        {
    //            Id = x.Id,
    //            EmployeeName = x.EmployeeName,
    //            DepartmentId = x.DepartmentId,
    //            DepartmentName = x.DepartmentName,
    //            Address = x.Address,
    //            ContactNumber = x.ContactNumber,
    //            Status = x.Status,
    //        });
    //        return data.ToList();
    //    }

    //    public bool UpdateEmployee(EmployeeViewModel model)
    //    {
    //        var data = new Employee();
    //        if (data != null)
    //        {
    //            data.EmployeeName = model.EmployeeName;
    //            data.DepartmentId = model.DepartmentId;
    //            data.DepartmentName = model.DepartmentName;
    //            data.Address = model.Address;
    //            data.ContactNumber = model.ContactNumber;
    //            data.Status = model.Status;

    //        }
    //        db.SaveChanges();
    //        return true;
    //    }
        
    //}

     
    }

        //    public EmployeeServices ()
        //    {
        //        db = new DataContext();
        //    }

        //    public void DeleteEmployee(int id)
        //    {

        //        var IsExistData = db.Employee.Where(x => x.Id == id).FirstOrDefault();
        //        db.Employee.Remove(IsExistData);
        //        db.SaveChanges();

        //    }

        //   public void AddEmployee(EmployeeViewModel model)
        //    {
        //        var data = new Employee() {

        //            EmployeeName = model.EmployeeName,
        //            DepartmentId = model.DepartmentId,
        //            DepartmentName = model.DepartmentName,
        //            Address = model.Address,
        //            ContactNumber = model.ContactNumber,
        //            Status = model.Status,

        //        };
        //        db.Employee.Add(data);
        //        db.SaveChanges();
        //    }

        //    public void DeleteEmployee(string id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //   public EmployeeViewModel GetEmployeeById(int id)
        //    {
        //        var data = db.Employee.Where(x => x.Id == id).Select(x => new EmployeeViewModel
        //        {
        //            Id=x.Id,
        //            EmployeeName = x.EmployeeName,
        //            DepartmentId = x.DepartmentId,
        //            DepartmentName = x.DepartmentName,
        //            Address = x.Address,
        //            ContactNumber = x.ContactNumber,
        //            Status = x.Status,
        //        }).FirstOrDefault();
        //        return data;
        //    }

        //    public List<EmployeeViewModel> ListEmployee()
        //    {
        //        var query = db.Employee.Select(x => new EmployeeViewModel()
        //        {
        //            Id = x.Id,
        //            EmployeeName = x.EmployeeName,
        //            DepartmentId = x.DepartmentId,
        //            DepartmentName = x.DepartmentName,
        //            Address = x.Address,
        //            ContactNumber=x.ContactNumber,
        //            Status=x.Status,

        //        }).ToList();
        //        return query;
        //    }

        //    public void UpdateEmployee(EmployeeViewModel model)
        //    {

        //        var data = GetEmployeeById(model.Id);
        //        if (data != null)
        //        {

        //            data.EmployeeName = model.EmployeeName;
        //            data.DepartmentId = model.DepartmentId;
        //            data.DepartmentName = model.DepartmentName;
        //            data.Address = model.Address;
        //            data.ContactNumber = model.ContactNumber;
        //            data.Status=model.Status;

        //            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //}

        //    Employee IEmployeeServices.GetEmployeeById(int id)
        //    {
        //        throw new NotImplementedException();
        //    }
    
