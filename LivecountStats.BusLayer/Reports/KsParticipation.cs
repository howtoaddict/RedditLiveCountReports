using LivecountStats.DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.BusLayer.Reports
{
    public class KsParticipation : BaseReport
    {
        public override string WikiName => "ks_participation";

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##K's Participation

Number of K's each user participated in.

");

            sb.AppendLine("| # |Username|K's Participated");
        }

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            return db.ViewParticipThreads.Where(a => a.KsParticipation > 5).ToList();
        }
    }
}
