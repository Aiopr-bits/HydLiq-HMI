using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimulationDesignPlatform.UserControls
{

    public partial class UserControl4 : UserControl
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public UserControl4()
        {
            InitializeComponent();

            GetDatabase01();
            GetDatabase02();
            GetDatabase03();
            Rectangle ScreenArea = Screen.GetWorkingArea(this);
            if(ScreenArea.Height < this.Height)
            {
                this.Height = ScreenArea.Height;
            }
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
        private void GetDatabase01()
        {
            
            DataTable dataTable01 = new DataTable();

            dataTable01.Columns.Add("id", typeof(int));
            dataTable01.Columns.Add("name", typeof(string));
            dataTable01.Columns.Add("type", typeof(int));
            dataTable01.Columns.Add("n_num", typeof(int));
            dataTable01.Columns.Add("cal_type", typeof(int));
            dataTable01.Columns.Add("n2_heat", typeof(bool));

            // 设置DataGridView的DataSource  
            dataGridView1.DataSource = dataTable01;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置列名  
            dataGridView1.Columns["id"].HeaderText = "部件序号";
            dataGridView1.Columns["name"].HeaderText = "部件名称";
            dataGridView1.Columns["type"].HeaderText = "部件类型";
            dataGridView1.Columns["n_num"].HeaderText = "流股数";
            dataGridView1.Columns["cal_type"].HeaderText = "计算类型";
            dataGridView1.Columns["n2_heat"].HeaderText = "含氮换热器";

            for (int i = 0; i < Data.n_node; i++)
            {
                //添加行数据
                DataRow row = dataTable01.NewRow();
                row["id"] = Data.node[i].id; ;
                row["name"] = Data.node[i].name;
                row["type"] = Data.node[i].type;
                row["n_num"] = Data.node[i].n;
                row["cal_type"] = Data.node[i].cal_type;
                row["n2_heat"] = Data.node[i].n2_heat;

                dataTable01.Rows.Add(row);
            }
        }

        private void GetDatabase02()
        {
            // -------表1--------
            DataTable dataTable01 = new DataTable();

            dataTable01.Columns.Add("gas_constant", typeof(double));
            dataTable01.Columns.Add("refer_t", typeof(double));
            dataTable01.Columns.Add("refer_p", typeof(double));

            // 设置DataGridView的DataSource  
            dataGridView2.DataSource = dataTable01;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置列名  
            dataGridView2.Columns["gas_constant"].HeaderText = "气体常数(kg/s)";
            dataGridView2.Columns["refer_t"].HeaderText = "参考温度(K)";
            dataGridView2.Columns["refer_p"].HeaderText = "参考压力(MPa)";
            DataRow row = dataTable01.NewRow();
            row["gas_constant"] = Data.gas_const;
            row["refer_t"] = Data.t_ref;
            row["refer_p"] = Data.p_ref;
            Console.WriteLine("01 = {0} ,02 = {1}, 03 = {2} ", Data.gas_const, Data.t_ref, Data.p_ref);
            dataTable01.Rows.Add(row);

            // ------表2-------
            DataTable dataTable02 = new DataTable();
            dataTable02.Columns.Add("material_num", typeof(int));
            // 设置DataGridView的DataSource  
            dataGridView3.DataSource = dataTable02;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 设置列名  
            dataGridView3.Columns["material_num"].HeaderText = "材料数";
            DataRow row2 = dataTable02.NewRow();
            row2["material_num"] = Data.n_mat;

            Console.WriteLine("01 = {0} ", Data.n_mat);
            dataTable02.Rows.Add(row2);

            // --------表3---------
            DataTable dataTable03 = new DataTable();
            dataTable03.Columns.Add("id_no", typeof(int));
            dataTable03.Columns.Add("name", typeof(string));
            dataTable03.Columns.Add("mol", typeof(double));

            dataGridView4.DataSource = dataTable03;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 设置列名  
            dataGridView4.Columns["id_no"].HeaderText = "介质序号";
            dataGridView4.Columns["name"].HeaderText = "介质名称";
            dataGridView4.Columns["mol"].HeaderText = "介质分子量";

            for (int i = 0; i < Data.n_mat; i++)
            {
                //添加行数据
                DataRow row3 = dataTable03.NewRow();
                row3["id_no"] = Data.mat[i].id;
                row3["name"] = Data.mat[i].name;
                row3["mol"] = Data.mat[i].mol;

                dataTable03.Rows.Add(row3);
            }
        }

        private void GetDatabase03()
        {

            DataTable dataTable01 = new DataTable();

            dataTable01.Columns.Add("id", typeof(int));
            dataTable01.Columns.Add("temperature", typeof(double));
            dataTable01.Columns.Add("pressure", typeof(double));
            dataTable01.Columns.Add("flow", typeof(double));
            dataTable01.Columns.Add("s_h_con", typeof(double));
            dataTable01.Columns.Add("l_n_ratio", typeof(double));
            dataTable01.Columns.Add("medium", typeof(int));
            dataTable01.Columns.Add("h2_type", typeof(bool));

            // 设置DataGridView的DataSource  
            dataGridView5.DataSource = dataTable01;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置列名  
            dataGridView5.Columns["id"].HeaderText = "流股序号";
            dataGridView5.Columns["temperature"].HeaderText = "温度(K)";
            dataGridView5.Columns["pressure"].HeaderText = "压力(MPa)";
            dataGridView5.Columns["flow"].HeaderText = "质量流量(kg/s)";
            dataGridView5.Columns["s_h_con"].HeaderText = "仲氢浓度";
            dataGridView5.Columns["l_n_ratio"].HeaderText = "液氮浓度";
            dataGridView5.Columns["medium"].HeaderText = "工质";
            dataGridView5.Columns["h2_type"].HeaderText = "循环氢";

            for (int i = 0; i < Data.n_line; i++)
            {
                //添加行数据
                DataRow row = dataTable01.NewRow();
                row["id"] = Data.line[i].ip;
                row["temperature"] = Data.line[i].t;
                row["pressure"] = Data.line[i].p;
                row["flow"] = Data.line[i].m;
                row["s_h_con"] = Data.line[i].para;
                row["l_n_ratio"] = Data.line[i].n2;
                row["medium"] = Data.line[i].mat;
                row["h2_type"] = Data.line[i].h2_type;

                dataTable01.Rows.Add(row);
            }
        }

        private void UserControl4_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
        private void ReWinformLayout()
        {
            var newx = Width / x;
            var newy = Height / y;
            setControls(newx, newy, this);
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
    }
}


