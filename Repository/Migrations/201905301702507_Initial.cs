namespace OnlineCourse.Repository
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Long(nullable: false, identity: true),
                        LastUpdated = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Teacher = c.String(maxLength: 1000),
                        MaxParticipants = c.Int(nullable: false),
                        CourseGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .Index(t => t.CourseGuid, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Course", new[] { "CourseGuid" });
            DropTable("dbo.Course");
        }
    }
}
