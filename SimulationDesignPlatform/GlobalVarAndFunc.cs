using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationDesignPlatform
{

    //物性参数
    public class MatData
    {

        public int id;
        public double mol, p, tc, tk, rho, h, u, cv, z, r, m, rm;
        public string name, notes;

        public MatData()
        {

        }
    }

    //部件参数
    public class NodeData
    {
        public const int line_per_node = 5;
        
        public string name;
        public bool n2_heat;
        public int type, n, ni, mi, li, lo, direction, n_cal, cal_i, cal_j, cal_type, id , ncal_seq;
        public int[] i, o = new int[line_per_node];
        
        public double t, p, ma, mo, para, h, s, e, vf, heat, eff, W, n2_i;

    }

    public class calSeqData
    {
        public const int cal_seq_max = 30;
        public int[] node_cal_seq = new int[cal_seq_max];
    }


    //流股参数
    public class lineData
    {
        public int i, o, ip, mat, h2_type;
        public double p, ma, mo, para, h, s, e, vf, heat, ne, t, m, n2;
        public string name;
    }

    //工况参数
    public class CaseData
    {
        public int icase, line_case;
        public double t_case, p_case, m_case;

    }

    //流股参数
    public class FaultData
    {
        public int id, node_id, line_id;
        public bool is_fault, is_result;
        public string node_name, in_out;

        public FaultData()
        {

        }
    }

    //设备初值参数
    public class nodeParaData
    {
        public int ip, cal_i, cal_j, direction;
        public double eff;
        public string name;
    }

    //一般参数，用于总调度
    public class Data
    {
        public static int n_mat, n_node, n_line, n_case;//材料数  部件总数   流股总数   工况数
        public static double gas_const, t_ref, p_ref;//气体常数	参考温度 参考压力
        public static string fzxt_name, user_name, user_password, case_name;//仿真系统名称, 用户登录用户名，密码, 指定目录文件夹名称
        public static bool multi_case;//多工况计算

        public static DateTime start_time = new DateTime(2024, 1, 17, 10, 00, 00);
        public static DateTime[] check_time = new DateTime[13];
        public static int[] yz_num = new int[14];//图表阈值设定
        public static List<List<string>> data = new List<List<string>>();//数据列表模块  导入数据存储
        public static List<List<string>> data1 = new List<List<string>>();//趋势监控-图表1  导入数据存储
        public static List<List<string>> data2 = new List<List<string>>();//趋势监控-图表2  导入数据存储
        public static List<List<string>> data3 = new List<List<string>>();//趋势监控-图表3  导入数据存储
        public static List<List<string>> data4 = new List<List<string>>();//趋势监控-图表4  导入数据存储
        public static List<List<string>> data5 = new List<List<string>>();//趋势监控-图表5  导入数据存储
        public static List<List<string>> data6 = new List<List<string>>();//趋势监控-图表6  导入数据存储
        public static List<List<string>> data7 = new List<List<string>>();//工艺流程-电解电流  导入数据存储
        public static List<List<string>> data8 = new List<List<string>>();//工艺流程-电解电压  导入数据存储
        public static List<List<string>> data9 = new List<List<string>>();//工艺流程-氧中氢  导入数据存储
        public static List<List<string>> data10 = new List<List<string>>();//工艺流程-温度  导入数据存储
        public static List<List<string>> data11 = new List<List<string>>();//数据回放-图表-1  导入数据存储
        public static List<List<string>> data12 = new List<List<string>>();//数据回放-图表-2  导入数据存储
        public static List<List<string>> data13 = new List<List<string>>();//数据回放-图表-3  导入数据存储
        public static List<List<string>> data14 = new List<List<string>>();//数据回放-数据列表 
        public static List<List<string>> data15 = new List<List<string>>();//部件仿真结果数据查看 
        public static List<List<string>> data16 = new List<List<string>>();//流股仿真结果数据查看 

        public static string[] data1_check;//趋势监控-图表1  列勾选情况
        public static string[] data2_check;//趋势监控-图表2  列勾选情况
        public static string[] data3_check;//趋势监控-图表3  列勾选情况
        public static string[] data4_check;//趋势监控-图表4  列勾选情况
        public static string[] data5_check;//趋势监控-图表5  列勾选情况
        public static string[] data6_check;//趋势监控-图表6  列勾选情况
        public static string[] data7_check;//工艺流程-电解电流  列勾选情况
        public static string[] data8_check;//工艺流程-电解电压  列勾选情况
        public static string[] data9_check;//工艺流程-氧中氢  列勾选情况
        public static string[] data10_check;//工艺流程-温度  列勾选情况
        public static string[] data11_check;//数据回放-图表-1  列勾选情况
        public static string[] data12_check;//数据回放-图表-2  列勾选情况
        public static string[] data13_check;//数据回放-图表-3  列勾选情况
        public static string[] data15_check;//部件仿真结果  列勾选情况
        public static string[] data16_check;//流股仿真结果  列勾选情况

        public static string imagePath;

        public const int n_mat_max = 10;//物性参数
        public static MatData[] mat = new MatData[n_mat_max]; //全局变量，存储

        public const int n_node_max = 20;//部件参数
        public static NodeData[] node = new NodeData[n_node_max]; //全局变量，存储

        public const int n_line_max = 50;//流股参数
        public static lineData[] line = new lineData[n_line_max]; //全局变量，存储
        public static lineData[] faultLine = new lineData[n_line_max]; //全局变量，存储

        public const int n_fault_max = 50;//故障流股参数
        public static FaultData[] fault = new FaultData[n_fault_max]; //全局变量，存储

        public const int n_case_max = 10;//工况参数
        public static CaseData[] case_data = new CaseData[n_case_max]; //全局变量，存储

        public const int n_nodepara_max = 20;//设备初值参数
        public static nodeParaData[] nodepara = new nodeParaData[n_nodepara_max]; //全局变量，存储

        public static TreeNodeData rootNode_01 = new TreeNodeData("电解水制氢仿真测试");
        public static TreeNodeData rootNode_02 = new TreeNodeData("电解水制氢仿真系统");


        public static calSeqData calSeq = new calSeqData(); //全局变量，存储

        public static string openFile, saveFile, fileName, filePath, exePath, casePath, caseUsePath, newFolderPath, newFolderName;  // 文件名，包含路径，用于存储文件

        // csv文件 转为 data.input
        //public static void CSV2Data(string fn)
        //{
        //    bool flag = true;
        //    //string str1;
        //    using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(fn)))
        //    {
        //        using (StreamReader sR1 = new StreamReader(ms, Encoding.UTF8))
        //        {
        //            //node初始化，保证node有值
        //            for (int i = 0; i < Data.n_node_max; i++)
        //            {
        //                Data.node[i] = new NodeData();    //部件
        //                Data.node[i].i = new int[5];
        //                Data.node[i].o = new int[5];
        //            }

        //            //line初始化，保证line有值
        //            for (int i = 0; i < Data.n_line_max; i++)
        //            {
        //                Data.line[i] = new lineData();    //流股
        //            }

        //            //faultLine初始化，保证faultLine有值
        //            for (int i = 0; i < Data.n_line_max; i++)
        //            {
        //                Data.faultLine[i] = new lineData();    //流股
        //            }

        //            //fault初始化，保证fault有值
        //            for (int i = 0; i < Data.n_fault_max; i++)
        //            {
        //                Data.fault[i] = new FaultData();    //故障注入                
        //            }

        //            //case初始化，保证case有值
        //            for (int i = 0; i < Data.n_case_max; i++)
        //            {
        //                Data.case_data[i] = new CaseData();    //自动测试                
        //            }

        //            //nodepara初始化，保证nodepara有值
        //            for (int i = 0; i < Data.n_nodepara_max; i++)
        //            {
        //                Data.nodepara[i] = new nodeParaData();    //设备初值                
        //            }

        //            //mat初始化
        //            for (int i = 0; i < Data.n_mat_max; i++)
        //            {
        //                Data.mat[i] = new MatData();    //物性
        //            }


        //            //-------------------------物性参数------------------------
        //            //读取csv文件
        //            string nextLine = "";

        //            nextLine = sR1.ReadLine(); //# 控制参数
        //            nextLine = sR1.ReadLine(); //# 控制参数
        //            nextLine = sR1.ReadLine(); //# 控制参数
        //            nextLine = sR1.ReadLine(); //# 控制参数
        //            nextLine = sR1.ReadLine(); //# 控制参数
        //            {
        //                string[] tmp = nextLine.Split(',');
        //                flag = flag && bool.TryParse(tmp[0], out Data.multi_case);    //多工况计算
        //            }
        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            {
        //                string[] tmp = nextLine.Split(',');

        //                flag = flag && double.TryParse(tmp[0], out Data.gas_const);    //气体常数
        //                flag = flag && double.TryParse(tmp[1], out Data.t_ref);    //参考温度
        //                flag = flag && double.TryParse(tmp[2], out Data.p_ref);    //参考压力
        //            }

        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            {
        //                string[] tmp = nextLine.Split(',');
        //                flag = flag && int.TryParse(tmp[0], out Data.n_mat);        //材料数
        //            }
        //            nextLine = sR1.ReadLine(); //# 物性参数
        //            for (int i = 0; i < Data.n_mat; i++)
        //            {
        //                nextLine = sR1.ReadLine();
        //                {
        //                    string[] tmp = nextLine.Split(',');
        //                    Data.mat[i].id = int.Parse(tmp[0]);
        //                    // flag = flag && int.TryParse(tmp[0], out Data.mat[i].id);  //介质编号
        //                    Data.mat[i].name = tmp[1];   //介质名称
        //                    Data.mat[i].mol = double.Parse(tmp[2]);
        //                    // flag = flag && double.TryParse(tmp[2], out Data.mat[i].mol);   //介质分子量
        //                    Data.mat[i].notes = tmp[3];   //备注
        //                    Console.WriteLine("i = {0} , id = {1}, name = {2}, mol = {3}", i, Data.mat[i].id, Data.mat[i].name, Data.mat[i].mol);
        //                }
        //            }

        //            //-------------------------部件参数------------------------
        //            nextLine = sR1.ReadLine(); //# 路由参数
        //            nextLine = sR1.ReadLine(); //# 路由参数
        //            nextLine = sR1.ReadLine(); //# 路由参数
        //            nextLine = sR1.ReadLine(); //# 路由参数
        //            nextLine = sR1.ReadLine(); //# 路由参数
        //            {
        //                string[] tmp = nextLine.Split(',');
        //                flag = flag && int.TryParse(tmp[0], out Data.n_node);  //部件总数
        //                flag = flag && int.TryParse(tmp[1], out Data.n_line);  //流股总数
        //                Console.WriteLine("n_node = {0} ,n_line = {1} ", Data.n_node, Data.n_line);
        //            }

        //            for (int i = 0; i < Data.n_node; i++)
        //            {
        //                nextLine = sR1.ReadLine();
        //                nextLine = sR1.ReadLine();
        //                nextLine = sR1.ReadLine();
        //                {
        //                    string[] tmp = nextLine.Split(',');
        //                    Data.node[i].id = i + 1;
        //                    Data.node[i].name = tmp[0];   //部件名称
        //                                                  // flag = flag && int.TryParse(tmp[1], out Data.node[i].type);  //部件类型
        //                    Data.node[i].type = int.Parse(tmp[1]);
        //                    // flag = flag && int.TryParse(tmp[2], out Data.node[i].n);  //部件流股数
        //                    Data.node[i].n = int.Parse(tmp[2]);
        //                    //flag = flag && int.TryParse(tmp[3], out Data.node[i].cal_type);//部件计算类型
        //                    Data.node[i].cal_type = int.Parse(tmp[3]);
        //                    flag = flag && bool.TryParse(tmp[4], out Data.node[i].n2_heat);   //部件是否为含氮换热器

        //                    Console.WriteLine("i = {0} ,name = {1} , type = {2}, n = {3}, cal_type = {4}, n2_heat = {5}", i, Data.node[i].name, Data.node[i].type, Data.node[i].n, Data.node[i].cal_type, Data.node[i].n2_heat);
        //                }
        //                nextLine = sR1.ReadLine();
        //                nextLine = sR1.ReadLine();
        //                {
        //                    string[] tmp = nextLine.Split(',');
        //                    for (int j = 0; j < Data.node[i].n; j++)
        //                    {
        //                        //flag = flag && int.TryParse(tmp[j], out Data.node[i].i[j]);   //输入流股
        //                        Data.node[i].i[j] = int.Parse(tmp[j]);
        //                        Console.WriteLine("j = {0} ,i = {1} ", j, Data.node[i].i[j]);
        //                    }

        //                }
        //                nextLine = sR1.ReadLine();
        //                nextLine = sR1.ReadLine();
        //                {
        //                    string[] tmp = nextLine.Split(',');
        //                    for (int k = 0; k < Data.node[i].n; k++)
        //                    {
        //                        //flag = flag && int.TryParse(tmp[k], out Data.node[i].o[k]);   //输出流股
        //                        Data.node[i].o[k] = int.Parse(tmp[k]);
        //                        Console.WriteLine("k = {0} ,o = {1} ", k, Data.node[i].o[k]);
        //                    }
        //                }

        //            }

        //            //-------------------------流股参数------------------------
        //            nextLine = sR1.ReadLine(); //# 流股参数
        //            nextLine = sR1.ReadLine(); //# 流股参数
        //            nextLine = sR1.ReadLine(); //# 流股参数
        //            nextLine = sR1.ReadLine(); //# 流股参数

        //            for (int i = 0; i < Data.n_line; i++)
        //            {
        //                nextLine = sR1.ReadLine();
        //                string[] tmp = nextLine.Split(',');
        //                // flag = flag && int.TryParse(tmp[0], out Data.line[i].ip);  //流股序号
        //                Data.line[i].ip = int.Parse(tmp[0] == "" ? "0" : tmp[0]);

        //                // 流股名称 （20240311，由M修改添加）
        //                Data.line[i].name = tmp[1];

        //                //flag = flag && double.TryParse(tmp[2], out Data.line[i].t);   //温度
        //                Data.line[i].t = double.Parse(tmp[2] == "" ? "0" : tmp[2]);

        //                //flag = flag && double.TryParse(tmp[3], out Data.line[i].p);   //压力
        //                Data.line[i].p = double.Parse(tmp[3] == "" ? "0" : tmp[3]);

        //                //flag = flag && double.TryParse(tmp[4], out Data.line[i].m);   //流量
        //                Data.line[i].m = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

        //                //flag = flag && double.TryParse(tmp[5], out Data.line[i].para);   //仲氢浓度
        //                Data.line[i].para = double.Parse(tmp[5] == "" ? "0" : tmp[5]);

        //                //flag = flag && double.TryParse(tmp[6], out Data.line[i].n2);   //液氮比例
        //                Data.line[i].n2 = double.Parse(tmp[6] == "" ? "0" : tmp[6]);

        //                //flag = flag && int.TryParse(tmp[7], out Data.line[i].mat);  //工质
        //                Data.line[i].mat = int.Parse(tmp[7] == "" ? "0" : tmp[7]);
        //                Data.line[i].h2_type = int.Parse(tmp[8] == "" ? "0" : tmp[8]);
        //                Console.WriteLine("i = {0} ,ip = {1}, t = {2}, p = {3}, m = {4}, para = {5}, n2 = {6}, mat = {7} ", i, Data.line[i].ip, Data.line[i].t, Data.line[i].p, Data.line[i].m, Data.line[i].para, Data.line[i].n2, Data.line[i].mat);
        //            }

        //            //-------------------------设备初值------------------------
        //            nextLine = sR1.ReadLine(); //# 设备初值
        //            nextLine = sR1.ReadLine(); //# 设备初值
        //            nextLine = sR1.ReadLine(); //# 设备初值
        //            nextLine = sR1.ReadLine(); //# 设备初值

        //            for (int i = 0; i < Data.n_node; i++)
        //            {
        //                nextLine = sR1.ReadLine();
        //                string[] tmp = nextLine.Split(',');
        //                //flag = flag && int.TryParse(tmp[0], out Data.nodepara[i].ip);  //部件序号
        //                Data.nodepara[i].ip = int.Parse(tmp[0] == "" ? "0" : tmp[0]);

        //                //flag = flag && double.TryParse(tmp[1], out Data.nodepara[i].eff);   //eff
        //                Data.nodepara[i].eff = double.Parse(tmp[1] == "" ? "0" : tmp[1]);

        //                //flag = flag && int.TryParse(tmp[2], out Data.nodepara[i].cal_i);   //cal_i
        //                Data.nodepara[i].cal_i = int.Parse(tmp[2] == "" ? "0" : tmp[2]);

        //                //flag = flag && int.TryParse(tmp[3], out Data.nodepara[i].cal_j);   //cal_j
        //                Data.nodepara[i].cal_j = int.Parse(tmp[3] == "" ? "0" : tmp[3]);

        //                //flag = flag && int.TryParse(tmp[4], out Data.nodepara[i].direction);   //膨胀机方向
        //                Data.nodepara[i].direction = int.Parse(tmp[4] == "" ? "0" : tmp[4]);

        //                Data.nodepara[i].name = tmp[5];
        //                Console.WriteLine("i = {0} , ip = {1}, eff = {2}, cal_i = {3}, cal_j = {4}, direction = {5}, name = {6}", i, Data.nodepara[i].ip, Data.nodepara[i].eff, Data.nodepara[i].cal_i, Data.nodepara[i].cal_j, Data.nodepara[i].direction, Data.nodepara[i].name);
        //            }

        //            //-------------------------自动测试------------------------
        //            nextLine = sR1.ReadLine(); //# 自动测试
        //            nextLine = sR1.ReadLine(); //# 自动测试
        //            nextLine = sR1.ReadLine(); //# 自动测试
        //            nextLine = sR1.ReadLine(); //# 自动测试
        //            nextLine = sR1.ReadLine(); //# 自动测试
        //            {
        //                string[] tmp = nextLine.Split(',');
        //                Data.n_case = int.Parse(tmp[0] == "" ? "0" : tmp[0]);//工况数
        //            }
        //            nextLine = sR1.ReadLine(); //# 自动测试

        //            for (int i = 0; i < Data.n_case; i++)
        //            {
        //                nextLine = sR1.ReadLine();
        //                string[] tmp = nextLine.Split(',');
        //                //工况序号
        //                Data.case_data[i].icase = int.Parse(tmp[0] == "" ? "0" : tmp[0]);
        //                //流股编号
        //                Data.case_data[i].line_case = int.Parse(tmp[1] == "" ? "0" : tmp[1]);
        //                //温度
        //                Data.case_data[i].t_case = double.Parse(tmp[2] == "" ? "0" : tmp[2]);
        //                //压力
        //                Data.case_data[i].p_case = double.Parse(tmp[3] == "" ? "0" : tmp[3]);
        //                //流量
        //                Data.case_data[i].m_case = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

        //            }

        //            for (int i = 1; i <= Data.fault.Length; i++)
        //            {
        //                Data.fault[i - 1].id = i;
        //            }
        //            int a = 0;
        //            for (int i = 0; i < Data.n_node; i++)
        //            {
        //                int nodeId = Data.node[i].id;

        //                for (int j = 0; j < Data.node[nodeId - 1].n; j++)
        //                {
        //                    Data.fault[a].node_id = nodeId;
        //                    Data.fault[a].node_name = Data.node[i].name;
        //                    int lineId = Data.node[nodeId - 1].i[j];
        //                    Data.fault[a].line_id = Data.line[lineId - 1].ip;
        //                    Data.fault[a].in_out = "输入";
        //                    Data.fault[a].is_fault = false;
        //                    Data.fault[a].is_result = false;
        //                    a++;
        //                }

        //                for (int k = 0; k < Data.node[nodeId - 1].n; k++)
        //                {
        //                    Data.fault[a].node_id = nodeId;
        //                    Data.fault[a].node_name = Data.node[i].name;
        //                    int lineId = Data.node[nodeId - 1].o[k];
        //                    Data.fault[a].line_id = Data.line[lineId - 1].ip;
        //                    Data.fault[a].in_out = "输出";
        //                    Data.fault[a].is_fault = false;
        //                    Data.fault[a].is_result = false;
        //                    a++;
        //                }

        //            }

        //            sR1.Close();
        //            MessageBox.Show("导入成功！");
        //        }
        //    }
        //}

        //public class StringEncodingConverter
        //{
        //    public static string ConvertStringToEncoding(string originalString, Encoding targetEncoding)
        //    {
        //        // 将字符串转换为字节数组，使用默认编码
        //        byte[] bytes = Encoding.Default.GetBytes(originalString);

        //        // 将字节数组转换为目标编码的字符串
        //        return targetEncoding.GetString(bytes);
        //    }
        //}
        //public static void GUI2CSV(string fn)
        //{
        //    // output gui.input
        //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(fn, false, Encoding.UTF8))
        //    {
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("# 控制参数,,,,,,,,,,,,,,,");
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("多工况计算,,,,,,,,,,,");
        //        file.WriteLine(Data.multi_case.ToString() + ',');
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("# 物性参数,,,,,,,,,,,,,,,");
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("气体常数,参考温度,参考压力,,,,,,,,,,,,,,,,");
        //        file.WriteLine(Data.gas_const.ToString() + ',' + Data.t_ref.ToString() + ',' + Data.p_ref.ToString() + ',');
        //        file.WriteLine("材料数,,,,,,,,,,,,,,,,,,");
        //        file.WriteLine(Data.n_mat.ToString() + ',');
        //        file.WriteLine("介质编号,名称,分子量,备注,,,,,,,,,,,,,,,,,");
        //        for (int i = 0; i < Data.n_mat; i++)
        //        {
        //            Encoding utf8Encoding = Encoding.UTF8;
        //            string utf8String = StringEncodingConverter.ConvertStringToEncoding(Data.mat[i].notes.ToString(), utf8Encoding);
        //            file.WriteLine(Data.mat[i].id.ToString() + ',' + Data.mat[i].name.ToString() + ','
        //                           + Data.mat[i].mol.ToString() + ',' + utf8String + ',');
        //        }
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("# 路由参数,,,,,,,,,,,,,,,");
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("部件总数,流股总数,,,,,,,,,,,,,,,,,,");
        //        file.WriteLine(Data.n_node.ToString() + ',' + Data.n_line.ToString() + ',');
        //        for (int i = 0; i < Data.n_node; i++)
        //        {
        //            file.WriteLine("### 部件" + Data.node[i].id + ",,,,,,,,,,,,,,,,");
        //            file.WriteLine("name,type,流股数,计算类型,含氮换热器,,,,,,,,,,,,,,,,");
        //            file.WriteLine(Data.node[i].name.ToString() + ',' + Data.node[i].type.ToString() + ','
        //                           + Data.node[i].n.ToString() + ',' + Data.node[i].cal_type.ToString() + ','
        //                           + Data.node[i].n2_heat.ToString() + ',');
        //            file.WriteLine("输入流股,,,,,,,,,,,,,,,");
        //            string tmp = "";
        //            string tmp2 = "";
        //            for (int j = 0; j < Data.node[i].n; j++)
        //            {
        //                tmp = tmp + Data.node[i].i[j] + ",";
        //                tmp2 = tmp2 + Data.node[i].o[j] + ",";
        //            }
        //            file.WriteLine(tmp);
        //            file.WriteLine("输出流股,,,,,,,,,,,,,,,");
        //            file.WriteLine(tmp2);
        //        }
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("# 流股初值,,,,,,,,,,,,,,,");
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("流股,温度,压力,流量,仲氢浓度,液氮比例,工质,纯氢,,,,,,,,,,,,");
        //        for (int i = 0; i < Data.n_line; i++)
        //        {
        //            file.WriteLine(Data.line[i].ip.ToString() + ',' + Data.line[i].t.ToString() + ','
        //                           + Data.line[i].p.ToString() + ',' + Data.line[i].m.ToString() + ','
        //                           + Data.line[i].para.ToString() + ',' + Data.line[i].n2.ToString() + ','
        //                           + Data.line[i].mat.ToString() + ',' + Data.line[i].h2_type.ToString() + ',');
        //        }
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("# 设备初值,,,,,,,,,,,,,,,");
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("设备,eff,cal_i,cal_j,膨胀机方向,设备名称,,,,,,,,,,,,");
        //        for (int i = 0; i < Data.n_node; i++)
        //        {
        //            file.WriteLine(Data.nodepara[i].ip.ToString() + ',' + Data.nodepara[i].eff.ToString() + ','
        //                           + Data.nodepara[i].cal_i.ToString() + ',' + Data.nodepara[i].cal_j.ToString() + ','
        //                           + Data.nodepara[i].direction.ToString() + ',' + Data.nodepara[i].name.ToString() + ',');
        //        }
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("# 自动测试,,,,,,,,,,,,,,,");
        //        file.WriteLine("###########################,,,,,,,,,,,,,,,");
        //        file.WriteLine("工况数,,,,,,,,,,,,,,,,");
        //        file.WriteLine(Data.n_case.ToString() + ',');
        //        file.WriteLine("工况,流股,温度,压力,流量,,,,,,,,,,,,,");
        //        for (int i = 0; i < Data.n_case; i++)
        //        {
        //            file.WriteLine(Data.case_data[i].icase.ToString() + ',' + Data.case_data[i].line_case.ToString() + ','
        //                + Data.case_data[i].t_case.ToString() + ',' + Data.case_data[i].p_case.ToString() + ','
        //                + Data.case_data[i].m_case.ToString() + ',');
        //        }
        //    }
        //}

        // csv文件 转为 dp.input
        public static void CSV2Data(string fn)
        {
            bool flag = true;
            //string str1;
            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(fn)))
            {
                using (StreamReader sR1 = new StreamReader(ms, Encoding.Default))
                {
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
                        flag = flag && bool.TryParse(tmp[0], out Data.multi_case);    //多工况计算
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

                        // 流股名称 （20240311，由M修改添加）
                        Data.line[i].name = tmp[1];

                        //flag = flag && double.TryParse(tmp[2], out Data.line[i].t);   //温度
                        Data.line[i].t = double.Parse(tmp[2] == "" ? "0" : tmp[2]);

                        //flag = flag && double.TryParse(tmp[3], out Data.line[i].p);   //压力
                        Data.line[i].p = double.Parse(tmp[3] == "" ? "0" : tmp[3]);

                        //flag = flag && double.TryParse(tmp[4], out Data.line[i].m);   //流量
                        Data.line[i].m = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

                        //flag = flag && double.TryParse(tmp[5], out Data.line[i].para);   //仲氢浓度
                        Data.line[i].para = double.Parse(tmp[5] == "" ? "0" : tmp[5]);

                        //flag = flag && double.TryParse(tmp[6], out Data.line[i].n2);   //液氮比例
                        Data.line[i].n2 = double.Parse(tmp[6] == "" ? "0" : tmp[6]);

                        //flag = flag && int.TryParse(tmp[7], out Data.line[i].mat);  //工质
                        Data.line[i].mat = int.Parse(tmp[7] == "" ? "0" : tmp[7]);
                        Data.line[i].h2_type = int.Parse(tmp[8] == "" ? "0" : tmp[8]); //循环氢

                        Console.WriteLine("i = {0} ,ip = {1}, t = {2}, p = {3}, m = {4}, para = {5}, n2 = {6}, mat = {7} , h2_type = {8}", i, Data.line[i].ip, Data.line[i].t, Data.line[i].p, Data.line[i].m, Data.line[i].para, Data.line[i].n2, Data.line[i].mat, Data.line[i].h2_type);
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

                    ////-------------------------自动测试------------------------
                    //nextLine = sR1.ReadLine(); //# 自动测试
                    //nextLine = sR1.ReadLine(); //# 自动测试
                    //nextLine = sR1.ReadLine(); //# 自动测试
                    //nextLine = sR1.ReadLine(); //# 自动测试
                    //nextLine = sR1.ReadLine(); //# 自动测试
                    //{
                    //    string[] tmp = nextLine.Split(',');
                    //    Data.n_case = int.Parse(tmp[0] == "" ? "0" : tmp[0]);//工况数
                    //}
                    //nextLine = sR1.ReadLine(); //# 自动测试

                    //for (int i = 0; i < Data.n_case; i++)
                    //{
                    //    nextLine = sR1.ReadLine();
                    //    string[] tmp = nextLine.Split(',');
                    //    //工况序号
                    //    Data.case_data[i].icase = int.Parse(tmp[0] == "" ? "0" : tmp[0]);
                    //    //流股编号
                    //    Data.case_data[i].line_case = int.Parse(tmp[1] == "" ? "0" : tmp[1]);
                    //    //温度
                    //    Data.case_data[i].t_case = double.Parse(tmp[2] == "" ? "0" : tmp[2]);
                    //    //压力
                    //    Data.case_data[i].p_case = double.Parse(tmp[3] == "" ? "0" : tmp[3]);
                    //    //流量
                    //    Data.case_data[i].m_case = double.Parse(tmp[4] == "" ? "0" : tmp[4]);

                    //}

                    //for (int i = 1; i <= Data.fault.Length; i++)
                    //{
                    //    Data.fault[i - 1].id = i;
                    //}
                    //int a = 0;
                    //for (int i = 0; i < Data.n_node; i++)
                    //{
                    //    int nodeId = Data.node[i].id;

                    //    for (int j = 0; j < Data.node[nodeId - 1].n; j++)
                    //    {
                    //        Data.fault[a].node_id = nodeId;
                    //        Data.fault[a].node_name = Data.node[i].name;
                    //        int lineId = Data.node[nodeId - 1].i[j];
                    //        Data.fault[a].line_id = Data.line[lineId - 1].ip;
                    //        Data.fault[a].in_out = "输入";
                    //        Data.fault[a].is_fault = false;
                    //        Data.fault[a].is_result = false;
                    //        a++;
                    //    }

                    //    for (int k = 0; k < Data.node[nodeId - 1].n; k++)
                    //    {
                    //        Data.fault[a].node_id = nodeId;
                    //        Data.fault[a].node_name = Data.node[i].name;
                    //        int lineId = Data.node[nodeId - 1].o[k];
                    //        Data.fault[a].line_id = Data.line[lineId - 1].ip;
                    //        Data.fault[a].in_out = "输出";
                    //        Data.fault[a].is_fault = false;
                    //        Data.fault[a].is_result = false;
                    //        a++;
                    //    }

                    //}

                    sR1.Close();
                    MessageBox.Show("导入成功！");
                }
            }
        }

        public static void GUI2CSV(string fn)
        {
            // output gui.input
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fn, false, Encoding.Default))
            {
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("# 控制参数,,,,,,,,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("多工况计算,,,,,,,,,,,");
                file.WriteLine(Data.multi_case.ToString() + ',');
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("# 物性参数,,,,,,,,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("气体常数,参考温度,参考压力,,,,,,,,,,,,,,,,");
                file.WriteLine(Data.gas_const.ToString() + ',' + Data.t_ref.ToString() + ',' + Data.p_ref.ToString() + ',');
                file.WriteLine("材料数,,,,,,,,,,,,,,,,,,");
                file.WriteLine(Data.n_mat.ToString() + ',');
                file.WriteLine("介质编号,名称,分子量,备注,,,,,,,,,,,,,,,,,");
                for (int i = 0; i < Data.n_mat; i++)
                {
                    file.WriteLine(Data.mat[i].id.ToString() + ',' + Data.mat[i].name.ToString() + ','
                                   + Data.mat[i].mol.ToString() + ',' + Data.mat[i].notes.ToString() + ',');
                }
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("# 路由参数,,,,,,,,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("部件总数,流股总数,,,,,,,,,,,,,,,,,,");
                file.WriteLine(Data.n_node.ToString() + ',' + Data.n_line.ToString() + ',');
                for (int i = 0; i < Data.n_node; i++)
                {
                    file.WriteLine("### 部件" + Data.node[i].id + ",,,,,,,,,,,,,,,,");
                    file.WriteLine("name,type,流股数,计算类型,含氮换热器,,,,,,,,,,,,,,,,");
                    file.WriteLine(Data.node[i].name.ToString() + ',' + Data.node[i].type.ToString() + ','
                                   + Data.node[i].n.ToString() + ',' + Data.node[i].cal_type.ToString() + ','
                                   + Data.node[i].n2_heat.ToString() + ',');
                    file.WriteLine("输入流股,,,,,,,,,,,,,,,");
                    string tmp = "";
                    string tmp2 = "";
                    for (int j = 0; j < Data.node[i].n; j++)
                    {
                        tmp = tmp + Data.node[i].i[j].ToString() + ",";
                        tmp2 = tmp2 + Data.node[i].o[j].ToString() + ",";
                    }
                    file.WriteLine(tmp);
                    file.WriteLine("输出流股,,,,,,,,,,,,,,,");
                    file.WriteLine(tmp2);
                }
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("# 流股初值,,,,,,,,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("流股,名称,温度,压力,流量,仲氢浓度,液氮比例,工质,循环氢,,,,,,,,,,,,");
                for (int i = 0; i < Data.n_line; i++)
                {
                    file.WriteLine(Data.line[i].ip.ToString() + ',' + Data.line[i].name + ','
                                   + Data.line[i].t.ToString() + ','
                                   + Data.line[i].p.ToString() + ',' + Data.line[i].m.ToString() + ','
                                   + Data.line[i].para.ToString() + ',' + Data.line[i].n2.ToString() + ','
                                   + Data.line[i].mat.ToString() + ',' + Data.line[i].h2_type.ToString() + ',');
                }
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("# 设备初值,,,,,,,,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,,,,,,,,");
                file.WriteLine("设备,eff,cal_i,cal_j,膨胀机方向,设备名称,,,,,,,,,,,,");
                for (int i = 0; i < Data.n_node; i++)
                {
                    file.WriteLine(Data.nodepara[i].ip.ToString() + ',' + Data.nodepara[i].eff.ToString() + ','
                                   + Data.nodepara[i].cal_i.ToString() + ',' + Data.nodepara[i].cal_j.ToString() + ','
                                   + Data.nodepara[i].direction.ToString() + ',' + Data.nodepara[i].name + ',');
                }
                //file.WriteLine("###########################,,,,,,,,,,,,,,,");
                //file.WriteLine("# 自动测试,,,,,,,,,,,,,,,");
                //file.WriteLine("###########################,,,,,,,,,,,,,,,");
                //file.WriteLine("工况数,,,,,,,,,,,,,,,,");
                //file.WriteLine(Data.n_case.ToString() + ',');
                //file.WriteLine("工况,流股,温度,压力,流量,,,,,,,,,,,,,");
                //for (int i = 0; i < Data.n_case; i++)
                //{
                //    file.WriteLine(Data.case_data[i].icase.ToString() + ',' + Data.case_data[i].line_case.ToString() + ','
                //        + Data.case_data[i].t_case.ToString() + ',' + Data.case_data[i].p_case.ToString() + ','
                //        + Data.case_data[i].m_case.ToString() + ',');
                //}
            }
        }

    }

    public class TreeNodeData
    {
        public string Name { get; set; }
        public List<TreeNodeData> Children { get; set; }

        public TreeNodeData(string name)
        {
            Name = name;
            Children = new List<TreeNodeData>();
        }
    }

}
