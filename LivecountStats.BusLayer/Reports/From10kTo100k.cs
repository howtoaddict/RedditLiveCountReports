using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;

namespace LivecountStats.BusLayer.Reports
{
    public class From10kTo100k : BaseReport
    {
        public override string WikiName => "from_10k_to_100k";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##From 10,000 to 100,000

How many days user needed to go from 10k counts to 100k counts.

");

            sb.AppendLine("| # |Username|DaysNeeded");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.SqlList<Item>(sql, null);
        }

        const string sql = @"
IF OBJECT_ID('tempdb..#MessagesNumber') IS NOT NULL DROP TABLE #MessagesNumber

SELECT *
INTO #MessagesNumber
FROM (
	SELECT author, ROW_NUMBER() OVER (PARTITION BY author ORDER BY countmessageid ASC) Cm, created_utc
	FROM dbo.CountMessage
	WHERE stricken = 0 and author IN (
		SELECT author
		FROM dbo.CountMessage
		WHERE stricken = 0 AND counter IS NOT NULL
		GROUP BY author
		HAVING Count(*) > 100000
	)
) t
WHERE Cm = 100000 OR Cm = 10000


SELECT 
	ROW_NUMBER() OVER (ORDER BY diff ASC) Pos,
	Author, 
	diff / (60 * 60 * 24) [DaysNeeded]
FROM (
	SELECT author,
		(SELECT created_utc FROM #MessagesNumber WHERE Cm = 100000 AND #MessagesNumber.author = mn.author) - 
		(SELECT created_utc FROM #MessagesNumber WHERE Cm = 10000 AND #MessagesNumber.author = mn.author) diff
	FROM #MessagesNumber mn
	GROUP BY author
) o
";

        public class Item
        {
            public long Pos { get; set; }
            public string Author { get; set; }
            public int DaysNeeded { get; set; }

            public override string ToString()
            {
                return String.Format("|{0}|/u/{1}|{2:N0}|", Pos, Author, DaysNeeded);
            }
        }
    }
}
