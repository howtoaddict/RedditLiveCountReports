using LivecountStats.BusLayer.Automation;
using LivecountStats.BusLayer.Config;
using LivecountStats.BusLayer.Reports;
using LivecountStats.DataLayer;
using LivecountStats.DataLayer.Entity;
using LivecountStats.DataLayer.EntityTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivecountStats.App.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // populate data for dropdowns
            cmbEnvironment.SelectedIndex = 0;

            cmbTask.Items.Add("ImportDataTask");
            foreach (var item in _reports)
                cmbTask.Items.Add(item.WikiName);

            cmbTask.SelectedIndex = 0;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (db != null)
                db.Dispose();
        }

        private AppDataContext db = AppDataContext.CreateConnection();

        List<BaseReport> _reports = new List<BaseReport>
        {
            new Counters(), new DaysParticipation(), new Decimal999(), new DecimalGets(),  new HallOf3000DaysReport(),
            new HallOfNewcomers(), new HallOfParticipation(), new KsParticipation(), new PalindromeReport(),
            new Perfect500CountReport(), new Perfect500LocationReport(), new CountersP5M(), new From10kTo100k()
        };
        private void AutoexecuteForm_Load(object sender, EventArgs e)
        {
            refreshData();

            timer1.Enabled = true;
        }

        private void refreshData()
        {
            bindingSource1.DataSource = db.Autoexecs.ToList();
            BaseReport.RefreshLivecount();
        }

        // REFACTOR: There is better way... but who has time to code everything from backlog... ;(
        private async void btnExecute_Click(object sender, EventArgs e)
        {
            onTaskStart();

            BaseTask task = new ImportDataTask();
            if (cmbTask.SelectedIndex > 0)
            {
                task = new GenerateReportTask
                {
                    Report = _reports[cmbTask.SelectedIndex - 1],
                    Environment = cmbEnvironment.SelectedItem.ToString(),
                    WikiRevisionFormat = "Manual update of Report, {0}"
                };
            }

            await task.Execute();

            onTaskEnd();
        }

        private void onTaskStart()
        {
            btnExecute.Enabled = false;
            btnExecute.Text = "Please wait...";
        }

        private void onTaskEnd()
        {
            btnExecute.Text = "Execute";
            btnExecute.Enabled = true;
        }

        private bool _alreadyRunning = false;
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (_alreadyRunning)
                return;

            _alreadyRunning = true;
            onTaskStart();

            var pendingTasks = db.Autoexecs.Where(a => a.NextRunTime < DateTime.UtcNow).OrderBy(a => a.NextRunTime).ToList();

            var hasDbUpdate = await processPendingTasks(pendingTasks);

            lblAutoexecStatus.Text = "";
            if (hasDbUpdate)
            {
                db.SaveChanges();
                refreshData();
            }

            onTaskEnd();
            _alreadyRunning = false;
        }

        private async Task<bool> processPendingTasks(List<Autoexec> pendingTasks)
        {
            var hasDbUpdate = false;
            foreach (var dbItem in pendingTasks)
            {
                BaseTask task = parseTask(dbItem);
                var statusString = $"Running '{task}'";
                lblAutoexecStatus.Text = statusString;

                task.Update += (sender, param) =>
                {
                    lblAutoexecStatus.Text = $"{statusString} - {param}";
                };

                try
                {
                    await task.Execute();
                    dbItem.NextRunTime = CalcNextRuntime(dbItem.NextRunTime, dbItem.RepeatUnit, dbItem.RepeatValue);
                    hasDbUpdate = true;
                }
                catch (Exception ex)
                {
                    lblAutoexecError.Text = $"{DateTime.Now} - Task '{task}' failed! Exception {ex}";
                    return hasDbUpdate;
                }
            }

            return hasDbUpdate;
        }

        private void Task_Update1(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void Task_Update(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private BaseTask parseTask(Autoexec dbItem)
        {
            BaseTask task = new ImportDataTask();
            if (dbItem.TaskName == "GenerateReport")
            {
                var pars = dbItem.TaskParams.Trim().Split('/');
                task = new GenerateReportTask
                {
                    Environment = pars[0],
                    Report = _reports.Single(a => a.WikiName == pars[1])
                };
            }

            return task;
        }

        public static DateTime CalcNextRuntime(DateTime dateTime, RepeatUnits unit, int val)
        {
            var resultData = DateTime.MaxValue;
            if (unit == RepeatUnits.Second)
                resultData = dateTime.AddSeconds(val);
            else if (unit == RepeatUnits.Minute)
                resultData = dateTime.AddMinutes(val);
            else if (unit == RepeatUnits.Hour)
                resultData = dateTime.AddHours(val);
            else if (unit == RepeatUnits.Day)
                resultData = dateTime.AddDays(val);

            if (resultData < DateTime.UtcNow)
            {
                // wherever you can, put some recursion into your code... makes it more fancy
                resultData = CalcNextRuntime(DateTime.UtcNow, unit, val);
            }

            return resultData;
        }



        // NOTIFY ICON STUFF
        private bool FirstRefresh = RedditSettings.Instance.MinimizeOnStart;
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (FirstRefresh)
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;

                FirstRefresh = false;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }
    }
}
