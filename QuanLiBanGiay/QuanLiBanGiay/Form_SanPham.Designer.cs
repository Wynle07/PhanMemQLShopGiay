namespace QuanLiBanGiay
{
    partial class Form_SanPham
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clKichCo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMauSac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSlton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.txtKichCo = new System.Windows.Forms.TextBox();
            this.cbMaLoai = new System.Windows.Forms.ComboBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.grbThongtin = new System.Windows.Forms.GroupBox();
            this.txtTH = new System.Windows.Forms.TextBox();
            this.lblTH = new System.Windows.Forms.Label();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpDanhSach.SuspendLayout();
            this.grbThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Location = new System.Drawing.Point(189, 369);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 45);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.Location = new System.Drawing.Point(498, 369);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 45);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSua.Location = new System.Drawing.Point(349, 369);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 45);
            this.btnSua.TabIndex = 25;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(645, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 45);
            this.button1.TabIndex = 26;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHinhAnh
            // 
            this.lblHinhAnh.AutoSize = true;
            this.lblHinhAnh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhAnh.Location = new System.Drawing.Point(1034, 63);
            this.lblHinhAnh.Name = "lblHinhAnh";
            this.lblHinhAnh.Size = new System.Drawing.Size(203, 27);
            this.lblHinhAnh.TabIndex = 33;
            this.lblHinhAnh.Text = "Hình ảnh sản phẩm:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSP,
            this.clTenSP,
            this.clLoaiSP,
            this.clMaNCC,
            this.clKichCo,
            this.clMauSac,
            this.clGiaBan,
            this.clSlton});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1479, 321);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // clMaSP
            // 
            this.clMaSP.DataPropertyName = "MAGIAY";
            this.clMaSP.HeaderText = "Mã SP";
            this.clMaSP.MinimumWidth = 6;
            this.clMaSP.Name = "clMaSP";
            this.clMaSP.Width = 125;
            // 
            // clTenSP
            // 
            this.clTenSP.DataPropertyName = "TENGIAY";
            this.clTenSP.HeaderText = "Tên SP";
            this.clTenSP.MinimumWidth = 6;
            this.clTenSP.Name = "clTenSP";
            this.clTenSP.Width = 150;
            // 
            // clLoaiSP
            // 
            this.clLoaiSP.DataPropertyName = "TENLOAI";
            this.clLoaiSP.HeaderText = "Loại SP";
            this.clLoaiSP.MinimumWidth = 6;
            this.clLoaiSP.Name = "clLoaiSP";
            this.clLoaiSP.Width = 125;
            // 
            // clMaNCC
            // 
            this.clMaNCC.DataPropertyName = "TENNCC";
            this.clMaNCC.HeaderText = "Tên nhà cung cấp";
            this.clMaNCC.MinimumWidth = 6;
            this.clMaNCC.Name = "clMaNCC";
            this.clMaNCC.Width = 125;
            // 
            // clKichCo
            // 
            this.clKichCo.DataPropertyName = "KICHCO";
            this.clKichCo.HeaderText = "Kích cỡ";
            this.clKichCo.MinimumWidth = 6;
            this.clKichCo.Name = "clKichCo";
            this.clKichCo.Width = 125;
            // 
            // clMauSac
            // 
            this.clMauSac.DataPropertyName = "TENMAU";
            this.clMauSac.HeaderText = "Màu Sắc";
            this.clMauSac.MinimumWidth = 6;
            this.clMauSac.Name = "clMauSac";
            this.clMauSac.Width = 125;
            // 
            // clGiaBan
            // 
            this.clGiaBan.DataPropertyName = "GIABAN";
            this.clGiaBan.HeaderText = "Giá Bán";
            this.clGiaBan.MinimumWidth = 6;
            this.clGiaBan.Name = "clGiaBan";
            this.clGiaBan.Width = 150;
            // 
            // clSlton
            // 
            this.clSlton.DataPropertyName = "SOLUONGTON";
            this.clSlton.HeaderText = "Số lượng tồn";
            this.clSlton.MinimumWidth = 8;
            this.clSlton.Name = "clSlton";
            this.clSlton.Width = 150;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDanhSach.Controls.Add(this.dataGridView1);
            this.grpDanhSach.Location = new System.Drawing.Point(0, 423);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1485, 346);
            this.grpDanhSach.TabIndex = 31;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách các sản phẩm";
            // 
            // txtKichCo
            // 
            this.txtKichCo.Location = new System.Drawing.Point(69, 214);
            this.txtKichCo.Name = "txtKichCo";
            this.txtKichCo.Size = new System.Drawing.Size(101, 32);
            this.txtKichCo.TabIndex = 10;
            // 
            // cbMaLoai
            // 
            this.cbMaLoai.FormattingEnabled = true;
            this.cbMaLoai.Location = new System.Drawing.Point(673, 116);
            this.cbMaLoai.Name = "cbMaLoai";
            this.cbMaLoai.Size = new System.Drawing.Size(298, 33);
            this.cbMaLoai.TabIndex = 14;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(257, 118);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(370, 32);
            this.txtTenSP.TabIndex = 95;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(590, 214);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(381, 32);
            this.txtMaNCC.TabIndex = 92;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(1330, 379);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 38);
            this.btnTimKiem.TabIndex = 91;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnTimKiem_KeyDown);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(1039, 383);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(271, 31);
            this.txtTimKiem.TabIndex = 90;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTenKM
            // 
            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKM.Location = new System.Drawing.Point(252, 63);
            this.lblTenKM.Name = "lblTenKM";
            this.lblTenKM.Size = new System.Drawing.Size(87, 27);
            this.lblTenKM.TabIndex = 86;
            this.lblTenKM.Text = "Tên SP:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(69, 117);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(157, 32);
            this.txtMaSP.TabIndex = 85;
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSanPham.Location = new System.Drawing.Point(66, 63);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(82, 27);
            this.lblSanPham.TabIndex = 84;
            this.lblSanPham.Text = "Mã SP:";
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNCC.Location = new System.Drawing.Point(594, 177);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(188, 27);
            this.lblMaNCC.TabIndex = 87;
            this.lblMaNCC.Text = "Tên nhà cung cấp:";
            this.lblMaNCC.Click += new System.EventHandler(this.lblMaNCC_Click);
            // 
            // grbThongtin
            // 
            this.grbThongtin.Controls.Add(this.txtTH);
            this.grbThongtin.Controls.Add(this.lblTH);
            this.grbThongtin.Controls.Add(this.btnChonAnh);
            this.grbThongtin.Controls.Add(this.txtSoLuongTon);
            this.grbThongtin.Controls.Add(this.lblSoLuongTon);
            this.grbThongtin.Controls.Add(this.pictureBox1);
            this.grbThongtin.Controls.Add(this.txtGiaBan);
            this.grbThongtin.Controls.Add(this.label1);
            this.grbThongtin.Controls.Add(this.label4);
            this.grbThongtin.Controls.Add(this.txtMauSac);
            this.grbThongtin.Controls.Add(this.lblMauSac);
            this.grbThongtin.Controls.Add(this.label2);
            this.grbThongtin.Controls.Add(this.cbMaLoai);
            this.grbThongtin.Controls.Add(this.txtKichCo);
            this.grbThongtin.Controls.Add(this.txtTenSP);
            this.grbThongtin.Controls.Add(this.txtMaNCC);
            this.grbThongtin.Controls.Add(this.lblMaNCC);
            this.grbThongtin.Controls.Add(this.lblHinhAnh);
            this.grbThongtin.Controls.Add(this.lblSanPham);
            this.grbThongtin.Controls.Add(this.txtMaSP);
            this.grbThongtin.Controls.Add(this.lblTenKM);
            this.grbThongtin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbThongtin.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongtin.Location = new System.Drawing.Point(0, 0);
            this.grbThongtin.Name = "grbThongtin";
            this.grbThongtin.Size = new System.Drawing.Size(1485, 363);
            this.grbThongtin.TabIndex = 96;
            this.grbThongtin.TabStop = false;
            this.grbThongtin.Text = "Thông tin sản phẩm";
            this.grbThongtin.Enter += new System.EventHandler(this.grbThongtin_Enter);
            // 
            // txtTH
            // 
            this.txtTH.Location = new System.Drawing.Point(241, 314);
            this.txtTH.Name = "txtTH";
            this.txtTH.Size = new System.Drawing.Size(181, 32);
            this.txtTH.TabIndex = 108;
            // 
            // lblTH
            // 
            this.lblTH.AutoSize = true;
            this.lblTH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTH.Location = new System.Drawing.Point(236, 272);
            this.lblTH.Name = "lblTH";
            this.lblTH.Size = new System.Drawing.Size(170, 27);
            this.lblTH.TabIndex = 107;
            this.lblTH.Text = "Tên thương hiệu";
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(1039, 314);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(231, 43);
            this.btnChonAnh.TabIndex = 106;
            this.btnChonAnh.Text = "Chọn ảnh để thêm";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(69, 314);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(101, 32);
            this.txtSoLuongTon.TabIndex = 105;
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongTon.Location = new System.Drawing.Point(66, 274);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(124, 25);
            this.lblSoLuongTon.TabIndex = 104;
            this.lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1039, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 203);
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(373, 214);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(181, 32);
            this.txtGiaBan.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(368, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 27);
            this.label1.TabIndex = 101;
            this.label1.Text = "Giá Bán:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(668, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 27);
            this.label4.TabIndex = 100;
            this.label4.Text = "Loại SP:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtMauSac
            // 
            this.txtMauSac.Location = new System.Drawing.Point(200, 214);
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(128, 32);
            this.txtMauSac.TabIndex = 99;
            // 
            // lblMauSac
            // 
            this.lblMauSac.AutoSize = true;
            this.lblMauSac.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMauSac.Location = new System.Drawing.Point(195, 177);
            this.lblMauSac.Name = "lblMauSac";
            this.lblMauSac.Size = new System.Drawing.Size(99, 27);
            this.lblMauSac.TabIndex = 98;
            this.lblMauSac.Text = "Màu sắc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 27);
            this.label2.TabIndex = 97;
            this.label2.Text = "Kích cỡ:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 769);
            this.Controls.Add(this.grbThongtin);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Name = "Form_SanPham";
            this.Text = "Form_SanPham";
            this.Load += new System.EventHandler(this.Form_SanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpDanhSach.ResumeLayout(false);
            this.grbThongtin.ResumeLayout(false);
            this.grbThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblHinhAnh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.TextBox txtKichCo;
        private System.Windows.Forms.ComboBox cbMaLoai;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.GroupBox grbThongtin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clKichCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMauSac;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSlton;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.TextBox txtTH;
        private System.Windows.Forms.Label lblTH;
    }
}