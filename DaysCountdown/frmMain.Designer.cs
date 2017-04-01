namespace DaysCountdown
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.prbDays = new System.Windows.Forms.ProgressBar();
            this.grbStatus = new System.Windows.Forms.GroupBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.prbMinutes = new System.Windows.Forms.ProgressBar();
            this.lblHours = new System.Windows.Forms.Label();
            this.prbHours = new System.Windows.Forms.ProgressBar();
            this.lblDays = new System.Windows.Forms.Label();
            this.grbSetting = new System.Windows.Forms.GroupBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.dtpDueDay = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerNow = new System.Windows.Forms.Timer(this.components);
            this.grbStatus.SuspendLayout();
            this.grbSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // prbDays
            // 
            this.prbDays.BackColor = System.Drawing.Color.Black;
            this.prbDays.Location = new System.Drawing.Point(82, 25);
            this.prbDays.Name = "prbDays";
            this.prbDays.Size = new System.Drawing.Size(632, 45);
            this.prbDays.TabIndex = 0;
            // 
            // grbStatus
            // 
            this.grbStatus.BackColor = System.Drawing.Color.Black;
            this.grbStatus.Controls.Add(this.lblMinutes);
            this.grbStatus.Controls.Add(this.prbMinutes);
            this.grbStatus.Controls.Add(this.lblHours);
            this.grbStatus.Controls.Add(this.prbHours);
            this.grbStatus.Controls.Add(this.lblDays);
            this.grbStatus.Controls.Add(this.prbDays);
            this.grbStatus.ForeColor = System.Drawing.Color.White;
            this.grbStatus.Location = new System.Drawing.Point(12, 25);
            this.grbStatus.Name = "grbStatus";
            this.grbStatus.Size = new System.Drawing.Size(735, 185);
            this.grbStatus.TabIndex = 1;
            this.grbStatus.TabStop = false;
            this.grbStatus.Text = "Countdown Status";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(9, 140);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(73, 23);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "Minutes";
            // 
            // prbMinutes
            // 
            this.prbMinutes.Location = new System.Drawing.Point(82, 127);
            this.prbMinutes.Name = "prbMinutes";
            this.prbMinutes.Size = new System.Drawing.Size(632, 45);
            this.prbMinutes.TabIndex = 2;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(13, 88);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(57, 23);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "Hours";
            // 
            // prbHours
            // 
            this.prbHours.Location = new System.Drawing.Point(82, 76);
            this.prbHours.Name = "prbHours";
            this.prbHours.Size = new System.Drawing.Size(632, 45);
            this.prbHours.TabIndex = 1;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(21, 38);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(48, 23);
            this.lblDays.TabIndex = 2;
            this.lblDays.Text = "Days";
            // 
            // grbSetting
            // 
            this.grbSetting.Controls.Add(this.label2);
            this.grbSetting.Controls.Add(this.label1);
            this.grbSetting.Controls.Add(this.dtpStart);
            this.grbSetting.Controls.Add(this.btnSetting);
            this.grbSetting.Controls.Add(this.dtpDueDay);
            this.grbSetting.ForeColor = System.Drawing.Color.White;
            this.grbSetting.Location = new System.Drawing.Point(770, 25);
            this.grbSetting.Name = "grbSetting";
            this.grbSetting.Size = new System.Drawing.Size(238, 185);
            this.grbSetting.TabIndex = 2;
            this.grbSetting.TabStop = false;
            this.grbSetting.Text = "Setting";
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.Black;
            this.btnSetting.Location = new System.Drawing.Point(58, 128);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(132, 35);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // dtpDueDay
            // 
            this.dtpDueDay.Location = new System.Drawing.Point(84, 88);
            this.dtpDueDay.Name = "dtpDueDay";
            this.dtpDueDay.Size = new System.Drawing.Size(125, 26);
            this.dtpDueDay.TabIndex = 0;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(84, 38);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(125, 26);
            this.dtpStart.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "DueDay";
            // 
            // timerNow
            // 
            this.timerNow.Enabled = true;
            this.timerNow.Interval = 1000;
            this.timerNow.Tick += new System.EventHandler(this.timerNow_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1033, 221);
            this.Controls.Add(this.grbSetting);
            this.Controls.Add(this.grbStatus);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DoubleClick += new System.EventHandler(this.frmMain_DoubleClick);
            this.grbStatus.ResumeLayout(false);
            this.grbStatus.PerformLayout();
            this.grbSetting.ResumeLayout(false);
            this.grbSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbDays;
        private System.Windows.Forms.GroupBox grbStatus;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.ProgressBar prbMinutes;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.ProgressBar prbHours;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.GroupBox grbSetting;
        private System.Windows.Forms.DateTimePicker dtpDueDay;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Timer timerNow;
    }
}

