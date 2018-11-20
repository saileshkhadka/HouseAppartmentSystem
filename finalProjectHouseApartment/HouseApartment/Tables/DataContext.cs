using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
   public class DataContext:DbContext
    {
        public DataContext():base("name=DefaultConnection")
        {
                
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Listing> Listing { get; set; }
        public DbSet<ListingAttachment> ListingAttachment{get;set;}
        public DbSet<Notice> Notice{get;set;}
        public DbSet<NoticeAttachment> NoticeAttachment { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationPerson> NotificationPerson { get; set; }
        public DbSet <Employee>Employee { get; set; }
        public DbSet <Department>Department { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
