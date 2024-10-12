using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationDesignPlatform.Forms
{
    public partial class Form7 : Form
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public Form7()
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
        private void button1_Click(object sender, EventArgs e)
        {
            // 获取 textBox1 内的文本内容  
            Data.fzxt_name = textBox1.Text;

            // 判断是否包含中文
            bool containsChinese = Regex.IsMatch(Data.fzxt_name, @"[\u4e00-\u9fa5]");
            if (containsChinese == true)
            {
                MessageBox.Show("输入的模型名称不能包含中文！");
                return;
            }

            // 判断是否包含特殊字符和符号
            bool containsSpecialChar = Regex.IsMatch(Data.fzxt_name, @"[^\w\s]");
            if (containsSpecialChar == true)
            {
                MessageBox.Show("输入的模型名称不能包含特殊字符和符号！");
                return;
            }

            // 判断是否包含空格
            bool containsSpace = Data.fzxt_name.Contains(" ");
            if (containsSpace == true)
            {
                MessageBox.Show("输入的模型名称不能包含空格！");
                return;
            }
            this.Hide();

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            Data.openFile = dlg.FileName;
            Data.fileName = Data.openFile.Substring(Data.openFile.LastIndexOf("\\") + 1);
            Data.filePath = Data.openFile.Substring(0, Data.openFile.LastIndexOf("\\"));

            CSV2Data(@Data.openFile);        //读取data_input.csv
        }

        // csv文件 转为 dp.input
        private void CSV2Data(string fn)
        {
            bool flag = true;
            //string str1;

            StreamReader sR1 = new StreamReader(fn, Encoding.Default);

            //node初始化，保证node有值
            for (int i = 0; i < Data.n_node_max; i++)
            {
                Data.node[i] = new NodeData();    //部件
                Data.node[i].i = new int[5];
                Data.node[i].o = new int[5];
            }

            //line初始化，保证line有值
            for (int i = 0; i < Data.n_line_max; i++)
            {
                Data.line[i] = new lineData();    //流股
            }

            //faultLine初始化，保证faultLine有值
            for (int i = 0; i < Data.n_line_max; i++)
            {
                Data.faultLine[i] = new lineData();    //流股
            }

            //fault初始化，保证fault有值
            for (int i = 0; i < Data.n_fault_max; i++)
            {
                Data.fault[i] = new FaultData();    //故障注入                
            }

            //case初始化，保证case有值
            for (int i = 0; i < Data.n_case_max; i++)
            {
                Data.case_data[i] = new CaseData();    //自动测试                
            }

            //nodepara初始化，保证nodepara有值
            for (int i = 0; i < Data.n_nodepara_max; i++)
            {
                Data.nodepara[i] = new nodeParaData();    //设备初值                
            }

            //mat初始化
            for (int i = 0; i < Data.n_mat_max; i++)
            {
                Data.mat[i] = new MatData();    //物性
            }


            //-------------------------物性参数------------------------
            //读取csv文件
            string nextLine = "";

            nextLine = sR1.ReadLine(); //# 控制参数
            nextLine = sR1.ReadLine(); //# 控制参数
            nextLine = sR1.ReadLine(); //# 控制参数
            nextLine = sR1.ReadLine(); //# 控制参数
            nextLine = sR1.ReadLine(); //# 控制参数
            {
                string[] tmp = nextLine.Split(',');
                flag = flag && bool.TryParse(tmp[0], out Data.opt_model_cal);    //优化模型计算
                flag = flag && bool.TryParse(tmp[1], out Data.cal_min_temp_diff);    //最小温差 
            }
            nextLine = sR1.ReadLine(); //# 物性参数
            nextLine = sR1.ReadLine(); //# 物性参数
            nextLine = sR1.ReadLine(); //# 物性参数
            nextLine = sR1.ReadLine(); //# 物性参数
            nextLine = sR1.ReadLine(); //# 物性参数
            {
                string[] tmp = nextLine.Split(',');

                flag = flag && double.TryParse(tmp[0], out Data.gas_const);    //气体常数
                flag = flag && double.TryParse(tmp[1], out Data.t_ref);    //参考温度
                flag = flag && double.TryParse(tmp[2], out Data.p_ref);    //参考压力
            }

            nextLine = sR1.ReadLine(); //# 物性参数
            nextLine = sR1.ReadLine(); //# 物性参数
            {
                string[] tmp = nextLine.Split(',');
                flag = flag && int.TryParse(tmp[0], out Data.n_mat);        //材料数
            }
            nextLine = sR1.ReadLine(); //# 物性参数
            for (int i = 0; i < Data.n_mat; i++)
            {
                nextLine = sR1.ReadLine();
                {
                    string[] tmp = nextLine.Split(',');
                    Data.mat[i].id = int.Parse(tmp[0]);
                    // flag = flag && int.TryParse(tmp[0], out Data.mat[i].id);  //介质编号
                    Data.mat[i].name = tmp[1];   //介质名称
                    Data.mat[i].mol = double.Parse(tmp[2]);
                    // flag = flag && double.TryParse(tmp[2], out Data.mat[i].mol);   //介质分子量
                    Data.mat[i].notes = tmp[3];   //备注
                    Console.WriteLine("i = {0} , id = {1}, name = {2}, mol = {3}", i, Data.mat[i].id, Data.mat[i].name, Data.mat[i].mol);
                }
            }

            //-------------------------部件参数------------------------
            nextLine = sR1.ReadLine(); //# 路由参数
            nextLine = sR1.ReadLine(); //# 路由参数
            nextLine = sR1.ReadLine(); //# 路由参数
            nextLine = sR1.ReadLine(); //# 路由参数
            nextLine = sR1.ReadLine(); //# 路由参数
            {
                string[] tmp = nextLine.Split(',');
                flag = flag && int.TryParse(tmp[0], out Data.n_node);  //部件总数
                flag = flag && int.TryParse(tmp[1], out Data.n_line);  //流股总数
                Console.WriteLine("n_node = {0} ,n_line = {1} ", Data.n_node, Data.n_line);
            }

            for (int i = 0; i < Data.n_node; i++)
            {
                nextLine = sR1.ReadLine();
                nextLine = sR1.ReadLine();
                nextLine = sR1.ReadLine();
                {
                    string[] tmp = nextLine.Split(',');
                    Data.node[i].id = i + 1;
                    Data.node[i].name = tmp[0];   //部件名称
                                                  // flag = flag && int.TryParse(tmp[1], out Data.node[i].type);  //部件类型
                    Data.node[i].type = int.Parse(tmp[1]);
                    // flag = flag && int.TryParse(tmp[2], out Data.node[i].n);  //部件流股数
                    Data.node[i].n = int.Parse(tmp[2]);
                    //flag = flag && int.TryParse(tmp[3], out Data.node[i].cal_type);//部件计算类型
                    Data.node[i].cal_type = int.Parse(tmp[3]);
                    flag = flag && bool.TryParse(tmp[4], out Data.node[i].n2_heat);   //部件是否为含氮换热器

                    Console.WriteLine("i = {0} ,name = {1} , type = {2}, n = {3}, cal_type = {4}, n2_heat = {5}", i, Data.node[i].name, Data.node[i].type, Data.node[i].n, Data.node[i].cal_type, Data.node[i].n2_heat);
                }
                nextLine = sR1.ReadLine();
                nextLine = sR1.ReadLine();
                {
                    string[] tmp = nextLine.Split(',');
                    for (int j = 0; j < Data.node[i].n; j++)
                    {
                        //flag = flag && int.TryParse(tmp[j], out Data.node[i].i[j]);   //输入流股
                        Data.node[i].i[j] = int.Parse(tmp[j]);
                        Console.WriteLine("j = {0} ,i = {1} ", j, Data.node[i].i[j]);
                    }

                }
                nextLine = sR1.ReadLine();
                nextLine = sR1.ReadLine();
                {
                    string[] tmp = nextLine.Split(',');
                    for (int k = 0; k < Data.node[i].n; k++)
                    {
                        //flag = flag && int.TryParse(tmp[k], out Data.node[i].o[k]);   //输出流股
                        Data.node[i].o[k] = int.Parse(tmp[k]);
                        Console.WriteLine("k = {0} ,o = {1} ", k, Data.node[i].o[k]);
                    }
                }

            }

            //-------------------------流股参数------------------------
            nextLine = sR1.ReadLine(); //# 流股参数
            nextLine = sR1.ReadLine(); //# 流股参数
            nextLine = sR1.ReadLine(); //# 流股参数
            nextLine = sR1.ReadLine(); //# 流股参数

            for (int i = 0; i < Data.n_line; i++)
            {
                nextLine = sR1.ReadLine();
                string[] tmp = nextLine.Split(',');
                // flag = flag && int.TryParse(tmp[0], out Data.line[i].ip);  //流股序号
                Data.line[i].ip = int.Parse(tmp[0] == "" ? "0" : tmp[0]);

                //flag = flag && double.TryParse(tmp[1], out Data.line[i].t);   //温度
                Data.line[i].t = double.Parse(tmp[1] == "" ? "0" : tmp[1]);

                //flag = flag && double.TryParse(tmp[2], out Data.line[i].p);   //压力
                Data.line[i].p = double.Parse(tmp[2] == "" ? "0" : tmp[2]);

                //flag = flag && double.TryParse(tmp[3], out Data.line[i].m);   //流量
                Data.line[i].m = double.Parse(tmp[3] == "" ? "0" : tmp[3]);

                //flag = flag && double.TryParse(tmp[4], out Data.line[i].para);   //仲氢浓度
                Data.line[i].para = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

                //flag = flag && double.TryParse(tmp[5], out Data.line[i].n2);   //液氮比例
                Data.line[i].n2 = double.Parse(tmp[5] == "" ? "0" : tmp[5]);

                //flag = flag && int.TryParse(tmp[6], out Data.line[i].mat);  //工质
                Data.line[i].mat = int.Parse(tmp[6] == "" ? "0" : tmp[6]);
                Data.line[i].h2_type = int.Parse(tmp[7] == "" ? "0" : tmp[7]);
                Console.WriteLine("i = {0} ,ip = {1}, t = {2}, p = {3}, m = {4}, para = {5}, n2 = {6}, mat = {7} ", i, Data.line[i].ip, Data.line[i].t, Data.line[i].p, Data.line[i].m, Data.line[i].para, Data.line[i].n2, Data.line[i].mat);
            }

            //-------------------------设备初值------------------------
            nextLine = sR1.ReadLine(); //# 设备初值
            nextLine = sR1.ReadLine(); //# 设备初值
            nextLine = sR1.ReadLine(); //# 设备初值
            nextLine = sR1.ReadLine(); //# 设备初值

            for (int i = 0; i < Data.n_node; i++)
            {
                nextLine = sR1.ReadLine();
                string[] tmp = nextLine.Split(',');
                //flag = flag && int.TryParse(tmp[0], out Data.nodepara[i].ip);  //部件序号
                Data.nodepara[i].ip = int.Parse(tmp[0] == "" ? "0" : tmp[0]);

                //flag = flag && double.TryParse(tmp[1], out Data.nodepara[i].eff);   //eff
                Data.nodepara[i].eff = double.Parse(tmp[1] == "" ? "0" : tmp[1]);

                //flag = flag && int.TryParse(tmp[2], out Data.nodepara[i].cal_i);   //cal_i
                Data.nodepara[i].cal_i = int.Parse(tmp[2] == "" ? "0" : tmp[2]);

                //flag = flag && int.TryParse(tmp[3], out Data.nodepara[i].cal_j);   //cal_j
                Data.nodepara[i].cal_j = int.Parse(tmp[3] == "" ? "0" : tmp[3]);

                //flag = flag && int.TryParse(tmp[4], out Data.nodepara[i].direction);   //膨胀机方向
                Data.nodepara[i].direction = int.Parse(tmp[4] == "" ? "0" : tmp[4]);

                Data.nodepara[i].name = tmp[5];
                Console.WriteLine("i = {0} , ip = {1}, eff = {2}, cal_i = {3}, cal_j = {4}, direction = {5}, name = {6}", i, Data.nodepara[i].ip, Data.nodepara[i].eff, Data.nodepara[i].cal_i, Data.nodepara[i].cal_j, Data.nodepara[i].direction, Data.nodepara[i].name);
            }

            //-------------------------自动测试------------------------
            nextLine = sR1.ReadLine(); //# 自动测试
            nextLine = sR1.ReadLine(); //# 自动测试
            nextLine = sR1.ReadLine(); //# 自动测试
            nextLine = sR1.ReadLine(); //# 自动测试
            nextLine = sR1.ReadLine(); //# 自动测试
            {
                string[] tmp = nextLine.Split(',');
                Data.n_case = int.Parse(tmp[0] == "" ? "0" : tmp[0]);//工况数
            }
            nextLine = sR1.ReadLine(); //# 自动测试

            for (int i = 0; i < Data.n_case; i++)
            {
                nextLine = sR1.ReadLine();
                string[] tmp = nextLine.Split(',');
                //工况序号
                Data.case_data[i].icase = int.Parse(tmp[0] == "" ? "0" : tmp[0]);
                //流股编号
                Data.case_data[i].line_case = int.Parse(tmp[1] == "" ? "0" : tmp[1]);
                //温度
                Data.case_data[i].t_case = double.Parse(tmp[2] == "" ? "0" : tmp[2]);
                //压力
                Data.case_data[i].p_case = double.Parse(tmp[3] == "" ? "0" : tmp[3]);
                //流量
                Data.case_data[i].m_case = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

            }

            for (int i = 1; i <= Data.fault.Length; i++)
            {
                Data.fault[i - 1].id = i;
            }
            int a = 0;
            for (int i = 0; i < Data.n_node; i++)
            {
                int nodeId = Data.node[i].id;

                for (int j = 0; j < Data.node[nodeId - 1].n; j++)
                {
                    Data.fault[a].node_id = nodeId;
                    Data.fault[a].node_name = Data.node[i].name;
                    int lineId = Data.node[nodeId - 1].i[j];
                    Data.fault[a].line_id = Data.line[lineId - 1].ip;
                    Data.fault[a].in_out = "输入";
                    Data.fault[a].is_fault = false;
                    Data.fault[a].is_result = false;
                    a++;
                }

                for (int k = 0; k < Data.node[nodeId - 1].n; k++)
                {
                    Data.fault[a].node_id = nodeId;
                    Data.fault[a].node_name = Data.node[i].name;
                    int lineId = Data.node[nodeId - 1].o[k];
                    Data.fault[a].line_id = Data.line[lineId - 1].ip;
                    Data.fault[a].in_out = "输出";
                    Data.fault[a].is_fault = false;
                    Data.fault[a].is_result = false;
                    a++;
                }

            }

            sR1.Close();
            MessageBox.Show("导入成功！");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
