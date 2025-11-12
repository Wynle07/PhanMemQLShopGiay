namespace QuanLiBanGiay
{
    partial class Form_KhuyenMai
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
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtNgayBatDau = new System.Windows.Forms.TextBox();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.data_KM = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtNgayKetThuc = new System.Windows.Forms.TextBox();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.lblMaKM = new System.Windows.Forms.Label();
            this.lblThongTinSanPham = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgaybatdau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgayKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_KM)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(22, 202);
            this.txtGiamGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(290, 26);
            this.txtGiamGia.TabIndex = 82;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGia.Location = new System.Drawing.Point(19, 151);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(104, 27);
            this.lblGiamGia.TabIndex = 81;
            this.lblGiamGia.Text = "Giảm giá:";
            // 
            // txtNgayBatDau
            // 
            this.txtNgayBatDau.Location = new System.Drawing.Point(559, 109);
            this.txtNgayBatDau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNgayBatDau.Name = "txtNgayBatDau";
            this.txtNgayBatDau.Size = new System.Drawing.Size(230, 26);
            this.txtNgayBatDau.TabIndex = 77;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.data_KM);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpDanhSach.Location = new System.Drawing.Point(0, 362);
            this.grpDanhSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDanhSach.Size = new System.Drawing.Size(1276, 408);
            this.grpDanhSach.TabIndex = 76;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách khuyến mãi";
            // 
            // data_KM
            // 
            this.data_KM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_KM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.clTenKM,
            this.clNgaybatdau,
            this.clNgayKetThuc,
            this.clGiamGia});
            this.data_KM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.data_KM.Location = new System.Drawing.Point(3, 44);
            this.data_KM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.data_KM.Name = "data_KM";
            this.data_KM.RowHeadersWidth = 51;
            this.data_KM.RowTemplate.Height = 24;
            this.data_KM.Size = new System.Drawing.Size(1270, 360);
            this.data_KM.TabIndex = 0;
            this.data_KM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_KM_CellClick_1);
            this.data_KM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_KM_CellContentClick_1);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(802, 194);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 39);
            this.btnTimKiem.TabIndex = 75;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(441, 197);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(339, 31);
            this.txtTimKiem.TabIndex = 74;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(595, 308);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 45);
            this.btnReset.TabIndex = 73;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSua.Location = new System.Drawing.Point(207, 308);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 45);
            this.btnSua.TabIndex = 72;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Location = new System.Drawing.Point(19, 308);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 45);
            this.btnThem.TabIndex = 70;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // txtNgayKetThuc
            // 
            this.txtNgayKetThuc.Location = new System.Drawing.Point(876, 109);
            this.txtNgayKetThuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNgayKetThuc.Name = "txtNgayKetThuc";
            this.txtNgayKetThuc.Size = new System.Drawing.Size(251, 26);
            this.txtNgayKetThuc.TabIndex = 69;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(871, 55);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(153, 27);
            this.lblNgayKetThuc.TabIndex = 68;
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // lblTenKM
            // 
            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKM.Location = new System.Drawing.Point(213, 55);
            this.lblTenKM.Name = "lblTenKM";
            this.lblTenKM.Size = new System.Drawing.Size(99, 27);
            this.lblTenKM.TabIndex = 65;
            this.lblTenKM.Text = "Tên KM:";
            // 
            // txtMaKM
            // 
            this.txtMaKM.Location = new System.Drawing.Point(21, 109);
            this.txtMaKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.Size = new System.Drawing.Size(157, 26);
            this.txtMaKM.TabIndex = 64;
            // 
            // lblMaKM
            // 
            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKM.Location = new System.Drawing.Point(18, 55);
            this.lblMaKM.Name = "lblMaKM";
            this.lblMaKM.Size = new System.Drawing.Size(94, 27);
            this.lblMaKM.TabIndex = 63;
            this.lblMaKM.Text = "Mã KM:";
            // 
            // lblThongTinSanPham
            // 
            this.lblThongTinSanPham.AutoSize = true;
            this.lblThongTinSanPham.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinSanPham.Location = new System.Drawing.Point(2, 4);
            this.lblThongTinSanPham.Name = "lblThongTinSanPham";
            this.lblThongTinSanPham.Size = new System.Drawing.Size(141, 26);
            this.lblThongTinSanPham.TabIndex = 62;
            this.lblThongTinSanPham.Text = "Khuyến Mãi";
            this.lblThongTinSanPham.Click += new System.EventHandler(this.lblThongTinSanPham_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.Location = new System.Drawing.Point(396, 308);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 45);
            this.btnXoa.TabIndex = 71;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Location = new System.Drawing.Point(554, 55);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(146, 27);
            this.lblNgayBatDau.TabIndex = 67;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(207, 109);
            this.txtTenKM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(280, 26);
            this.txtTenKM.TabIndex = 83;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MAKM";
            this.Column1.HeaderText = "Mã KM";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // clTenKM
            // 
            this.clTenKM.DataPropertyName = "TENKM";
            this.clTenKM.HeaderText = "Tên KM";
            this.clTenKM.MinimumWidth = 6;
            this.clTenKM.Name = "clTenKM";
            this.clTenKM.Width = 200;
            // 
            // clNgaybatdau
            // 
            this.clNgaybatdau.DataPropertyName = "NGAYBATDAU";
            this.clNgaybatdau.HeaderText = "Ngày bắt đầu";
            this.clNgaybatdau.MinimumWidth = 6;
            this.clNgaybatdau.Name = "clNgaybatdau";
            this.clNgaybatdau.Width = 200;
            // 
            // clNgayKetThuc
            // 
            this.clNgayKetThuc.DataPropertyName = "NGAYKETTHUC";
            this.clNgayKetThuc.HeaderText = "Ngày kết thúc";
            this.clNgayKetThuc.MinimumWidth = 6;
            this.clNgayKetThuc.Name = "clNgayKetThuc";
            this.clNgayKetThuc.Width = 200;
            // 
            // clGiamGia
            // 
            this.clGiamGia.DataPropertyName = "GIAMGIA";
            this.clGiamGia.HeaderText = "Giảm giá";
            this.clGiamGia.MinimumWidth = 6;
            this.clGiamGia.Name = "clGiamGia";
            this.clGiamGia.Width = 200;
            // 
            // Form_KhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 770);
            this.Controls.Add(this.txtTenKM);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.lblGiamGia);
            this.Controls.Add(this.txtNgayBatDau);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNgayKetThuc);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.lblTenKM);
            this.Controls.Add(this.txtMaKM);
            this.Controls.Add(this.lblMaKM);
            this.Controls.Add(this.lblThongTinSanPham);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lblNgayBatDau);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_KhuyenMai";
            this.Text = "Form_KhuyenMai";
            this.Load += new System.EventHandler(this.Form_KhuyenMai_Load_1);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_KM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtNgayBatDau;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView data_KM;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtNgayKetThuc;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.Label lblMaKM;
        private System.Windows.Forms.Label lblThongTinSanPham;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgaybatdau;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiamGia;
    }
}