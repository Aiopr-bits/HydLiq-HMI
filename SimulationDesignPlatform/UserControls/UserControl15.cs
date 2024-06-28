using Microsoft.VisualBasic.FileIO;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulationDesignPlatform.UserControls
{
    public partial class UserControl15 : UserControl
    {
        private readonly float x;//定义当前窗体的宽度
        private readonly float y;//定义当前窗体的高度
        public UserControl15()
        {
            InitializeComponent();
            Show_Chart();
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

        private void Show_Chart()
        {
            string filepath = Path.Combine(Data.exePath, Data.case_name, "output.data", "case_0.csv");
            if (File.Exists(filepath)) // 添加一重文件路径检测（20240311，M修改）
            {
                using (TextFieldParser parser = new TextFieldParser(filepath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        List<string> row = new List<string>(fields);
                        Data.data.Add(row);
                    }
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (Data.data.Count > 0)
                {
                    dataGridView1.ColumnCount = Data.data[0].Count;
                    for (int k = 0; k < Data.data[0].Count; k++)
                    {
                        dataGridView1.Columns[k].Name = Data.data[0][k];
                    }
                }

                for (int i = 1; i < Data.data.Count; i++)
                {
                    dataGridView1.Rows.Add(Data.data[i].ToArray());
                }
            }
        }

        private void UserControl15_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
    }
}
