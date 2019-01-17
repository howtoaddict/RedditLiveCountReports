using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;

namespace LivecountStats.BusLayer.Reports
{
    public class DaysParticipation : BaseReport
    {
        public override string WikiName => "days_participation";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Days Participation

Number of days each user participated in counting.

");

            sb.AppendLine("| # |Username|Days Participated");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.ViewParticipDays.Where(a=>a.DaysParticipation > 5).ToList();
        }
    }
}
