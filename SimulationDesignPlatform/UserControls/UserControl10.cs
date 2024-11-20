using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationDesignPlatform.UserControls
{
    public partial class UserControl10 : UserControl
    {
        public readonly float x;//定义当前窗体的宽度
        public readonly float y;//定义当前窗体的高度
        public UserControl10()
        {
            InitializeComponent();
            GetDatabase();
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

        public void GetDatabase()
        {
            dataGridView1.AllowUserToAddRows = false;
            DataTable dataTable01 = new DataTable();

            dataTable01.Columns.Add("node_id", typeof(int));
            dataTable01.Columns.Add("name", typeof(string));
            dataTable01.Columns.Add("line_id", typeof(int));
            dataTable01.Columns.Add("temperature", typeof(double));
            dataTable01.Columns.Add("pressure", typeof(double));
            dataTable01.Columns.Add("flow", typeof(double));
            dataTable01.Columns.Add("s_h_con", typeof(double));
            dataTable01.Columns.Add("l_n_ratio", typeof(double));
            dataTable01.Columns.Add("medium", typeof(int));
            dataTable01.Columns.Add("h2_type", typeof(int));

            // 设置DataGridView的DataSource  
            dataGridView1.DataSource = dataTable01;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置列名
            dataGridView1.Columns["node_id"].HeaderText = "部件序号";
            dataGridView1.Columns["name"].HeaderText = "部件名称";
            dataGridView1.Columns["line_id"].HeaderText = "流股序号";
            dataGridView1.Columns["temperature"].HeaderText = "温度(K)";
            dataGridView1.Columns["pressure"].HeaderText = "压力(MPa)";
            dataGridView1.Columns["flow"].HeaderText = "流量(kg/s)";
            dataGridView1.Columns["s_h_con"].HeaderText = "仲氢浓度";
            dataGridView1.Columns["l_n_ratio"].HeaderText = "液氮比例";
            dataGridView1.Columns["medium"].HeaderText = "工质";
            dataGridView1.Columns["h2_type"].HeaderText = "纯氢";

            for (int i = 0; i < Data.n_node; i++)
            {
                //添加行数据
                DataRow row = dataTable01.NewRow();

                row["node_id"] = Data.node[i].id;
                row["name"] = Data.node[i].name;
                int nodeId = Data.node[i].id;
                for (int j = 0; j < Data.node[nodeId - 1].n; j++)
                {
                    int lineId = Data.node[nodeId - 1].i[j];
                    //Console.WriteLine("输入ID 01 = {0} ", lineId);
                    row["line_id"] = Data.line[lineId-1].ip;
                    row["temperature"] = Data.line[lineId-1].t;
                    row["pressure"] = Data.line[lineId - 1].p;
                    row["flow"] = Data.line[lineId-1].m;
                    row["s_h_con"] = Data.line[lineId - 1].para;
                    row["l_n_ratio"] = Data.line[lineId-1].n2;
                    row["medium"] = Data.line[lineId - 1].mat;
                    row["h2_type"] = Data.line[lineId - 1].h2_type;

                    dataTable01.Rows.Add(row.ItemArray);
                }

                for (int k = 0; k < Data.node[nodeId - 1].n; k++)
                {
                    int lineId = Data.node[nodeId - 1].o[k];
                    //Console.WriteLine("输出ID 01 = {0} ", lineId);
                    row["line_id"] = Data.line[lineId - 1].ip;
                    row["temperature"] = Data.line[lineId-1].t;
                    row["pressure"] = Data.line[lineId - 1].p;
                    row["flow"] = Data.line[lineId-1].m;
                    row["s_h_con"] = Data.line[lineId - 1].para;
                    row["l_n_ratio"] = Data.line[lineId-1].n2;
                    row["medium"] = Data.line[lineId-1].mat;
                    row["h2_type"] = Data.line[lineId - 1].h2_type;

                    dataTable01.Rows.Add(row.ItemArray);
                }

            }
        }

        public void UserControl10_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
