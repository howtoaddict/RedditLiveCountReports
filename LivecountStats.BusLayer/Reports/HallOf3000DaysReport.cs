using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;

namespace LivecountStats.BusLayer.Reports
{
    public class HallOf3000DaysReport : BaseReport
    {
        public override string WikiName => "hall_of_3000_days";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of 3000+ Days

How many days user had 3000 or more counts.

");

            sb.AppendLine("| # |Username|Days3000");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.SqlList<Item>(sql, null);
        }

        const string sql = @"
SELECT 
	ROW_NUMBER() OVER (ORDER BY Days3000 DESC) Pos, t.Author, t.Days3000
FROM (
	SELECT Author, Count(*) Days3000
	FROM (
		SELECT        Author, 1 AS Days3000
		FROM            dbo.CountMessage
		WHERE        author IS NOT NULL AND stricken = 0
		GROUP BY Author, CAST(DATEADD(s, created_utc + - 21600, '1970-01-01 00:00:00') AS DATE)
		HAVING Count(*) >= 3000
	) o
	GROUP BY Author
) t
";

        public class Item
        {
            public long Pos { get; set; }
            public string Author { get; set; }
            public int Days3000 { get; set; }

            public override string ToString()
            {
                return String.Format("|{0}|/u/{1}|{2:N0}|", Pos, Author, Days3000);
            }
        }
    }
}
