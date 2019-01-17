using LivecountStats.BusLayer.Config;
using LivecountStats.BusLayer.Reports;
using RedditSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.BusLayer.Automation
{
    public class GenerateReportTask : BaseTask
    {
        public string WikiRevisionFormat { get; set; } = "Auto update of Report, {0}";
        public BaseReport Report { get; set; }

        public string Environment { get; set; }

        public override string ToString()
        {
            return String.Format("Generate Report r/{0}/wiki/{1}", Environment, Report.WikiName); 
        }

        public override async Task<int> Execute()
        {
            await uploadReport(Report.WikiName, Report.ReportMarkdown());
            return 0;
        }

        private async Task uploadReport(string wikiName, string content)
        {
            var rs = RedditSettings.Instance;
            var webAgent = new BotWebAgent(rs.Username, rs.Password, rs.ClientId, rs.ClientSecret, rs.RedirectUri);

            var reddit = new RedditSharp.Reddit(webAgent);
            var subreddit = await reddit.GetSubredditAsync(Environment);

            var reason = String.Format(WikiRevisionFormat, DateTime.Now.ToString("yyyy-MM-dd"));
            await subreddit.GetWiki.EditPageAsync(wikiName, content, reason: reason);
        }
    }
}
