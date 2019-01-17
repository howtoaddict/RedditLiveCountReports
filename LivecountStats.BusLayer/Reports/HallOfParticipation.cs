using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecountStats.DataLayer;
using LivecountStats.DataLayer.EntityView;

namespace LivecountStats.BusLayer.Reports
{
    public class HallOfParticipation : BaseReport
    {
        public override string WikiName => "participation";

        protected override IEnumerable ReportSql(AppDataContext db)
        {
            const string sql = @"
SELECT ROW_NUMBER() OVER (ORDER BY Score DESC) Pos, 
	t.*,
	((GetsRatio+AssistsRatio)/2) CombinedRatio
FROM (
	SELECT o.*, 
		(Counts * 2) + ((Gets + Assists)*500) + (KsParticipated * 250) + (DaysParticipated * 250) Score,
		(Gets + Assists) GetsAndAssists,
		(Gets * 1000.0 / Counts) GetsRatio,
		(Assists * 1000.0 / Counts) AssistsRatio
	FROM (
		SELECT 
			vc.author, 
			IsNull(vc.Counts, 0) Counts, 
			IsNull(vg.Gets, 0) Gets, 
			IsNull(va.Assists, 0) Assists, 
			IsNull(vt.KsParticipation, 0) KsParticipated, 
			IsNull(vd.DaysParticipation, 0) DaysParticipated
		FROM dbo.ViewCounter vc
			LEFT JOIN dbo.ViewGet vg ON vc.author = vg.author
			LEFT JOIN dbo.ViewAssist va ON vc.author = va.author
			LEFT JOIN dbo.ViewParticipThread vt ON vc.author = vt.author
			LEFT JOIN dbo.ViewParticipDay vd ON vc.author = vd.author
	) o
) t
";

            return db.SqlList<ViewHallParticipation>(sql, null).Take(30).ToList();
        }

        protected override void appendHeader(StringBuilder sb)
        {
            sb.AppendLine(@"##Hall of Participation

###Calculation Method

Score: (number of counts * 2) + ((Gets + Assists)*500) + (k's participated * 250) + (day's participated * 250)

Get Ratio: (# of gets * 1000) / number of counts

Assist Ratio: (# of assists * 1000) / number of counts

Combined Ratio: (Get Ratio + Assist Ratio) / 2

###Score Top 200

");

            sb.AppendLine("|# | Username | Score | Counts | Gets | Assists | Gets + Assists | Ks Participated |Days Participated |Gets Ratio |Assists Ratio |Combined Ratio");


            /* Backup section for others
##Combined Others(upto 3176k)

This chart combines all the stats of counters that are not TOP 20 into a single row.

Username | Score | No. of Counts | # of gets | # of assists | Gets + Assists | K's Participated | Day's Participated | Get Ratio | Assist Ratio | Combined Ratio | 
:--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | 
Combined Other | 2049146 | 201973| 336| 143| 479| 4286| 3342 | 1.66 | 0.71 | 1.19 | 
*/
        }

        protected override void appendHeadSplitter(StringBuilder sb)
        {
            sb.AppendLine("|:--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |---- ");
        }
    }
}
