using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimulationDesignPlatform.UserControls
{
	public partial class UserControl5 : UserControl
	{
		public readonly float x;//定义当前窗体的宽度
		public readonly float y;//定义当前窗体的高度

		public DataTable dataTable02= new DataTable();
        public DataTable dataTable01 = new DataTable();

        // 一些可能用到的单元格样式
        public readonly DataGridViewCellStyle sDefault = new DataGridViewCellStyle();  // 默认单元格样式
		public readonly DataGridViewCellStyle sReadOnly = new DataGridViewCellStyle()
		{
			BackColor = Color.Gainsboro,
		};  // 不可编辑的单元格样式
		public readonly DataGridViewCellStyle sIgnore = new DataGridViewCellStyle()
		{
			BackColor = Color.Gainsboro,
			ForeColor = Color.Gray,
		};  // 表示此项无意义可忽略的单元格样式

		public UserControl5()
		{
			InitializeComponent();
			GetDatabase01();
            GetDatabase02();
            UpdateData();
			//Tree_Load();
			#region  初始化控件缩放
			x = Width;
			y = Height;
			setTag(this);
            #endregion

			this.dataGridView2.DataBindingComplete += dataGridView2_DataBindingComplete;
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

		public void GetDatabase01()
		{

			this.dataTable01 = new DataTable();

			this.dataGridView1.DataSource = dataTable01;
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "id",
				HeaderText = "部件序号",
				DataPropertyName = "id",
			});
			this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "name",
				HeaderText = "部件名称",
				DataPropertyName = "name",
			});
			this.dataGridView1.Columns.Add(new DataGridViewComboBoxColumn()
			{
				Name = "type",
				HeaderText = "部件类型",
				DataPropertyName = "type",
				DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
			});
			((DataGridViewComboBoxColumn)this.dataGridView1.Columns["type"]).Items.AddRange(
				new object[] { "1-正仲转换器", "2-换热器", "3-压缩机", "4-膨胀机", "5-混合器",
					"6-氢气节流阀", "7-泵", "8-汽液分离器", "9-冷却器", "10-储罐" , "11-分流", "12-合流"});
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
			{
				Name = "n_num",
				HeaderText = "流股数",
				DataPropertyName = "n_num",
			});
			this.dataGridView1.Columns.Add(new DataGridViewComboBoxColumn()
			{
				Name = "cal_type",
				HeaderText = "计算类型",
				DataPropertyName = "cal_type",
				DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
			});
			((DataGridViewComboBoxColumn)this.dataGridView1.Columns["cal_type"]).Items.AddRange(
				new object[] { "计算温度", "计算流量", "赋值浓度", "反向赋值浓度", "赋值流量", "赋值温度", "正向计算流量", "反向计算流量","其他类型" });
            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
			{
				Name = "n2_heat",
				HeaderText = "非纯氢换热器",
				DataPropertyName = "n2_heat",
			});

			dataTable01.Columns.Add("id", typeof(int));
			dataTable01.Columns.Add("name", typeof(string));
			dataTable01.Columns.Add("type", typeof(string));
			dataTable01.Columns.Add("n_num", typeof(int));
			dataTable01.Columns.Add("cal_type", typeof(string));
			dataTable01.Columns.Add("n2_heat", typeof(bool));

			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.AllowUserToAddRows = true;

			for (int i = 0; i < Data.n_node; i++)
			{
				//添加行数据
				DataRow row = dataTable01.NewRow();
				row["id"] = Data.node[i].id;
				row["name"] = Data.node[i].name;
				// if分支改成switch-case（20240312，由M修改）
				switch (Data.node[i].type)
				{
					case 1:
						row["type"] = "1-正仲转换器";
						break;
					case 2:
						row["type"] = "2-换热器";
						break;
					case 3:
						row["type"] = "3-压缩机";
						break;
					case 4:
						row["type"] = "4-膨胀机";
						break;
					case 5:
						row["type"] = "5-混合器";
						break;
					case 6:
						row["type"] = "6-氢气节流阀";
						break;
					case 7:
						row["type"] = "7-泵";
						break;
					case 8:
						row["type"] = "8-汽液分离器";
						break;
					case 9:
						row["type"] = "9-冷却器";
						break;
					case 10:
						row["type"] = "10-储罐";
						break;
					case 11:
						row["type"] = "11-分流";
						break;
					case 12:
						row["type"] = "12-合流";
						break;
				}

				row["n_num"] = Data.node[i].n;
                var calTypeDescriptions = new Dictionary<(int, int), string>
				{
					{(1, 1), "计算温度"},
					{(1, 2), "计算流量"},
					{(2, 1), "计算温度"},
					{(2, 2), "计算流量"},
					{(2, 3), "赋值浓度"},
					{(2, 4), "反向赋值浓度"},
					{(4, 1), "计算温度"},
					{(4, 2), "赋值流量"},
					{(11, 1), "赋值温度"},
					{(11, 2), "正向计算流量"},
					{(11, 3), "反向计算流量"},
					{(12, 1), "赋值温度"},
					{(12, 2), "正向计算流量"},
					{(12, 3), "反向计算流量"}
				};
                if (calTypeDescriptions.TryGetValue((Data.node[i].type, Data.node[i].cal_type), out string description))
                {
                    row["cal_type"] = description;
                }
                else
                {
                    row["cal_type"] = "其他类型";
                }

                if (Data.node[i].type == 2)
					row["n2_heat"] = Data.node[i].n2_heat;
				else
					row["n2_heat"] = false;
				dataTable01.Rows.Add(row);
			}
        }


        public void GetDatabase02()
        {
            // 20240313，由M添加
            dataTable02 = new DataTable();
            this.dataGridView2.DataSource = dataTable02;
            this.dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ip",
                HeaderText = "部件序号",
                DataPropertyName = "ip",
            });
            this.dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "name",
                HeaderText = "部件类型",
                DataPropertyName = "name",
            });
            this.dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "eff",
                HeaderText = "等熵效率",
                DataPropertyName = "eff",
            });
            this.dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "cal_i",
                HeaderText = "计算流股序号",
                DataPropertyName = "cal_i",
            });
            this.dataGridView2.Columns.Add(new DataGridViewComboBoxColumn()
            {
                Name = "cal_j",
                HeaderText = "计算流股端口",
                DataPropertyName = "cal_j",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
            });
            ((DataGridViewComboBoxColumn)this.dataGridView2.Columns["cal_j"]).Items.AddRange(
                new object[] { "输入端", "输出端" });
            this.dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "direction",
                HeaderText = "膨胀机方向",
                DataPropertyName = "direction",
            });

            dataTable02.Columns.Add("ip", typeof(int));
            dataTable02.Columns.Add("name", typeof(string));
            dataTable02.Columns.Add("eff", typeof(double));
            dataTable02.Columns.Add("cal_i", typeof(int));
            dataTable02.Columns.Add("cal_j", typeof(string));
            dataTable02.Columns.Add("direction", typeof(int));

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AllowUserToAddRows = false;

            for (int i = 0; i < Data.n_node; i++)
            {
                //添加行数据
                if (Data.nodepara[i] == null) break;
                DataRow row = dataTable02.NewRow();
                row["ip"] = Data.nodepara[i].ip;
                row["name"] = Data.nodepara[i].name;
                row["eff"] = Data.nodepara[i].eff;
                row["cal_i"] = Data.nodepara[i].cal_i;
                switch (Data.nodepara[i].cal_j)
                {
                    case 1:
                        row["cal_j"] = "输入端";
                        break;
                    case 2:
                        row["cal_j"] = "输出端";
                        break;
                    default:
                        row["cal_j"] = null;
                        break;
                }
                row["direction"] = Data.nodepara[i].direction;
                dataTable02.Rows.Add(row);
            }

            //隐藏第二列
            this.dataGridView2.Columns[1].Visible = false;
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
				if (Data.node[i].type != 3 && Data.node[i].type != 4)
				{
					DataGridViewCell cell = dataGridView2.Rows[i].Cells["eff"];
					cell.Style.BackColor = Color.LightGray;
					cell.ReadOnly = true;
				}
			}
        }

        public void button1_Click(object sender, EventArgs e)
		{
            int id = dataGridView1.Rows.Count;
            Data.n_node = id;

            var calTypeDescriptions = new Dictionary<(int, int), string>
			{
				{(1, 1), "计算温度"},
				{(1, 2), "计算流量"},
				{(2, 1), "计算温度"},
				{(2, 2), "计算流量"},
				{(2, 3), "赋值浓度"},
				{(2, 4), "反向赋值浓度"},
				{(4, 1), "计算温度"},
				{(4, 2), "赋值流量"},
				{(11, 1), "赋值温度"},
				{(11, 2), "正向计算流量"},
				{(11, 3), "反向计算流量"},
				{(12, 1), "赋值温度"},
				{(12, 2), "正向计算流量"},
				{(12, 3), "反向计算流量"}
			};

            for (int i = 0; i < id; i++)
			{
				Data.node[i].id =(int)dataGridView1.Rows[i].Cells[0].Value;
				Data.node[i].name = (string)dataGridView1.Rows[i].Cells[1].Value;
				Data.node[i].type =  Convert.ToInt32(((string)dataGridView1.Rows[i].Cells[2].Value).Split('-')[0]);
				Data.node[i].n =  (int)dataGridView1.Rows[i].Cells[3].Value;

                string calTypeDescription = (string)dataGridView1.Rows[i].Cells[4].Value;
                var calTypeEntry = calTypeDescriptions.FirstOrDefault(entry => entry.Value == calTypeDescription);
                if (!calTypeEntry.Equals(default(KeyValuePair<(int, int), string>)))
                {
                    Data.node[i].cal_type = calTypeEntry.Key.Item2;
                }

                Data.node[i].n2_heat =  Convert.ToBoolean(dataGridView1.Rows[i].Cells[5].Value.ToString());
			}

			if (dataTable02.Rows.Count < dataTable01.Rows.Count)
			{
				DataRow row = dataTable02.NewRow();
				row["ip"] = Data.node[id - 1].id;
				row["name"] = Data.node[id - 1].name;
				row["eff"] = Data.node[id - 1].eff;
				row["cal_i"] = Data.node[id - 1].cal_i;
				switch (Data.node[id - 1].cal_j)
				{
					case 1:
						row["cal_j"] = "输入端";
						break;
					case 2:
						row["cal_j"] = "输出端";
						break;
					default:
						row["cal_j"] = null;
						break;
				}
				row["direction"] = Data.node[id - 1].direction;
				dataTable02.Rows.Add(row);
				this.dataGridView2.DataSource = dataTable02;
			}
            Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            //GetDatabase01();
          
            Task.Run(() =>
			{
				MessageBox.Show("保存成功！");
			});
		}

		public void button2_Click(object sender, EventArgs e)
		{
			// 修改界面按钮：取消设备初值区域的保存及删除按钮，将功能并入部件参数区域的相应按钮中。20240318，由M修改
			DialogResult dr = MessageBox.Show("确定要删除吗？", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				// 删除对应行部件参数
				int del = dataGridView1.CurrentCell.RowIndex;
				dataGridView1.Rows.Remove(dataGridView1.Rows[del]);
				NodeData[] node2 = new NodeData[Data.n_node_max - 1];
				int index = 0;
				for (int i = 0; i < Data.n_node; i++)
				{
					if (i != del)
					{
						node2[index] = Data.node[i];
						index++;
					}
				}
				Data.node = node2;

				// 删除对应行设备初值
				dataGridView2.Rows.Remove(dataGridView2.Rows[del]);
				nodeParaData[] nodepara2 = new nodeParaData[Data.n_node_max - 1];
				index = 0;
				for (int i = 0; i < Data.n_node; i++)
				{
					if (i != del)
					{
						nodepara2[index] = Data.nodepara[i];
						index++;
					}
				}
				Data.nodepara = nodepara2;

				Data.n_node--;

                Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
                Data.GUI2CSV(@Data.saveFile);
                GetDatabase01();
                GetDatabase02();
                Task.Run(() =>
				{
					MessageBox.Show("删除成功！");
				});

				UpdateData();
			}
			else
			{
				MessageBox.Show("取消删除");
			}
		}

        public void button3_Click(object sender, EventArgs e)
        {

			int id = dataGridView2.Rows.Count;
            Data.n_node = id;

			for (int i = 0; i < id; i++)
			{
				// 修改界面按钮：取消设备初值区域的保存及删除按钮，将功能并入部件参数区域的相应按钮中。20240318，由M修改
				// 设备初值
				Data.nodepara[i].ip = (int)dataGridView2.Rows[i].Cells[0].Value;
				Data.nodepara[i].name = (string)dataGridView2.Rows[i].Cells[1].Value;
				Data.nodepara[i].eff = (double)dataGridView2.Rows[i].Cells[2].Value;
				Data.nodepara[i].cal_i = (int)dataGridView2.Rows[i].Cells[3].Value;
                string cellValue = dataGridView2.Rows[i].Cells[4].Value.ToString().Trim();
                if (cellValue == "输入端")
                {
                    Data.nodepara[i].cal_j = 1;
                }
                else if (cellValue == "输出端")
                {
                    Data.nodepara[i].cal_j = 2;
                }
                else
                {
                    Data.nodepara[i].cal_j = 0;
                }
                Data.nodepara[i].direction = (int)dataGridView2.Rows[i].Cells[5].Value;
			}

			Data.saveFile = Path.Combine(Data.exePath, Data.case_name, "data_input.csv");
            Data.GUI2CSV(@Data.saveFile);
            GetDatabase02();

            Task.Run(() =>
            {
                MessageBox.Show("保存成功！");
            });
        }

        public void UserControl5_Resize(object sender, EventArgs e)
		{
			//重置窗口布局
			ReWinformLayout();
		}

		public void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			// 基于设备类型的数据可写性控制，20240315，由M修改
			if (dataGridView1["type", e.RowIndex].Value == DBNull.Value) return;
			int type = Convert.ToInt32(((string)dataGridView1["type", e.RowIndex].Value).Split('-')[0]);
			switch (e.ColumnIndex)
			{
				case 3: //表示选定单元格为流股数所在列dataGridView1.Columns["n_num"]
					/* 只有node[i].type=2或node[i].type=5时，允许修改流股数，
					 * 其他情况下流股数等于1，且不允许用户修改。
					 */
					if (type != 2 && type != 5)
						e.Cancel = true;
					return;
				case 4: //表示选定单元格为计算类型所在列dataGridView1.Columns["cal_type"]
					/* 计算类型，不同的部件类型也不一样
					 * node[i].type=1，正仲转换器：
					 * node[i].cal_type=0：求解温度；node[i].cal_type=1：求解流量
					 * node[i].type=2，换热器：
					 * node[i].cal_type=0：求解温度；node[i].cal_type=1：求解流量
					 * 其他部件，值为0，此处为灰色，不允许修改，显示为空
					 */
					if (type != 1 && type != 2)
						e.Cancel = true;
					return;
				case 5: //表示选定单元格为非纯氢换热器所在列dataGridView1.Columns["n2_heat"]
					/* 非纯氢换热器
					 * 仅针对换热器node(i).type=2，其他类型不允许修改
					 */
					if (type != 2)
						e.Cancel = true;
					return;
				default:
					return;
			}
		}

		public void dataGridView1_Paint(object sender, PaintEventArgs e)
		{
			UpdateCellStyle();
		}

		public void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			UpdateData();
		}

		public void UpdateCellStyle()
		{
			//// 设置更新各单元格的显示状态。20240315，由M修改添加
			//for (int i = 0; i < dataGridView1.Rows.Count; i++)
			//{
			//	// dataGridView1 部件信息
			//	DataGridViewRow row1 = dataGridView1.Rows[i];
			//	if (row1.Cells["type"].Value == null || row1.Cells["type"].Value == DBNull.Value) continue;
			//	int type = Convert.ToInt32(((string)row1.Cells["type"].Value).Split('-')[0]);
			//	foreach (DataGridViewCell cell in row1.Cells)
			//	{
			//		switch (cell.ColumnIndex)
			//		{
			//			/* 只有node[i].type=2或node[i].type=5时，允许修改流股数，
			//			 * 其他情况下流股数等于1，且不允许用户修改。
			//			 */
			//			case 3:
			//				if (type == 2 || type == 5)
			//					cell.Style = sDefault;
			//				else
			//					cell.Style = sReadOnly;
			//				break;
			//			/* 计算类型，不同的部件类型也不一样
			//			 * node[i].type=1，正仲转换器：
			//			 * node[i].cal_type=0：求解温度；node[i].cal_type=1：求解流量
			//			 * node[i].type=2，换热器：
			//			 * node[i].cal_type=0：求解温度；node[i].cal_type=1：求解流量
			//			 * 其他部件，值为0，此处为灰色，不允许修改，显示为空
			//			 */
			//			case 4:
			//				if (type == 1 || type == 2)
			//					cell.Style = sDefault;
			//				else
			//					cell.Style = sIgnore;
			//				break;
			//			/* 非纯氢换热器
			//			 * 仅针对换热器node(i).type=2，其他类型不允许修改
			//			 */
			//			case 5:
			//				if (type == 2)
			//					cell.Style = sDefault;
			//				else
			//					cell.Style = sReadOnly;
			//				break;
			//			default:
			//				cell.Style = sDefault;
			//				break;
			//		}
			//	}

			//}


   //         // dataGridView2 设备初值。20240318，由M添加
   //         //zhangax修改
   //         for (int i = 0; i < dataGridView2.Rows.Count; i++)
   //         {
			//	if (i <= dataGridView1.RowCount)
			//	{
			//		DataGridViewRow row1 = dataGridView1.Rows[i];
			//		if (row1.Cells["type"].Value == null || row1.Cells["type"].Value == DBNull.Value) continue;
			//		int type = Convert.ToInt32(((string)row1.Cells["type"].Value).Split('-')[0]);
			//		DataGridViewRow row2 = dataGridView2.Rows[i];
			//		foreach (DataGridViewCell cell in row2.Cells)
			//		{
			//			switch (cell.ColumnIndex)
			//			{
			//				// 序号和设备名默认由dataGridView1决定，此处不可修改
			//				case 0:
			//				case 1:
			//					cell.Style = sReadOnly;
			//					break;
			//				// 效率eff，仅针对压缩机和膨胀机node[i].type = 3或node[i].type = 4
			//				case 2:
			//					if (type == 3 || type == 4)
			//						cell.Style = sDefault;
			//					else
			//						cell.Style = sIgnore;
			//					break;
			//				// cal_i，仅针对换热器node[i].type = 2，第几个流股有未知数
			//				case 3:
			//				// cal_j，仅针对换热器node[i].type = 2，1：输入端为未知数，2：输出端为未知数
			//				case 4:
			//					if (type == 2)
			//						cell.Style = sDefault;
			//					else
			//						cell.Style = sIgnore;
			//					break;
			//				// 膨胀机方向，仅针对膨胀机node[i].type = 4
			//				case 5:
			//					if (type == 4)
			//						cell.Style = sDefault;
			//					else
			//						cell.Style = sIgnore;
			//					break;
			//			}
			//		}
			//	}
			//}
		}
		public void UpdateData()
		{

			//// 更新各数据依赖的单元格的值。20240315，由M修改添加
			//for (int i = 0; i < dataGridView1.RowCount; i++)
			//{
			//	// dataGridView1 部件信息
			//	DataGridViewRow row1 = dataGridView1.Rows[i];
			//	if (row1.Cells["type"].Value == null || row1.Cells["type"].Value == DBNull.Value) continue;
			//	int type = Convert.ToInt32(((string)row1.Cells["type"].Value).Split('-')[0]);
			//	foreach (DataGridViewCell cell in row1.Cells)
			//	{
			//		switch (cell.ColumnIndex)
			//		{
			//			/* 只有node[i].type=2或node[i].type=5时，允许修改流股数，
			//			 * 其他情况下流股数等于1，且不允许用户修改。
			//			 */
			//			case 3:
			//				if (type != 2 && type != 5)
			//					cell.Value = 1;
			//				break;
			//			/* 计算类型，不同的部件类型也不一样
			//			 * node[i].type=1，正仲转换器：
			//			 * node[i].cal_type=0：求解温度；node[i].cal_type=1：求解流量
			//			 * node[i].type=2，换热器：
			//			 * node[i].cal_type=0：求解温度；node[i].cal_type=1：求解流量
			//			 * 其他部件，值为0，此处为灰色，不允许修改，显示为空
			//			 */
			//			case 4:
			//				if (type != 1 && type != 2)
			//					cell.Value = null;
			//				break;
			//			/* 非纯氢换热器
			//			 * 仅针对换热器node(i).type=2，其他类型不允许修改
			//			 */
			//			case 5:
			//				if (type != 2)
			//					cell.Value = false;
			//				break;
			//			default:
			//				break;
			//		}
			//	}
			//}

   //         for (int i = 0; i < dataGridView2.Rows.Count; i++)
			//{
			//	DataGridViewRow row1 = dataGridView1.Rows[i];
			//	if (row1.Cells["type"].Value == null || row1.Cells["type"].Value == DBNull.Value) continue;
			//	int type = Convert.ToInt32(((string)row1.Cells["type"].Value).Split('-')[0]);

			//	DataGridViewRow row2 = dataGridView2.Rows[i];
			//	foreach (DataGridViewCell cell in row2.Cells)
			//	{
			//		switch (cell.ColumnIndex)
			//		{
			//			// 序号和设备名默认由dataGridView1决定，此处不可修改
			//			case 0:
			//				cell.Value = dataGridView1["id", cell.RowIndex].Value;
			//				break;
			//			case 1:
			//				cell.Value = dataGridView1["type", cell.RowIndex].Value.ToString().Split('-')[1];
			//				break;
			//			// 效率eff，仅针对压缩机和膨胀机node[i].type = 3或node[i].type = 4
			//			case 2:
			//				if (type != 3 && type != 4)
			//					cell.Value = 0;
			//				break;
			//			// cal_i，仅针对换热器node[i].type = 2，第几个流股有未知数
			//			case 3:
			//				if (type != 2)
			//					cell.Value = 0;
			//				break;
			//			// cal_j，仅针对换热器node[i].type = 2，1：输入端为未知数，2：输出端为未知数
			//			case 4:
			//				if (type != 2)
			//					cell.Value = null;
			//				break;
			//			// 膨胀机方向，仅针对膨胀机node[i].type = 4
			//			case 5:
			//				if (type != 4)
			//					cell.Value = 0;
			//				break;
			//		}
			//	}

			//}
		}
    }
}
