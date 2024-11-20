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
	public partial class UserControl7 : UserControl
	{
		public readonly float x;//定义当前窗体的宽度
		public readonly float y;//定义当前窗体的高度
		public UserControl7()
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
			// -------表1--------
			DataTable dataTable01 = new DataTable();

			dataTable01.Columns.Add("gas_constant", typeof(double));
			dataTable01.Columns.Add("refer_t", typeof(double));
			dataTable01.Columns.Add("refer_p", typeof(double));

			// 设置DataGridView的DataSource  
			dataGridView1.DataSource = dataTable01;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			// 设置列名  
			dataGridView1.Columns["gas_constant"].HeaderText = "气体常数(J/(mol·K))";
			dataGridView1.Columns["refer_t"].HeaderText = "参考温度(K)";
			dataGridView1.Columns["refer_p"].HeaderText = "参考压力(MPa)";
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
			dataGridView2.DataSource = dataTable02;
			dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			// 设置列名  
			dataGridView2.Columns["material_num"].HeaderText = "材料数";
			DataRow row2 = dataTable02.NewRow();
			row2["material_num"] = Data.n_mat;

			Console.WriteLine("01 = {0} ", Data.n_mat);
			dataTable02.Rows.Add(row2);

			// --------表3---------
			DataTable dataTable03 = new DataTable();
			dataTable03.Columns.Add("id_no", typeof(int));
			dataTable03.Columns.Add("name", typeof(string));
			dataTable03.Columns.Add("mol", typeof(double));

			dataGridView3.DataSource = dataTable03;
			dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			// 设置列名  
			dataGridView3.Columns["id_no"].HeaderText = "介质序号";
			dataGridView3.Columns["name"].HeaderText = "介质名称";
			dataGridView3.Columns["mol"].HeaderText = "介质分子量";

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

		public void button1_Click(object sender, EventArgs e)
		{
			Data.gas_const = (double)dataGridView1.Rows[0].Cells[0].Value;
			Data.t_ref = (double)dataGridView1.Rows[0].Cells[1].Value;
			Data.p_ref = (double)dataGridView1.Rows[0].Cells[2].Value;

            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase();
			Task.Run(() =>
			{
				MessageBox.Show("保存成功！");
			});
		}

		public void button3_Click(object sender, EventArgs e)
		{
			dataGridView3.AllowUserToAddRows = true;
			int id = dataGridView3.NewRowIndex;
			Data.n_mat = id;

			for (int i = 0; i < id; i++)
			{
				object value = dataGridView3.Rows[i].Cells[0].Value;
				Data.mat[i].id = value == null || value == DBNull.Value ? id : (int)value;
				Data.mat[i].name = (string)dataGridView3.Rows[i].Cells[1].Value;
				value = dataGridView3.Rows[i].Cells[2].Value;
				Data.mat[i].mol = value == null || value == DBNull.Value ? 0 : (double)value;
			}
            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase();
			Task.Run(() =>
			{
				MessageBox.Show("保存成功！");
			});
		}

		public void button2_Click(object sender, EventArgs e)
		{
			dataGridView3.AllowUserToDeleteRows = true;

			DialogResult dr = MessageBox.Show("确定要删除吗？", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				int a = dataGridView3.CurrentCell.RowIndex;
				DataGridViewRow row = dataGridView3.Rows[a];
				dataGridView3.Rows.Remove(row);

				MatData[] mat2 = new MatData[Data.n_mat - 1];
				int index = 0;
				for (int i = 0; i < Data.n_mat; i++)
				{
					if (i != a)
					{
						mat2[index] = Data.mat[i];
						index++;
					}
				}
				Data.mat = mat2;
				Data.n_mat = Data.n_mat - 1;
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

		public void UserControl7_Resize(object sender, EventArgs e)
		{
			//重置窗口布局
			ReWinformLayout();
		}
	}
}
