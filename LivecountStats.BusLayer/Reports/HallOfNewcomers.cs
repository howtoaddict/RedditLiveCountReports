using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;
using LivecountStats.DataLayer.EntityView;

namespace LivecountStats.BusLayer.Reports
{
    public class HallOfNewcomers : BaseReport
    {
        public override string WikiName => "hall_of_newcomers";

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            const string sql = @"
SELECT ROW_NUMBER() OVER (ORDER BY Counts DESC) Pos, *
FROM (
	SELECT author, COUNT(*) Counts
	FROM dbo.CountMessage
	GROUP BY author
	HAVING MIN(CAST(DATEADD(s, created_utc + - 21600, '1970-01-01 00:00:00') AS DATE)) >= DATEADD(d, -7, GETDATE())
) o

";

            return db.SqlList<ViewCounter>(sql, null).ToList();
        }

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of Newcomers

Celebrating those that have joined Live Counting in last 7 days!

");

            sb.AppendLine("|# | Username | Counts");
        }
    }
}
