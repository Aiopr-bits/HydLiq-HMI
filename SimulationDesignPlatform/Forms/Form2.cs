using SimulationDesignPlatform.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimulationDesignPlatform.Forms
{
	public partial class Form2 : Form
	{
		private UserControl1 ucd;
		private UserControl2 ucd2;
		private UserControl4 ucd4;
		private UserControl5 ucd5;
		private UserControl6 ucd6;
		private UserControl7 ucd7;
		private UserControl8_1 ucd8_1;
		private UserControl8_2 ucd8_2;
		private UserControl9 ucd9;
		private UserControl10 ucd10;
		private UserControl11 ucd11;
		private UserControl12 ucd12;
		private UserControl13 ucd13;
		private UserControl14 ucd14;
		private UserControl15 ucd15;
		private UserControl16 ucd16;
		private UserControl17 ucd17;
		private UserControl18 ucd18;
		private UserControl19 ucd19;
		private UserControl20 ucd20;

        public Form2()
		{
			InitializeComponent();
			showShouye();
			Rectangle ScreenArea = Screen.GetWorkingArea(this);
			if (ScreenArea.Height < this.Height)
			{
				this.Height = ScreenArea.Height;
			}

		}

		private void showShouye()
		{

			splitContainer4.Panel2.Controls.Clear();
			ucd = new UserControl1();
			ucd.Dock = DockStyle.Fill;
			ucd.Parent = this.splitContainer4.Panel2;
			splitContainer4.Panel2.Controls.Add(ucd);
			comboBox1.Visible = false;
			button2.Visible = false;
			button1.Visible = false;
			button4.Visible = false;
			label2.Text = "主页面图表数据加载完毕";
			label3.Text = "主页面";
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{

			switch (treeView1.SelectedNode.Text)
			{
				case "主页面":
					splitContainer4.Panel2.Controls.Clear();
					ucd = new UserControl1();
					ucd.Dock = DockStyle.Fill;
					ucd.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "主页面图表数据加载完毕";
					label3.Text = "主页面";
					break;
				case "仿真模型信息汇总":
					splitContainer4.Panel2.Controls.Clear();
					ucd4 = new UserControl4();
					ucd4.Dock = DockStyle.Fill;
					ucd4.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd4);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "仿真模型信息汇总数据加载完毕";
					label3.Text = "仿真模型信息汇总";
					break;
				case "部件参数配置":
					splitContainer4.Panel2.Controls.Clear();
					ucd5 = new UserControl5();
					ucd5.Dock = DockStyle.Fill;
					ucd5.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd5);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "部件参数配置数据加载完毕";
					label3.Text = "部件参数配置";
					break;
				case "流股参数配置":
					splitContainer4.Panel2.Controls.Clear();
					ucd6 = new UserControl6();
					ucd6.Dock = DockStyle.Fill;
					ucd6.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd6);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "流股参数配置数据加载完毕";
					label3.Text = "流股参数配置";
					break;
				case "计算顺序":
                    splitContainer4.Panel2.Controls.Clear();
                    ucd20 = new UserControl20();
                    ucd20.Dock = DockStyle.Fill;
                    ucd20.Parent = this.splitContainer4.Panel2;
                    splitContainer4.Panel2.Controls.Add(ucd20);
                    comboBox1.Visible = false;
                    button2.Visible = false;
                    button1.Visible = false;
                    button4.Visible = false;
                    label2.Text = "计算顺序数据加载完毕";
                    label3.Text = "计算顺序";
                    break;
                case "物性参数配置":
					splitContainer4.Panel2.Controls.Clear();
					ucd7 = new UserControl7();
					ucd7.Dock = DockStyle.Fill;
					ucd7.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd7);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "物性参数配置数据加载完毕";
					label3.Text = "物性参数配置";
					break;
				case "部件仿真结果":
					splitContainer4.Panel2.Controls.Clear();
					ucd8_1 = new UserControl8_1();
					ucd8_1.Dock = DockStyle.Fill;
					ucd8_1.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd8_1);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button3.Visible = true;
					button4.Visible = false;
					label2.Text = "仿真结果图表数据加载完毕";
					label3.Text = "仿真结果";
					break;
				case "流股仿真结果":
					splitContainer4.Panel2.Controls.Clear();
					ucd8_2 = new UserControl8_2();
					ucd8_2.Dock = DockStyle.Fill;
					ucd8_2.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd8_2);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button3.Visible = true;
					button4.Visible = false;
					label2.Text = "仿真结果图表数据加载完毕";
					label3.Text = "仿真结果";
					break;
				case "信号路由":
					splitContainer4.Panel2.Controls.Clear();
					ucd9 = new UserControl9();
					ucd9.Dock = DockStyle.Fill;
					ucd9.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd9);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "信号路由数据加载完毕";
					label3.Text = "信号路由";
					break;
				case "变量清单":
					splitContainer4.Panel2.Controls.Clear();
					ucd10 = new UserControl10();
					ucd10.Dock = DockStyle.Fill;
					ucd10.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd10);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "变量清单数据加载完毕";
					label3.Text = "变量清单";
					break;
					/*
				case "故障注入":
					splitContainer4.Panel2.Controls.Clear();
					ucd11 = new UserControl11();
					ucd11.Dock = DockStyle.Fill;
					ucd11.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd11);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "故障注入数据加载完毕";
					label3.Text = "故障注入";
					break;
					*/
				case "自动测试":
					splitContainer4.Panel2.Controls.Clear();
					ucd12 = new UserControl12();
					ucd12.Dock = DockStyle.Fill;
					ucd12.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd12);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "自动测试数据加载完毕";
					label3.Text = "自动测试";
					break;
				case "工艺流程":
					splitContainer4.Panel2.Controls.Clear();
					ucd13 = new UserControl13();
					ucd13.Dock = DockStyle.Fill;
					ucd13.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd13);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = true;
					button4.Visible = false;
					label2.Text = "工艺流程图表数据加载完毕";
					label3.Text = "工艺流程";
					break;
				/*case "趋势监视":
					splitContainer4.Panel2.Controls.Clear();
					ucd14 = new UserControl14();
					ucd14.Dock = DockStyle.Fill;
					ucd14.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd14);
					comboBox1.Visible = true;
					button2.Visible = true;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "趋势监视图表数据加载完毕";
					label3.Text = "趋势监视";
					break;
					*/
				case "数据列表":
					splitContainer4.Panel2.Controls.Clear();
					ucd15 = new UserControl15();
					ucd15.Dock = DockStyle.Fill;
					ucd15.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd15);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = false;
					label2.Text = "数据列表数据加载完毕";
					label3.Text = "数据列表";
					break;
				/*
				case "数据回放":
					splitContainer4.Panel2.Controls.Clear();
					ucd16 = new UserControl16();
					ucd16.Dock = DockStyle.Fill;
					ucd16.Parent = this.splitContainer4.Panel2;
					splitContainer4.Panel2.Controls.Add(ucd16);
					comboBox1.Visible = false;
					button2.Visible = false;
					button1.Visible = false;
					button4.Visible = true;
					label2.Text = "数据回放图表数据加载完毕";
					label3.Text = "数据回放";
					break;
					*/
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			// 获取选择的选项
			string selectedOption = comboBox1.SelectedItem.ToString();

			// 更新标签文本
			comboBox1.Text = selectedOption;

			// 执行其他操作
			if (selectedOption == "2-图表")
			{
				splitContainer4.Panel2.Controls.Clear();
				ucd14 = new UserControl14();
				ucd14.Dock = DockStyle.Fill;
				ucd14.Parent = this.splitContainer4.Panel2;
				splitContainer4.Panel2.Controls.Add(ucd14);

			}
			else if (selectedOption == "3-图表")
			{
				splitContainer4.Panel2.Controls.Clear();
				ucd17 = new UserControl17();
				ucd17.Dock = DockStyle.Fill;
				ucd17.Parent = this.splitContainer4.Panel2;
				splitContainer4.Panel2.Controls.Add(ucd17);

			}
			else if (selectedOption == "4-图表")
			{
				splitContainer4.Panel2.Controls.Clear();
				ucd18 = new UserControl18();
				ucd18.Dock = DockStyle.Fill;
				ucd18.Parent = this.splitContainer4.Panel2;
				splitContainer4.Panel2.Controls.Add(ucd18);
			}
			else if (selectedOption == "6-图表")
			{
				splitContainer4.Panel2.Controls.Clear();
				ucd19 = new UserControl19();
				ucd19.Dock = DockStyle.Fill;
				ucd19.Parent = this.splitContainer4.Panel2;
				splitContainer4.Panel2.Controls.Add(ucd19);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (Form4 fs = new Form4())
			{
				fs.ShowDialog();
				this.refresh14();
			}
		}

		public void refresh14()
		{
			splitContainer4.Panel2.Controls.Clear();
			ucd14 = new UserControl14();
			ucd14.Dock = DockStyle.Fill;
			ucd14.Parent = this.splitContainer4.Panel2;
			splitContainer4.Panel2.Controls.Add(ucd14);
			comboBox1.Visible = true;
			button2.Visible = true;
			button1.Visible = false;
			button4.Visible = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (Form5 fs = new Form5())
			{
				fs.ShowDialog();
				this.refresh13();
			}
		}

		public void refresh13()
		{
			splitContainer4.Panel2.Controls.Clear();
			ucd13 = new UserControl13();
			ucd13.Dock = DockStyle.Fill;
			ucd13.Parent = this.splitContainer4.Panel2;
			splitContainer4.Panel2.Controls.Add(ucd13);
			comboBox1.Visible = false;
			button2.Visible = false;
			button1.Visible = true;
			button4.Visible = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (Form6 fs = new Form6())
			{
				fs.ShowDialog();
				this.refresh16();
			}
		}

		public void refresh16()
		{
			splitContainer4.Panel2.Controls.Clear();
			ucd16 = new UserControl16();
			ucd16.Dock = DockStyle.Fill;
			ucd16.Parent = this.splitContainer4.Panel2;
			splitContainer4.Panel2.Controls.Add(ucd16);
			comboBox1.Visible = false;
			button2.Visible = false;
			button1.Visible = false;
			button4.Visible = true;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (Data.caseUsePath == "" || Data.caseUsePath == null)
			{
				MessageBox.Show("请先指定工作目录！");
				return;
			}
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = " csv files(*.csv)|*.csv";
			//设置默认⽂件类型显⽰顺序
			saveFileDialog1.FilterIndex = 2;
			//保存对话框是否记忆上次打开的目录
			saveFileDialog1.RestoreDirectory = true;

			//点了保存按钮进⼊
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//获得⽂件路径
				Data.saveFile = saveFileDialog1.FileName.ToString();
				Data.GUI2CSV(@Data.saveFile);

				MessageBox.Show("仿真模型参数数据导出成功！");
			}
		}

		//public static void GUI2CSV(string fn)
		//{
		//	// output gui.input
		//	using (System.IO.StreamWriter file = new System.IO.StreamWriter(fn, false, Encoding.Default))
		//	{
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("# 控制参数,,,,,,,,,,,,,,,");
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("多工况计算,,,,,,,,,,,");
		//		file.WriteLine(Data.multi_case.ToString() + ',');
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("# 物性参数,,,,,,,,,,,,,,,");
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("气体常数,参考温度,参考压力,,,,,,,,,,,,,,,,");
		//		file.WriteLine(Data.gas_const.ToString() + ',' + Data.t_ref.ToString() + ',' + Data.p_ref.ToString() + ',');
		//		file.WriteLine("材料数,,,,,,,,,,,,,,,,,,");
		//		file.WriteLine(Data.n_mat.ToString() + ',');
		//		file.WriteLine("介质编号,名称,分子量,备注,,,,,,,,,,,,,,,,,");
		//		for (int i = 0; i < Data.n_mat; i++)
		//		{
		//			file.WriteLine(Data.mat[i].id.ToString() + ',' + Data.mat[i].name.ToString() + ','
		//						   + Data.mat[i].mol.ToString() + ',' + Data.mat[i].notes.ToString() + ',');
		//		}
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("# 路由参数,,,,,,,,,,,,,,,");
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("部件总数,流股总数,,,,,,,,,,,,,,,,,,");
		//		file.WriteLine(Data.n_node.ToString() + ',' + Data.n_line.ToString() + ',');
		//		for (int i = 0; i < Data.n_node; i++)
		//		{
		//			file.WriteLine("### 部件" + Data.node[i].id + ",,,,,,,,,,,,,,,,");
		//			file.WriteLine("name,type,流股数,计算类型,含氮换热器,,,,,,,,,,,,,,,,");
		//			file.WriteLine(Data.node[i].name.ToString() + ',' + Data.node[i].type.ToString() + ','
		//						   + Data.node[i].n.ToString() + ',' + Data.node[i].cal_type.ToString() + ','
		//						   + Data.node[i].n2_heat.ToString() + ',');
		//			file.WriteLine("输入流股,,,,,,,,,,,,,,,");
		//			string tmp = "";
		//			string tmp2 = "";
		//			for (int j = 0; j < Data.node[i].n; j++)
		//			{
		//				tmp = tmp + Data.node[i].i[j] + ",";
		//				tmp2 = tmp2 + Data.node[i].o[j] + ",";
		//			}
		//			file.WriteLine(tmp);
		//			file.WriteLine("输出流股,,,,,,,,,,,,,,,");
		//			file.WriteLine(tmp2);
		//		}
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("# 流股初值,,,,,,,,,,,,,,,");
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("流股,温度,压力,流量,仲氢浓度,液氮比例,工质,纯氢,,,,,,,,,,,,");
		//		for (int i = 0; i < Data.n_line; i++)
		//		{
		//			file.WriteLine(Data.line[i].ip.ToString() + ',' + Data.line[i].t.ToString() + ','
		//						   + Data.line[i].p.ToString() + ',' + Data.line[i].m.ToString() + ','
		//						   + Data.line[i].para.ToString() + ',' + Data.line[i].n2.ToString() + ','
		//						   + Data.line[i].mat.ToString() + ',' + Data.line[i].h2_type.ToString() + ',');
		//		}
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("# 设备初值,,,,,,,,,,,,,,,");
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("设备,eff,cal_i,cal_j,膨胀机方向,设备名称,,,,,,,,,,,,");
		//		for (int i = 0; i < Data.n_node; i++)
		//		{
		//			file.WriteLine(Data.nodepara[i].ip.ToString() + ',' + Data.nodepara[i].eff.ToString() + ','
		//						   + Data.nodepara[i].cal_i.ToString() + ',' + Data.nodepara[i].cal_j.ToString() + ','
		//						   + Data.nodepara[i].direction.ToString() + ',' + Data.nodepara[i].name.ToString() + ',');
		//		}
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("# 自动测试,,,,,,,,,,,,,,,");
		//		file.WriteLine("###########################,,,,,,,,,,,,,,,");
		//		file.WriteLine("工况数,,,,,,,,,,,,,,,,");
		//		file.WriteLine(Data.n_case.ToString() + ',');
		//		file.WriteLine("工况,流股,温度,压力,流量,,,,,,,,,,,,,");
		//		for (int i = 0; i < Data.n_case; i++)
		//		{
		//			file.WriteLine(Data.case_data[i].icase.ToString() + ',' + Data.case_data[i].line_case.ToString() + ','
		//				+ Data.case_data[i].t_case.ToString() + ',' + Data.case_data[i].p_case.ToString() + ','
		//				+ Data.case_data[i].m_case.ToString() + ',');
		//		}
		//	}
		//}

		private void Form2_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (Data.caseUsePath == "" || Data.caseUsePath == null)
			{
				MessageBox.Show("请先指定工作目录！");
				return;
			}

			Process proc = null;
			try
			{
				proc = new Process();
				proc.StartInfo.WorkingDirectory = Data.exePath;
				proc.StartInfo.FileName = "hydLiq.exe";
				proc.StartInfo.CreateNoWindow = true;
				proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				proc.Start();
				proc.WaitForExit();
				MessageBox.Show("计算完成！");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace.ToString());
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			// 运行用户加载上次成功载入的工作目录路径（20240311，由M添加）
			string selectedFolder = string.Empty;
			// 检查历史工作路径是否存在
			string historypath = Path.Combine(Data.exePath, "history.csv");
			if ((Data.caseUsePath == null || Data.caseUsePath == string.Empty) && File.Exists(historypath) &&
				MessageBox.Show("是否加载历史工作目录？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				selectedFolder = File.ReadAllText(historypath);
			}
			else
			{
				// 用户放弃加载历史工作目录或未加载成功时令用户重新指定工作目录
				using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
				{
					if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
					{
						selectedFolder = folderBrowserDialog.SelectedPath;
					}
					else return;
				}
			}
			string case_name;
			string datainput_path = Path.Combine(selectedFolder, "data_input.csv");
			if (Directory.Exists(selectedFolder))
			{
				// 获取case1文件夹的绝对路径
				string case1Path = selectedFolder;
				int lastBackslashIndex = case1Path.LastIndexOf('\\');
				if (lastBackslashIndex != -1)
				{
					case1Path = case1Path.Substring(lastBackslashIndex + 1);
				}

				// 将绝对路径写入文件
				string filePath = Path.Combine(Data.exePath, "case_path.csv");
				File.WriteAllText(filePath, case1Path);
				case_name = case1Path;
				Data.case_name = case1Path;
				Data.caseUsePath = selectedFolder;
				//判断选中的工况文件夹下面是否有data_input文件
				string targetFileName = "data_input.csv";

				// 获取case1文件夹下的所有文件路径
				string[] files = Directory.GetFiles(selectedFolder);

				// 遍历所有文件，检查是否存在目标文件
				bool fileExists = false;
				foreach (string file in files)
				{
					if (Path.GetFileName(file) == targetFileName)
					{
						fileExists = true;
						break;
					}
				}

				if (fileExists)
				{
					MessageBox.Show("工作目录指定成功！指定的工况为：" + case_name);
					// 储存为历史工作路径，方便下次启动（20240311，由M添加）
					File.WriteAllText(historypath, selectedFolder);
				}
				else
				{
					string selectedPath = selectedFolder;
					// 判断是否包含中文
					bool containsChinese = Regex.IsMatch(selectedPath, @"[\u4e00-\u9fa5]");
					if (containsChinese == true)
					{
						MessageBox.Show("文件夹路径不能包含中文！");
						return;
					}

					// 判断是否包含空格
					bool containsSpace = selectedPath.Contains(" ");
					if (containsSpace == true)
					{
						MessageBox.Show("文件夹路径不能包含空格！");
						return;
					}

					// 拷贝文件夹
					string sourceFolderPath = Data.casePath;
					string destinationFolderPath = selectedPath;
					CopyFolder(sourceFolderPath, destinationFolderPath);
					MessageBox.Show("新建工况成功！工作目录指定为：" + case_name);
				}
			}
			else
			{
				MessageBox.Show("文件夹路径不存在！");
				return;
			}

			// 导入仿真参数数据  
			Data.fzxt_name = case_name;
			// 读取data_input.csv文件的内容

			try
			{
				string fileContent = File.ReadAllText(datainput_path);
				Data.CSV2Data(fileContent);
			}
			catch(Exception myException)
			{
				MessageBox.Show("请检查工况文件是否为打开状态或不存在！", "提示" );
			}

		}

		// csv文件 转为 dp.input
		//private void CSV2Data(string fn)
		//{
		//	bool flag = true;
		//	//string str1;
		//	using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(fn)))
		//	{
		//		using (StreamReader sR1 = new StreamReader(ms, Encoding.Default))
		//		{
		//			//node初始化，保证node有值
		//			for (int i = 0; i < Data.n_node_max; i++)
		//			{
		//				Data.node[i] = new NodeData();    //部件
		//				Data.node[i].i = new int[5];
		//				Data.node[i].o = new int[5];
		//			}

		//			//line初始化，保证line有值
		//			for (int i = 0; i < Data.n_line_max; i++)
		//			{
		//				Data.line[i] = new lineData();    //流股
		//			}

		//			//faultLine初始化，保证faultLine有值
		//			for (int i = 0; i < Data.n_line_max; i++)
		//			{
		//				Data.faultLine[i] = new lineData();    //流股
		//			}

		//			//fault初始化，保证fault有值
		//			for (int i = 0; i < Data.n_fault_max; i++)
		//			{
		//				Data.fault[i] = new FaultData();    //故障注入                
		//			}

		//			//case初始化，保证case有值
		//			for (int i = 0; i < Data.n_case_max; i++)
		//			{
		//				Data.case_data[i] = new CaseData();    //自动测试                
		//			}

		//			//nodepara初始化，保证nodepara有值
		//			for (int i = 0; i < Data.n_nodepara_max; i++)
		//			{
		//				Data.nodepara[i] = new nodeParaData();    //设备初值                
		//			}

		//			//mat初始化
		//			for (int i = 0; i < Data.n_mat_max; i++)
		//			{
		//				Data.mat[i] = new MatData();    //物性
		//			}


		//			//-------------------------物性参数------------------------
		//			//读取csv文件
		//			string nextLine = "";

		//			nextLine = sR1.ReadLine(); //# 控制参数
		//			nextLine = sR1.ReadLine(); //# 控制参数
		//			nextLine = sR1.ReadLine(); //# 控制参数
		//			nextLine = sR1.ReadLine(); //# 控制参数
		//			nextLine = sR1.ReadLine(); //# 控制参数
		//			{
		//				string[] tmp = nextLine.Split(',');
		//				flag = flag && bool.TryParse(tmp[0], out Data.multi_case);    //多工况计算
		//			}
		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			{
		//				string[] tmp = nextLine.Split(',');

		//				flag = flag && double.TryParse(tmp[0], out Data.gas_const);    //气体常数
		//				flag = flag && double.TryParse(tmp[1], out Data.t_ref);    //参考温度
		//				flag = flag && double.TryParse(tmp[2], out Data.p_ref);    //参考压力
		//			}

		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			{
		//				string[] tmp = nextLine.Split(',');
		//				flag = flag && int.TryParse(tmp[0], out Data.n_mat);        //材料数
		//			}
		//			nextLine = sR1.ReadLine(); //# 物性参数
		//			for (int i = 0; i < Data.n_mat; i++)
		//			{
		//				nextLine = sR1.ReadLine();
		//				{
		//					string[] tmp = nextLine.Split(',');
		//					Data.mat[i].id = int.Parse(tmp[0]);
		//					// flag = flag && int.TryParse(tmp[0], out Data.mat[i].id);  //介质编号
		//					Data.mat[i].name = tmp[1];   //介质名称
		//					Data.mat[i].mol = double.Parse(tmp[2]);
		//					// flag = flag && double.TryParse(tmp[2], out Data.mat[i].mol);   //介质分子量
		//					Data.mat[i].notes = tmp[3];   //备注
		//					Console.WriteLine("i = {0} , id = {1}, name = {2}, mol = {3}", i, Data.mat[i].id, Data.mat[i].name, Data.mat[i].mol);
		//				}
		//			}

		//			//-------------------------部件参数------------------------
		//			nextLine = sR1.ReadLine(); //# 路由参数
		//			nextLine = sR1.ReadLine(); //# 路由参数
		//			nextLine = sR1.ReadLine(); //# 路由参数
		//			nextLine = sR1.ReadLine(); //# 路由参数
		//			nextLine = sR1.ReadLine(); //# 路由参数
		//			{
		//				string[] tmp = nextLine.Split(',');
		//				flag = flag && int.TryParse(tmp[0], out Data.n_node);  //部件总数
		//				flag = flag && int.TryParse(tmp[1], out Data.n_line);  //流股总数
		//				Console.WriteLine("n_node = {0} ,n_line = {1} ", Data.n_node, Data.n_line);
		//			}

		//			for (int i = 0; i < Data.n_node; i++)
		//			{
		//				nextLine = sR1.ReadLine();
		//				nextLine = sR1.ReadLine();
		//				nextLine = sR1.ReadLine();
		//				{
		//					string[] tmp = nextLine.Split(',');
		//					Data.node[i].id = i + 1;
		//					Data.node[i].name = tmp[0];   //部件名称
		//												  // flag = flag && int.TryParse(tmp[1], out Data.node[i].type);  //部件类型
		//					Data.node[i].type = int.Parse(tmp[1]);
		//					// flag = flag && int.TryParse(tmp[2], out Data.node[i].n);  //部件流股数
		//					Data.node[i].n = int.Parse(tmp[2]);
		//					//flag = flag && int.TryParse(tmp[3], out Data.node[i].cal_type);//部件计算类型
		//					Data.node[i].cal_type = int.Parse(tmp[3]);
		//					flag = flag && bool.TryParse(tmp[4], out Data.node[i].n2_heat);   //部件是否为含氮换热器

		//					Console.WriteLine("i = {0} ,name = {1} , type = {2}, n = {3}, cal_type = {4}, n2_heat = {5}", i, Data.node[i].name, Data.node[i].type, Data.node[i].n, Data.node[i].cal_type, Data.node[i].n2_heat);
		//				}
		//				nextLine = sR1.ReadLine();
		//				nextLine = sR1.ReadLine();
		//				{
		//					string[] tmp = nextLine.Split(',');
		//					for (int j = 0; j < Data.node[i].n; j++)
		//					{
		//						//flag = flag && int.TryParse(tmp[j], out Data.node[i].i[j]);   //输入流股
		//						Data.node[i].i[j] = int.Parse(tmp[j]);
		//						Console.WriteLine("j = {0} ,i = {1} ", j, Data.node[i].i[j]);
		//					}

		//				}
		//				nextLine = sR1.ReadLine();
		//				nextLine = sR1.ReadLine();
		//				{
		//					string[] tmp = nextLine.Split(',');
		//					for (int k = 0; k < Data.node[i].n; k++)
		//					{
		//						//flag = flag && int.TryParse(tmp[k], out Data.node[i].o[k]);   //输出流股
		//						Data.node[i].o[k] = int.Parse(tmp[k]);
		//						Console.WriteLine("k = {0} ,o = {1} ", k, Data.node[i].o[k]);
		//					}
		//				}

		//			}

		//			//-------------------------流股参数------------------------
		//			nextLine = sR1.ReadLine(); //# 流股参数
		//			nextLine = sR1.ReadLine(); //# 流股参数
		//			nextLine = sR1.ReadLine(); //# 流股参数
		//			nextLine = sR1.ReadLine(); //# 流股参数

		//			for (int i = 0; i < Data.n_line; i++)
		//			{
		//				nextLine = sR1.ReadLine();
		//				string[] tmp = nextLine.Split(',');
		//				// flag = flag && int.TryParse(tmp[0], out Data.line[i].ip);  //流股序号
		//				Data.line[i].ip = int.Parse(tmp[0] == "" ? "0" : tmp[0]);

		//				// 流股名称 （20240311，由M修改添加）
		//				Data.line[i].name = tmp[1];

		//				//flag = flag && double.TryParse(tmp[2], out Data.line[i].t);   //温度
		//				Data.line[i].t = double.Parse(tmp[2] == "" ? "0" : tmp[2]);

		//				//flag = flag && double.TryParse(tmp[3], out Data.line[i].p);   //压力
		//				Data.line[i].p = double.Parse(tmp[3] == "" ? "0" : tmp[3]);

		//				//flag = flag && double.TryParse(tmp[4], out Data.line[i].m);   //流量
		//				Data.line[i].m = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

		//				//flag = flag && double.TryParse(tmp[5], out Data.line[i].para);   //仲氢浓度
		//				Data.line[i].para = double.Parse(tmp[5] == "" ? "0" : tmp[5]);

		//				//flag = flag && double.TryParse(tmp[6], out Data.line[i].n2);   //液氮比例
		//				Data.line[i].n2 = double.Parse(tmp[6] == "" ? "0" : tmp[6]);

		//				//flag = flag && int.TryParse(tmp[7], out Data.line[i].mat);  //工质
		//				Data.line[i].mat = int.Parse(tmp[7] == "" ? "0" : tmp[7]);
		//				Data.line[i].h2_type = int.Parse(tmp[8] == "" ? "0" : tmp[8]);
		//				Console.WriteLine("i = {0} ,ip = {1}, t = {2}, p = {3}, m = {4}, para = {5}, n2 = {6}, mat = {7} ", i, Data.line[i].ip, Data.line[i].t, Data.line[i].p, Data.line[i].m, Data.line[i].para, Data.line[i].n2, Data.line[i].mat);
		//			}

		//			//-------------------------设备初值------------------------
		//			nextLine = sR1.ReadLine(); //# 设备初值
		//			nextLine = sR1.ReadLine(); //# 设备初值
		//			nextLine = sR1.ReadLine(); //# 设备初值
		//			nextLine = sR1.ReadLine(); //# 设备初值

		//			for (int i = 0; i < Data.n_node; i++)
		//			{
		//				nextLine = sR1.ReadLine();
		//				string[] tmp = nextLine.Split(',');
		//				//flag = flag && int.TryParse(tmp[0], out Data.nodepara[i].ip);  //部件序号
		//				Data.nodepara[i].ip = int.Parse(tmp[0] == "" ? "0" : tmp[0]);

		//				//flag = flag && double.TryParse(tmp[1], out Data.nodepara[i].eff);   //eff
		//				Data.nodepara[i].eff = double.Parse(tmp[1] == "" ? "0" : tmp[1]);

		//				//flag = flag && int.TryParse(tmp[2], out Data.nodepara[i].cal_i);   //cal_i
		//				Data.nodepara[i].cal_i = int.Parse(tmp[2] == "" ? "0" : tmp[2]);

		//				//flag = flag && int.TryParse(tmp[3], out Data.nodepara[i].cal_j);   //cal_j
		//				Data.nodepara[i].cal_j = int.Parse(tmp[3] == "" ? "0" : tmp[3]);

		//				//flag = flag && int.TryParse(tmp[4], out Data.nodepara[i].direction);   //膨胀机方向
		//				Data.nodepara[i].direction = int.Parse(tmp[4] == "" ? "0" : tmp[4]);

		//				Data.nodepara[i].name = tmp[5];
		//				Console.WriteLine("i = {0} , ip = {1}, eff = {2}, cal_i = {3}, cal_j = {4}, direction = {5}, name = {6}", i, Data.nodepara[i].ip, Data.nodepara[i].eff, Data.nodepara[i].cal_i, Data.nodepara[i].cal_j, Data.nodepara[i].direction, Data.nodepara[i].name);
		//			}

		//			//-------------------------自动测试------------------------
		//			nextLine = sR1.ReadLine(); //# 自动测试
		//			nextLine = sR1.ReadLine(); //# 自动测试
		//			nextLine = sR1.ReadLine(); //# 自动测试
		//			nextLine = sR1.ReadLine(); //# 自动测试
		//			nextLine = sR1.ReadLine(); //# 自动测试
		//			{
		//				string[] tmp = nextLine.Split(',');
		//				Data.n_case = int.Parse(tmp[0] == "" ? "0" : tmp[0]);//工况数
		//			}
		//			nextLine = sR1.ReadLine(); //# 自动测试

		//			for (int i = 0; i < Data.n_case; i++)
		//			{
		//				nextLine = sR1.ReadLine();
		//				string[] tmp = nextLine.Split(',');
		//				//工况序号
		//				Data.case_data[i].icase = int.Parse(tmp[0] == "" ? "0" : tmp[0]);
		//				//流股编号
		//				Data.case_data[i].line_case = int.Parse(tmp[1] == "" ? "0" : tmp[1]);
		//				//温度
		//				Data.case_data[i].t_case = double.Parse(tmp[2] == "" ? "0" : tmp[2]);
		//				//压力
		//				Data.case_data[i].p_case = double.Parse(tmp[3] == "" ? "0" : tmp[3]);
		//				//流量
		//				Data.case_data[i].m_case = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

		//			}

		//			for (int i = 1; i <= Data.fault.Length; i++)
		//			{
		//				Data.fault[i - 1].id = i;
		//			}
		//			int a = 0;
		//			for (int i = 0; i < Data.n_node; i++)
		//			{
		//				int nodeId = Data.node[i].id;

		//				for (int j = 0; j < Data.node[nodeId - 1].n; j++)
		//				{
		//					Data.fault[a].node_id = nodeId;
		//					Data.fault[a].node_name = Data.node[i].name;
		//					int lineId = Data.node[nodeId - 1].i[j];
		//					Data.fault[a].line_id = Data.line[lineId - 1].ip;
		//					Data.fault[a].in_out = "输入";
		//					Data.fault[a].is_fault = false;
		//					Data.fault[a].is_result = false;
		//					a++;
		//				}

		//				for (int k = 0; k < Data.node[nodeId - 1].n; k++)
		//				{
		//					Data.fault[a].node_id = nodeId;
		//					Data.fault[a].node_name = Data.node[i].name;
		//					int lineId = Data.node[nodeId - 1].o[k];
		//					Data.fault[a].line_id = Data.line[lineId - 1].ip;
		//					Data.fault[a].in_out = "输出";
		//					Data.fault[a].is_fault = false;
		//					Data.fault[a].is_result = false;
		//					a++;
		//				}

		//			}

		//			sR1.Close();
		//			MessageBox.Show("导入成功！");
		//		}
		//	}
		//}

		private void CopyFolder(string sourceFolder, string destFolder)
		{
			if (!Directory.Exists(destFolder))
			{
				Directory.CreateDirectory(destFolder);
			}

			string[] files = Directory.GetFiles(sourceFolder);
			foreach (string file in files)
			{
				string name = Path.GetFileName(file);
				string dest = Path.Combine(destFolder, name);
				//Console.WriteLine("name = {0}, dest = {1} ", name, dest);
				if (name == "data_input.csv")
				{
					File.Copy(file, dest);
				}
			}

			string[] folders = Directory.GetDirectories(sourceFolder);
			foreach (string folder in folders)
			{
				string name = Path.GetFileName(folder);
				string dest = Path.Combine(destFolder, name);
				if (name == "output.data")
				{
					CopyFolder(folder, dest);
				}
			}
		}

		private void Form2_Resize(object sender, EventArgs e)
		{
			label1.Parent = splitContainer1.Panel1;
			label1.Location = new Point((splitContainer1.Panel1.Width - label1.Width) / 2, (splitContainer1.Panel1.Height - label1.Height) / 2);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode.Text == "部件仿真结果")
			{
				using (Form8_1 fs = new Form8_1())
				{
					fs.ShowDialog();
					this.refresh8_1();
				}
			}
			if (treeView1.SelectedNode.Text == "流股仿真结果")
			{
				using (Form8_2 fs = new Form8_2())
				{
					fs.ShowDialog();
					this.refresh8_2();
				}
			}
		}

		public void refresh8_1()
		{
			splitContainer4.Panel2.Controls.Clear();
			ucd8_1 = new UserControl8_1();
			ucd8_1.Dock = DockStyle.Fill;
			ucd8_1.Parent = this.splitContainer4.Panel2;
			splitContainer4.Panel2.Controls.Add(ucd8_1);
			comboBox1.Visible = false;
			button2.Visible = false;
			button1.Visible = false;
			button3.Visible = true;
			button4.Visible = false;
		}
		public void refresh8_2()
		{
			splitContainer4.Panel2.Controls.Clear();
			ucd8_2 = new UserControl8_2();
			ucd8_2.Dock = DockStyle.Fill;
			ucd8_2.Parent = this.splitContainer4.Panel2;
			splitContainer4.Panel2.Controls.Add(ucd8_2);
			comboBox1.Visible = false;
			button2.Visible = false;
			button1.Visible = false;
			button3.Visible = true;
			button4.Visible = false;
		}
	}
}
