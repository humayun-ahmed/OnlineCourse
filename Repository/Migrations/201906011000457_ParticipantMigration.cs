namespace OnlineCourse.Repository
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParticipantMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        ParticipantId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        CourseId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipantId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participant", "CourseId", "dbo.Course");
            DropIndex("dbo.Participant", new[] { "CourseId" });
            DropTable("dbo.Participant");
        }
    }
}
