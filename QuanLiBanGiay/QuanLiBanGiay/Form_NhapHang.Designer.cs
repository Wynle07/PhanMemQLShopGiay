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
            this.components = new System.ComponentModel.Container();
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
            this.cboMauSac = new System.Windows.Forms.ComboBox();
            this.cboKichCo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInPN = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.dgvCTPN = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMaSP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.grpPhieuNhap.SuspendLayout();
            this.grpCTPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPN)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
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
            this.grpPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPhieuNhap.Location = new System.Drawing.Point(38, 24);
            this.grpPhieuNhap.Name = "grpPhieuNhap";
            this.grpPhieuNhap.Size = new System.Drawing.Size(1519, 145);
            this.grpPhieuNhap.TabIndex = 0;
            this.grpPhieuNhap.TabStop = false;
            this.grpPhieuNhap.Text = "Phiếu nhập";
            this.grpPhieuNhap.Enter += new System.EventHandler(this.grpPhieuNhap_Enter);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(1057, 34);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(124, 33);
            this.txtMaNV.TabIndex = 96;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(980, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 23);
            this.label9.TabIndex = 95;
            this.label9.Text = "Mã NV";
            // 
            // btnTaoPN
            // 
            this.btnTaoPN.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTaoPN.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTaoPN.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoPN.Image")));
            this.btnTaoPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPN.Location = new System.Drawing.Point(557, 84);
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
            this.btnLuuPN.Location = new System.Drawing.Point(767, 84);
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
            this.cboNCC.Location = new System.Drawing.Point(390, 34);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new System.Drawing.Size(262, 33);
            this.cboNCC.TabIndex = 7;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(1303, 34);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(200, 33);
            this.txtTongTien.TabIndex = 6;
            this.txtTongTien.Text = "0";
            // 
            // txtNgayNhap
            // 
            this.txtNgayNhap.Location = new System.Drawing.Point(786, 34);
            this.txtNgayNhap.Name = "txtNgayNhap";
            this.txtNgayNhap.ReadOnly = true;
            this.txtNgayNhap.Size = new System.Drawing.Size(167, 33);
            this.txtNgayNhap.TabIndex = 5;
            this.txtNgayNhap.TextChanged += new System.EventHandler(this.txtNgayNhap_TextChanged);
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(98, 34);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(133, 33);
            this.txtMaPhieuNhap.TabIndex = 4;
            this.txtMaPhieuNhap.TextChanged += new System.EventHandler(this.txtMaPhieuNhap_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1207, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(681, 39);
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
            this.label2.Location = new System.Drawing.Point(253, 39);
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
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã PN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // grpCTPhieuNhap
            // 
            this.grpCTPhieuNhap.Controls.Add(this.cboMauSac);
            this.grpCTPhieuNhap.Controls.Add(this.cboKichCo);
            this.grpCTPhieuNhap.Controls.Add(this.label11);
            this.grpCTPhieuNhap.Controls.Add(this.label10);
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
            this.grpCTPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCTPhieuNhap.Location = new System.Drawing.Point(38, 477);
            this.grpCTPhieuNhap.Name = "grpCTPhieuNhap";
            this.grpCTPhieuNhap.Size = new System.Drawing.Size(1519, 389);
            this.grpCTPhieuNhap.TabIndex = 1;
            this.grpCTPhieuNhap.TabStop = false;
            this.grpCTPhieuNhap.Text = "Chi tiết phiếu nhập";
            // 
            // cboMauSac
            // 
            this.cboMauSac.FormattingEnabled = true;
            this.cboMauSac.Location = new System.Drawing.Point(617, 93);
            this.cboMauSac.Name = "cboMauSac";
            this.cboMauSac.Size = new System.Drawing.Size(169, 33);
            this.cboMauSac.TabIndex = 110;
            // 
            // cboKichCo
            // 
            this.cboKichCo.FormattingEnabled = true;
            this.cboKichCo.Location = new System.Drawing.Point(617, 41);
            this.cboKichCo.Name = "cboKichCo";
            this.cboKichCo.Size = new System.Drawing.Size(169, 33);
            this.cboKichCo.TabIndex = 109;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(521, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 23);
            this.label11.TabIndex = 108;
            this.label11.Text = "Màu sắc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(521, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 23);
            this.label10.TabIndex = 107;
            this.label10.Text = "Kích cỡ";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(984, 93);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(140, 33);
            this.txtThanhTien.TabIndex = 106;
            this.txtThanhTien.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(838, 95);
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
            this.btnInPN.Location = new System.Drawing.Point(1204, 84);
            this.btnInPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInPN.Name = "btnInPN";
            this.btnInPN.Size = new System.Drawing.Size(204, 50);
            this.btnInPN.TabIndex = 95;
            this.btnInPN.Text = "In phiếu nhập";
            this.btnInPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInPN.UseVisualStyleBackColor = false;
            this.btnInPN.Click += new System.EventHandler(this.btnInPN_Click);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThemSP.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemSP.Location = new System.Drawing.Point(1204, 27);
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
            this.dgvCTPN.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCTPN.Enabled = false;
            this.dgvCTPN.Location = new System.Drawing.Point(27, 142);
            this.dgvCTPN.Name = "dgvCTPN";
            this.dgvCTPN.RowHeadersWidth = 62;
            this.dgvCTPN.RowTemplate.Height = 28;
            this.dgvCTPN.Size = new System.Drawing.Size(1419, 224);
            this.dgvCTPN.TabIndex = 103;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 36);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(115, 32);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(242, 91);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(221, 33);
            this.txtSoLuong.TabIndex = 102;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(984, 45);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(140, 33);
            this.txtDonGia.TabIndex = 101;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(96, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 23);
            this.label8.TabIndex = 100;
            this.label8.Text = "Số lượng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(838, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 99;
            this.label7.Text = "Đơn giá";
            // 
            // cboMaSP
            // 
            this.cboMaSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSP.FormattingEnabled = true;
            this.cboMaSP.Location = new System.Drawing.Point(242, 41);
            this.cboMaSP.Name = "cboMaSP";
            this.cboMaSP.Size = new System.Drawing.Size(221, 33);
            this.cboMaSP.TabIndex = 98;
            this.cboMaSP.SelectedIndexChanged += new System.EventHandler(this.cboMaSP_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(94, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 23);
            this.label6.TabIndex = 97;
            this.label6.Text = "Tên sản phẩm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPhieuNhap);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1519, 286);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu nhập";
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(27, 32);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.RowHeadersWidth = 62;
            this.dgvPhieuNhap.RowTemplate.Height = 28;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(1419, 248);
            this.dgvPhieuNhap.TabIndex = 0;
            // 
            // Form__NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1613, 866);
            this.Controls.Add(this.groupBox1);
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
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
        private System.Windows.Forms.ComboBox cboMauSac;
        private System.Windows.Forms.ComboBox cboKichCo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
    }
}