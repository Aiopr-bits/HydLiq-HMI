using Microsoft.VisualBasic.FileIO;
using SimulationDesignPlatform.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationDesignPlatform.Forms
{
    public partial class Form6 : Form
    {
        public readonly float x;//定义当前窗体的宽度
        public readonly float y;//定义当前窗体的高度
        public Form6()
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

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取选择的选项
            string selectedOption = comboBox1.SelectedItem.ToString();

            // 更新标签文本
            comboBox1.Text = selectedOption;

            dataGridView1.AutoGenerateColumns = false;

            if (selectedOption == "图表-1")
            {
                //清空列勾选框的所有选项
                checkedListBox1.Items.Clear();
                // 添加列勾选项
                if (Data.data11.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data11[0].Count;
                    for (int k = 0; k < Data.data11[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data11[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                    for (int i = 0; i < Data.data11_check.Length; i++)
                    {
                        if (Data.data11_check[i] == "true")
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }
                
                for (int i = 1; i < Data.data11.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data11[i].ToArray());
                }
                //显示设置的时间
                if (Data.check_time[10] > DateTime.MinValue)
                {
                    dateTimePicker1.Value = Data.check_time[10];
                }
                //显示设置的阈值
                textBox1.Text = Data.yz_num[10].ToString();
            }
            else if (selectedOption == "图表-2")
            {
                //清空列勾选框的所有选项
                checkedListBox1.Items.Clear();
                // 添加列勾选项
                if (Data.data12.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data12[0].Count;
                    for (int k = 0; k < Data.data12[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data12[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                    for (int i = 0; i < Data.data12_check.Length; i++)
                    {
                        if (Data.data12_check[i] == "true")
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }

                for (int i = 1; i < Data.data12.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data12[i].ToArray());
                }
                //显示设置的时间
                if (Data.check_time[11] > DateTime.MinValue)
                {
                    dateTimePicker1.Value = Data.check_time[11];
                }
                //显示设置的阈值
                textBox1.Text = Data.yz_num[11].ToString();

            }
            else if (selectedOption == "图表-3")
            {
                //清空列勾选框的所有选项
                checkedListBox1.Items.Clear();
                // 添加列勾选项
                if (Data.data13.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data13[0].Count;
                    for (int k = 0; k < Data.data13[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data13[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                    for (int i = 0; i < Data.data13_check.Length; i++)
                    {
                        if (Data.data13_check[i] == "true")
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }

                for (int i = 1; i < Data.data13.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data13[i].ToArray());
                }
                //显示设置的时间
                if (Data.check_time[12] > DateTime.MinValue)
                {
                    dateTimePicker1.Value = Data.check_time[12];
                }
                //显示设置的阈值
                textBox1.Text = Data.yz_num[12].ToString();
            }
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();
            if (selectedOption == "图表-1")
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    Data.yz_num[10] = 0;
                }
                else
                {
                    Data.yz_num[10] = int.Parse(textBox1.Text);
                }

                Data.check_time[10] = dateTimePicker1.Value;

                Data.data11_check = new string[Data.data11[0].Count];
                for (int i = 0; i < Data.data11_check.Length; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Data.data11_check[i] = "true";
                    }
                    else
                    {
                        Data.data11_check[i] = "false";
                    }
                }
            }
            else if (selectedOption == "图表-2")
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    Data.yz_num[11] = 0;
                }
                else
                {
                    Data.yz_num[11] = int.Parse(textBox1.Text);
                }

                Data.check_time[11] = dateTimePicker1.Value;

                Data.data12_check = new string[Data.data12[0].Count];
                for (int i = 0; i < Data.data12_check.Length; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Data.data12_check[i] = "true";
                    }
                    else
                    {
                        Data.data12_check[i] = "false";
                    }
                }
            }
            else if (selectedOption == "图表-3")
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    Data.yz_num[12] = 0;
                }
                else
                {
                    Data.yz_num[12] = int.Parse(textBox1.Text);
                }

                Data.check_time[12] = dateTimePicker1.Value;

                Data.data13_check = new string[Data.data13[0].Count];
                for (int i = 0; i < Data.data13_check.Length; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Data.data13_check[i] = "true";
                    }
                    else
                    {
                        Data.data13_check[i] = "false";
                    }
                }
            }

            this.Close();

        }

        public void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            object selectedOption = comboBox1.SelectedItem;
            if (selectedOption == null)
            {
                MessageBox.Show("请先选择图表！");
                return;
            }
            if (selectedOption.ToString() == "图表-1")
            {
                using (TextFieldParser parser = new TextFieldParser("line_result.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data11.Add(row);
                    }
                }

                MessageBox.Show("图表-1数据导入成功！");

                if (Data.data11.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data11[0].Count;
                    for (int k = 0; k < Data.data11[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data11[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                }

                for (int i = 1; i < Data.data11.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data11[i].ToArray());
                }

            }
            else if (selectedOption.ToString() == "图表-2")
            {
                using (TextFieldParser parser = new TextFieldParser("line_result.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data12.Add(row);
                    }
                }

                MessageBox.Show("图表-2数据导入成功！");

                if (Data.data12.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data12[0].Count;
                    for (int k = 0; k < Data.data12[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data12[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                }

                for (int i = 1; i < Data.data12.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data12[i].ToArray());
                }
            }
            else if (selectedOption.ToString() == "图表-3")
            {
                using (TextFieldParser parser = new TextFieldParser("line_result.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data13.Add(row);
                    }
                }

                MessageBox.Show("图表-2数据导入成功！");

                if (Data.data13.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data13[0].Count;
                    for (int k = 0; k < Data.data13[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data13[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                }

                for (int i = 1; i < Data.data13.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data13[i].ToArray());
                }
            }
            
        }

        public void Form6_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

    }
}
