using LivecountStats.DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.BusLayer.Reports
{
    public abstract class BaseReport
    {
        public abstract string WikiName { get; }
        protected abstract IEnumerable ReportSql(AppDataContext db);

        protected IEnumerable GenerateFromDb()
        {
            using (var db = AppDataContext.CreateConnection())
            {
                var list = ReportSql(db);
                return list;
            }
        }

        public string ReportMarkdown()
        {
            var list = GenerateFromDb();

            var sb = new StringBuilder();

            appendHeader(sb);
            appendHeadSplitter(sb);

            foreach (var item in list)
            {
                sb.AppendFormat(item.ToString());
                sb.AppendLine();
            }

            appendFooter(sb);

            var report = sb.ToString();
            return report;
        }

        protected virtual void appendHeader(StringBuilder sb)
        {
            sb.AppendLine("| # |Author|Value");
        }

        protected virtual void appendHeadSplitter(StringBuilder sb)
        {
            sb.AppendLine("|---|------|---------------");
        }

        public static int UpdatedUpToLivecount = 0;
        public static void RefreshLivecount()
        {
            using (var db = AppDataContext.CreateConnection())
            {
                // NOTE: You need to be sure to download all the data before generating reports
                // because otherwise this variable will not be properly initialized... will be null
                UpdatedUpToLivecount = db.SqlScalar<int?>(@"
SELECT MAX(counter)
FROM dbo.CountMessage
WHERE CountMessageId > 7144404 -- LOTS of garbage before
	AND stricken = 0") ?? 0;
            }
        }

        protected virtual void appendFooter(StringBuilder sb)
        {
            if (UpdatedUpToLivecount > 0)
            {
                var str = String.Format(@"

Updated up to: {0:N0}", UpdatedUpToLivecount);
                sb.AppendLine(str);
            }

            sb.AppendLine(@"

Thanks to /u/howtoaddict for these statistics.");
        }


    }
}
