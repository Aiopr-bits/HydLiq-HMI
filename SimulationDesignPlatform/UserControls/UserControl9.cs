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
        public readonly float x;//定义当前窗体的宽度
        public readonly float y;//定义当前窗体的高度
        public UserControl9()
        {
            InitializeComponent();
            Show_TreeView();
            #region  初始化控件缩放
            x = Width;
            y = Height;
            setTag(this);
            #endregion

            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
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

        public void Show_TreeView()
        {
            TreeNode tn1 = new TreeNode(Data.fzxt_name);
            treeView1.Nodes.Add(tn1);

            for (int i = 0; i < Data.n_node; i++)
            {
                tn1.Nodes.Add(Data.node[i].name);
            }
        }

        public void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode sn1 = treeView1.SelectedNode; 

            if (treeView1.SelectedNode.Text.Trim().ToLower() ==string.Empty|| treeView1.SelectedNode.Text.Trim().ToLower() == Data.fzxt_name.Trim().ToLower())
                return;
            else
            {
                int node_id = treeView1.SelectedNode.Index + 1;
                Show_NodeData(node_id);
            }
        }


        public void Show_NodeData(int id)
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 获取当前编辑的列名
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            // 获取当前行
            DataGridViewRow currentRow = dataGridView1.Rows[e.RowIndex];

            // 根据列名处理逻辑
            if (columnName == "in_id")
            {
                // 用户修改了 in_id，更新 in_name
                int inId = Convert.ToInt32(currentRow.Cells["in_id"].Value);
                string inName = GetNameById(inId);
                currentRow.Cells["in_name"].Value = inName;
            }
            else if (columnName == "in_name")
            {
                // 用户修改了 in_name，更新 in_id
                string inName = currentRow.Cells["in_name"].Value.ToString();
                int inId = GetIdByName(inName);
                currentRow.Cells["in_id"].Value = inId;
            }
            else if (columnName == "out_id")
            {
                // 用户修改了 out_id，更新 out_name
                int outId = Convert.ToInt32(currentRow.Cells["out_id"].Value);
                string outName = GetNameById(outId);
                currentRow.Cells["out_name"].Value = outName;
            }
            else if (columnName == "out_name")
            {
                // 用户修改了 out_name，更新 out_id
                string outName = currentRow.Cells["out_name"].Value.ToString();
                int outId = GetIdByName(outName);
                currentRow.Cells["out_id"].Value = outId;
            }
        }

        private string GetNameById(int id)
        {
            foreach (var line in Data.line)
            {
                if (line.ip == id)
                {
                    return line.name;
                }
            }
            return string.Empty; 
        }

        private int GetIdByName(string name)
        {
            foreach (var line in Data.line)
            {
                if (line.name == name)
                {
                    return line.ip;
                }
            }
            return 0; 
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // 获取当前选中的节点
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode == null || selectedNode.Parent == null)
            {
                MessageBox.Show("请选择一个有效的节点。");
                return;
            }

            // 获取节点ID
            int node_id = selectedNode.Index + 1;

            // 更新 Data.node 对象
            if (node_id > 0 && node_id <= Data.node.Length)
            {
                var currentNode = Data.node[node_id - 1];
                currentNode.i = new int[dataGridView1.Rows.Count];
                currentNode.o = new int[dataGridView1.Rows.Count];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    currentNode.i[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells["in_id"].Value);
                    currentNode.o[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells["out_id"].Value);
                }
            }

            // 保存数据到 CSV 文件
            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);

            Task.Run(() =>
            {
                MessageBox.Show("保存成功！");
            });
        }

        public void UserControl9_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
