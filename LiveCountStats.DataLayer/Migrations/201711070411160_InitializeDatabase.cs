namespace LivecountStats.DataLayer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountMessage",
                c => new
                    {
                        CountMessageId = c.Int(nullable: false, identity: true),
                        body = c.String(),
                        author = c.String(maxLength: 50),
                        stricken = c.Boolean(nullable: false),
                        id = c.String(maxLength: 50),
                        name = c.String(maxLength: 100),
                        created_utc = c.Int(nullable: false),
                        counter = c.Int(),
                    })
                .PrimaryKey(t => t.CountMessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CountMessage");
        }
    }
}
