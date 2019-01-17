namespace LivecountStats.App.UI
{
    partial class LegacyMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnimportLiveData = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn500Count = new System.Windows.Forms.Button();
            this.btn500Location = new System.Windows.Forms.Button();
            this.btnPalindromes = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDays3000 = new System.Windows.Forms.Button();
            this.btnHallOfNewcomers = new System.Windows.Forms.Button();
            this.btnHallOfParticipation = new System.Windows.Forms.Button();
            this.btnDecimalGets = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCounters = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDecimal999 = new System.Windows.Forms.Button();
            this.btnDaysParticipation = new System.Windows.Forms.Button();
            this.cmbSubreddit = new System.Windows.Forms.ComboBox();
            this.btnKsParticipation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnimportLiveData
            // 
            this.btnimportLiveData.Location = new System.Drawing.Point(458, 39);
            this.btnimportLiveData.Name = "btnimportLiveData";
            this.btnimportLiveData.Size = new System.Drawing.Size(160, 23);
            this.btnimportLiveData.TabIndex = 3;
            this.btnimportLiveData.Text = "Import Live Data";
            this.btnimportLiveData.UseVisualStyleBackColor = true;
            this.btnimportLiveData.Click += new System.EventHandler(this.btnimportLiveData_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(440, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "https://www.reddit.com/live/ta535s1hq2je.json?before={0}&limit=100";
            // 
            // btn500Count
            // 
            this.btn500Count.Location = new System.Drawing.Point(6, 48);
            this.btn500Count.Name = "btn500Count";
            this.btn500Count.Size = new System.Drawing.Size(174, 23);
            this.btn500Count.TabIndex = 5;
            this.btn500Count.Text = "500 Count";
            this.btn500Count.UseVisualStyleBackColor = true;
            this.btn500Count.Click += new System.EventHandler(this.btn500Count_Click);
            // 
            // btn500Location
            // 
            this.btn500Location.Location = new System.Drawing.Point(6, 77);
            this.btn500Location.Name = "btn500Location";
            this.btn500Location.Size = new System.Drawing.Size(174, 23);
            this.btn500Location.TabIndex = 6;
            this.btn500Location.Text = "500 Location";
            this.btn500Location.UseVisualStyleBackColor = true;
            this.btn500Location.Click += new System.EventHandler(this.btn500Location_Click);
            // 
            // btnPalindromes
            // 
            this.btnPalindromes.Location = new System.Drawing.Point(218, 106);
            this.btnPalindromes.Name = "btnPalindromes";
            this.btnPalindromes.Size = new System.Drawing.Size(174, 23);
            this.btnPalindromes.TabIndex = 7;
            this.btnPalindromes.Text = "Palindromes";
            this.btnPalindromes.UseVisualStyleBackColor = true;
            this.btnPalindromes.Click += new System.EventHandler(this.btnPalindromes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDays3000);
            this.groupBox1.Controls.Add(this.btnHallOfNewcomers);
            this.groupBox1.Controls.Add(this.btnHallOfParticipation);
            this.groupBox1.Controls.Add(this.btnDecimalGets);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCounters);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDecimal999);
            this.groupBox1.Controls.Add(this.btnDaysParticipation);
            this.groupBox1.Controls.Add(this.cmbSubreddit);
            this.groupBox1.Controls.Add(this.btnKsParticipation);
            this.groupBox1.Controls.Add(this.btn500Count);
            this.groupBox1.Controls.Add(this.btnPalindromes);
            this.groupBox1.Controls.Add(this.btn500Location);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 294);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Generation";
            // 
            // btnDays3000
            // 
            this.btnDays3000.Location = new System.Drawing.Point(218, 135);
            this.btnDays3000.Name = "btnDays3000";
            this.btnDays3000.Size = new System.Drawing.Size(174, 23);
            this.btnDays3000.TabIndex = 18;
            this.btnDays3000.Text = "Days 3000";
            this.btnDays3000.UseVisualStyleBackColor = true;
            this.btnDays3000.Click += new System.EventHandler(this.btnDays3000_Click);
            // 
            // btnHallOfNewcomers
            // 
            this.btnHallOfNewcomers.Location = new System.Drawing.Point(6, 263);
            this.btnHallOfNewcomers.Name = "btnHallOfNewcomers";
            this.btnHallOfNewcomers.Size = new System.Drawing.Size(174, 23);
            this.btnHallOfNewcomers.TabIndex = 17;
            this.btnHallOfNewcomers.Text = "Hall of Newcomers";
            this.btnHallOfNewcomers.UseVisualStyleBackColor = true;
            this.btnHallOfNewcomers.Click += new System.EventHandler(this.btnHallOfNewcomers_Click);
            // 
            // btnHallOfParticipation
            // 
            this.btnHallOfParticipation.Location = new System.Drawing.Point(6, 234);
            this.btnHallOfParticipation.Name = "btnHallOfParticipation";
            this.btnHallOfParticipation.Size = new System.Drawing.Size(174, 23);
            this.btnHallOfParticipation.TabIndex = 16;
            this.btnHallOfParticipation.Text = "Hall of Participation";
            this.btnHallOfParticipation.UseVisualStyleBackColor = true;
            this.btnHallOfParticipation.Click += new System.EventHandler(this.btnHallOfParticipation_Click);
            // 
            // btnDecimalGets
            // 
            this.btnDecimalGets.Location = new System.Drawing.Point(218, 77);
            this.btnDecimalGets.Name = "btnDecimalGets";
            this.btnDecimalGets.Size = new System.Drawing.Size(174, 23);
            this.btnDecimalGets.TabIndex = 15;
            this.btnDecimalGets.Text = "Decimal Gets";
            this.btnDecimalGets.UseVisualStyleBackColor = true;
            this.btnDecimalGets.Click += new System.EventHandler(this.btnDecimalGets_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Others maintaining";
            // 
            // btnCounters
            // 
            this.btnCounters.Location = new System.Drawing.Point(6, 164);
            this.btnCounters.Name = "btnCounters";
            this.btnCounters.Size = new System.Drawing.Size(174, 23);
            this.btnCounters.TabIndex = 13;
            this.btnCounters.Text = "Counters";
            this.btnCounters.UseVisualStyleBackColor = true;
            this.btnCounters.Click += new System.EventHandler(this.btnCounters_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Need to implement range reports";
            // 
            // btnDecimal999
            // 
            this.btnDecimal999.Location = new System.Drawing.Point(218, 48);
            this.btnDecimal999.Name = "btnDecimal999";
            this.btnDecimal999.Size = new System.Drawing.Size(174, 23);
            this.btnDecimal999.TabIndex = 11;
            this.btnDecimal999.Text = "Decimal 999 (lup)";
            this.btnDecimal999.UseVisualStyleBackColor = true;
            this.btnDecimal999.Click += new System.EventHandler(this.btnDecimal999_Click);
            // 
            // btnDaysParticipation
            // 
            this.btnDaysParticipation.Location = new System.Drawing.Point(6, 135);
            this.btnDaysParticipation.Name = "btnDaysParticipation";
            this.btnDaysParticipation.Size = new System.Drawing.Size(174, 23);
            this.btnDaysParticipation.TabIndex = 10;
            this.btnDaysParticipation.Text = "Days Participation";
            this.btnDaysParticipation.UseVisualStyleBackColor = true;
            this.btnDaysParticipation.Click += new System.EventHandler(this.btnDaysParticipation_Click);
            // 
            // cmbSubreddit
            // 
            this.cmbSubreddit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubreddit.FormattingEnabled = true;
            this.cmbSubreddit.Items.AddRange(new object[] {
            "Test_Piyush",
            "livecounting"});
            this.cmbSubreddit.Location = new System.Drawing.Point(6, 19);
            this.cmbSubreddit.Name = "cmbSubreddit";
            this.cmbSubreddit.Size = new System.Drawing.Size(174, 21);
            this.cmbSubreddit.TabIndex = 9;
            // 
            // btnKsParticipation
            // 
            this.btnKsParticipation.Location = new System.Drawing.Point(6, 106);
            this.btnKsParticipation.Name = "btnKsParticipation";
            this.btnKsParticipation.Size = new System.Drawing.Size(174, 23);
            this.btnKsParticipation.TabIndex = 8;
            this.btnKsParticipation.Text = "Ks Participation";
            this.btnKsParticipation.UseVisualStyleBackColor = true;
            this.btnKsParticipation.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 362);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnimportLiveData);
            this.Name = "MainForm";
            this.Text = "Reddit LiveCounting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnimportLiveData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn500Count;
        private System.Windows.Forms.Button btn500Location;
        private System.Windows.Forms.Button btnPalindromes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnKsParticipation;
        private System.Windows.Forms.ComboBox cmbSubreddit;
        private System.Windows.Forms.Button btnDaysParticipation;
        private System.Windows.Forms.Button btnDecimal999;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHallOfParticipation;
        private System.Windows.Forms.Button btnDecimalGets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCounters;
        private System.Windows.Forms.Button btnHallOfNewcomers;
        private System.Windows.Forms.Button btnDays3000;
    }
}

