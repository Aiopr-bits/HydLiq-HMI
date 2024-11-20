using Microsoft.VisualBasic.FileIO;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimulationDesignPlatform.Forms
{
	public partial class Form8_2 : Form
	{
		public readonly float x;//定义当前窗体的宽度
		public readonly float y;//定义当前窗体的高度

		public Form8_2()
		{
			InitializeComponent();
			GetDatabase();
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

		public void Form8_Resize(object sender, EventArgs e)
		{
			//重置窗口布局
			ReWinformLayout();
		}

		public void GetDatabase()
		{
			dataGridView1.AutoGenerateColumns = false;

			//清空列勾选框的所有选项
			checkedListBox1.Items.Clear();
			Data.data16.Clear();
			// 添加列勾选项
			if (Data.data16.Count > 0)
			{
				dataGridView1.ColumnCount = Data.data16[0].Count;
				for (int i = 0; i < dataGridView1.ColumnCount; i++)
				{
					dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.ColumnCount;
				}
				dataGridView1.Columns[0].Width = 80; 
                for (int k = 0; k < Data.data16[0].Count; k++)
                {
                    switch (Data.data16[0][k].ToUpper().Trim())
                    {
                        case "NUM":
                            dataGridView1.Columns[k].Name = "流股序号";
                            checkedListBox1.Items.Add("流股序号");
                            break;
                        case "T":
                            dataGridView1.Columns[k].Name = "温度(K)";
                            checkedListBox1.Items.Add("温度");
                            break;
                        case "P":
                            dataGridView1.Columns[k].Name = "压力(MPa)";
                            checkedListBox1.Items.Add("压力");
							break;
                        case "PARA":
                            dataGridView1.Columns[k].Name = "仲氢浓度";
                            checkedListBox1.Items.Add("仲氢浓度");
                            break;
                        case "M":
                            dataGridView1.Columns[k].Name = "质量流量(kg/s)";
                            checkedListBox1.Items.Add("质量流量");
                            break;
                        case "W":
                            dataGridView1.Columns[k].Name = "功(kW)";
                            checkedListBox1.Items.Add("功");
                            break;
                        case "Q":
                            dataGridView1.Columns[k].Name = "热(kW)";
                            checkedListBox1.Items.Add("热");
                            break;
                        case "H":
                            dataGridView1.Columns[k].Name = "比焓(kJ/kg)";
                            checkedListBox1.Items.Add("比焓");
                            break;
                        case "S":
                            dataGridView1.Columns[k].Name = "比熵(kJ/(kg·K))";
                            checkedListBox1.Items.Add("比熵");
                            break;
                    }
                }

				if (Data.data16_check != null)
				{
					for (int i = 0; i < Data.data16_check.Length; i++)
					{
						if (Data.data16_check[i] == "true")
						{
							checkedListBox1.SetItemChecked(i, true);
						}
					}
				}
				for (int i = 1; i < Data.data16.Count; i++)
				{
					dataGridView1.Rows.Add(Data.data16[i].ToArray());
				}
				//显示设置的阈值
				textBox1.Text = Data.yz_num[13].ToString();
			}
			else
			{
				String filepath = Path.Combine(Data.caseUsePath, "output.data", "line_1.csv");
				using (TextFieldParser parser = new TextFieldParser(filepath))
				{
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");

					while (!parser.EndOfData)
					{
						string[] fields = parser.ReadFields();
						List<string> rfields=new List<string> { };
						for (int i = 0; i < fields.Length; i++)
						{
							if (fields[i].Trim() != String.Empty)
							{ rfields.Add(fields[i].Trim()); }
						}
						List<string> row = new List<string>(rfields);
						Data.data16.Add(row);
					}
				}

				if (Data.data16.Count > 0)
				{
					dataGridView1.ColumnCount = Data.data16[0].Count;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {						
                        dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.ColumnCount;
                    }
                    dataGridView1.Columns[0].Width = 80; 
                    for (int k = 0; k < Data.data16[0].Count; k++)
					{
                        switch (Data.data16[0][k].ToUpper().Trim())
                        {
                            case "NUM":
                                dataGridView1.Columns[k].Name = "流股序号";
                                checkedListBox1.Items.Add("流股序号");
                                break;
                            case "T":
                                dataGridView1.Columns[k].Name = "温度(K)";
                                checkedListBox1.Items.Add("温度");
                                break;
                            case "P":
                                dataGridView1.Columns[k].Name = "压力(MPa)";
                                checkedListBox1.Items.Add("压力");
                                break;
                            case "PARA":
                                dataGridView1.Columns[k].Name = "仲氢浓度";
                                checkedListBox1.Items.Add("仲氢浓度");
                                break;
                            case "M":
                                dataGridView1.Columns[k].Name = "质量流量(kg/s)";
                                checkedListBox1.Items.Add("质量流量");
                                break;
                            case "W":
                                dataGridView1.Columns[k].Name = "功(kW)";
                                checkedListBox1.Items.Add("功");
                                break;
                            case "Q":
                                dataGridView1.Columns[k].Name = "热(kW)";
                                checkedListBox1.Items.Add("热");
                                break;
                            case "H":
                                dataGridView1.Columns[k].Name = "比焓(kJ/kg)";
                                checkedListBox1.Items.Add("比焓");
                                break;
                            case "S":
                                dataGridView1.Columns[k].Name = "比熵(kJ/(kg·K))";
                                checkedListBox1.Items.Add("比熵");
                                break;
                        }
                    }

                    for (int i = 1; i < Data.data16.Count; i++)
                    {
                        dataGridView1.Rows.Add(Data.data16[i].ToArray());
                    }
                }
			}
		}

		public void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == null || textBox1.Text == "")
			{
				Data.yz_num[13] = 0;
			}
			else
			{
				Data.yz_num[13] = int.Parse(textBox1.Text);
			}

			Data.data16_check = new string[Data.data16[0].Count];
			for (int i = 0; i < Data.data16_check.Length; i++)
			{
				if (checkedListBox1.GetItemChecked(i))
				{
					Data.data16_check[i] = "true";
				}
				else
				{
					Data.data16_check[i] = "false";
				}
			}

			this.Close();
		}

		public void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
