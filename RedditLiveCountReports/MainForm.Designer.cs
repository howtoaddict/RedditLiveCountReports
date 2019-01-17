namespace LivecountStats.App.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cmbTask = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEnvironment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.taskNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskParamsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextRunTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repeatUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repeatValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAutoexecStatus = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblAutoexecError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExecute);
            this.groupBox1.Controls.Add(this.cmbTask);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEnvironment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Execution";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(390, 73);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(159, 23);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cmbTask
            // 
            this.cmbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTask.FormattingEnabled = true;
            this.cmbTask.Location = new System.Drawing.Point(255, 46);
            this.cmbTask.Name = "cmbTask";
            this.cmbTask.Size = new System.Drawing.Size(294, 21);
            this.cmbTask.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Task";
            // 
            // cmbEnvironment
            // 
            this.cmbEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnvironment.FormattingEnabled = true;
            this.cmbEnvironment.Items.AddRange(new object[] {
            "Test_Piyush",
            "livecounting"});
            this.cmbEnvironment.Location = new System.Drawing.Point(255, 19);
            this.cmbEnvironment.Name = "cmbEnvironment";
            this.cmbEnvironment.Size = new System.Drawing.Size(294, 21);
            this.cmbEnvironment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Environment";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(LivecountStats.DataLayer.Entity.Autoexec);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 388);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Execution";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskNameDataGridViewTextBoxColumn,
            this.taskParamsDataGridViewTextBoxColumn,
            this.nextRunTimeDataGridViewTextBoxColumn,
            this.repeatUnitDataGridViewTextBoxColumn,
            this.repeatValueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(568, 325);
            this.dataGridView1.TabIndex = 0;
            // 
            // taskNameDataGridViewTextBoxColumn
            // 
            this.taskNameDataGridViewTextBoxColumn.DataPropertyName = "TaskName";
            this.taskNameDataGridViewTextBoxColumn.HeaderText = "TaskName";
            this.taskNameDataGridViewTextBoxColumn.Name = "taskNameDataGridViewTextBoxColumn";
            this.taskNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taskParamsDataGridViewTextBoxColumn
            // 
            this.taskParamsDataGridViewTextBoxColumn.DataPropertyName = "TaskParams";
            this.taskParamsDataGridViewTextBoxColumn.FillWeight = 200F;
            this.taskParamsDataGridViewTextBoxColumn.HeaderText = "TaskParams";
            this.taskParamsDataGridViewTextBoxColumn.Name = "taskParamsDataGridViewTextBoxColumn";
            this.taskParamsDataGridViewTextBoxColumn.ReadOnly = true;
            this.taskParamsDataGridViewTextBoxColumn.Width = 200;
            // 
            // nextRunTimeDataGridViewTextBoxColumn
            // 
            this.nextRunTimeDataGridViewTextBoxColumn.DataPropertyName = "NextRunTime";
            this.nextRunTimeDataGridViewTextBoxColumn.HeaderText = "NextRunTime";
            this.nextRunTimeDataGridViewTextBoxColumn.Name = "nextRunTimeDataGridViewTextBoxColumn";
            this.nextRunTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // repeatUnitDataGridViewTextBoxColumn
            // 
            this.repeatUnitDataGridViewTextBoxColumn.DataPropertyName = "RepeatUnit";
            this.repeatUnitDataGridViewTextBoxColumn.FillWeight = 70F;
            this.repeatUnitDataGridViewTextBoxColumn.HeaderText = "RepeatUnit";
            this.repeatUnitDataGridViewTextBoxColumn.Name = "repeatUnitDataGridViewTextBoxColumn";
            this.repeatUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.repeatUnitDataGridViewTextBoxColumn.Width = 70;
            // 
            // repeatValueDataGridViewTextBoxColumn
            // 
            this.repeatValueDataGridViewTextBoxColumn.DataPropertyName = "RepeatValue";
            this.repeatValueDataGridViewTextBoxColumn.FillWeight = 80F;
            this.repeatValueDataGridViewTextBoxColumn.HeaderText = "RepeatValue";
            this.repeatValueDataGridViewTextBoxColumn.Name = "repeatValueDataGridViewTextBoxColumn";
            this.repeatValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.repeatValueDataGridViewTextBoxColumn.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAutoexecError);
            this.panel1.Controls.Add(this.lblAutoexecStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 44);
            this.panel1.TabIndex = 1;
            // 
            // lblAutoexecStatus
            // 
            this.lblAutoexecStatus.AutoSize = true;
            this.lblAutoexecStatus.Location = new System.Drawing.Point(9, 7);
            this.lblAutoexecStatus.Name = "lblAutoexecStatus";
            this.lblAutoexecStatus.Size = new System.Drawing.Size(85, 13);
            this.lblAutoexecStatus.TabIndex = 0;
            this.lblAutoexecStatus.Text = "                          ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Livecount Stats";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // lblAutoexecError
            // 
            this.lblAutoexecError.AutoSize = true;
            this.lblAutoexecError.Location = new System.Drawing.Point(9, 20);
            this.lblAutoexecError.Name = "lblAutoexecError";
            this.lblAutoexecError.Size = new System.Drawing.Size(85, 13);
            this.lblAutoexecError.TabIndex = 1;
            this.lblAutoexecError.Text = "                          ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 495);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Livecount Stats";
            this.Load += new System.EventHandler(this.AutoexecuteForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cmbTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEnvironment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskParamsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextRunTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repeatUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repeatValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAutoexecStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblAutoexecError;
    }
}