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


            prbDays.Maximum = Convert.ToInt32(CalcDateDiff(DueDay, StartDay, DateDiffResultType.Days));
            prbHours.Maximum = 24;
            prbMinutes.Maximum = 60;
           // prbHours.Maximum = Convert.ToInt32(CalcDateDiff(DueDay, StartDay, DateDiffResultType.Hours));
           // prbMinutes.Maximum = Convert.ToInt32(CalcDateDiff(DueDay, StartDay, DateDiffResultType.Minutes));

            prbDays.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now , StartDay, DateDiffResultType.Days));
            prbHours.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Hours));
            prbMinutes.Value  = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Minutes));

        }




        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {

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
                prbDays.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Days));
                prbHours.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Hours));
                prbMinutes.Value = Convert.ToInt32(CalcDateDiff(DateTime.Now, StartDay, DateDiffResultType.Minutes));
            }

       
        }



    }
}
