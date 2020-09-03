namespace LearnToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Capacity = c.Int(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsTeacher = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Grade = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersCourses",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Courses_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Courses_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.Courses_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersCourses", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.UsersCourses", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersCourses", new[] { "Courses_Id" });
            DropIndex("dbo.UsersCourses", new[] { "Users_Id" });
            DropTable("dbo.UsersCourses");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
        }
    }
}
