using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;

namespace LivecountStats.BusLayer.Reports
{
    public class DecimalGets : BaseReport
    {
        public override string WikiName => "decimal_gets";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of Gets (000s)

Get is a count of number ending in 000. This is a place to celebrate the getters, whose count ended one thread and started another.

");

            sb.AppendLine("| # |Username|Gets");
        }

        protected override void appendFooter(StringBuilder sb)
        {
            sb.AppendLine(@"

###Halls

####[1k - 2000k](/r/livecounting/wiki/decimal_gets_2M)
####[2001k - 4000k](/r/livecounting/wiki/decimal_gets_4M)
####[4001k - 6000k](/r/livecounting/wiki/decimal_gets_6M)

");

            base.appendFooter(sb);
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.ViewGets.ToList();
        }
    }
}
