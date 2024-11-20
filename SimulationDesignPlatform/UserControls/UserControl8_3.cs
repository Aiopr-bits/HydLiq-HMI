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
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulationDesignPlatform.UserControls
{
	public partial class UserControl8_3 : UserControl
	{
		public readonly float x;//定义当前窗体的宽度
		public readonly float y;//定义当前窗体的高度
		public UserControl8_3()
		{
			InitializeComponent();
			Show_Chart();
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

		public void Show_Chart()
		{
			if (Data.data17.Count > 0)
			{
				chart1.Series.Clear();
				chart1.Titles.Add("仿真结果");
				int check_num = 0;
				if (Data.data17_check != null)
				{
					for (int a = 0; a < Data.data17_check.Length; a++)
					{
						if (Data.data17_check[a] == "true" && a > 0)
						{
							check_num++;
						}
					}
					int[] nums = new int[check_num];
					int m = 0;
					if (Data.data17_check != null)
					{
						for (int b = 0; b < Data.data17_check.Length; b++)
						{
							if (Data.data17_check[b] == "true" && b > 0)
							{
								nums[m] = b;
								m++;
							}
						}

						for (int i = 0; i < check_num; i++)
						{
							Series series1 = chart1.Series.Add(Data.data17[0][nums[i]]);
							string lineName = "";
							switch (series1.Name.Trim())
							{
								case "num":
                                    lineName = "num";
                                    break;
								case "inode":
                                    lineName = "inode";
                                    break;
                                case "deltaT_min":
                                    lineName = "deltaT_min";
                                    break;
								case "deltaT_average":
									lineName = "deltaT_average";
                                    break;
                            }
							series1.Name = lineName;
							series1.ChartType = SeriesChartType.Spline;
							for (int k = 1; k < Data.data17.Count; k++)
							{
								series1.Points.AddXY(Data.data17[k][0], Data.data17[k][nums[i]]);
							}
						}
					}
				}

				dataGridView1.AllowUserToAddRows = false;

				if (Data.data17.Count > 0)
				{
					dataGridView1.ColumnCount = Data.data17[0].Count;
					dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

					for (int k = 0; k < Data.data17[0].Count; k++)
					{
						switch (Data.data17[0][k].Trim())	
						{
							case "num":
								dataGridView1.Columns[k].Name = "num";
								break;
                            case "inode":
                                dataGridView1.Columns[k].Name = "inode";
                                break;
                            case "deltaT_min":
                                dataGridView1.Columns[k].Name = "deltaT_min";
                                break;
                            case "deltaT_average":
                                dataGridView1.Columns[k].Name = "deltaT_average";
                                break;
                        }
					}
				}

				for (int i = 1; i < Data.data17.Count; i++)
				{
					dataGridView1.Rows.Add(Data.data17[i].ToArray());
				}
			}
			else
             {
                String filepath = Path.Combine(Data.caseUsePath, "output.data", "deltaT.csv");
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
                        Data.data17.Add(row);
                    }
                }

				if (Data.data17.Count > 0)
				{
					dataGridView1.ColumnCount = Data.data17[0].Count;
					for (int i = 0; i < dataGridView1.ColumnCount; i++)
					{
						dataGridView1.Columns[i].Width = dataGridView1.Width / dataGridView1.ColumnCount;
					}
					dataGridView1.Columns[0].Width = 80;
					for (int k = 0; k < Data.data17[0].Count; k++)
					{
						switch (Data.data17[0][k].Trim())
						{
							case "num":
								dataGridView1.Columns[k].Name = "num";
								break;
                            case "inode":
                                dataGridView1.Columns[k].Name = "inode";
                                break;
                            case "deltaT_min":
                                dataGridView1.Columns[k].Name = "deltaT_min";
                                break;
                            case "deltaT_average":
                                dataGridView1.Columns[k].Name = "deltaT_average";
                                break;
                        }
					}

					for (int i = 1; i < Data.data17.Count; i++)
					{
						dataGridView1.Rows.Add(Data.data17[i].ToArray());
					}
				}
            }	
		}

		public void UserControl8_Resize(object sender, EventArgs e)
		{
			//重置窗口布局
			ReWinformLayout();
		}
	}
}
