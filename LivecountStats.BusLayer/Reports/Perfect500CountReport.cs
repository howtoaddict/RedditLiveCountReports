using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;

namespace LivecountStats.BusLayer.Reports
{
    public class Perfect500CountReport : BaseReport
    {
        public override string WikiName => "perfect_500_count";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Perfect 500 Count

How many times user had Perfect 500 counts in thread (1000).
");

            sb.AppendLine("| # |Username|Perfect500s");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.SqlList<Item>(sql, null);
        }

        const string sql = @"
SELECT ROW_NUMBER() OVER (ORDER BY Count(*) DESC) Pos, Author, COUNT(*) Perfect500s
FROM (
	SELECT author, Count(*) KCount, MIN (counter) StartedAt
	FROM dbo.CountMessage
    WHERE author IS NOT NULL AND stricken = 0
	GROUP BY author, counter/1000
) o
WHERE o.KCount = 500
GROUP BY author
";

        public class Item
        {
            public long Pos { get; set; }
            public string Author { get; set; }
            public int Perfect500s { get; set; }

            public override string ToString()
            {
                return String.Format("|{0}|/u/{1}|{2}|", Pos, Author, Perfect500s);
            }
        }
    }
}
