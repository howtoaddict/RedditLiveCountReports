using LivecountStats.BusLayer.Reports;
using LivecountStats.DataLayer;
using LivecountStats.DataLayer.Entity;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.BusLayer.Automation
{
    public class ImportDataTask : BaseTask
    {
        public override string ToString()
        {
            return "Import Data from Reddit";
        }

        private string DataSource => "https://www.reddit.com/live/ta535s1hq2je.json?before={0}&limit=100";

        public override async Task<int> Execute()
        {
            var urlFormat = DataSource;
            using (var db = AppDataContext.CreateConnection())
            {
                var lastItem = db.CountMessages.OrderByDescending(a => a.CountMessageId).FirstOrDefault();
                if (lastItem == null)
                    return 0;

                string finalUrl = String.Format(urlFormat, lastItem.name);
                int imported = 0;
                do
                {
                    string json = null;
                    using (var client = new WebClient())
                        json = await client.DownloadStringTaskAsync(finalUrl);

                    dynamic parsed = DynamicJson.Deserialize(json);
                    dynamic children = parsed.data.children;
                    if (children.Length == 0)
                    {
                        BaseReport.RefreshLivecount();
                        return imported; // BREAKING AND RETURNING
                    }

                    var list = new List<CountMessage>();
                    foreach (var child in children)
                    {
                        var str = child.data.ToString();
                        CountMessage cm = JsonSerializer.DeserializeFromString<CountMessage>(str);
                        cm.counter = extractCounter(cm.body);
                        cm.created_utc = (int)decimal.Parse(child.data.created_utc);
                        list.Add(cm);
                    }

                    list.Reverse();

                    db.CountMessages.AddRange(list);
                    db.SaveChanges();

                    var nextItem = list.Last();
                    finalUrl = String.Format(urlFormat, nextItem.name);

                    var dt = DateTimeOffset.FromUnixTimeSeconds(nextItem.created_utc);
                    OnUpdate(dt.ToString("yyyy-MM-dd HH:mm:ss"));
                } while (true);
            }
        }

        private int? extractCounter(string body)
        {
            string num = null;
            int i = 0;
            char delimiter = '+';
            for (int len = body.Length; i < len; i++)
            {
                char s = body[i];
                if (Char.IsDigit(s))
                {
                    num += s;
                    continue;
                }
                else if (s == ' ' || s == ',' || s == '.')
                {
                    if (delimiter == '+')
                        delimiter = s;

                    if (s != delimiter)
                        break;

                    continue;
                }
                else if (s == '~' || s == '^' || s == '#' ||
                        s == '*' || s == '>' || s == '`' || s == '\n')
                {
                    // Only allow special formatting characters if they are at 
                    // the start of the string
                    if (num == null)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (num == null)
                return null;
            else
            {
                try
                {
                    return int.Parse(num);
                }
                catch (OverflowException ex)
                {
                    return null;
                }
                catch (FormatException fex)
                {
                    return null;
                }
            }
        }
    }
}
