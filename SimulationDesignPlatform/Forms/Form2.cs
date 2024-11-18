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
using System.Threading;
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
        private UserControl8_3 ucd8_3;
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
        private UserControl21 ucd21;
        private UserControl22 ucd22;

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
                    label2.Text = "部件仿真结果图表数据加载完毕";
                    label3.Text = "部件仿真结果";
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
                    label2.Text = "流股仿真结果图表数据加载完毕";
                    label3.Text = "流股仿真结果";
                    break;
                case "换热器最小温差结果":
                    splitContainer4.Panel2.Controls.Clear();
                    ucd8_3 = new UserControl8_3();
                    ucd8_3.Dock = DockStyle.Fill;
                    ucd8_3.Parent = this.splitContainer4.Panel2;
                    splitContainer4.Panel2.Controls.Add(ucd8_3);
                    comboBox1.Visible = false;
                    button2.Visible = false;
                    button1.Visible = false;
                    button3.Visible = true;
                    button4.Visible = false;
                    label2.Text = "换热器最小温差结果数据加载完毕";
                    label3.Text = "换热器最小温差结果";
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
                case "自动测试&优化模型":
                    splitContainer4.Panel2.Controls.Clear();
                    ucd12 = new UserControl12();
                    ucd12.Dock = DockStyle.Fill;
                    ucd12.Parent = this.splitContainer4.Panel2;
                    splitContainer4.Panel2.Controls.Add(ucd12);
                    comboBox1.Visible = false;
                    button2.Visible = false;
                    button1.Visible = false;
                    button4.Visible = false;
                    label2.Text = "自动测试&&优化模型数据加载完毕";
                    label3.Text = "自动测试&&优化模型";
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
                case "自动测试结果":
                    splitContainer4.Panel2.Controls.Clear();
                    ucd21 = new UserControl21();
                    ucd21.Dock = DockStyle.Fill;
                    ucd21.Parent = this.splitContainer4.Panel2;
                    splitContainer4.Panel2.Controls.Add(ucd21);
                    comboBox1.Visible = false;
                    button2.Visible = false;
                    button1.Visible = false;
                    button4.Visible = false;
                    label2.Text = "自动测试结果数据加载完毕";
                    label3.Text = "自动测试结果";
                    break;
                case "优化模型结果":
                    splitContainer4.Panel2.Controls.Clear();
                    ucd22 = new UserControl22();
                    ucd22.Dock = DockStyle.Fill;
                    ucd22.Parent = this.splitContainer4.Panel2;
                    splitContainer4.Panel2.Controls.Add(ucd22);
                    comboBox1.Visible = false;
                    button2.Visible = false;
                    button1.Visible = false;
                    button4.Visible = false;
                    label2.Text = "优化模型结果数据加载完毕";
                    label3.Text = "优化模型结果";
                    break;
            }
            RemoveDataGridViewColumnHeaders(this);
            DisableDataGridViewSorting(this);
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void readFiles()
        {
            // 运行用户加载上次成功载入的工作目录路径（20240311，由M添加）
            string selectedFolder = string.Empty;
            // 检查历史工作路径是否存在
            string historypath = Path.Combine(Data.exePath, "history.csv");
            if (File.Exists(historypath))
            {
                selectedFolder = File.ReadAllText(historypath);
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

                string autoTest_path = Path.Combine(Path.GetDirectoryName(datainput_path), "output.data", "autoTest.csv");
                fileContent = File.ReadAllText(autoTest_path);
                Data.CSVOutputdataAutoTest(fileContent);

                string optimResult_path = Path.Combine(Path.GetDirectoryName(datainput_path), "output.data", "optim.csv");
                fileContent = File.ReadAllText(optimResult_path);
                Data.CSVOutputdataOptimResult(fileContent);
            }
            catch (Exception myException)
            {
                MessageBox.Show("请检查工况文件是否为打开状态或不存在！", "提示");
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (Data.caseUsePath == "" || Data.caseUsePath == null)
            {
                MessageBox.Show("请先指定工作目录！");
                return;
            }

            Process proc = null;
            try
            {
                splitContainer4.Panel2.Controls.Clear();
                UserControl23 ucd23 = new UserControl23();
                ucd23.Dock = DockStyle.Fill;
                ucd23.Parent = this.splitContainer4.Panel2;
                splitContainer4.Panel2.Controls.Add(ucd23);
                ucd23.richTextBox1.ReadOnly = true; // 设置为只读
                ucd23.richTextBox1.Font = new Font(ucd23.richTextBox1.Font.FontFamily, 10); // 设置字体大小
                comboBox1.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
                button4.Visible = false;
                label2.Text = "求解计算";
                label3.Text = "求解计算";

                proc = new Process();
                proc.StartInfo.WorkingDirectory = Data.exePath;
                proc.StartInfo.FileName = "hydLiq.exe";
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;

                // 获取当前的同步上下文
                var context = SynchronizationContext.Current;

                proc.OutputDataReceived += (s, args) =>
                {
                    if (args.Data != null)
                    {
                        // 使用同步上下文在 UI 线程中执行更新操作
                        context.Post(_ =>
                        {
                            ucd23.richTextBox1.AppendText(args.Data + Environment.NewLine);
                        }, null);
                    }
                };

                proc.Start();
                proc.BeginOutputReadLine();
                await Task.Run(() => proc.WaitForExit());
                readFiles();
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

                string autoTest_path = Path.Combine(Path.GetDirectoryName(datainput_path), "output.data", "autoTest.csv");
                fileContent = File.ReadAllText(autoTest_path);
                Data.CSVOutputdataAutoTest(fileContent);

                string optimResult_path = Path.Combine(Path.GetDirectoryName(datainput_path), "output.data", "optim.csv");
                fileContent = File.ReadAllText(optimResult_path);
                Data.CSVOutputdataOptimResult(fileContent);
            }
            catch (Exception myException)
            {
                //MessageBox.Show("请检查工况文件是否为打开状态或不存在！", "提示");
            }

            MessageBox.Show("导入成功！");

            File.WriteAllText(historypath, selectedFolder);

            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];

        }

        public void RemoveDataGridViewColumnHeaders(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    dataGridView.RowHeadersVisible = false;
                    dataGridView.AllowUserToAddRows = false;
                }

                // 递归处理子控件
                if (control.HasChildren)
                {
                    RemoveDataGridViewColumnHeaders(control);
                }
            }
        }

        private void DisableDataGridViewSorting(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                else if (control.HasChildren)
                {
                    DisableDataGridViewSorting(control); // 递归调用
                }
            }
        }

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
