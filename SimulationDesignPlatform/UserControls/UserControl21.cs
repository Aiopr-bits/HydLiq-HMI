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
    public partial class UserControl21 : UserControl
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public UserControl21()
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

        private void UserControl21_Resize(object sender, EventArgs e)
        {
            ReWinformLayout();
        }

        private void GetDatabase()
        {
            DataTable dataTable01 = new DataTable();
            dataTable01.Columns.Add("icase");
            dataTable01.Columns.Add("T_1");
            dataTable01.Columns.Add("T_2");
            dataTable01.Columns.Add("T_3");
            dataTable01.Columns.Add("Eff_1");
            dataTable01.Columns.Add("Eff_2");
            dataTable01.Columns.Add("W_comp_1");
            dataTable01.Columns.Add("W_exp_1");
            dataTable01.Columns.Add("W_exp_2");
            dataTable01.Columns.Add("W_exp_3");
            dataTable01.Columns.Add("W_exp_4");
            dataTable01.Columns.Add("dtMin_1");
            dataTable01.Columns.Add("dtMin_2");
            dataTable01.Columns.Add("dtMin_3");
            dataTable01.Columns.Add("dtMin_4");
            dataTable01.Columns.Add("dtMin_5");
            dataTable01.Columns.Add("dtMin_6");
            dataTable01.Columns.Add("dtMin_7");
            dataTable01.Columns.Add("dtMin_8");
            dataTable01.Columns.Add("dtMin_9");
            dataTable01.Columns.Add("dtMin_10");
            dataTable01.Columns.Add("dtMin_11");
            dataTable01.Columns.Add("dtAve_1");
            dataTable01.Columns.Add("dtAve_2");
            dataTable01.Columns.Add("dtAve_3");
            dataTable01.Columns.Add("dtAve_4");
            dataTable01.Columns.Add("dtAve_5");
            dataTable01.Columns.Add("dtAve_6");
            dataTable01.Columns.Add("dtAve_7");
            dataTable01.Columns.Add("dtAve_8");
            dataTable01.Columns.Add("dtAve_9");
            dataTable01.Columns.Add("dtAve_10");
            dataTable01.Columns.Add("dtAve_11");
            dataTable01.Columns.Add("SEC");
            for(int i = 0; i < Data.autoTest_result.nrow; i++)
            {
                dataTable01.Rows.Add(
                    Data.autoTest_result.auto_test_result[i][0],
                    Data.autoTest_result.auto_test_result[i][1],
                    Data.autoTest_result.auto_test_result[i][2],
                    Data.autoTest_result.auto_test_result[i][3],
                    Data.autoTest_result.auto_test_result[i][4],
                    Data.autoTest_result.auto_test_result[i][5],
                    Data.autoTest_result.auto_test_result[i][6],
                    Data.autoTest_result.auto_test_result[i][7],
                    Data.autoTest_result.auto_test_result[i][8],
                    Data.autoTest_result.auto_test_result[i][9],
                    Data.autoTest_result.auto_test_result[i][10],
                    Data.autoTest_result.auto_test_result[i][11],
                    Data.autoTest_result.auto_test_result[i][12],
                    Data.autoTest_result.auto_test_result[i][13],
                    Data.autoTest_result.auto_test_result[i][14],
                    Data.autoTest_result.auto_test_result[i][15],
                    Data.autoTest_result.auto_test_result[i][16],
                    Data.autoTest_result.auto_test_result[i][17],
                    Data.autoTest_result.auto_test_result[i][18],
                    Data.autoTest_result.auto_test_result[i][19],
                    Data.autoTest_result.auto_test_result[i][20],
                    Data.autoTest_result.auto_test_result[i][21],
                    Data.autoTest_result.auto_test_result[i][22],
                    Data.autoTest_result.auto_test_result[i][23],
                    Data.autoTest_result.auto_test_result[i][24],
                    Data.autoTest_result.auto_test_result[i][25],
                    Data.autoTest_result.auto_test_result[i][26],
                    Data.autoTest_result.auto_test_result[i][27],
                    Data.autoTest_result.auto_test_result[i][28],
                    Data.autoTest_result.auto_test_result[i][29],
                    Data.autoTest_result.auto_test_result[i][30],
                    Data.autoTest_result.auto_test_result[i][31],
                    Data.autoTest_result.auto_test_result[i][32],
                    Data.autoTest_result.auto_test_result[i][33]);
            }
            dataGridView1.DataSource = dataTable01;
        }
    }
}
