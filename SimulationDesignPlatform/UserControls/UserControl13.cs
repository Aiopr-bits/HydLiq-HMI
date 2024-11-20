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
    public partial class UserControl13 : UserControl
    {
        public readonly float x;//定义当前窗体的宽度
        public readonly float y;//定义当前窗体的高度

        public UserControl13()
        {
            InitializeComponent();

            #region  初始化控件缩放
            x = Width;
            y = Height;
            setTag(this);

            #endregion
            Show_pic();
            ShowChart();
        }

        public void Show_pic()
        {
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Dock = DockStyle.Fill;
            if(Data.imagePath != null)
            {
                pictureBox1.LoadAsync(Data.imagePath);
                panel3.Controls.Add(pictureBox1);
            }
        }

        public void ShowChart()
        {
            if (Data.data7.Count == 0)
            {
                return;
            }
            chart1.Series.Clear();
            chart1.Titles.Add("电解电流");
            int check_num = 0;
            if (Data.data7_check != null)
            {
                for (int a = 0; a < Data.data7_check.Length; a++)
                {
                    if (Data.data7_check[a] == "true" && a > 0)
                    {
                        check_num++;
                    }
                }
                int[] nums = new int[check_num];
                int m = 0;
                for (int b = 0; b < Data.data7_check.Length; b++)
                {
                    if (Data.data7_check[b] == "true" && b > 0)
                    {
                        nums[m] = b;
                        m++;
                    }
                }

                for (int i = 0; i < check_num; i++)
                {
                    Series series1 = chart1.Series.Add(Data.data7[0][nums[i]]);
                    series1.ChartType = SeriesChartType.Spline;
                    if (Data.check_time[6].Ticks < Data.start_time.Ticks)
                    {
                        return;
                    }
                    TimeSpan ts = new TimeSpan(Data.check_time[6].Ticks - Data.start_time.Ticks);
                    int seconds = (int)ts.TotalSeconds;
                    int aa = seconds * 10 - Data.yz_num[6];
                    if (seconds * 10 <= Data.yz_num[6])
                    {
                        for (int k = 1; k < seconds * 10; k++)
                        {
                            series1.Points.AddXY(Data.data7[k][0], Data.data7[k][nums[i]]);
                        }
                    }
                    else if (seconds * 10 > Data.data7.Count && aa < Data.data7.Count)
                    {
                        for (int k = 1; k < seconds * 10 - Data.data7.Count; k++)
                        {
                            series1.Points.AddXY(Data.data7[aa][0], Data.data7[aa][nums[i]]);
                            aa++;
                        }
                    }
                    else if (aa >= 0 && aa <= Data.data7.Count)
                    {

                        for (int k = 1; k < Data.yz_num[6]; k++)
                        {
                            series1.Points.AddXY(Data.data7[aa][0], Data.data7[aa][nums[i]]);
                            aa++;
                        }
                    }
                }
            }

            chart2.Series.Clear();
            chart2.Titles.Add("电解电压");
            int check_num2 = 0;
            if (Data.data8_check != null)
            {
                for (int a = 0; a < Data.data8_check.Length; a++)
                {
                    if (Data.data8_check[a] == "true" && a > 0)
                    {
                        check_num2++;
                    }
                }
                int[] nums = new int[check_num2];
                int m = 0;
                for (int b = 0; b < Data.data8_check.Length; b++)
                {
                    if (Data.data8_check[b] == "true" && b > 0)
                    {
                        nums[m] = b;
                        m++;
                    }
                }

                for (int i = 0; i < check_num2; i++)
                {
                    Series series2 = chart2.Series.Add(Data.data8[0][nums[i]]);
                    series2.ChartType = SeriesChartType.Spline;
                    if (Data.check_time[7].Ticks < Data.start_time.Ticks)
                    {
                        return;
                    }
                    TimeSpan ts = new TimeSpan(Data.check_time[7].Ticks - Data.start_time.Ticks);
                    int seconds = (int)ts.TotalSeconds;
                    int aa = seconds * 10 - Data.yz_num[7];
                    if (seconds * 10 <= Data.yz_num[7])
                    {
                        for (int k = 1; k < seconds * 10; k++)
                        {
                            series2.Points.AddXY(Data.data8[k][0], Data.data8[k][nums[i]]);
                        }
                    }
                    else if (seconds * 10 > Data.data8.Count && aa < Data.data8.Count)
                    {
                        for (int k = 1; k < seconds * 10 - Data.data8.Count; k++)
                        {
                            series2.Points.AddXY(Data.data8[aa][0], Data.data8[aa][nums[i]]);
                            aa++;
                        }
                    }
                    else if (aa >= 0 && aa <= Data.data8.Count)
                    {

                        for (int k = 1; k < Data.yz_num[7]; k++)
                        {
                            series2.Points.AddXY(Data.data8[aa][0], Data.data8[aa][nums[i]]);
                            aa++;
                        }
                    }
                }
               
            }

            chart3.Series.Clear();
            chart3.Titles.Add("氧中氢");
            int check_num3 = 0;
            if (Data.data9_check != null)
            {
                for (int a = 0; a < Data.data9_check.Length; a++)
                {
                    if (Data.data9_check[a] == "true" && a > 0)
                    {
                        check_num3++;
                    }
                }
                int[] nums = new int[check_num3];
                int m = 0;
                for (int b = 0; b < Data.data9_check.Length; b++)
                {
                    if (Data.data9_check[b] == "true" && b > 0)
                    {
                        nums[m] = b;
                        m++;
                    }
                }

                for (int i = 0; i < check_num3; i++)
                {
                    Series series3 = chart3.Series.Add(Data.data9[0][nums[i]]);
                    series3.ChartType = SeriesChartType.Spline;
                    if (Data.check_time[8].Ticks < Data.start_time.Ticks)
                    {
                        return;
                    }
                    TimeSpan ts = new TimeSpan(Data.check_time[8].Ticks - Data.start_time.Ticks);
                    int seconds = (int)ts.TotalSeconds;
                    int aa = seconds * 10 - Data.yz_num[8];
                    if (seconds * 10 <= Data.yz_num[8])
                    {
                        for (int k = 1; k < seconds * 10; k++)
                        {
                            series3.Points.AddXY(Data.data9[k][0], Data.data9[k][nums[i]]);
                        }
                    }
                    else if (seconds * 10 > Data.data9.Count && aa < Data.data9.Count)
                    {
                        for (int k = 1; k < seconds * 10 - Data.data9.Count; k++)
                        {
                            series3.Points.AddXY(Data.data9[aa][0], Data.data9[aa][nums[i]]);
                            aa++;
                        }
                    }
                    else if (aa >= 0 && aa <= Data.data9.Count)
                    {

                        for (int k = 1; k < Data.yz_num[8]; k++)
                        {
                            series3.Points.AddXY(Data.data9[aa][0], Data.data9[aa][nums[i]]);
                            aa++;
                        }
                    }
                }
            }

            chart4.Series.Clear();
            chart4.Titles.Add("温度");
            int check_num4 = 0;
            if (Data.data10_check != null)
            {
                for (int a = 0; a < Data.data10_check.Length; a++)
                {
                    if (Data.data10_check[a] == "true" && a > 0)
                    {
                        check_num4++;
                    }
                }
                int[] nums = new int[check_num4];
                int m = 0;
                for (int b = 0; b < Data.data10_check.Length; b++)
                {
                    if (Data.data10_check[b] == "true" && b > 0)
                    {
                        nums[m] = b;
                        m++;
                    }
                }

                for (int i = 0; i < check_num4; i++)
                {
                    Series series4 = chart4.Series.Add(Data.data10[0][nums[i]]);
                    series4.ChartType = SeriesChartType.Spline;
                    if (Data.check_time[9].Ticks < Data.start_time.Ticks)
                    {
                        return;
                    }
                    TimeSpan ts = new TimeSpan(Data.check_time[9].Ticks - Data.start_time.Ticks);
                    int seconds = (int)ts.TotalSeconds;
                    int aa = seconds * 10 - Data.yz_num[9];
                    if (seconds * 10 <= Data.yz_num[9])
                    {
                        for (int k = 1; k < seconds * 10; k++)
                        {
                            series4.Points.AddXY(Data.data10[k][0], Data.data10[k][nums[i]]);
                        }
                    }
                    else if (seconds * 10 > Data.data10.Count && aa < Data.data10.Count)
                    {
                        for (int k = 1; k < seconds * 10 - Data.data10.Count; k++)
                        {
                            series4.Points.AddXY(Data.data10[aa][0], Data.data10[aa][nums[i]]);
                            aa++;
                        }
                    }
                    else if (aa >= 0 && aa <= Data.data10.Count)
                    {

                        for (int k = 1; k < Data.yz_num[9]; k++)
                        {
                            series4.Points.AddXY(Data.data10[aa][0], Data.data10[aa][nums[i]]);
                            aa++;
                        }
                    }
                }
            }
        }

        public void UserControl13_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        public void setTag(Control cons)
        {
            foreach (Control con in cons.Controls) 
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if(con.Controls.Count > 0) setTag(con);
            }
        }

        public void setControls(float newx,  float newy, Control cons)
        {
            foreach(Control con in cons.Controls)
            {
                if(con.Tag != null)
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
                    if(con.Controls.Count > 0) setControls(newx, newy, con);
                }
            }
        }

        public void ReWinformLayout()
        {
            var newx = Width / x;
            var newy = Height / y;
            setControls(newx, newy, this);
        }
    }
}
