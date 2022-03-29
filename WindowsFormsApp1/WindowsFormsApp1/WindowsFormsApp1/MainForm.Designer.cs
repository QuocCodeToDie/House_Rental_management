
using System;

namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridViewKH = new System.Windows.Forms.DataGridView();
            this.khachHang = new System.Windows.Forms.Button();
            this.nha = new System.Windows.Forms.Button();
            this.chiNhanh = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chuNha = new System.Windows.Forms.Button();
            this.demoLoi = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.refresh_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listView1.ForeColor = System.Drawing.SystemColors.Menu;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 95);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(164, 411);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 76);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Ứng dụng quản lý nhà cho thuê";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewKH
            // 
            this.dataGridViewKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKH.Location = new System.Drawing.Point(217, 95);
            this.dataGridViewKH.Name = "dataGridViewKH";
            this.dataGridViewKH.Size = new System.Drawing.Size(554, 164);
            this.dataGridViewKH.TabIndex = 4;
            this.dataGridViewKH.Visible = false;
            this.dataGridViewKH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKH_CellContentClick);
            // 
            // khachHang
            // 
            this.khachHang.Location = new System.Drawing.Point(24, 111);
            this.khachHang.Name = "khachHang";
            this.khachHang.Size = new System.Drawing.Size(132, 47);
            this.khachHang.TabIndex = 5;
            this.khachHang.Text = "Khách Hàng";
            this.khachHang.UseVisualStyleBackColor = true;
            this.khachHang.Click += new System.EventHandler(this.khachHang_Click);
            // 
            // nha
            // 
            this.nha.Location = new System.Drawing.Point(24, 187);
            this.nha.Name = "nha";
            this.nha.Size = new System.Drawing.Size(132, 47);
            this.nha.TabIndex = 6;
            this.nha.Text = "Nhà đang cho thuê/bán";
            this.nha.UseVisualStyleBackColor = true;
            this.nha.Click += new System.EventHandler(this.nha_Click);
            // 
            // chiNhanh
            // 
            this.chiNhanh.Location = new System.Drawing.Point(24, 269);
            this.chiNhanh.Name = "chiNhanh";
            this.chiNhanh.Size = new System.Drawing.Size(132, 47);
            this.chiNhanh.TabIndex = 7;
            this.chiNhanh.Text = "Chi Nhánh";
            this.chiNhanh.UseVisualStyleBackColor = true;
            this.chiNhanh.Click += new System.EventHandler(this.chiNhanh_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(337, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(307, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(217, 329);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(554, 146);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(337, 296);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(307, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            // 
            // chuNha
            // 
            this.chuNha.Location = new System.Drawing.Point(24, 351);
            this.chuNha.Name = "chuNha";
            this.chuNha.Size = new System.Drawing.Size(132, 47);
            this.chuNha.TabIndex = 12;
            this.chuNha.Text = "Chủ Nhà";
            this.chuNha.UseVisualStyleBackColor = true;
            this.chuNha.Click += new System.EventHandler(this.chuNha_Click);
            // 
            // demoLoi
            // 
            this.demoLoi.Location = new System.Drawing.Point(24, 432);
            this.demoLoi.Name = "demoLoi";
            this.demoLoi.Size = new System.Drawing.Size(132, 47);
            this.demoLoi.TabIndex = 13;
            this.demoLoi.Text = "Demo Lỗi";
            this.demoLoi.UseVisualStyleBackColor = true;
            this.demoLoi.Click += new System.EventHandler(this.demoLoi_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(678, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 25);
            this.button3.TabIndex = 16;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 


            // button7
            // 
            this.button7.Location = new System.Drawing.Point(480, 265);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 25);
            this.button7.TabIndex = 20;
            this.button7.Text = "Thêm";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(678, 265);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(93, 25);
            this.button9.TabIndex = 22;
            this.button9.Text = "Sửa";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(480, 481);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 25);
            this.button10.TabIndex = 23;
            this.button10.Text = "Thêm";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 

            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(678, 265);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(93, 25);
            this.button15.TabIndex = 28;
            this.button15.Text = "Sửa";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(480, 481);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(93, 25);
            this.button16.TabIndex = 29;
            this.button16.Text = "Thêm";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(678, 481);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(93, 25);
            this.button18.TabIndex = 31;
            this.button18.Text = "Sửa";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(769, 10);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(75, 23);
            this.refresh_button.TabIndex = 32;
            this.refresh_button.Text = "Refresh";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 530);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.demoLoi);
            this.Controls.Add(this.chuNha);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.chiNhanh);
            this.Controls.Add(this.nha);
            this.Controls.Add(this.khachHang);
            this.Controls.Add(this.dataGridViewKH);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridViewKH;
        private System.Windows.Forms.Button khachHang;
        private System.Windows.Forms.Button nha;
        private System.Windows.Forms.Button chiNhanh;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button chuNha;
        private System.Windows.Forms.Button demoLoi;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button refresh_button;
    }
}