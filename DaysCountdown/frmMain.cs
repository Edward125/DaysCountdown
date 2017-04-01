using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Edward;

namespace DaysCountdown
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            prbDays.Visible = false;
            prbHours.Visible = false;
            prbMinutes.Visible = false;


       



        }

        #region parameters
        static string AppFolder = Application.StartupPath + @"DaysCountdown";
        static string IniFilePath = AppFolder + @"\SysConfig.ini";
        static string _DueDay = "";
        static string _StartDay = "";

        static int SETTINGWIDTH = 1039;
        static int RUNWIDTH = 777;

        static DateTime DueDay;
        static DateTime StartDay;
        int tempSec = 0;
       

            textProgressBar  prbDay = new textProgressBar();
            //prbDay.Location  = new Point(82, 25);
            //prbDay.Size  = new Size(632, 45);
            //this.Controls.Add(prbDay);
            //prbDay.Visible = true;

            textProgressBar  prbHour = new textProgressBar();
            //prbHour.Location = new Point(82, 76);
            //prbHour.Size = new Size(632, 45);
            //this.Controls.Add(prbHour);

           textProgressBar  prbMinute = new textProgressBar();
            //prbMinute.Location = new Point(82, 127);
            //prbMinute.Size = new Size(632, 45);
            //this.Controls.Add(prbMinute);

            //prbDay.Minimum = 0;
            //prbHour.Minimum = 0;
            //prbMinute.Minimum = 0;



        #endregion



        #region checkFolder

        /// <summary>
        /// check folder & config file,if not exits,create 
        /// </summary>
        private void CheckFolderConfig()
        {
            if (!Directory.Exists(AppFolder))
                Directory.CreateDirectory(AppFolder);

            if (!File.Exists(IniFilePath))
            {
                IniFile.CreateIniFile(IniFilePath);
                // write default config
                IniFile.IniWriteValue("SysConfig", "StartDay", "", IniFilePath);
                IniFile.IniWriteValue("SysConfig", "DueDay", "", IniFilePath);
            }
        }

        #endregion

        #region LoadConfig

        private void LoadConfig()
        {
            _StartDay = IniFile.IniReadValue ("SysConfig", "StartDay", IniFilePath);
            _DueDay = IniFile.IniReadValue("SysConfig", "DueDay", IniFilePath);

            if (string.IsNullOrEmpty(_StartDay))
            {
                this.Width = SETTINGWIDTH;
                MessageBox.Show("You don't set the START DAY,pls setting...", "DO NOT SET START DAY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpStart.Focus();
                return;
            }
            else
            {
                this.Width = RUNWIDTH;

                try
                {
                    StartDay  = Convert.ToDateTime(_StartDay );
                }
                catch (Exception ex)
                {
                    this.Width = SETTINGWIDTH;
                    MessageBox.Show("Can't convert setting to DATTIME,pls check the setting...,details message:" + ex.Message, "CONVERT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDueDay.Focus();
                    return;
                }
            }



            if (string.IsNullOrEmpty(_DueDay))
            {
                this.Width = SETTINGWIDTH;
                MessageBox.Show("You don't set the DUE DAY,pls setting...", "DO NOT SET DUE DAY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDueDay.Focus();
            }
            else
            {
                this.Width = RUNWIDTH;

                try
                {
                    DueDay = Convert.ToDateTime(_DueDay);
                }
                catch (Exception ex)
                {
                    this.Width = SETTINGWIDTH;
                    MessageBox.Show("Can't convert setting to DATTIME,pls check the setting...,details message:" + ex.Message,"CONVERT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDueDay.Focus();
                }
            }
        }

        #endregion

        



        #region CalcDateDiff


        /// <summary>
        /// define datetime diff result type
        /// </summary>
        enum DateDiffResultType
        {
            Days,
            Hours,
            Minutes
        }



        /// <summary>
        /// calculate dt1 subtract dt2 
        /// </summary>
        /// <param name="_dt1">dt1</param>
        /// <param name="_dt2">dt2</param>
        /// <param name="_resulttype">result type</param>
        /// <returns></returns>
        private int  CalcDateDiff(DateTime _dt1, DateTime _dt2,DateDiffResultType _resulttype)
        {

            TimeSpan ts1 = new TimeSpan(_dt1.Ticks);
            TimeSpan ts2 = new TimeSpan(_dt2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            int    diff;


            switch (_resulttype)
            {
                case DateDiffResultType.Days:
                    diff = ts.Days;
                    break;
                case DateDiffResultType.Hours:
                    diff = ts.Hours;
                    break;
                case DateDiffResultType.Minutes:
                    diff = ts.Minutes;
                    break;
                default:
                    diff = ts.Seconds;
                    break;
            }
            return diff;

        }


        private void SetProgress()
        {


            //prbDays.Maximum = Convert.ToInt32(CalcDateDiff(DueDay, StartDay, DateDiffResultType.Days));    
            prbDay.Maximum = Convert.ToInt32(CalcDateDiff(DueDay, StartDay, DateDiffResultType.Days));    
            //prbHours.Maximum = 24;
            prbHour.Maximum = 24;
           // prbMinutes.Maximum = 60;
            prbMinute.Maximum = 60;
           // prbHours.Maximum = Convert.ToInt32(CalcDateDiff(DueDay, StartDay, DateDiffResultType.Hours));
           // prbMinutes.Maximum = Convert.ToInt32(CalcDateDiff(DueDay, StartDay, DateDiffResultType.Minutes));





            prbDay.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Days));
            //prbDays.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Days));
            prbHour.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Hours));
            // prbHours.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Hours));
            prbMinute.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Minutes));
            //prbMinutes.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Minutes));

            //


        }




        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {



            prbDay.Location = new Point(82, 25);
            prbDay.Size = new Size(632, 45);
            this.Controls.Add(prbDay);
            prbDay.Visible = true;


            prbHour.Location = new Point(82, 76);
            prbHour.Size = new Size(632, 45);
            this.Controls.Add(prbHour);


            prbMinute.Location = new Point(82, 127);
            prbMinute.Size = new Size(632, 45);
            this.Controls.Add(prbMinute);

            prbDay.Minimum = 0;
            prbHour.Minimum = 0;
            prbMinute.Minimum = 0;


            prbDay.Visible = true;
            prbHour.Visible = true;
            prbMinute.Visible = true;


            CheckFolderConfig();
            LoadConfig();
            SetProgress();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            _StartDay = dtpStart.Value.ToString("yyyy-MM-dd");
            IniFile.IniWriteValue("SysConfig", "StartDay", _StartDay, IniFilePath);
            _DueDay = dtpDueDay.Value.ToString("yyyy-MM-dd");
            IniFile.IniWriteValue("SysConfig", "DueDay", _DueDay, IniFilePath);
            MessageBox.Show("Setting OK,the proramm will RESTART", "SETTING & RESTART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void timerNow_Tick(object sender, EventArgs e)
        {
            grbStatus.Text = "Countdown Status: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ",Due Day:" + _DueDay;
            if (DateTime.Now.Second == 0)
            {
                prbDay.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Days));
                //prbDays.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Days));
                prbHour.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Hours));
               // prbHours.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Hours));
                prbMinute.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Minutes));
                //prbMinutes.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Minutes));
            }

       
        }

        private void frmMain_DoubleClick(object sender, EventArgs e)
        {
            if (this.Width == RUNWIDTH)
                this.Width = SETTINGWIDTH;
            else
                this.Width = RUNWIDTH;
        }



        #region 重写grogessbar

        [ToolboxItem(true)]

       public  class textProgressBar : System.Windows.Forms.ProgressBar
        {

            //[System.Runtime.InteropServices.DllImport("user32.dll ")]

            //static extern IntPtr GetWindowDC(IntPtr hWnd);

            //[System.Runtime.InteropServices.DllImport("user32.dll ")]

            //static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            //private System.Drawing.Color _TextColor = System.Drawing.Color.Black;

            //private System.Drawing.Font _TextFont = new System.Drawing.Font("SimSun ", 12);

            //public System.Drawing.Color TextColor
            //{

            //    get { return _TextColor; }

            //    set { _TextColor = value; this.Invalidate(); }

            //}

            //public System.Drawing.Font TextFont
            //{

            //    get { return _TextFont; }

            //    set { _TextFont = value; this.Invalidate(); }

            //}

            //protected override void WndProc(ref   Message m)
            //{

            //    base.WndProc(ref   m);

            //    if (m.Msg == 0xf || m.Msg == 0x133)
            //    {

            //        //拦截系统消息，获得当前控件进程以便重绘。  

            //        //一些控件（如TextBox、Button等）是由系统进程绘制，重载OnPaint方法将不起作用.  

            //        //所有这里并没有使用重载OnPaint方法绘制TextBox边框。  

            //        //  

            //        //MSDN:重写   OnPaint   将禁止修改所有控件的外观。  

            //        //那些由   Windows   完成其所有绘图的控件（例如   Textbox）从不调用它们的   OnPaint   方法，  

            //        //因此将永远不会使用自定义代码。请参见您要修改的特定控件的文档，  

            //        //查看   OnPaint   方法是否可用。如果某个控件未将   OnPaint   作为成员方法列出，  

            //        //则您无法通过重写此方法改变其外观。  

            //        //  

            //        //MSDN:要了解可用的   Message.Msg、Message.LParam   和   Message.WParam   值，  

            //        //请参考位于   MSDN   Library   中的   Platform   SDK   文档参考。可在   Platform   SDK（“Core   SDK”一节）  

            //        //下载中包含的   windows.h   头文件中找到实际常数值，该文件也可在   MSDN   上找到。  

            //        IntPtr hDC = GetWindowDC(m.HWnd);

            //        if (hDC.ToInt32() == 0)
            //        {

            //            return;

            //        }

            //        //base.OnPaint(e);

            //        System.Drawing.Graphics g = Graphics.FromHdc(hDC);

            //        SolidBrush brush = new SolidBrush(_TextColor);

            //        string s = string.Format("{0}%", this.Value * 100 / this.Maximum);

            //        SizeF size = g.MeasureString(s, _TextFont);

            //        float x = (this.Width - size.Width) / 2;

            //        float y = (this.Height - size.Height) / 2;

            //        g.DrawString(s, _TextFont, brush, x, y);

            //        //返回结果  

            //        m.Result = IntPtr.Zero;

            //        //释放  

            //        ReleaseDC(m.HWnd, hDC);

            //    }

            //}


        //=========================================
         public textProgressBar ()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);
            if (Value > 0)
            {
                var clip = new Rectangle(rect.X, rect.Y, (int) ((float) Value/Maximum*rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }

            string text = string.Format("{0}%", Value * 100 / Maximum);;
            using (var font = new Font(FontFamily.GenericSerif, 20))
            {
                SizeF sz = g.MeasureString(text, font);
                var location = new PointF(rect.Width/2 - sz.Width/2, rect.Height/2 - sz.Height/2 + 2);
                g.DrawString(text, font, Brushes.Red, location);
            }
        }





        }

        #endregion

 



    }
}
