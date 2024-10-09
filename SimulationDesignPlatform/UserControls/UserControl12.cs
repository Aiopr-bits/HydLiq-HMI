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

namespace SimulationDesignPlatform.UserControls
{
    public partial class UserControl12 : UserControl
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public UserControl12()
        {
            InitializeComponent();
            tableLayoutPanel1.SetColumnSpan(button1, 2);
            tableLayoutPanel1.SetColumnSpan(dataGridView5, 2);
            GetDatabase();
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

        private void UserControl12_Resize(object sender, EventArgs e)
        {
            ReWinformLayout();
        }

        private void GetDatabase()
        {
            DataTable dataTable01 = new DataTable();
            dataTable01.Columns.Add("计算流股参数个数");
            dataTable01.Columns.Add("计算部件参数个数");
            dataTable01.Rows.Add(Data.autoTest.n_line, Data.autoTest.n_node);
            dataGridView1.DataSource = dataTable01;

            DataTable dataTable02 = new DataTable();
            dataTable02.Columns.Add("流股", typeof(string));
            dataTable02.Columns.Add("起始温度", typeof(double));
            dataTable02.Columns.Add("结束温度", typeof(double));
            dataTable02.Columns.Add("计算点数", typeof(int));
            for (int i = 0; i < Data.autoTest.n_line; i++)
            {
                dataTable02.Rows.Add(Data.autoTest.line[i][0], Data.autoTest.line[i][1], Data.autoTest.line[i][2], Data.autoTest.line[i][3]);
            }
            dataGridView2.DataSource = dataTable02;

            DataTable dataTable03 = new DataTable();
            dataTable03.Columns.Add("部件", typeof(string));
            dataTable03.Columns.Add("起始效率", typeof(double));
            dataTable03.Columns.Add("结束效率", typeof(double));
            dataTable03.Columns.Add("计算点数", typeof(int));
            for (int i = 0; i < Data.autoTest.n_node; i++)
            {
                dataTable03.Rows.Add(Data.autoTest.node[i][0], Data.autoTest.node[i][1], Data.autoTest.node[i][2], Data.autoTest.node[i][3]);
            }
            dataGridView3.DataSource = dataTable03;

            DataTable dataTable04 = new DataTable();
            dataTable04.Columns.Add("氢流量部件", typeof(string));
            dataTable04.Columns.Add("氢流量流股", typeof(string));
            dataTable04.Rows.Add(Data.autoTest.n_h2_node, Data.autoTest.n_line);
            dataGridView4.DataSource = dataTable04;

            DataTable dataTable05 = new DataTable();
            dataTable05.Columns.Add("自动测试");
            dataTable05.Columns.Add("计算最小温差");
            dataTable05.Columns.Add("优化模型计算");
            dataTable05.Rows.Add(Data.multi_case, Data.cal_min_temp_diff, Data.opt_model_cal);
            dataGridView5.DataSource = dataTable05;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.AllowUserToAddRows = true;
            //int id = dataGridView1.NewRowIndex;
            //Data.n_case = id;

            //for (int i = 0; i < id; i++)
            //{
            //    Data.case_data[i].icase = (int)dataGridView1.Rows[i].Cells[0].Value;
            //    Data.case_data[i].line_case = (int)dataGridView1.Rows[i].Cells[1].Value;
            //    Data.case_data[i].t_case = (double)dataGridView1.Rows[i].Cells[2].Value;
            //    Data.case_data[i].p_case = (double)dataGridView1.Rows[i].Cells[3].Value;
            //    Data.case_data[i].m_case = (double)dataGridView1.Rows[i].Cells[4].Value;
            //}
            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase();
            MessageBox.Show("保存成功！");
        }
    }
}
