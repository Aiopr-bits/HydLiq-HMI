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
    public partial class UserControl11 : UserControl
    {
        public readonly float x;//定义当前窗体的宽度
        public readonly float y;//定义当前窗体的高度
        public TabControl tabControl; // 创建一个 TabControl 控件来管理多个标签页
        public int fault_id = 0;
        public UserControl11()
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

            dataTable01.Columns.Add("id", typeof(int));
            dataTable01.Columns.Add("node_id", typeof(int));
            dataTable01.Columns.Add("name", typeof(string));
            dataTable01.Columns.Add("line_id", typeof(int));
            dataTable01.Columns.Add("in_out", typeof(string));
            dataTable01.Columns.Add("is_zhuru", typeof(bool));
            dataTable01.Columns.Add("is_result", typeof(bool));

            // 设置DataGridView的DataSource  
            dataGridView1.DataSource = dataTable01;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置列名
            dataGridView1.Columns["id"].HeaderText = "序号";
            dataGridView1.Columns["id"].ReadOnly = true;
            dataGridView1.Columns["node_id"].HeaderText = "部件序号";
            dataGridView1.Columns["node_id"].ReadOnly = true;
            dataGridView1.Columns["name"].HeaderText = "部件名称";
            dataGridView1.Columns["name"].ReadOnly = true;
            dataGridView1.Columns["line_id"].HeaderText = "流股序号";
            dataGridView1.Columns["line_id"].ReadOnly = true;
            dataGridView1.Columns["in_out"].HeaderText = "输入输出";
            dataGridView1.Columns["in_out"].ReadOnly = true;
            dataGridView1.Columns["is_zhuru"].HeaderText = "是否故障注入";
            dataGridView1.Columns["is_result"].HeaderText = "是否查看结果";

            for (int i = 0; i < Data.fault.Length; i++)
            {
                if (Data.fault[0] == null)
                {
                    return;
                }
                //添加行数据
                DataRow row = dataTable01.NewRow();

                row["id"] = Data.fault[i].id;
                row["node_id"] = Data.fault[i].node_id;
                row["name"] = Data.fault[i].node_name;
                row["line_id"] = Data.fault[i].line_id;
                row["in_out"] = Data.fault[i].in_out;
                row["is_zhuru"] = Data.fault[i].is_fault;
                row["is_result"] = Data.fault[i].is_result;
                if (Data.fault[i].node_id != 0 && Data.fault[i].line_id != 0)
                {
                    dataTable01.Rows.Add(row.ItemArray);
                    fault_id = Data.fault[i].id;
                }
                
                
                //int nodeId = Data.node[i].id;
                //for (int j = 0; j < Data.node[nodeId - 1].n; j++)
                //{
                //    int lineId = Data.node[nodeId - 1].i[j];
                //    row["line_id"] = Data.line[lineId - 1].ip;
                //    row["is_zhuru"] = Data.fault[lineId - 1].is_fault;
                //    row["is_result"] = Data.fault[lineId - 1].is_result;

                //    dataTable01.Rows.Add(row.ItemArray);
                //}

                //for (int k = 0; k < Data.node[nodeId - 1].n; k++)
                //{
                //    int lineId = Data.node[nodeId - 1].o[k];
                //    row["line_id"] = Data.line[lineId - 1].ip;
                //    row["is_zhuru"] = Data.fault[lineId - 1].is_fault;
                //    row["is_result"] = Data.fault[lineId - 1].is_result;

                //    dataTable01.Rows.Add(row.ItemArray);
                //}

            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            Array.Clear(Data.faultLine, 0, Data.faultLine.Length); // 清空数组中的所有元素
            for (int i = 0; i < Data.n_line_max; i++)
            {
                Data.faultLine[i] = new lineData();    //故障注入流股
            }

            int a = 0;
            for (int i = 0; i < fault_id; i++)
            {
                Data.fault[i].id = (int)dataGridView1.Rows[i].Cells[0].Value;
                Data.fault[i].node_id = (int)dataGridView1.Rows[i].Cells[1].Value;
                Data.fault[i].node_name = (string)dataGridView1.Rows[i].Cells[2].Value;
                Data.fault[i].line_id = (int)dataGridView1.Rows[i].Cells[3].Value;
                Data.fault[i].in_out = (string)dataGridView1.Rows[i].Cells[4].Value;
                Data.fault[i].is_fault = (bool)dataGridView1.Rows[i].Cells[5].Value;
                Data.fault[i].is_result = (bool)dataGridView1.Rows[i].Cells[6].Value;
                if(Data.fault[i].is_fault == true || Data.fault[i].is_result == true)
                {
                    for (int j = 0; j < Data.n_line; j++)
                    {
                        if (Data.fault[i].line_id == Data.line[j].ip)
                        {
                            Data.faultLine[a].ip = Data.fault[i].line_id;
                            Data.faultLine[a].t = Data.line[j].t;
                            Data.faultLine[a].p = Data.line[j].p;
                            Data.faultLine[a].m = Data.line[j].m;
                            Data.faultLine[a].para = Data.line[j].para;
                            Data.faultLine[a].n2 = Data.line[j].n2;
                            Data.faultLine[a].mat = Data.line[j].mat;
                            a++;
                            
                        }
                    }
                }
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("i = {0} ,ip = {1}, t = {2}, p = {3}, m = {4}, para = {5}, n2 = {6}, mat = {7} ", i, Data.faultLine[i].ip, Data.faultLine[i].t, Data.faultLine[i].p, Data.faultLine[i].m, Data.faultLine[i].para, Data.faultLine[i].n2, Data.faultLine[i].mat);
            //}

            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase();
            Task.Run(() =>
            {
                MessageBox.Show("保存成功！");
            });
        }

        public void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = false;

            for (int i = 0; i < Data.n_line; i++)
            {
                if (Data.faultLine[i].ip != 0)
                {
                    Data.faultLine[i].ip = (int)dataGridView2.Rows[i].Cells[0].Value;
                    Data.faultLine[i].t = Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);
                    Data.faultLine[i].p = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
                    Data.faultLine[i].m = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    Data.faultLine[i].para = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                    Data.faultLine[i].n2 = Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);
                    Data.faultLine[i].mat = Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value);
                   
                }
                
            }
            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase2();
            Task.Run(() =>
            {
                MessageBox.Show("保存成功！");
            });
        }

        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                GetDatabase2();
            }
        }

        public void GetDatabase2()
        {
            dataGridView2.AllowUserToAddRows = false;
            DataTable dataTable01 = new DataTable();

            dataTable01.Columns.Add("id", typeof(int));
            dataTable01.Columns.Add("temperature", typeof(double));
            dataTable01.Columns.Add("pressure", typeof(double));
            dataTable01.Columns.Add("flow", typeof(double));
            dataTable01.Columns.Add("s_h_con", typeof(double));
            dataTable01.Columns.Add("l_n_ratio", typeof(int));
            dataTable01.Columns.Add("medium", typeof(int));
            dataTable01.Columns.Add("h2_type", typeof(int));

            // 设置DataGridView的DataSource  
            dataGridView2.DataSource = dataTable01;

            // 设置列名
            dataGridView2.Columns["id"].HeaderText = "流股序号";
            dataGridView2.Columns["temperature"].HeaderText = "温度";
            dataGridView2.Columns["pressure"].HeaderText = "压力";
            dataGridView2.Columns["flow"].HeaderText = "流量";
            dataGridView2.Columns["s_h_con"].HeaderText = "仲氢浓度";
            dataGridView2.Columns["l_n_ratio"].HeaderText = "液氮比例";
            dataGridView2.Columns["medium"].HeaderText = "工质";
            dataGridView2.Columns["h2_type"].HeaderText = "纯氢";

            for (int i = 0; i < Data.n_line; i++)
            {
                //添加行数据
                DataRow row = dataTable01.NewRow();
                row["id"] = Data.faultLine[i].ip;
                row["temperature"] = Data.faultLine[i].t;
                row["pressure"] = Data.faultLine[i].p;
                row["flow"] = Data.faultLine[i].m;
                row["s_h_con"] = Data.faultLine[i].para;
                row["l_n_ratio"] = Data.faultLine[i].n2;
                row["medium"] = Data.faultLine[i].mat;
                row["h2_type"] = Data.line[i].h2_type;

                if (Data.faultLine[i].ip != 0)
                {
                    dataTable01.Rows.Add(row);
                }
                
            }
        }

        public void UserControl11_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
