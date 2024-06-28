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

namespace SimulationDesignPlatform.Forms
{
	public partial class Form8_1 : Form
	{
		private readonly float x;//定义当前窗体的宽度
		private readonly float y;//定义当前窗体的高度

		public Form8_1()
		{
			InitializeComponent();
			GetDatabase();
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

		private void Form8_Resize(object sender, EventArgs e)
		{
			//重置窗口布局
			ReWinformLayout();
		}

		private void GetDatabase()
		{
			dataGridView1.AutoGenerateColumns = false;

			//清空列勾选框的所有选项
			checkedListBox1.Items.Clear();
			// 添加列勾选项
			if (Data.data15.Count > 0)
			{
				dataGridView1.ColumnCount = Data.data15[0].Count;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.ColumnCount;
                }
                dataGridView1.Columns[0].Width = 80;

                for (int k = 0; k < Data.data15[0].Count; k++)
				{
					switch (Data.data15[0][k].ToUpper().Trim())
					{
						case "NUM":
							dataGridView1.Columns[k].Name = "流股序号";
							checkedListBox1.Items.Add("流股序号");
							break;
						case "T ":
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
				if (Data.data15_check != null)
				{
					for (int i = 0; i < Data.data15_check.Length; i++)
					{
						if (Data.data15_check[i] == "true")
						{
							checkedListBox1.SetItemChecked(i, true);
						}
					}
				}
				for (int i = 1; i < Data.data15.Count; i++)
				{
					dataGridView1.Rows.Add(Data.data15[i].ToArray());
				}
				//显示设置的阈值
				textBox1.Text = Data.yz_num[13].ToString();
			}
			else
			{
				string filepath = Path.Combine(Data.caseUsePath, "output.data", "node_1.csv");
				using (TextFieldParser parser = new TextFieldParser(filepath))
				{
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");

					while (!parser.EndOfData)
					{
						string[] fields = parser.ReadFields();
                        List<string> rfields = new List<string> { };
                        for (int i = 0; i < fields.Length; i++)
                        {
                            if (fields[i].Trim() != String.Empty)
                            { rfields.Add(fields[i].Trim()); }
                        }

                        List<string> row = new List<string>(rfields);
						Data.data15.Add(row);
					}
				}

				if (Data.data15.Count > 0)
				{
					dataGridView1.ColumnCount = Data.data15[0].Count;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.ColumnCount;
                    }
                    dataGridView1.Columns[0].Width = 80;

                    for (int k = 0; k < Data.data15[0].Count; k++)
					{
						switch (Data.data15[0][k].ToUpper().Trim())
						{
							case "NUM":
								dataGridView1.Columns[k].Name = "流股序号";
								checkedListBox1.Items.Add("流股序号");
								break;
							case "T ":
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
				}

				for (int i = 1; i < Data.data15.Count; i++)
				{
					dataGridView1.Rows.Add(Data.data15[i].ToArray());
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == null || textBox1.Text == "")
			{
				Data.yz_num[13] = 0;
			}
			else
			{
				Data.yz_num[13] = int.Parse(textBox1.Text);
			}

			Data.data15_check = new string[Data.data15[0].Count];
			for (int i = 0; i < Data.data15_check.Length; i++)
			{
				if (checkedListBox1.GetItemChecked(i))
				{
					Data.data15_check[i] = "true";
				}
				else
				{
					Data.data15_check[i] = "false";
				}
			}

			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
