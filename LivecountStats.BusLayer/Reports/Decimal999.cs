using LivecountStats.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LivecountStats.BusLayer.Reports
{
    public class Decimal999 : BaseReport
    {
        public override string WikiName => "999";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of Assists (999s)

A place to celebrate the assisters, for behind every getter is a trusty assister.

To find an assist for a given get, go to the get itself, then in the url change the '/updates/' to '?after=LiveUpdate_'

");

            sb.AppendLine("| # |Username|Assists");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.ViewAssists.ToList();
        }

        protected override void appendFooter(StringBuilder sb)
        {
            sb.AppendLine(@"

###Halls

####[1k - 2000k](/r/livecounting/wiki/decimal_assists_2M)
####[2001k - 4000k](/r/livecounting/wiki/decimal_assists_4M)
####[4001k - 6000k](/r/livecounting/wiki/decimal_assists_6M)

");

            base.appendFooter(sb);
        }
    }
}
