namespace QuanLiBanGiay
{
    partial class Form_KhoHang
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
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.clMaNVXL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiemTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXuatExcel.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXuatExcel.Location = new System.Drawing.Point(578, 555);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(116, 36);
            this.btnXuatExcel.TabIndex = 60;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNhapHang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNhapHang.Location = new System.Drawing.Point(393, 555);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(116, 36);
            this.btnNhapHang.TabIndex = 58;
            this.btnNhapHang.Text = "Nhập Hàng";
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.Location = new System.Drawing.Point(778, 555);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(116, 36);
            this.btnXoa.TabIndex = 57;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnRefesh
            // 
            this.btnRefesh.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRefesh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefesh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefesh.Location = new System.Drawing.Point(209, 555);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(116, 36);
            this.btnRefesh.TabIndex = 56;
            this.btnRefesh.Text = "Refesh";
            this.btnRefesh.UseVisualStyleBackColor = false;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvSanPham);
            this.grpDanhSach.Location = new System.Drawing.Point(12, 26);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1134, 511);
            this.grpDanhSach.TabIndex = 61;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Sản phẩm có trong kho";
            // 
            // clMaNVXL
            // 
            this.clMaNVXL.HeaderText = "NV Xử lý";
            this.clMaNVXL.MinimumWidth = 6;
            this.clMaNVXL.Name = "clMaNVXL";
            this.clMaNVXL.Width = 125;
            // 
            // clThoiGian
            // 
            this.clThoiGian.HeaderText = "Thời Gian";
            this.clThoiGian.MinimumWidth = 6;
            this.clThoiGian.Name = "clThoiGian";
            this.clThoiGian.Width = 125;
            // 
            // clDiemTL
            // 
            this.clDiemTL.HeaderText = "Điểm Tích Lũy";
            this.clDiemTL.MinimumWidth = 6;
            this.clDiemTL.Name = "clDiemTL";
            this.clDiemTL.Width = 125;
            // 
            // clDiaChi
            // 
            this.clDiaChi.HeaderText = "Địa Chỉ";
            this.clDiaChi.MinimumWidth = 6;
            this.clDiaChi.Name = "clDiaChi";
            this.clDiaChi.Width = 125;
            // 
            // clSDT
            // 
            this.clSDT.HeaderText = "SĐT";
            this.clSDT.MinimumWidth = 6;
            this.clSDT.Name = "clSDT";
            this.clSDT.Width = 125;
            // 
            // clTenKH
            // 
            this.clTenKH.HeaderText = "Tên KH";
            this.clTenKH.MinimumWidth = 6;
            this.clTenKH.Name = "clTenKH";
            this.clTenKH.Width = 200;
            // 
            // clMaKH
            // 
            this.clMaKH.HeaderText = "Mã KH";
            this.clMaKH.MinimumWidth = 6;
            this.clMaKH.Name = "clMaKH";
            this.clMaKH.Width = 125;
            // 
            // clMaDH
            // 
            this.clMaDH.HeaderText = "Mã ĐH";
            this.clMaDH.MinimumWidth = 6;
            this.clMaDH.Name = "clMaDH";
            this.clMaDH.Width = 150;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaDH,
            this.clMaKH,
            this.clTenKH,
            this.clSDT,
            this.clDiaChi,
            this.clDiemTL,
            this.clThoiGian,
            this.clMaNVXL});
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSanPham.Location = new System.Drawing.Point(3, 21);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(1128, 487);
            this.dgvSanPham.TabIndex = 1;
            // 
            // Form_KhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 616);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnRefesh);
            this.Name = "Form_KhoHang";
            this.Text = "Form_KhoHang";
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiemTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaNVXL;
    }
}