namespace LivecountStats.DataLayer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGetsAssists : DbMigration
    {
        public override void Up()
        {
            Sql(@"
CREATE VIEW dbo.ViewAssist AS
SELECT ROW_NUMBER() OVER (ORDER BY Assists DESC) Pos, t.Author, t.Assists
FROM (
	SELECT Author, COUNT(*) Assists
	FROM (
		SELECT *
		FROM dbo.CountMessage
		WHERE author IS NOT NULL AND stricken = 0 AND CAST(counter AS varchar) LIKE '%999'
	) o
	GROUP BY o.Author
) t
");

            Sql(@"
CREATE VIEW dbo.ViewGet AS
SELECT ROW_NUMBER() OVER (ORDER BY Gets DESC) Pos, t.Author, t.Gets
FROM (
	SELECT Author, COUNT(*) Gets
	FROM (
		SELECT *
		FROM dbo.CountMessage
		WHERE author IS NOT NULL AND stricken = 0 AND CAST(counter AS varchar) LIKE '%000'
	) o
	GROUP BY o.Author
) t
");         
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewGet");
            DropTable("dbo.ViewAssist");
        }
    }
}
