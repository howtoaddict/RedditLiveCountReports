using LivecountStats.DataLayer;
using LivecountStats.DataLayer.Entity;
using LivecountStats.BusLayer.Reports;
using RedditSharp;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivecountStats.BusLayer.Automation;

namespace LivecountStats.App.UI
{
    public partial class LegacyMainForm : Form
    {
        public LegacyMainForm()
        {
            InitializeComponent();

            cmbSubreddit.SelectedIndex = 0;
        }

        private async void btnimportLiveData_Click(object sender, EventArgs e)
        {
            btnimportLiveData.Enabled = false;

            var importTask = new ImportDataTask();
            var result = await importTask.Execute();

            btnimportLiveData.Enabled = true;
        }

        [Obsolete("Moved to new MainForm")]
        private void uploadReport(string wikiName, string content)
        {

        }

        private void btn500Count_Click(object sender, EventArgs e)
        {
            var report = new Perfect500CountReport();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btn500Location_Click(object sender, EventArgs e)
        {
            var report = new Perfect500LocationReport();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnPalindromes_Click(object sender, EventArgs e)
        {
            var report = new PalindromeReport();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var report = new KsParticipation();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnDaysParticipation_Click(object sender, EventArgs e)
        {
            var report = new DaysParticipation();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnDecimal999_Click(object sender, EventArgs e)
        {
            var report = new Decimal999();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnDecimalGets_Click(object sender, EventArgs e)
        {
            var report = new DecimalGets();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnHallOfParticipation_Click(object sender, EventArgs e)
        {
            var report = new HallOfParticipation();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnHallOfNewcomers_Click(object sender, EventArgs e)
        {
            var report = new HallOfNewcomers();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnCounters_Click(object sender, EventArgs e)
        {
            var report = new Counters();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }

        private void btnDays3000_Click(object sender, EventArgs e)
        {
            var report = new HallOf3000DaysReport();
            uploadReport(report.WikiName, report.ReportMarkdown());
        }
    }
}
