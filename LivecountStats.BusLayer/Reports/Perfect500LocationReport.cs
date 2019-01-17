using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;

namespace LivecountStats.BusLayer.Reports
{
    public class Perfect500LocationReport : BaseReport
    {
        public override string WikiName => "perfect_500_location";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Perfect 500 Location

From which count Perfect 500 started.

");

            sb.AppendLine("| # |Username|Perfect500 Starts at");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.SqlList<Item>(sql, null);
        }

        const string sql = @"
SELECT ROW_NUMBER() OVER (ORDER BY StartedAt DESC) Pos, Author, StartedAt
FROM (
	SELECT author, Count(*) KCount, MIN (counter) StartedAt
	FROM dbo.CountMessage
    WHERE author IS NOT NULL AND stricken = 0
	GROUP BY author, counter/1000
) o
WHERE o.KCount = 500
ORDER BY StartedAt DESC
";

        public class Item
        {
            public long Pos { get; set; }
            public string Author { get; set; }
            public int StartedAt { get; set; }

            public override string ToString()
            {
                return String.Format("|{0}|/u/{1}|{2}|", Pos, Author, StartedAt);
            }
        }
    }
}
