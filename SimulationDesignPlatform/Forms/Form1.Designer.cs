﻿namespace SimulationDesignPlatform.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cb = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SeaGreen;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.Color.Green;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1164, 62);
			this.panel1.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.SeaGreen;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(389, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(355, 50);
			this.label1.TabIndex = 1;
			this.label1.Text = "氢液化仿真计算平台";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.SeaGreen;
			this.label6.Location = new System.Drawing.Point(330, 294);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 35);
			this.label6.TabIndex = 15;
			this.label6.Text = "账号:";
			// 
			// cb
			// 
			this.cb.AutoSize = true;
			this.cb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cb.Location = new System.Drawing.Point(336, 478);
			this.cb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb.Name = "cb";
			this.cb.Size = new System.Drawing.Size(154, 31);
			this.cb.TabIndex = 14;
			this.cb.Text = "记住账号密码";
			this.cb.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button1.BackColor = System.Drawing.Color.SeaGreen;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(333, 542);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(422, 45);
			this.button1.TabIndex = 13;
			this.button1.Text = "立即登录";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(333, 419);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(423, 37);
			this.txtPassword.TabIndex = 11;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// txtName
			// 
			this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(333, 338);
			this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(423, 37);
			this.txtName.TabIndex = 12;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.SeaGreen;
			this.label4.Location = new System.Drawing.Point(330, 385);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 35);
			this.label4.TabIndex = 8;
			this.label4.Text = "密码:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.SeaGreen;
			this.label3.Location = new System.Drawing.Point(6, 688);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(537, 25);
			this.label3.TabIndex = 9;
			this.label3.Text = "Copyrights @ 2022.All rights Reserved By KeXin TianCheng";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SeaGreen;
			this.label2.Location = new System.Drawing.Point(471, 194);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 50);
			this.label2.TabIndex = 10;
			this.label2.Text = "欢迎使用";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1164, 743);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cb);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}