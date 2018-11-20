namespace HouseApartment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Address = c.String(),
                        ContactNumber = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        DepartmentName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        SquareFeet = c.String(),
                        AvailabilityDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        RentID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ListingAttachments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ListingID = c.Guid(nullable: false),
                        AttachmentName = c.String(),
                        AttachmentUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NoticeAttachments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NoticeID = c.Guid(nullable: false),
                        AttachmentName = c.String(),
                        AttachmentUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotifyID = c.Int(nullable: false, identity: true),
                        SourceID = c.Int(nullable: false),
                        SourceType = c.String(),
                        Message = c.String(),
                        ModifiedByID = c.Int(),
                        ModifiedTS = c.DateTime(),
                    })
                .PrimaryKey(t => t.NotifyID);
            
            CreateTable(
                "dbo.NotificationPersons",
                c => new
                    {
                        NotificationPersonID = c.Int(nullable: false, identity: true),
                        NotifyID = c.Int(),
                        UserID = c.Int(),
                        Viewed = c.Boolean(),
                        SourceID = c.Int(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.NotificationPersonID)
                .ForeignKey("dbo.Notifications", t => t.NotifyID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.NotifyID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailID = c.String(),
                        DateOfBirth = c.DateTime(),
                        Password = c.String(),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRolesId = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRolesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificationPersons", "UserID", "dbo.Users");
            DropForeignKey("dbo.NotificationPersons", "NotifyID", "dbo.Notifications");
            DropIndex("dbo.NotificationPersons", new[] { "UserID" });
            DropIndex("dbo.NotificationPersons", new[] { "NotifyID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.NotificationPersons");
            DropTable("dbo.Notifications");
            DropTable("dbo.NoticeAttachments");
            DropTable("dbo.Notices");
            DropTable("dbo.ListingAttachments");
            DropTable("dbo.Listings");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
