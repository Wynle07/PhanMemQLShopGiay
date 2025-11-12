namespace QuanLiBanGiay
{
    partial class Form__NhapHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form__NhapHang));
            this.grpPhieuNhap = new System.Windows.Forms.GroupBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTaoPN = new System.Windows.Forms.Button();
            this.btnLuuPN = new System.Windows.Forms.Button();
            this.cboNCC = new System.Windows.Forms.ComboBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtNgayNhap = new System.Windows.Forms.TextBox();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCTPhieuNhap = new System.Windows.Forms.GroupBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInPN = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.dgvCTPN = new System.Windows.Forms.DataGridView();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMaSP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpPhieuNhap.SuspendLayout();
            this.grpCTPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPN)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPhieuNhap
            // 
            this.grpPhieuNhap.Controls.Add(this.txtMaNV);
            this.grpPhieuNhap.Controls.Add(this.label9);
            this.grpPhieuNhap.Controls.Add(this.btnTaoPN);
            this.grpPhieuNhap.Controls.Add(this.btnLuuPN);
            this.grpPhieuNhap.Controls.Add(this.cboNCC);
            this.grpPhieuNhap.Controls.Add(this.txtTongTien);
            this.grpPhieuNhap.Controls.Add(this.txtNgayNhap);
            this.grpPhieuNhap.Controls.Add(this.txtMaPhieuNhap);
            this.grpPhieuNhap.Controls.Add(this.label4);
            this.grpPhieuNhap.Controls.Add(this.label3);
            this.grpPhieuNhap.Controls.Add(this.label2);
            this.grpPhieuNhap.Controls.Add(this.label1);
            this.grpPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPhieuNhap.Location = new System.Drawing.Point(38, 24);
            this.grpPhieuNhap.Name = "grpPhieuNhap";
            this.grpPhieuNhap.Size = new System.Drawing.Size(1243, 203);
            this.grpPhieuNhap.TabIndex = 0;
            this.grpPhieuNhap.TabStop = false;
            this.grpPhieuNhap.Text = "Phiếu nhập";
            this.grpPhieuNhap.Enter += new System.EventHandler(this.grpPhieuNhap_Enter);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(179, 91);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(205, 30);
            this.txtMaNV.TabIndex = 96;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 23);
            this.label9.TabIndex = 95;
            this.label9.Text = "Mã nhân viên";
            // 
            // btnTaoPN
            // 
            this.btnTaoPN.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTaoPN.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTaoPN.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoPN.Image")));
            this.btnTaoPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPN.Location = new System.Drawing.Point(371, 137);
            this.btnTaoPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaoPN.Name = "btnTaoPN";
            this.btnTaoPN.Size = new System.Drawing.Size(192, 50);
            this.btnTaoPN.TabIndex = 94;
            this.btnTaoPN.Text = "Tạo phiếu nhập";
            this.btnTaoPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoPN.UseVisualStyleBackColor = false;
            this.btnTaoPN.Click += new System.EventHandler(this.btnTaoPN_Click);
            // 
            // btnLuuPN
            // 
            this.btnLuuPN.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLuuPN.Enabled = false;
            this.btnLuuPN.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLuuPN.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuPN.Image")));
            this.btnLuuPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuPN.Location = new System.Drawing.Point(579, 137);
            this.btnLuuPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuuPN.Name = "btnLuuPN";
            this.btnLuuPN.Size = new System.Drawing.Size(201, 50);
            this.btnLuuPN.TabIndex = 93;
            this.btnLuuPN.Text = "Lưu phiếu nhập";
            this.btnLuuPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuPN.UseVisualStyleBackColor = false;
            this.btnLuuPN.Click += new System.EventHandler(this.btnLuuPN_Click);
            // 
            // cboNCC
            // 
            this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Location = new System.Drawing.Point(529, 37);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new System.Drawing.Size(262, 30);
            this.cboNCC.TabIndex = 7;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(518, 93);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(262, 30);
            this.txtTongTien.TabIndex = 6;
            this.txtTongTien.Text = "0";
            // 
            // txtNgayNhap
            // 
            this.txtNgayNhap.Location = new System.Drawing.Point(914, 37);
            this.txtNgayNhap.Name = "txtNgayNhap";
            this.txtNgayNhap.ReadOnly = true;
            this.txtNgayNhap.Size = new System.Drawing.Size(167, 30);
            this.txtNgayNhap.TabIndex = 5;
            this.txtNgayNhap.TextChanged += new System.EventHandler(this.txtNgayNhap_TextChanged);
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(179, 37);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(205, 30);
            this.txtMaPhieuNhap.TabIndex = 4;
            this.txtMaPhieuNhap.TextChanged += new System.EventHandler(this.txtMaPhieuNhap_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(809, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày nhập";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(401, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhà cung cấp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu nhập";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // grpCTPhieuNhap
            // 
            this.grpCTPhieuNhap.Controls.Add(this.txtThanhTien);
            this.grpCTPhieuNhap.Controls.Add(this.label5);
            this.grpCTPhieuNhap.Controls.Add(this.btnInPN);
            this.grpCTPhieuNhap.Controls.Add(this.btnThemSP);
            this.grpCTPhieuNhap.Controls.Add(this.dgvCTPN);
            this.grpCTPhieuNhap.Controls.Add(this.txtSoLuong);
            this.grpCTPhieuNhap.Controls.Add(this.txtDonGia);
            this.grpCTPhieuNhap.Controls.Add(this.label8);
            this.grpCTPhieuNhap.Controls.Add(this.label7);
            this.grpCTPhieuNhap.Controls.Add(this.cboMaSP);
            this.grpCTPhieuNhap.Controls.Add(this.label6);
            this.grpCTPhieuNhap.Enabled = false;
            this.grpCTPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCTPhieuNhap.Location = new System.Drawing.Point(38, 233);
            this.grpCTPhieuNhap.Name = "grpCTPhieuNhap";
            this.grpCTPhieuNhap.Size = new System.Drawing.Size(1243, 509);
            this.grpCTPhieuNhap.TabIndex = 1;
            this.grpCTPhieuNhap.TabStop = false;
            this.grpCTPhieuNhap.Text = "Chi tiết phiếu nhập";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(700, 90);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(221, 30);
            this.txtThanhTien.TabIndex = 106;
            this.txtThanhTien.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(554, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 105;
            this.label5.Text = "Thành tiền";
            // 
            // btnInPN
            // 
            this.btnInPN.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnInPN.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInPN.Image = ((System.Drawing.Image)(resources.GetObject("btnInPN.Image")));
            this.btnInPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInPN.Location = new System.Drawing.Point(579, 452);
            this.btnInPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInPN.Name = "btnInPN";
            this.btnInPN.Size = new System.Drawing.Size(184, 50);
            this.btnInPN.TabIndex = 95;
            this.btnInPN.Text = "In phiếu nhập";
            this.btnInPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInPN.UseVisualStyleBackColor = false;
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThemSP.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemSP.Location = new System.Drawing.Point(359, 452);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(204, 50);
            this.btnThemSP.TabIndex = 104;
            this.btnThemSP.Text = "Thêm sản phẩm";
            this.btnThemSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // dgvCTPN
            // 
            this.dgvCTPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPN.Enabled = false;
            this.dgvCTPN.Location = new System.Drawing.Point(52, 142);
            this.dgvCTPN.Name = "dgvCTPN";
            this.dgvCTPN.RowHeadersWidth = 62;
            this.dgvCTPN.RowTemplate.Height = 28;
            this.dgvCTPN.Size = new System.Drawing.Size(1114, 289);
            this.dgvCTPN.TabIndex = 103;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(284, 90);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(221, 30);
            this.txtSoLuong.TabIndex = 102;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(700, 42);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(221, 30);
            this.txtDonGia.TabIndex = 101;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(138, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 23);
            this.label8.TabIndex = 100;
            this.label8.Text = "Số lượng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(554, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 99;
            this.label7.Text = "Đơn giá";
            // 
            // cboMaSP
            // 
            this.cboMaSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSP.FormattingEnabled = true;
            this.cboMaSP.Location = new System.Drawing.Point(284, 40);
            this.cboMaSP.Name = "cboMaSP";
            this.cboMaSP.Size = new System.Drawing.Size(221, 30);
            this.cboMaSP.TabIndex = 98;
            this.cboMaSP.SelectedIndexChanged += new System.EventHandler(this.cboMaSP_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 23);
            this.label6.TabIndex = 97;
            this.label6.Text = "Mã sản phẩm";
            // 
            // Form__NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 754);
            this.Controls.Add(this.grpCTPhieuNhap);
            this.Controls.Add(this.grpPhieuNhap);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form__NhapHang";
            this.Text = "Form__NhapHang";
            this.Load += new System.EventHandler(this.Form__NhapHang_Load);
            this.grpPhieuNhap.ResumeLayout(false);
            this.grpPhieuNhap.PerformLayout();
            this.grpCTPhieuNhap.ResumeLayout(false);
            this.grpCTPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpPhieuNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCTPhieuNhap;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtNgayNhap;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTaoPN;
        private System.Windows.Forms.Button btnLuuPN;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMaSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInPN;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.DataGridView dgvCTPN;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label9;
    }
}