using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationDesignPlatform.UserControls
{
	public partial class UserControl6 : UserControl
	{
		public readonly float x;//定义当前窗体的宽度
		public readonly float y;//定义当前窗体的高度

		// 一些可能用到的单元格样式
		public readonly DataGridViewCellStyle sDefault = new DataGridViewCellStyle();    // 默认单元格样式
		public readonly DataGridViewCellStyle sToBeSolved = new DataGridViewCellStyle()
		{
			BackColor = Color.PaleGreen,
		};	// 表示该单元格值待求解

		public UserControl6()
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
			DataTable dataTable01 = new DataTable();

			this.dataGridView1.DataSource = dataTable01;
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "id",
				HeaderText = "流股序号",
				DataPropertyName = "id",
			});
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "name",
				HeaderText = "流股名称",
				DataPropertyName = "name",
			});
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "temperature",
				HeaderText = "温度(K)",
				DataPropertyName = "temperature",
			});
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "pressure",
				HeaderText = "压力(MPa)",
				DataPropertyName = "pressure",
			});
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "flow",
				HeaderText = "流量(kg/s)",
				DataPropertyName = "flow",
			});
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "s_h_con",
				HeaderText = "仲氢浓度",
				DataPropertyName = "s_h_con",
			});
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "l_n_ratio",
				HeaderText = "液氮浓度",
				DataPropertyName = "l_n_ratio",
			});
			this.dataGridView1.Columns.Add(new DataGridViewComboBoxColumn()
			{
				Name = "medium",
				HeaderText = "工质",
				DataPropertyName = "medium",
				DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
			});
			this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
			{
				Name = "h2_type",
				HeaderText = "循环氢",
				DataPropertyName = "h2_type",
			});

			dataTable01.Columns.Add("id", typeof(int));
			dataTable01.Columns.Add("name", typeof(string));
			dataTable01.Columns.Add("temperature", typeof(double));
			dataTable01.Columns.Add("pressure", typeof(double));
			dataTable01.Columns.Add("flow", typeof(double));
			dataTable01.Columns.Add("s_h_con", typeof(double));
			dataTable01.Columns.Add("l_n_ratio", typeof(double));
			dataTable01.Columns.Add("medium", typeof(string));
			dataTable01.Columns.Add("h2_type", typeof(bool));

			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			CheckMedium();

			for (int i = 0; i < Data.n_line; i++)
			{
				//添加行数据
				DataRow row = dataTable01.NewRow();
				row["id"] = Data.line[i].ip;
				row["name"] = Data.line[i].name;
				row["temperature"] = Data.line[i].t;
				row["pressure"] = Data.line[i].p;
				row["flow"] = Data.line[i].m;
				row["s_h_con"] = Data.line[i].para;
				row["l_n_ratio"] = Data.line[i].n2;
				int mediumInx = Data.line[i].mat - 1;
				row["medium"] = mediumInx < 0 || mediumInx >= Data.n_mat ?
					null : ((DataGridViewComboBoxColumn)dataGridView1.Columns["medium"]).Items[mediumInx];
				row["h2_type"] = Data.line[i].h2_type;

				dataTable01.Rows.Add(row);
			}
        }

        public void button2_Click(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToDeleteRows = true;

			DialogResult dr = MessageBox.Show("确定要删除吗？", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				int a = dataGridView1.CurrentCell.RowIndex;
				DataGridViewRow row = dataGridView1.Rows[a];
				dataGridView1.Rows.Remove(row);
				Console.WriteLine("a = {0} ", a);

				lineData[] line2 = new lineData[Data.n_line_max - 1];
				int index = 0;
				for (int i = 0; i < Data.n_line; i++)
				{
					if (i != a)
					{
						line2[index] = Data.line[i];
						index++;
					}
				}
				Data.line = line2;
				Data.n_line = Data.n_line - 1;
				GetDatabase();
				Task.Run(() =>
				{
					MessageBox.Show("删除成功！");
				});
			}
			else
			{
				MessageBox.Show("取消删除");
			}
		}

		public void button1_Click(object sender, EventArgs e)
		{
			// 取得当前单元格内容 
			//Console.WriteLine(dataGridView1.CurrentCell.Value);
			// 取得当前单元格的列 Index
			//Console.WriteLine(dataGridView1.CurrentCell.ColumnIndex);
			// 取得当前单元格的行 Index
			//Console.WriteLine(dataGridView1.CurrentCell.RowIndex);

			dataGridView1.AllowUserToAddRows = true;
			int id = dataGridView1.NewRowIndex;
			Data.n_line = id;

			for (int i = 0; i < id; i++)
			{
				Data.line[i].ip = (int)dataGridView1.Rows[i].Cells[0].Value;
				Data.line[i].name = (string)dataGridView1.Rows[i].Cells[1].Value;
				Data.line[i].t = (double)dataGridView1.Rows[i].Cells[2].Value;
				Data.line[i].p = (double)dataGridView1.Rows[i].Cells[3].Value;
				Data.line[i].m = (double)dataGridView1.Rows[i].Cells[4].Value;
				Data.line[i].para = (double)dataGridView1.Rows[i].Cells[5].Value;
				Data.line[i].n2 = (double)dataGridView1.Rows[i].Cells[6].Value;
                Data.line[i].mat =( dataGridView1.Rows[i].Cells[7].Value == null || dataGridView1.Rows[i].Cells[7].Value.ToString()=="") ? -1 :
					Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString().Split('-')[0].Trim(' '));
				Data.line[i].h2_type = (bool)dataGridView1.Rows[i].Cells[8].Value ? 1 : 0;
			}

            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase();
			Task.Run(() =>
			{
				MessageBox.Show("保存成功！");
			});
		}

		public void UserControl6_Resize(object sender, EventArgs e)
		{
			//重置窗口布局
			ReWinformLayout();
		}

		public void CheckMedium()
		{
			// 根据材料表重新生成介质下拉菜单。20240318，由M添加
			DataGridViewComboBoxCell.ObjectCollection items =
				((DataGridViewComboBoxColumn)dataGridView1.Columns["medium"]).Items;
			items.Clear();
			for (int i = 0; i < Data.n_mat; i++)
				items.Add(string.Format("{0} - {1}", Data.mat[i].id, Data.mat[i].name));
		}

		public void dataGridView1_Paint(object sender, PaintEventArgs e)
		{
			// 待求解变量的突出显示。20240318，由M添加
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				DataGridViewCell t = row.Cells["temperature"];
				if (t == null || t.Value == null) continue;
				if ((double)t.Value == 0)
					t.Style = sToBeSolved;
				else
					t.Style = sDefault;
				DataGridViewCell f = row.Cells["flow"];
				if (f == null || f.Value == null) continue;
				if ((double)f.Value == 0)
					f.Style = sToBeSolved;
				else
					f.Style = sDefault;
			}
		}
	}
}
