﻿using SimulationDesignPlatform.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulationDesignPlatform.UserControls
{
    public partial class UserControl14 : UserControl
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public UserControl14()
        {
            InitializeComponent();
            ShowChart();
            #region  初始化控件缩放
            x = Width;
            y = Height;
            setTag(this);
            #endregion
        }

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0) setTag(con);
            }
        }

        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                if (con.Tag != null)
                {
                    var mytag = con.Tag.ToString().Split(';');
                    con.Width = Convert.ToInt32(Convert.ToSingle(mytag[0]) * newx);
                    con.Height = Convert.ToInt32(Convert.ToSingle(mytag[1]) * newy);
                    con.Left = Convert.ToInt32(Convert.ToSingle(mytag[2]) * newx);
                    con.Top = Convert.ToInt32(Convert.ToSingle(mytag[3]) * newy);
                    var currentSize = Convert.ToSingle(mytag[4]) * newy;

                    if (currentSize > 0)
                    {
                        FontFamily fontFamily = new FontFamily(con.Font.Name);
                        con.Font = new Font(fontFamily, currentSize, con.Font.Style, con.Font.Unit);
                    }
                    con.Focus();
                    if (con.Controls.Count > 0) setControls(newx, newy, con);
                }
            }
        }

        private void ReWinformLayout()
        {
            var newx = Width / x;
            var newy = Height / y;
            setControls(newx, newy, this);
        }

        private void ShowChart()
        {
            if (Data.data1.Count == 0)
            {
                return;
            }
            chart1.Series.Clear();
            chart1.Titles.Add("图表1");
            int check_num = 0;
            if (Data.data1_check != null)
            {
                for (int a = 0; a < Data.data1_check.Length; a++)
                {
                    if (Data.data1_check[a] == "true" && a > 0)
                    {
                        check_num++;
                    }
                }
                int[] nums = new int[check_num];
                int m = 0;
                for (int b = 0; b < Data.data1_check.Length; b++)
                {
                    if (Data.data1_check[b] == "true" && b > 0)
                    {
                        nums[m] = b;
                        m++;
                    }
                }
                
                for (int i = 0; i < check_num; i++)
                {
                    Series series1 = chart1.Series.Add(Data.data1[0][nums[i]]);
                    series1.ChartType = SeriesChartType.Spline;
                    if(Data.check_time[0].Ticks < Data.start_time.Ticks)
                    {
                        return;
                    }
                    TimeSpan ts = new TimeSpan(Data.check_time[0].Ticks - Data.start_time.Ticks);
                    int seconds = (int)ts.TotalSeconds;
                    int aa = seconds * 10 - Data.yz_num[0];
                    if (seconds * 10 <= Data.yz_num[0])
                    {
                        for (int k = 1; k < seconds * 10; k++)
                        {
                            series1.Points.AddXY(Data.data1[k][0], Data.data1[k][nums[i]]);
                        }
                    }
                    else if (seconds * 10 > Data.data1.Count && aa < Data.data1.Count)
                    {
                        for (int k = 1; k < seconds * 10 - Data.data1.Count; k++)
                        {
                            series1.Points.AddXY(Data.data1[aa][0], Data.data1[aa][nums[i]]);
                            aa++;
                        }
                    }
                    else if(aa >= 0 && aa <= Data.data1.Count)
                    {
                        
                        for (int k = 1; k < Data.yz_num[0]; k++)
                        {
                            series1.Points.AddXY(Data.data1[aa][0], Data.data1[aa][nums[i]]);
                            aa++;
                        }
                    }
                }
            }

            chart2.Series.Clear();
            chart2.Titles.Add("图表2");
            int check_num2 = 0;
            if (Data.data2_check != null)
            {
                for (int a = 0; a < Data.data2_check.Length; a++)
                {
                    if (Data.data2_check[a] == "true" && a > 0)
                    {
                        check_num2++;
                    }
                }
                int[] nums = new int[check_num2];
                int m = 0;
                for (int b = 0; b < Data.data2_check.Length; b++)
                {
                    if (Data.data2_check[b] == "true" && b > 0)
                    {
                        nums[m] = b;
                        m++;
                    }
                }

                for (int i = 0; i < check_num2; i++)
                {
                    Series series2 = chart2.Series.Add(Data.data2[0][nums[i]]);
                    series2.ChartType = SeriesChartType.Spline;
                    if (Data.check_time[1].Ticks < Data.start_time.Ticks)
                    {
                        return;
                    }
                    TimeSpan ts = new TimeSpan(Data.check_time[1].Ticks - Data.start_time.Ticks);
                    int seconds = (int)ts.TotalSeconds;
                    int aa = seconds * 10 - Data.yz_num[1];
                    if (seconds * 10 <= Data.yz_num[1])
                    {
                        for (int k = 1; k < seconds * 10; k++)
                        {
                            series2.Points.AddXY(Data.data2[k][0], Data.data2[k][nums[i]]);
                        }
                    }
                    else if (seconds * 10 > Data.data2.Count && aa < Data.data2.Count)
                    {
                        for (int k = 1; k < seconds * 10 - Data.data2.Count; k++)
                        {
                            series2.Points.AddXY(Data.data2[aa][0], Data.data2[aa][nums[i]]);
                            aa++;
                        }
                    }
                    else if (aa >= 0 && aa <= Data.data2.Count)
                    {

                        for (int k = 1; k < Data.yz_num[1]; k++)
                        {
                            series2.Points.AddXY(Data.data2[aa][0], Data.data2[aa][nums[i]]);
                            aa++;
                        }
                    }
                }
            //    Series series2 = chart2.Series.Add("温度");
            //series2.ChartType = SeriesChartType.Spline;

            //for (int i = 0; i < Data.data1.Count; i++)
            //{
                
            //    for (int j = 0; j < Data.data1_check.Length; j++)
            //    {
            //        if (Data.data1_check[j] == "true" && j > 0)
            //        {
            //            series2.Points.AddXY(Data.data1[i][0], Data.data1[i][j]);
            //        }
            //    }
                
            }
        }

        private void UserControl14_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
