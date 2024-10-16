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
	public partial class UserControl20 : UserControl
	{
		private readonly float x;//定义当前窗体的宽度
		private readonly float y;//定义当前窗体的高度
		public UserControl20()
		{
			InitializeComponent();
			GetDatabase();
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

		private void GetDatabase()
		{
			// ------表2-------
			DataTable dataTable02 = new DataTable();
			dataTable02.Columns.Add("calculate_num", typeof(int));
			// 设置DataGridView的DataSource  
			dataGridView2.DataSource = dataTable02;
			dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			// 设置列名  
			dataGridView2.Columns["calculate_num"].HeaderText = "计算个数";
			DataRow row2 = dataTable02.NewRow();
			row2["calculate_num"] = Data.n_calSeq;

            Console.WriteLine("01 = {0} ", Data.n_calSeq);
			dataTable02.Rows.Add(row2);

			// --------表3---------
			DataTable dataTable03 = new DataTable();
			dataTable03.Columns.Add("part_name", typeof(int));
			dataTable03.Columns.Add("calculate_type", typeof(int));
			dataTable03.Columns.Add("cal_i", typeof(int));
            dataTable03.Columns.Add("cal_j", typeof(int));

            dataGridView3.DataSource = dataTable03;
			dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			// 设置列名  
			dataGridView3.Columns["part_name"].HeaderText = "部件名称";
			dataGridView3.Columns["calculate_type"].HeaderText = "计算类型";
			dataGridView3.Columns["cal_i"].HeaderText = "cal_i";
            dataGridView3.Columns["cal_j"].HeaderText = "cal_j";

            for (int i = 0; i < Data.n_calSeq; i++)
			{
				//添加行数据
				DataRow row3 = dataTable03.NewRow();
				if (Data.calSeq[i].part_name != -1) row3["part_name"] = Data.calSeq[i].part_name;
				if(Data.calSeq[i].calculate_type != -1) row3["calculate_type"] = Data.calSeq[i].calculate_type;
                if (Data.calSeq[i].cal_i != -1) row3["cal_i"] = Data.calSeq[i].cal_i;
                if (Data.calSeq[i].cal_j != -1) row3["cal_j"] = Data.calSeq[i].cal_j;

                dataTable03.Rows.Add(row3);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			dataGridView3.AllowUserToAddRows = true;
			int id = dataGridView3.NewRowIndex;
			Data.n_calSeq = id;

			for (int i = 0; i < id; i++)
			{
				object value = dataGridView3.Rows[i].Cells[0].Value;
				Data.calSeq[i].part_name = value == null || value == DBNull.Value ? -1 : (int)value;
                value = dataGridView3.Rows[i].Cells[1].Value;
                Data.calSeq[i].calculate_type = value == null || value == DBNull.Value ? -1 : (int)value;
                value = dataGridView3.Rows[i].Cells[2].Value;
                Data.calSeq[i].cal_i = value == null || value == DBNull.Value ? -1 : (int)value;
                value = dataGridView3.Rows[i].Cells[3].Value;
                Data.calSeq[i].cal_j = value == null || value == DBNull.Value ? -1 : (int)value;
            }
            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase();
			Task.Run(() =>
			{
				MessageBox.Show("保存成功！");
			});
		}

		private void button2_Click(object sender, EventArgs e)
		{
			dataGridView3.AllowUserToDeleteRows = true;

			DialogResult dr = MessageBox.Show("确定要删除吗？", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				int a = dataGridView3.CurrentCell.RowIndex;
				DataGridViewRow row = dataGridView3.Rows[a];
				dataGridView3.Rows.Remove(row);
                calSeqData[] calSeq = new calSeqData[Data.n_calSeq - 1];

                int index = 0;
				for (int i = 0; i < Data.n_calSeq; i++)
				{
					if (i != a)
					{
                        calSeq[index] = Data.calSeq[i];
                        index++;
					}
				}
				Data.calSeq = calSeq;
				Data.n_calSeq = Data.n_calSeq - 1;
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

		private void UserControl7_Resize(object sender, EventArgs e)
		{
			//重置窗口布局
			ReWinformLayout();
		}
	}
}
