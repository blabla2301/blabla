﻿namespace QuanLyGara.GUI
{
    partial class frmThongKe_KH
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXong = new System.Windows.Forms.Button();
            this.cmbTK = new System.Windows.Forms.ComboBox();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInDanhSach = new System.Windows.Forms.Button();
            this.lsvDanhSach = new System.Windows.Forms.ListView();
            this.colMaNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoQD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLyDo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHinhThuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThoiGian = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXong);
            this.groupBox1.Controls.Add(this.cmbTK);
            this.groupBox1.Controls.Add(this.txtTK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1083, 58);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnXong
            // 
            this.btnXong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXong.Location = new System.Drawing.Point(934, 12);
            this.btnXong.Name = "btnXong";
            this.btnXong.Size = new System.Drawing.Size(81, 33);
            this.btnXong.TabIndex = 4;
            this.btnXong.Text = "Xong";
            this.btnXong.UseVisualStyleBackColor = true;
            this.btnXong.Click += new System.EventHandler(this.btnXong_Click);
            // 
            // cmbTK
            // 
            this.cmbTK.FormattingEnabled = true;
            this.cmbTK.Items.AddRange(new object[] {
            "Mã khách hàng",
            "Họ tên",
            "Biển số xe"});
            this.cmbTK.Location = new System.Drawing.Point(141, 19);
            this.cmbTK.Name = "cmbTK";
            this.cmbTK.Size = new System.Drawing.Size(121, 21);
            this.cmbTK.TabIndex = 3;
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(266, 17);
            this.txtTK.Multiline = true;
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(650, 26);
            this.txtTK.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê theo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lsvDanhSach);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(1083, 490);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInDanhSach);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 436);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0, 0, 30, 3);
            this.groupBox3.Size = new System.Drawing.Size(1077, 51);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // btnInDanhSach
            // 
            this.btnInDanhSach.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnInDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInDanhSach.Image = global::QuanLyGara.Properties.Resources.if_printer_16414;
            this.btnInDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDanhSach.Location = new System.Drawing.Point(929, 15);
            this.btnInDanhSach.Name = "btnInDanhSach";
            this.btnInDanhSach.Padding = new System.Windows.Forms.Padding(3);
            this.btnInDanhSach.Size = new System.Drawing.Size(118, 33);
            this.btnInDanhSach.TabIndex = 0;
            this.btnInDanhSach.Text = "In danh sách";
            this.btnInDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDanhSach.UseVisualStyleBackColor = true;
            this.btnInDanhSach.Click += new System.EventHandler(this.btnInDanhSach_Click);
            // 
            // lsvDanhSach
            // 
            this.lsvDanhSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaNV,
            this.colTenNV,
            this.colSoQD,
            this.colLyDo,
            this.colHinhThuc,
            this.colThoiGian,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDanhSach.FullRowSelect = true;
            this.lsvDanhSach.GridLines = true;
            this.lsvDanhSach.Location = new System.Drawing.Point(3, 25);
            this.lsvDanhSach.Name = "lsvDanhSach";
            this.lsvDanhSach.Size = new System.Drawing.Size(1077, 462);
            this.lsvDanhSach.TabIndex = 0;
            this.lsvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lsvDanhSach.View = System.Windows.Forms.View.Details;
            // 
            // colMaNV
            // 
            this.colMaNV.Text = "Mã khách hàng";
            this.colMaNV.Width = 106;
            // 
            // colTenNV
            // 
            this.colTenNV.Text = "Họ tên";
            this.colTenNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTenNV.Width = 119;
            // 
            // colSoQD
            // 
            this.colSoQD.Text = "Biển số xe";
            this.colSoQD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSoQD.Width = 122;
            // 
            // colLyDo
            // 
            this.colLyDo.Text = "Hãng xe";
            this.colLyDo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLyDo.Width = 127;
            // 
            // colHinhThuc
            // 
            this.colHinhThuc.Text = "Đời xe";
            this.colHinhThuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHinhThuc.Width = 107;
            // 
            // colThoiGian
            // 
            this.colThoiGian.Text = "Số khung";
            this.colThoiGian.Width = 97;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số máy";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số điện thoại";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 103;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Email";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Địa chỉ";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 101;
            // 
            // frmThongKe_KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 548);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThongKe_KH";
            this.Text = "Thống kê khách hàng";
            this.Load += new System.EventHandler(this.frmThongKe_KH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXong;
        private System.Windows.Forms.ComboBox cmbTK;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInDanhSach;
        private System.Windows.Forms.ListView lsvDanhSach;
        private System.Windows.Forms.ColumnHeader colMaNV;
        private System.Windows.Forms.ColumnHeader colTenNV;
        private System.Windows.Forms.ColumnHeader colSoQD;
        private System.Windows.Forms.ColumnHeader colLyDo;
        private System.Windows.Forms.ColumnHeader colHinhThuc;
        private System.Windows.Forms.ColumnHeader colThoiGian;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}