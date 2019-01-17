namespace LivecountStats.DataLayer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIndexOnCounter : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CountMessage", "counter");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CountMessage", new[] { "counter" });
        }
    }
}
