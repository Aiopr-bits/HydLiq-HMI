using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationDesignPlatform.UserControls
{
    public partial class UserControl9 : UserControl
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public UserControl9()
        {
            InitializeComponent();
            Show_TreeView();
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

        private void Show_TreeView()
        {
            TreeNode tn1 = new TreeNode(Data.fzxt_name);
            treeView1.Nodes.Add(tn1);

            for (int i = 0; i < Data.n_node; i++)
            {
                //tn1.Nodes.Add(Data.node[i].id + Data.node[i].name);
                tn1.Nodes.Add(Data.node[i].name);
            }
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode sn1 = treeView1.SelectedNode; // 获取选中的节点
            /*                                      
           string node_text = sn1.Text;
           if (node_text == "")
           {
               return;
           }
           bool startsWithNumber = Regex.IsMatch(node_text, @"^*\d*$");
           if (startsWithNumber == true)
           {
               int node_id = treeView1.SelectedNode.Index;
               int node_id = int.Parse(node_text.Substring(0, 1));
               Show_NodeData(node_id);
           }
           else
           {
               MessageBox.Show("所选节点格式有误！");
           }
            */


            //zhangax修改
            if (treeView1.SelectedNode.Text.Trim().ToLower() ==string.Empty|| treeView1.SelectedNode.Text.Trim().ToLower() == Data.fzxt_name.Trim().ToLower())
                return;
            else
            {
                int node_id = treeView1.SelectedNode.Index + 1;
                Show_NodeData(node_id);
            }
        }


        private void Show_NodeData(int id)
        {

            dataGridView1.AllowUserToAddRows = false;
            DataTable dataTable01 = new DataTable();

            dataTable01.Columns.Add("in_id", typeof(int));
            dataTable01.Columns.Add("in_name", typeof(string));
            dataTable01.Columns.Add("out_id", typeof(int));
            dataTable01.Columns.Add("out_name", typeof(string));

            // 设置DataGridView的DataSource  
            dataGridView1.DataSource = dataTable01;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 设置列名
            dataGridView1.Columns["in_id"].HeaderText = "输入流股序号";
            dataGridView1.Columns["in_name"].HeaderText = "输入流股名称";
            dataGridView1.Columns["out_id"].HeaderText = "输出流股序号";
            dataGridView1.Columns["out_name"].HeaderText = "输出流股名称";

            /*
            for (int i = 0; i < Data.node[id - 1].n; i++)
            {
                //添加行数据
                DataRow row = dataTable01.NewRow();
                row["in_id"] = Data.node[id - 1].i[i];
                row["out_id"] = Data.node[id - 1].o[i];

                dataTable01.Rows.Add(row);
            }*/


            //zhangax修改
            if (id > 0)
            {
                for (int i = 0; i < Data.node[id - 1].n; i++)
                {
                    //添加行数据
                    DataRow row = dataTable01.NewRow();
                    row["in_id"] = Data.node[id - 1].i[i];
                    string lineName = String.Empty;
                    for (int j = 0; j < Data.line.Length; j++)
                    {
                        if (Data.node[id - 1].i[i] == Data.line[j].ip)
                        {
                            lineName = Data.line[j].name;
                            break;
                        }
                    }
                    row["in_name"] = lineName;
                    row["out_id"] = Data.node[id - 1].o[i];
                    lineName = String.Empty;
                    for (int j = 0; j < Data.line.Length; j++)
                    {
                        if (Data.node[id - 1].o[i] == Data.line[j].ip)
                        {
                            lineName = Data.line[j].name;
                            break;
                        }
                    }
                    row["out_name"] = lineName;
                    dataTable01.Rows.Add(row);
                }
            }
        }


        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
           if( this.dataGridView1.CurrentRow==null)
                return;

            int inNum = int.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            string lineName = String.Empty;

            for (int j = 0; j < Data.line.Length; j++)
            {
                if (inNum == Data.line[j].ip)
                {
                    lineName = Data.line[j].name;
                    break;
                }
            }
            this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value = lineName;

            int outNum = int.Parse(this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString());
            lineName = String.Empty;

            for (int j = 0; j < Data.line.Length; j++)
            {
                if (outNum == Data.line[j].ip)
                {
                    lineName = Data.line[j].name;
                    break;
                }
            }
            this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[3].Value = lineName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode sn1 = treeView1.SelectedNode; // 获取选中的节点
            string node_text = sn1.Text;
            int id = int.Parse(node_text.Substring(0, 1));
            for (int i = 0; i < Data.node[id-1].n; i++)
            {
                Data.node[id - 1].i[i] = (int)dataGridView1.Rows[i].Cells[0].Value;
                Data.node[id - 1].o[i] = (int)dataGridView1.Rows[i].Cells[1].Value;
            }

            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);

            Task.Run(() =>
            {
                MessageBox.Show("保存成功！");
            });
        }

        private void UserControl9_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }


    }
}
