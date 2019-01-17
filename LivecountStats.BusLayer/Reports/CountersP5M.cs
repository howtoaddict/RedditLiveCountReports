using LivecountStats.DataLayer.EntityView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;
using System.Collections;

namespace LivecountStats.BusLayer.Reports
{
    public class CountersP5M : BaseReport
    {
        public override string WikiName => "hall_of_counters_p5m";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of Counters P5M

A place to celebrate rookies that just got into [Live Counting](https://www.reddit.com/live/ta535s1hq2je). Current cutoff is 5,000,000+, users who had less than 2,000 counts before.

");

            sb.AppendLine("| # |Username|Counts");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.SqlList<ViewCounter>(sql, null);
        }

        const string sql = @"
SELECT ROW_NUMBER() OVER (ORDER BY Counts DESC) Pos, t.Author, t.Counts
FROM (
	SELECT Author, COUNT(*) Counts
	FROM (
		SELECT *
		FROM dbo.CountMessage
		WHERE author IS NOT NULL
			AND stricken = 0
			AND counter IS NOT NULL
			AND counter > 5000000
			AND author NOT IN (
				SELECT VeteranName
				FROM dbo.Veteran
				)
		) o
	GROUP BY o.Author
	) t

";
    }
}
