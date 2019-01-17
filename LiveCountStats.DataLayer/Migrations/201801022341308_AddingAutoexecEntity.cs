namespace LivecountStats.DataLayer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAutoexecEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autoexec",
                c => new
                    {
                        AutoexectId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(maxLength: 50),
                        TaskParams = c.String(maxLength: 50),
                        NextRunTime = c.DateTime(nullable: false),
                        RepeatUnit = c.Int(nullable: false),
                        RepeatValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AutoexectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Autoexec");
        }
    }
}
