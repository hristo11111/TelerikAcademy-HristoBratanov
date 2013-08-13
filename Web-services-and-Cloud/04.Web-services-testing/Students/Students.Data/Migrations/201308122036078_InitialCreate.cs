namespace Students.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FristName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MarkStudents",
                c => new
                    {
                        Mark_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mark_Id, t.Student_Id })
                .ForeignKey("dbo.Marks", t => t.Mark_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Mark_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.MarkStudents", new[] { "Student_Id" });
            DropIndex("dbo.MarkStudents", new[] { "Mark_Id" });
            DropIndex("dbo.Students", new[] { "SchoolId" });
            DropForeignKey("dbo.MarkStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.MarkStudents", "Mark_Id", "dbo.Marks");
            DropForeignKey("dbo.Students", "SchoolId", "dbo.Schools");
            DropTable("dbo.MarkStudents");
            DropTable("dbo.Schools");
            DropTable("dbo.Marks");
            DropTable("dbo.Students");
        }
    }
}
