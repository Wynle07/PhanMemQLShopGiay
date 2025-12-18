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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SanPham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thêmSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.cbMaLoai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblTH = new System.Windows.Forms.Label();
            this.grbThongtin = new System.Windows.Forms.GroupBox();
            this.cboTH = new System.Windows.Forms.ComboBox();
            this.cboMauSac = new System.Windows.Forms.ComboBox();
            this.cboNCC = new System.Windows.Forms.ComboBox();
            this.cboKichCo = new System.Windows.Forms.ComboBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.clMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clKichCo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMauSac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSlton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HINHANHSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpDanhSach.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbThongtin.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSP,
            this.clTenSP,
            this.clLoaiSP,
            this.clKichCo,
            this.clMauSac,
            this.clGiaBan,
            this.clSlton,
            this.clMaNCC,
            this.clTH,
            this.HINHANHSP});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1479, 323);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dataGridView1);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(0, 416);
            this.grpDanhSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpDanhSach.Size = new System.Drawing.Size(1485, 353);
            this.grpDanhSach.TabIndex = 31;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách các sản phẩm";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmSảnPhẩmToolStripMenuItem,
            this.xóaSảnPhẩmToolStripMenuItem,
            this.sửaSảnPhẩmToolStripMenuItem,
            this.refeshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 132);
            // 
            // thêmSảnPhẩmToolStripMenuItem
            // 
            this.thêmSảnPhẩmToolStripMenuItem.Image = global::QuanLiBanGiay.Properties.Resources.icons8_add_16;
            this.thêmSảnPhẩmToolStripMenuItem.Name = "thêmSảnPhẩmToolStripMenuItem";
            this.thêmSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.thêmSảnPhẩmToolStripMenuItem.Text = "Thêm sản phẩm";
            this.thêmSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.thêmSảnPhẩmToolStripMenuItem_Click);
            // 
            // xóaSảnPhẩmToolStripMenuItem
            // 
            this.xóaSảnPhẩmToolStripMenuItem.Image = global::QuanLiBanGiay.Properties.Resources.icons8_delete_16;
            this.xóaSảnPhẩmToolStripMenuItem.Name = "xóaSảnPhẩmToolStripMenuItem";
            this.xóaSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.xóaSảnPhẩmToolStripMenuItem.Text = "Xóa sản phẩm";
            this.xóaSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.xóaSảnPhẩmToolStripMenuItem_Click);
            // 
            // sửaSảnPhẩmToolStripMenuItem
            // 
            this.sửaSảnPhẩmToolStripMenuItem.Image = global::QuanLiBanGiay.Properties.Resources.icons8_repair_16;
            this.sửaSảnPhẩmToolStripMenuItem.Name = "sửaSảnPhẩmToolStripMenuItem";
            this.sửaSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.sửaSảnPhẩmToolStripMenuItem.Text = "Sửa sản phẩm";
            this.sửaSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sửaSảnPhẩmToolStripMenuItem_Click);
            // 
            // refeshToolStripMenuItem
            // 
            this.refeshToolStripMenuItem.Image = global::QuanLiBanGiay.Properties.Resources.icons8_refresh_16;
            this.refeshToolStripMenuItem.Name = "refeshToolStripMenuItem";
            this.refeshToolStripMenuItem.Size = new System.Drawing.Size(215, 32);
            this.refeshToolStripMenuItem.Text = "Refesh";
            this.refeshToolStripMenuItem.Click += new System.EventHandler(this.refeshToolStripMenuItem_Click);
            // 
            // lblTenKM
            // 
            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKM.Location = new System.Drawing.Point(251, 40);
            this.lblTenKM.Name = "lblTenKM";
            this.lblTenKM.Size = new System.Drawing.Size(82, 25);
            this.lblTenKM.TabIndex = 86;
            this.lblTenKM.Text = "Tên SP:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(56, 69);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(157, 33);
            this.txtMaSP.TabIndex = 85;
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSanPham.Location = new System.Drawing.Point(51, 40);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(77, 25);
            this.lblSanPham.TabIndex = 84;
            this.lblSanPham.Text = "Mã SP:";
            // 
            // lblHinhAnh
            // 
            this.lblHinhAnh.AutoSize = true;
            this.lblHinhAnh.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhAnh.Location = new System.Drawing.Point(1068, 27);
            this.lblHinhAnh.Name = "lblHinhAnh";
            this.lblHinhAnh.Size = new System.Drawing.Size(177, 25);
            this.lblHinhAnh.TabIndex = 33;
            this.lblHinhAnh.Text = "Hình ảnh sản phẩm";
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNCC.Location = new System.Drawing.Point(676, 128);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(172, 25);
            this.lblMaNCC.TabIndex = 87;
            this.lblMaNCC.Text = "Tên nhà cung cấp:";
            this.lblMaNCC.Click += new System.EventHandler(this.lblMaNCC_Click);
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(256, 69);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(370, 33);
            this.txtTenSP.TabIndex = 95;
            // 
            // cbMaLoai
            // 
            this.cbMaLoai.FormattingEnabled = true;
            this.cbMaLoai.Location = new System.Drawing.Point(673, 69);
            this.cbMaLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaLoai.Name = "cbMaLoai";
            this.cbMaLoai.Size = new System.Drawing.Size(298, 33);
            this.cbMaLoai.TabIndex = 14;
            this.cbMaLoai.SelectedIndexChanged += new System.EventHandler(this.cbMaLoai_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 97;
            this.label2.Text = "Kích cỡ:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblMauSac
            // 
            this.lblMauSac.AutoSize = true;
            this.lblMauSac.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMauSac.Location = new System.Drawing.Point(251, 128);
            this.lblMauSac.Name = "lblMauSac";
            this.lblMauSac.Size = new System.Drawing.Size(93, 25);
            this.lblMauSac.TabIndex = 98;
            this.lblMauSac.Text = "Màu sắc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(668, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 100;
            this.label4.Text = "Loại SP:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 101;
            this.label1.Text = "Giá Bán:";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(432, 157);
            this.txtGiaBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(194, 33);
            this.txtGiaBan.TabIndex = 102;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(516, 295);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.txtTimKiem.Location = new System.Drawing.Point(56, 297);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(409, 31);
            this.txtTimKiem.TabIndex = 90;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1040, 69);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 202);
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongTon.Location = new System.Drawing.Point(51, 214);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(124, 25);
            this.lblSoLuongTon.TabIndex = 104;
            this.lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(56, 241);
            this.txtSoLuongTon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(157, 33);
            this.txtSoLuongTon.TabIndex = 105;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.Location = new System.Drawing.Point(1073, 291);
            this.btnChonAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(231, 42);
            this.btnChonAnh.TabIndex = 106;
            this.btnChonAnh.Text = "Chọn ảnh để thêm";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // lblTH
            // 
            this.lblTH.AutoSize = true;
            this.lblTH.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTH.Location = new System.Drawing.Point(252, 214);
            this.lblTH.Name = "lblTH";
            this.lblTH.Size = new System.Drawing.Size(155, 25);
            this.lblTH.TabIndex = 107;
            this.lblTH.Text = "Tên thương hiệu";
            // 
            // grbThongtin
            // 
            this.grbThongtin.Controls.Add(this.cboTH);
            this.grbThongtin.Controls.Add(this.cboMauSac);
            this.grbThongtin.Controls.Add(this.cboNCC);
            this.grbThongtin.Controls.Add(this.cboKichCo);
            this.grbThongtin.Controls.Add(this.lblTH);
            this.grbThongtin.Controls.Add(this.btnChonAnh);
            this.grbThongtin.Controls.Add(this.txtSoLuongTon);
            this.grbThongtin.Controls.Add(this.lblSoLuongTon);
            this.grbThongtin.Controls.Add(this.pictureBox1);
            this.grbThongtin.Controls.Add(this.txtTimKiem);
            this.grbThongtin.Controls.Add(this.btnTimKiem);
            this.grbThongtin.Controls.Add(this.txtGiaBan);
            this.grbThongtin.Controls.Add(this.label1);
            this.grbThongtin.Controls.Add(this.label4);
            this.grbThongtin.Controls.Add(this.lblMauSac);
            this.grbThongtin.Controls.Add(this.label2);
            this.grbThongtin.Controls.Add(this.cbMaLoai);
            this.grbThongtin.Controls.Add(this.txtTenSP);
            this.grbThongtin.Controls.Add(this.lblMaNCC);
            this.grbThongtin.Controls.Add(this.lblHinhAnh);
            this.grbThongtin.Controls.Add(this.lblSanPham);
            this.grbThongtin.Controls.Add(this.txtMaSP);
            this.grbThongtin.Controls.Add(this.lblTenKM);
            this.grbThongtin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbThongtin.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongtin.Location = new System.Drawing.Point(0, 68);
            this.grbThongtin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbThongtin.Name = "grbThongtin";
            this.grbThongtin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbThongtin.Size = new System.Drawing.Size(1485, 348);
            this.grbThongtin.TabIndex = 96;
            this.grbThongtin.TabStop = false;
            this.grbThongtin.Text = "Thông tin sản phẩm";
            this.grbThongtin.Enter += new System.EventHandler(this.grbThongtin_Enter);
            // 
            // cboTH
            // 
            this.cboTH.FormattingEnabled = true;
            this.cboTH.Location = new System.Drawing.Point(250, 242);
            this.cboTH.Name = "cboTH";
            this.cboTH.Size = new System.Drawing.Size(376, 33);
            this.cboTH.TabIndex = 111;
            this.cboTH.SelectedIndexChanged += new System.EventHandler(this.cboTH_SelectedIndexChanged);
            // 
            // cboMauSac
            // 
            this.cboMauSac.FormattingEnabled = true;
            this.cboMauSac.Location = new System.Drawing.Point(250, 157);
            this.cboMauSac.Name = "cboMauSac";
            this.cboMauSac.Size = new System.Drawing.Size(157, 33);
            this.cboMauSac.TabIndex = 110;
            this.cboMauSac.SelectedIndexChanged += new System.EventHandler(this.cboMauSac_SelectedIndexChanged);
            // 
            // cboNCC
            // 
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Location = new System.Drawing.Point(681, 157);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new System.Drawing.Size(290, 33);
            this.cboNCC.TabIndex = 109;
            this.cboNCC.SelectedIndexChanged += new System.EventHandler(this.cboNCC_SelectedIndexChanged);
            // 
            // cboKichCo
            // 
            this.cboKichCo.FormattingEnabled = true;
            this.cboKichCo.Location = new System.Drawing.Point(56, 157);
            this.cboKichCo.Name = "cboKichCo";
            this.cboKichCo.Size = new System.Drawing.Size(157, 33);
            this.cboKichCo.TabIndex = 108;
            this.cboKichCo.SelectedIndexChanged += new System.EventHandler(this.cboKichCo_SelectedIndexChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnLuu);
            this.panelButtons.Controls.Add(this.btnThem);
            this.panelButtons.Controls.Add(this.btnXoa);
            this.panelButtons.Controls.Add(this.btnSua);
            this.panelButtons.Controls.Add(this.button1);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1485, 68);
            this.panelButtons.TabIndex = 27;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(353, 10);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(92, 52);
            this.btnLuu.TabIndex = 93;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Image = global::QuanLiBanGiay.Properties.Resources.plus_icon;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(18, 11);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 53);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.Image = global::QuanLiBanGiay.Properties.Resources.substract_icon;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(134, 11);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(89, 53);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSua.Image = global::QuanLiBanGiay.Properties.Resources.update_icon;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(243, 11);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 53);
            this.btnSua.TabIndex = 25;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Image = global::QuanLiBanGiay.Properties.Resources.icons8_refresh_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(461, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 53);
            this.button1.TabIndex = 26;
            this.button1.Text = "Làm mới";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clMaSP
            // 
            this.clMaSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clMaSP.DataPropertyName = "MAGIAY";
            dataGridViewCellStyle1.NullValue = null;
            this.clMaSP.DefaultCellStyle = dataGridViewCellStyle1;
            this.clMaSP.HeaderText = "Mã SP";
            this.clMaSP.MinimumWidth = 6;
            this.clMaSP.Name = "clMaSP";
            this.clMaSP.Width = 107;
            // 
            // clTenSP
            // 
            this.clTenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clTenSP.DataPropertyName = "TENGIAY";
            this.clTenSP.HeaderText = "Tên SP";
            this.clTenSP.MinimumWidth = 6;
            this.clTenSP.Name = "clTenSP";
            this.clTenSP.Width = 112;
            // 
            // clLoaiSP
            // 
            this.clLoaiSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clLoaiSP.DataPropertyName = "TENLOAI";
            this.clLoaiSP.HeaderText = "Loại SP";
            this.clLoaiSP.MinimumWidth = 6;
            this.clLoaiSP.Name = "clLoaiSP";
            this.clLoaiSP.Width = 117;
            // 
            // clKichCo
            // 
            this.clKichCo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clKichCo.DataPropertyName = "KICHCO";
            this.clKichCo.HeaderText = "Kích cỡ";
            this.clKichCo.MinimumWidth = 6;
            this.clKichCo.Name = "clKichCo";
            this.clKichCo.Width = 117;
            // 
            // clMauSac
            // 
            this.clMauSac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clMauSac.DataPropertyName = "TENMAU";
            this.clMauSac.HeaderText = "Màu Sắc";
            this.clMauSac.MinimumWidth = 6;
            this.clMauSac.Name = "clMauSac";
            this.clMauSac.Width = 126;
            // 
            // clGiaBan
            // 
            this.clGiaBan.DataPropertyName = "GIABAN";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.clGiaBan.DefaultCellStyle = dataGridViewCellStyle2;
            this.clGiaBan.HeaderText = "Giá bán";
            this.clGiaBan.MinimumWidth = 8;
            this.clGiaBan.Name = "clGiaBan";
            this.clGiaBan.Width = 150;
            // 
            // clSlton
            // 
            this.clSlton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clSlton.DataPropertyName = "SOLUONGTON";
            this.clSlton.HeaderText = "Số lượng tồn";
            this.clSlton.MinimumWidth = 8;
            this.clSlton.Name = "clSlton";
            // 
            // clMaNCC
            // 
            this.clMaNCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clMaNCC.DataPropertyName = "TENNCC";
            this.clMaNCC.HeaderText = "Tên nhà cung cấp";
            this.clMaNCC.MinimumWidth = 6;
            this.clMaNCC.Name = "clMaNCC";
            this.clMaNCC.Width = 157;
            // 
            // clTH
            // 
            this.clTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clTH.DataPropertyName = "TENTH";
            this.clTH.HeaderText = "Tên thương hiệu";
            this.clTH.MinimumWidth = 8;
            this.clTH.Name = "clTH";
            // 
            // HINHANHSP
            // 
            this.HINHANHSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HINHANHSP.DataPropertyName = "HINHANHSP";
            this.HINHANHSP.HeaderText = "Hình ảnh";
            this.HINHANHSP.MinimumWidth = 8;
            this.HINHANHSP.Name = "HINHANHSP";
            this.HINHANHSP.Visible = false;
            // 
            // Form_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 769);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grbThongtin);
            this.Controls.Add(this.panelButtons);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_SanPham";
            this.Text = "Form_SanPham";
            this.Load += new System.EventHandler(this.Form_SanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpDanhSach.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbThongtin.ResumeLayout(false);
            this.grbThongtin.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thêmSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.Label lblHinhAnh;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.ComboBox cbMaLoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lblTH;
        private System.Windows.Forms.GroupBox grbThongtin;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboTH;
        private System.Windows.Forms.ComboBox cboMauSac;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.ComboBox cboKichCo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clKichCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMauSac;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSlton;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn HINHANHSP;
    }
}