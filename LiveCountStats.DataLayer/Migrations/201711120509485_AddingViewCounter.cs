namespace LivecountStats.DataLayer
{
    using LivecountStats.DataLayer.EntityView;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingViewCounter : DbMigration
    {
        public override void Up()
        {
            var sql = @"CREATE VIEW dbo.ViewCounter AS 
SELECT ROW_NUMBER() OVER(ORDER BY Counts DESC) Pos, t.Author, t.Counts
FROM(
   SELECT Author, COUNT(*) Counts

   FROM (
       SELECT*
       FROM dbo.CountMessage
       WHERE author IS NOT NULL AND stricken = 0 AND counter IS NOT NULL

   ) o
   GROUP BY o.Author
) t
";
            Sql(sql);
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewCounter");
        }
    }
}
