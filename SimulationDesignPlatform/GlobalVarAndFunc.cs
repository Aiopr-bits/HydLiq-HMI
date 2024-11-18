using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    //计算顺序
    public class calSeqData
    {
        public int part_name, calculate_type, cal_i, cal_j;
    }

    //自动测试
    public class autoTestData
    {
        public int n_line, n_node;
        public double[][] line, node;
        public int n_h2_node, n_h2_line;
    }

    //优化模型
    public class optModelData
    {
        public int n_line, n_node;
        public double[] line, node, initialValue;
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

    //自动测试结果(34)
    public class autoTestResult
    {
        public int nrow;
        public double[][] auto_test_result;
    }

    //优化模型结果(7)
    public class optModelResult
    {
        public int nrow;
        public double[][] opt_model_result;
    }

    //一般参数，用于总调度
    public class Data
    {
        public static int n_mat, n_node, n_line, n_case, n_calSeq;//材料数  部件总数   流股总数   工况数    计算个数
        public static double gas_const, t_ref, p_ref;//气体常数	参考温度 参考压力
        public static string fzxt_name, user_name, user_password, case_name;//仿真系统名称, 用户登录用户名，密码, 指定目录文件夹名称
        public static bool auto_test, cal_min_temp_diff, opt_model_cal;//自动测试,计算最小温差,优化模型计算

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
        public static List<List<string>> data17 = new List<List<string>>();//换热器最小温差结果数据查看 

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
        public static string[] data17_check;//换热器最小温差结果  列勾选情况

        public static string imagePath;

        public const int n_mat_max = 500;//物性参数
        public static MatData[] mat = new MatData[n_mat_max]; //全局变量，存储

        public const int n_calSeq_max = 500;//计算顺序参数
        public static calSeqData[] calSeq = new calSeqData[n_calSeq_max]; //全局变量，存储
  
        public static autoTestData autoTest = new autoTestData();//自动测试参数

        public static optModelData optModel = new optModelData();//优化模型参数

        public const int n_node_max = 500;//部件参数
        public static NodeData[] node = new NodeData[n_node_max]; //全局变量，存储

        public const int n_line_max = 500;//流股参数
        public static lineData[] line = new lineData[n_line_max]; //全局变量，存储
        public static lineData[] faultLine = new lineData[n_line_max]; //全局变量，存储

        public const int n_fault_max = 500;//故障流股参数
        public static FaultData[] fault = new FaultData[n_fault_max]; //全局变量，存储

        public const int n_case_max = 500;//工况参数
        public static CaseData[] case_data = new CaseData[n_case_max]; //全局变量，存储

        public const int n_nodepara_max = 500;//设备初值参数
        public static nodeParaData[] nodepara = new nodeParaData[n_nodepara_max]; //全局变量，存储

        public static autoTestResult autoTest_result = new autoTestResult(); //全局变量，存储

        public static optModelResult optModel_result = new optModelResult(); //全局变量，存储

        public static TreeNodeData rootNode_01 = new TreeNodeData("电解水制氢仿真测试");
        public static TreeNodeData rootNode_02 = new TreeNodeData("电解水制氢仿真系统");

        public static string openFile, saveFile, fileName, filePath, exePath, casePath, caseUsePath, newFolderPath, newFolderName;  // 文件名，包含路径，用于存储文件

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

                    //calSeq初始化
                    for (int  i= 0; i<Data.n_calSeq_max; i++)
                    {
                        Data.calSeq[i] = new calSeqData();
                        calSeq[i].part_name = -1;
                        calSeq[i].calculate_type = -1;
                        calSeq[i].cal_i= -1;
                        calSeq[i].cal_j = -1;
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
                        flag = flag && bool.TryParse(tmp[0], out Data.auto_test);           //自动测试
                        flag = flag && bool.TryParse(tmp[1], out Data.cal_min_temp_diff);       //优化模型计算
                        flag = flag && bool.TryParse(tmp[2], out Data.opt_model_cal);           //最小温差


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

                    //-------------------------计算顺序------------------------
                    nextLine = sR1.ReadLine(); //# 计算顺序
                    nextLine = sR1.ReadLine(); //# 计算顺序
                    nextLine = sR1.ReadLine(); //# 计算顺序
                    nextLine = sR1.ReadLine(); //# 计算顺序
                    nextLine = sR1.ReadLine(); 
                    {
                        string[] tmp = nextLine.Split(',');
                        Data.n_calSeq = int.Parse(tmp[0] == "" ? "0" : tmp[0]);//计算个数
                    }
                    nextLine = sR1.ReadLine(); //# 计算顺序

                    for(int i = 0; i < Data.n_calSeq; i++)
                    {
                        nextLine = sR1.ReadLine();
                        string[] tmp = nextLine.Split(',');
                        if (tmp.Length > 1)
                        {
                            Data.calSeq[i].part_name = int.TryParse(tmp[0], out int partNameResult) ? partNameResult : 0;
                        }

                        if (tmp.Length > 2)
                        {
                            Data.calSeq[i].calculate_type = int.TryParse(tmp[1], out int calculateTypeResult) ? calculateTypeResult : 0;
                        }

                        if (tmp.Length > 3)
                        {
                            Data.calSeq[i].cal_i = int.TryParse(tmp[2], out int calIResult) ? calIResult : 0;
                        }

                        if (tmp.Length > 4)
                        {
                            Data.calSeq[i].cal_j = int.TryParse(tmp[3], out int calJResult) ? calJResult : 0;
                        }
                    }

                    //-------------------------自动测试------------------------//
                    nextLine = sR1.ReadLine(); //# 自动测试
                    nextLine = sR1.ReadLine(); //# 自动测试
                    nextLine = sR1.ReadLine(); //# 自动测试
                    nextLine = sR1.ReadLine(); //# 自动测试
                    nextLine = sR1.ReadLine();
                    {
                        string[] tmp = nextLine.Split(',');
                        Data.autoTest.n_line = int.Parse(tmp[0] == "" ? "0" : tmp[0]);
                        Data.autoTest.n_node = int.Parse(tmp[1] == "" ? "0" : tmp[1]);
                    }
                    Data.autoTest.line=new double[Data.autoTest.n_line][];
                    Data.autoTest.node = new double[Data.autoTest.n_node][];
                    nextLine = sR1.ReadLine();
                    for(int i=0;i< Data.autoTest.n_line; i++)
                    {
                        nextLine = sR1.ReadLine();
                        string[] tmp = nextLine.Split(',');
                        Data.autoTest.line[i] = new double[tmp.Length];
                        for (int j = 0; j < tmp.Length; j++)
                        {
                            Data.autoTest.line[i][j] = double.Parse(tmp[j] == "" ? "0" : tmp[j]);
                        }
                    }
                    nextLine = sR1.ReadLine();
                    for (int i = 0; i < Data.autoTest.n_node; i++)
                    {
                        nextLine = sR1.ReadLine();
                        string[] tmp = nextLine.Split(',');
                        Data.autoTest.node[i] = new double[tmp.Length];
                        for (int j = 0; j < tmp.Length; j++)
                        {
                            Data.autoTest.node[i][j] = double.Parse(tmp[j] == "" ? "0" : tmp[j]);
                        }
                    }
                    nextLine = sR1.ReadLine();
                    nextLine = sR1.ReadLine();
                    {
                        string[] tmp = nextLine.Split(',');
                        Data.autoTest.n_h2_node = int.Parse(tmp[0] == "" ? "0" : tmp[0]);
                        Data.autoTest.n_h2_line = int.Parse(tmp[1] == "" ? "0" : tmp[1]);
                    }

                    //-------------------------优化模型------------------------//
                    nextLine = sR1.ReadLine(); //# 优化模型
                    nextLine = sR1.ReadLine(); //# 优化模型
                    nextLine = sR1.ReadLine(); //# 优化模型
                    nextLine = sR1.ReadLine(); //# 优化模型
                    nextLine = sR1.ReadLine();
                    {
                        string[] tmp = nextLine.Split(',');
                        Data.optModel.n_line = int.Parse(tmp[0] == "" ? "0" : tmp[0]);
                        Data.optModel.n_node = int.Parse(tmp[1] == "" ? "0" : tmp[1]);
                    }
                    Data.optModel.line = new double[Data.optModel.n_line];
                    Data.optModel.node = new double[Data.optModel.n_node];
                    nextLine = sR1.ReadLine();
                    nextLine = sR1.ReadLine();
                    {
                        for(int i = 0; i< Data.optModel.n_line; i++)
                        {
                            string[] tmp = nextLine.Split(',');
                            Data.optModel.line[i] = double.Parse(tmp[i] == "" ? "0" : tmp[i]);
                        }
                    }
                    nextLine = sR1.ReadLine();
                    nextLine = sR1.ReadLine();
                    {
                        for (int i = 0; i < Data.optModel.n_node; i++)
                        {
                            string[] tmp = nextLine.Split(',');
                            Data.optModel.node[i] = double.Parse(tmp[i] == "" ? "0" : tmp[i]);
                        }
                    }
                    nextLine = sR1.ReadLine();
                    nextLine = sR1.ReadLine();
                    {
                        string[] tmp = nextLine.Split(',');
                        Data.optModel.initialValue = new double[tmp.Length];
                        for (int i = 0; i < Data.optModel.n_line + Data.optModel.n_node; i++)
                        {
                            Data.optModel.initialValue[i] = double.Parse(tmp[i] == "" ? "0" : tmp[i]);
                        }
                    }

                    sR1.Close();
                }
            }
        }

        public static void CSVOutputdataAutoTest(string fn)
        {
            Data.autoTest_result.auto_test_result = new double[500][];

            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(fn)))
            {
                using (StreamReader sR1 = new StreamReader(ms, Encoding.Default))
                {
                    string nextLine = "";
                    nextLine = sR1.ReadLine();
                    nextLine = sR1.ReadLine();

                    Data.autoTest_result.nrow = 0;
                    for (int i=0; nextLine != null; i++)
                    {           
                        string[] tmp = nextLine.Split(',');
                        Data.autoTest_result.nrow++;
                        Data.autoTest_result.auto_test_result[i] = new double[34];
                        for (int j = 0; j < 34; j++)
                        {
                            Data.autoTest_result.auto_test_result[i][j] = double.Parse(tmp[j] == "" ? "0" : tmp[j]);
                        }

                        nextLine = sR1.ReadLine();
                    }
                    sR1.Close();
                }
            }
        }

        public static void CSVOutputdataOptimResult(string fn)
        {
            Data.optModel_result.opt_model_result = new double[500][];

            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(fn)))
            {
                using (StreamReader sR1 = new StreamReader(ms, Encoding.Default))
                {
                    string nextLine = "";
                    nextLine = sR1.ReadLine();
                    nextLine = sR1.ReadLine();
                    Data.optModel_result.nrow = 0;
                    for (int i = 0; nextLine != null; i++)
                    {
                        string[] tmp = nextLine.Split(',');
                        Data.optModel_result.nrow++;
                        Data.optModel_result.opt_model_result[i] = new double[8];
                        for (int j = 0; j < 8; j++)
                        {
                            Data.optModel_result.opt_model_result[i][j] = double.Parse(tmp[j] == "" ? "0" : tmp[j]);
                        }

                        nextLine = sR1.ReadLine();
                    }
                    sR1.Close();
                }
            }
        }

        public static void GUI2CSV(string fn)
        {
            // output gui.input
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fn, false, Encoding.Default))
            {
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 控制参数,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("自动测试,计算最小温差,优化模型计算,,,,,,");
                file.WriteLine(Data.auto_test.ToString() + ',' + Data.cal_min_temp_diff.ToString() + ',' + Data.opt_model_cal.ToString() + ",,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 物性参数,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("气体常数,参考温度,参考压力,,,,,,");
                file.WriteLine(Data.gas_const.ToString() + ',' + Data.t_ref.ToString() + ',' + Data.p_ref.ToString() + ",,,,,,");
                file.WriteLine("材料数,,,,,,,,");
                file.WriteLine(Data.n_mat.ToString() + ",,,,,,,,");
                file.WriteLine("介质编号,名称,分子量,备注,,,,,");
                for (int i = 0; i < Data.n_mat; i++)
                {
                    file.WriteLine(Data.mat[i].id.ToString() + ',' + Data.mat[i].name.ToString() + ','
                                   + Data.mat[i].mol.ToString() + ',' + Data.mat[i].notes.ToString() + ",,,,,");
                }
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 路由参数,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("部件总数,流股总数,,,,,,,");
                file.WriteLine(Data.n_node.ToString() + ',' + Data.n_line.ToString() + ",,,,,,,");
                for (int i = 0; i < Data.n_node; i++)
                {
                    file.WriteLine("### 部件" + Data.node[i].id + ",,,,,,,,");
                    file.WriteLine("name,type,流股数,计算类型,非纯氢换热器,,计算流量,,");
                    file.WriteLine(Data.node[i].name.ToString() + ',' + Data.node[i].type.ToString() + ','
                                   + Data.node[i].n.ToString() + ',' + Data.node[i].cal_type.ToString() + ','
                                   + Data.node[i].n2_heat.ToString() + ",,,,");
                    file.WriteLine("输入流股,,,,,,,,");
                    string tmp = "";
                    string tmp2 = "";
                    for (int j = 0; j < Data.node[i].n; j++)
                    {
                        tmp = tmp + Data.node[i].i[j].ToString() + ",";
                        tmp2 = tmp2 + Data.node[i].o[j].ToString() + ",";
                    }
                    file.WriteLine(tmp+ ",,,,,");
                    file.WriteLine("输出流股,,,,,,,,");
                    file.WriteLine(tmp2+ ",,,,,");
                }
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 流股初值,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("流股,名称,温度,压力,流量,仲氢浓度,液氮比例,工质,纯氢");
                for (int i = 0; i < Data.n_line; i++)
                {
                    file.WriteLine(Data.line[i].ip.ToString() + ',' + Data.line[i].name + ','
                                   + Data.line[i].t.ToString() + ','
                                   + Data.line[i].p.ToString() + ',' + Data.line[i].m.ToString() + ','
                                   + Data.line[i].para.ToString() + ',' + Data.line[i].n2.ToString() + ','
                                   + Data.line[i].mat.ToString() + ',' + Data.line[i].h2_type.ToString() );
                }
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 设备初值,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("设备,eff,cal_i,cal_j,膨胀机方向,设备名称,,,");
                for (int i = 0; i < Data.n_node; i++)
                {
                    file.WriteLine(Data.nodepara[i].ip.ToString() + ',' + Data.nodepara[i].eff.ToString() + ','
                                   + Data.nodepara[i].cal_i.ToString() + ',' + Data.nodepara[i].cal_j.ToString() + ','
                                   + Data.nodepara[i].direction.ToString() + ',' + Data.nodepara[i].name + ",,,");
                }
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 计算顺序,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("计算个数,,,,,,,,");
                file.WriteLine(Data.n_calSeq.ToString() + ",,,,,,,,");
                file.WriteLine("部件名称,计算类型,cal_i,cal_j,,,,,");
                for (int i = 0; i < Data.n_calSeq; i++)
                {
                    string partName = Data.calSeq[i].part_name != -1 ? Data.calSeq[i].part_name.ToString() : "";
                    string calculateType = Data.calSeq[i].calculate_type != -1 ? Data.calSeq[i].calculate_type.ToString() : "";
                    string calI = Data.calSeq[i].cal_i != -1 ? Data.calSeq[i].cal_i.ToString() : "";
                    string calJ = Data.calSeq[i].cal_j != -1 ? Data.calSeq[i].cal_j.ToString() : "";
                    file.WriteLine(partName + ',' + calculateType + ',' + calI + ',' + calJ + ",,,,");
                }
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 自动测试,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("计算流股参数个数,计算部件参数个数,,,,,,,");
                file.WriteLine(Data.autoTest.n_line.ToString() + ',' + Data.autoTest.n_node.ToString() + ",,,,,,,");
                file.WriteLine("流股,起始温度,结束温度,计算点数,,,,");
                for (int i = 0; i < Data.autoTest.n_line; i++)
                {
                    file.Write(Data.autoTest.line[i][0].ToString() + ',');
                    for (int j = 1; j < 4; j++)
                    {
                        file.Write(Data.autoTest.line[i][j].ToString() + ',');
                    }
                    file.WriteLine();
                }
                file.WriteLine("部件,起始效率,结束效率,计算点数,,,,");
                for (int i = 0; i < Data.autoTest.n_node; i++)
                {
                    file.Write(Data.autoTest.node[i][0].ToString() + ',');
                    for (int j = 1; j < 4; j++)
                    {
                        file.Write(Data.autoTest.node[i][j].ToString() + ',');
                    }
                    file.WriteLine();
                }
                file.WriteLine("氢流量部件,氢流量流股,,,,,,,");
                file.WriteLine(Data.autoTest.n_h2_node.ToString() + ',' + Data.autoTest.n_h2_line.ToString() + ",,,,,,,");

                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("# 优化模型,,,,,,,,");
                file.WriteLine("###########################,,,,,,,,");
                file.WriteLine("计算流股参数个数,计算部件参数个数,,,,,,,");
                file.WriteLine(Data.optModel.n_line.ToString() + ',' + Data.optModel.n_node.ToString() + ",,,,,,,");
                file.WriteLine("流股,,,,");
                for (int i = 0; i < Data.optModel.n_line; i++)
                {
                    file.Write(Data.optModel.line[i].ToString() + ',');
                }
                file.WriteLine();
                file.WriteLine("部件,,,,");
                for (int i = 0; i < Data.optModel.n_node; i++)
                {
                    file.Write(Data.optModel.node[i].ToString() + ',');
                }
                file.WriteLine();
                file.WriteLine("初值,,,,");
                for (int i = 0; i < Data.optModel.n_line + Data.optModel.n_node; i++)
                {
                    file.Write(Data.optModel.initialValue[i].ToString() + ',');
                }
                file.WriteLine();

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
