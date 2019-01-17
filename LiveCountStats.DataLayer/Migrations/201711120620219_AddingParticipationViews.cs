namespace LivecountStats.DataLayer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingParticipationViews : DbMigration
    {
        public override void Up()
        {
            Sql(@"
CREATE VIEW dbo.ViewParticipThread AS
SELECT ROW_NUMBER() OVER (ORDER BY KsParticipation DESC) Pos, Author, KsParticipation
FROM
	(SELECT Author, COUNT(*) KsParticipation
	FROM (
		SELECT author, counter/1000 K
		FROM dbo.CountMessage
		WHERE author IS NOT NULL AND stricken = 0
		GROUP BY author, counter/1000
	) o
	GROUP BY author
) t
");

            Sql(@"
--DECLARE @Localtimezone int -- EST
--SET @Localtimezone = -21600

CREATE VIEW dbo.ViewParticipDay AS
SELECT ROW_NUMBER() OVER (ORDER BY DaysParticipation DESC) Pos, t.Author, t.DaysParticipation
FROM (
	SELECT author, COUNT(*) DaysParticipation
	FROM (
		SELECT Author, 1 Parcipated
		FROM dbo.CountMessage
		WHERE author IS NOT NULL AND stricken = 0
		GROUP BY Author, CAST(DATEADD(s, created_utc + -21600, '1970-01-01 00:00:00') AS DATE)
		) o
	GROUP BY author
	) t
");
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewParticipThread");
            DropTable("dbo.ViewParticipDay");
        }
    }
}
