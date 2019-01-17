using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;

namespace LivecountStats.BusLayer.Reports
{
    public class PalindromeReport : BaseReport
    {
        public override string WikiName => "hall_of_palindromes";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of Palindromes

Palindromes are numbers which are the same backwards or forwards.

");

            sb.AppendLine("| # |Username|Palindromes");
        }

        protected override void appendFooter(StringBuilder sb)
        {
            sb.AppendLine(@"

###Palindromes

####[1k - 2000k](/r/livecounting/wiki/hall_of_palindromes_2m)
####[2001k - 4000k](/r/livecounting/wiki/hall_of_palindromes_4m)
");
        }

        public class Item
        {
            public long Pos { get; set; }
            public string Author { get; set; }
            public int Palindromes { get; set; }

            public override string ToString()
            {
                return String.Format("|{0}|/u/{1}|{2}|", Pos, Author, Palindromes);
            }
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.SqlList<Item>(sql, null);
        }

        const string sql = @"
SELECT ROW_NUMBER() OVER (ORDER BY Palindromes DESC) Pos, Author, Palindromes
FROM (
	SELECT author, Count(*) Palindromes
	FROM dbo.CountMessage
	WHERE author IS NOT NULL AND stricken = 0
		AND counter > 1000 AND counter = CAST(REVERSE(CAST(counter AS bigint)) AS bigint)
	GROUP BY author
) o
WHERE Palindromes >= 5
";
    }
}
