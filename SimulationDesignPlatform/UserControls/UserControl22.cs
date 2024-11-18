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
    public partial class UserControl22 : UserControl
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public UserControl22()
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

        private void UserControl22_Resize(object sender, EventArgs e)
        {
            ReWinformLayout();
        }

        private void GetDatabase()
        {
            DataTable dataTable01 = new DataTable();
            dataTable01.Columns.Add("迭代数");
            dataTable01.Columns.Add("变量1");
            dataTable01.Columns.Add("变量2");
            dataTable01.Columns.Add("变量3");
            dataTable01.Columns.Add("变量4");
            dataTable01.Columns.Add("变量5");
            dataTable01.Columns.Add("能耗");
            dataTable01.Columns.Add("误差");

            for (int i = 0; i < Data.optModel_result.nrow; i++)
            {
                dataTable01.Rows.Add(
                    Data.optModel_result.opt_model_result[i][0],
                    Data.optModel_result.opt_model_result[i][1],
                    Data.optModel_result.opt_model_result[i][2],
                    Data.optModel_result.opt_model_result[i][3],
                    Data.optModel_result.opt_model_result[i][4],
                    Data.optModel_result.opt_model_result[i][5],
                    Data.optModel_result.opt_model_result[i][6],
                    Data.optModel_result.opt_model_result[i][7]
                    );

            }
            dataGridView1.DataSource = dataTable01;
        }
    }
}
