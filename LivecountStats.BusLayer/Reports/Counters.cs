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
    public class Counters : BaseReport
    {
        public override string WikiName => "hall_of_counters";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of Counters

A place to celebrate the greatest counters in [Live Counting](https://www.reddit.com/live/ta535s1hq2je). 

(Hall of Counters Per 100k can be accessed [here](https://www.reddit.com/r/livecounting/wiki/hoc_index))

");

            sb.AppendLine("| # |Username|Counts");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.ViewCounters.ToList();
        }
    }
}
