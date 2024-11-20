using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulationDesignPlatform.Forms
{
    public partial class Form3 : Form
    {
        public readonly float x;//定义当前窗体的宽度
        public readonly float y;//定义当前窗体的高度
        public Form3()
        {
            InitializeComponent();
            #region  初始化控件缩放
            x = Width;
            y = Height;
            setTag(this);
            #endregion
        }

        public void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0) setTag(con);
            }
        }

        public void setControls(float newx, float newy, Control cons)
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

        public void ReWinformLayout()
        {
            var newx = Width / x;
            var newy = Height / y;
            setControls(newx, newy, this);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            List<double> listX = new List<double>();
            List<double> listY = new List<double>();
            double x_ = 0;
            double y_ = 0;
            int nrow = 21;

            //读取result文件
            string fn = "line_result.csv";
            bool flag = true;
            StreamReader sR1 = new StreamReader(fn, Encoding.Default);

            string nextLine = "";
            nextLine = sR1.ReadLine();

            for (int i = 0; i < nrow; i++)
            {
                nextLine = sR1.ReadLine();
                string[] tmp = nextLine.Split(',');
                flag = flag && double.TryParse(tmp[0], out x_);
                flag = flag && double.TryParse(tmp[3], out y_);
                listX.Add(x_);
                listY.Add(y_);
                //Console.WriteLine("x={0} , y={1}", x_, y_);
            }

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "X";
            dataGridView1.Columns[1].Name = "Y";

            for (int i = 0; i < nrow; i++)
            {
                dataGridView1.Rows.Add(listX[i], listY[i]);
            }

            chart1.Series.Clear();
            chart1.Titles.Add("曲线绘图");
            Series series1 = chart1.Series.Add("数据");
            series1.ChartType = SeriesChartType.Spline;



            //for (int i = 1; i < this.dataGridView1.Rows.Count - 1; i++)
            //{
            //    double valueX = double.Parse(this.dataGridView1.Rows[i].Cells[0].Value.ToString());
            //    listX.Add(valueX);
            //    double valueY = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString());
            //    listY.Add(valueY);
            //}

            for (int i = 0; i < nrow; i++)
            {
                series1.Points.AddXY(listX[i], listY[i]);
            }
        }

        public void Form3_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
