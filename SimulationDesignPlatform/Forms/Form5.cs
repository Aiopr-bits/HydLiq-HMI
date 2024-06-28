using Microsoft.VisualBasic.FileIO;
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
    public partial class Form5 : Form
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public Form5()
        {
            InitializeComponent();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取选择的选项
            string selectedOption = comboBox1.SelectedItem.ToString();

            // 更新标签文本
            comboBox1.Text = selectedOption;

            dataGridView1.AutoGenerateColumns = false;

            if (selectedOption == "电解电流")
            {
                //清空列勾选框的所有选项
                checkedListBox1.Items.Clear();
                // 添加列勾选项
                if (Data.data7.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data7[0].Count;
                    for (int k = 0; k < Data.data7[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data7[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                    for (int i = 0; i < Data.data7_check.Length; i++)
                    {
                        if (Data.data7_check[i] == "true")
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }
                
                for (int i = 1; i < Data.data7.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data7[i].ToArray());
                }
                //显示设置的时间
                if (Data.check_time[6] > DateTime.MinValue)
                {
                    dateTimePicker1.Value = Data.check_time[6];
                }
                //显示设置的阈值
                textBox1.Text = Data.yz_num[6].ToString();
            }
            else if (selectedOption == "电解电压")
            {
                //清空列勾选框的所有选项
                checkedListBox1.Items.Clear();
                // 添加列勾选项
                if (Data.data8.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data8[0].Count;
                    for (int k = 0; k < Data.data8[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data8[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                    for (int i = 0; i < Data.data8_check.Length; i++)
                    {
                        if (Data.data8_check[i] == "true")
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }

                for (int i = 1; i < Data.data8.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data8[i].ToArray());
                }
                //显示设置的时间
                if (Data.check_time[7] > DateTime.MinValue)
                {
                    dateTimePicker1.Value = Data.check_time[7];
                }
                //显示设置的阈值
                textBox1.Text = Data.yz_num[7].ToString();
            }
            else if (selectedOption == "氧中氢")
            {
                //清空列勾选框的所有选项
                checkedListBox1.Items.Clear();
                // 添加列勾选项
                if (Data.data9.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data9[0].Count;
                    for (int k = 0; k < Data.data9[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data9[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                    for (int i = 0; i < Data.data9_check.Length; i++)
                    {
                        if (Data.data9_check[i] == "true")
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }

                for (int i = 1; i < Data.data9.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data9[i].ToArray());
                }
                //显示设置的时间
                if (Data.check_time[8] > DateTime.MinValue)
                {
                    dateTimePicker1.Value = Data.check_time[8];
                }
                //显示设置的阈值
                textBox1.Text = Data.yz_num[8].ToString();
            }
            else if (selectedOption == "温度")
            {
                //清空列勾选框的所有选项
                checkedListBox1.Items.Clear();
                // 添加列勾选项
                if (Data.data10.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data10[0].Count;
                    for (int k = 0; k < Data.data10[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data10[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                    for (int i = 0; i < Data.data10_check.Length; i++)
                    {
                        if (Data.data10_check[i] == "true")
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }

                for (int i = 1; i < Data.data10.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data10[i].ToArray());
                }
                //显示设置的时间
                if (Data.check_time[9] > DateTime.MinValue)
                {
                    dateTimePicker1.Value = Data.check_time[9];
                }
                //显示设置的阈值
                textBox1.Text = Data.yz_num[9].ToString();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object selectedOption = comboBox1.SelectedItem;
            if (selectedOption == null)
            {
                MessageBox.Show("请先选择图表！");
                return;
            }
            if (selectedOption.ToString() == "电解电流")
            {
                using (TextFieldParser parser = new TextFieldParser("line_result.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data7.Add(row);
                    }
                }

                MessageBox.Show("电解电流数据导入成功！");

                if (Data.data7.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data7[0].Count;
                    for (int k = 0; k < Data.data7[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data7[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                }

                for (int i = 1; i < Data.data7.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data7[i].ToArray());
                }

            }
            else if (selectedOption.ToString() == "电解电压")
            {
                using (TextFieldParser parser = new TextFieldParser("line_result.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data8.Add(row);
                    }
                }

                MessageBox.Show("电解电压数据导入成功！");

                if (Data.data8.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data8[0].Count;
                    for (int k = 0; k < Data.data8[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data8[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                }

                for (int i = 1; i < Data.data8.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data8[i].ToArray());
                }
            }
            else if (selectedOption.ToString() == "氧中氢")
            {
                using (TextFieldParser parser = new TextFieldParser("line_result.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data9.Add(row);
                    }
                }

                MessageBox.Show("氧中氢数据导入成功！");

                if (Data.data9.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data9[0].Count;
                    for (int k = 0; k < Data.data9[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data9[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                }

                for (int i = 1; i < Data.data9.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data9[i].ToArray());
                }
            }
            else if (selectedOption.ToString() == "温度")
            {
                using (TextFieldParser parser = new TextFieldParser("line_result.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data10.Add(row);
                    }
                }

                MessageBox.Show("温度数据导入成功！");

                if (Data.data10.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data10[0].Count;
                    for (int k = 0; k < Data.data10[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data10[0][k];
                        checkedListBox1.Items.Add(dataGridView1.Columns[k].Name);
                    }
                }

                for (int i = 1; i < Data.data10.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data10[i].ToArray());
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();
            if (selectedOption == "电解电流")
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    Data.yz_num[6] = 0;
                }
                else
                {
                    Data.yz_num[6] = int.Parse(textBox1.Text);
                }

                Data.check_time[6] = dateTimePicker1.Value;

                Data.data7_check = new string[Data.data7[0].Count];
                for (int i = 0; i < Data.data7_check.Length; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Data.data7_check[i] = "true";
                    }
                    else
                    {
                        Data.data7_check[i] = "false";
                    }
                }
            }
            else if (selectedOption == "电解电压")
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    Data.yz_num[7] = 0;
                }
                else
                {
                    Data.yz_num[7] = int.Parse(textBox1.Text);
                }

                Data.check_time[7] = dateTimePicker1.Value;

                Data.data8_check = new string[Data.data8[0].Count];
                for (int i = 0; i < Data.data8_check.Length; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Data.data8_check[i] = "true";
                    }
                    else
                    {
                        Data.data8_check[i] = "false";
                    }
                }
            }
            else if (selectedOption == "氧中氢")
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    Data.yz_num[8] = 0;
                }
                else
                {
                    Data.yz_num[8] = int.Parse(textBox1.Text);
                }

                Data.check_time[8] = dateTimePicker1.Value;

                Data.data9_check = new string[Data.data9[0].Count];
                for (int i = 0; i < Data.data9_check.Length; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Data.data9_check[i] = "true";
                    }
                    else
                    {
                        Data.data9_check[i] = "false";
                    }
                }
            }
            else if (selectedOption == "温度")
            {
                if (textBox1.Text == null || textBox1.Text == "")
                {
                    Data.yz_num[9] = 0;
                }
                else
                {
                    Data.yz_num[9] = int.Parse(textBox1.Text);
                }

                Data.check_time[9] = dateTimePicker1.Value;

                Data.data10_check = new string[Data.data10[0].Count];
                for (int i = 0; i < Data.data10_check.Length; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        Data.data10_check[i] = "true";
                    }
                    else
                    {
                        Data.data10_check[i] = "false";
                    }
                }
            }
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
