using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLiBanGiay
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            TimerDongHo = new Timer();
            TimerDongHo.Interval = 1000;
            TimerDongHo.Tick += TimerDongHo_Tick;
            TimerDongHo.Start();
            InitializeComponent();
            PhanQuyen();
            CapNhatDongHo();
        }
        private void PhanQuyen()
        {
            string vaiTro = global::QuanLiBanGiay.SessionContext.VaiTro;

            //Mặc định vô hiệu hóa tất cả các nút quản lý (Trang chủ và Đăng xuất luôn được bật)
            btnSanPham.Enabled = false;
            btnNhaCungCap.Enabled = false;
            btnTaoDonHang.Enabled = false;
            btnNhanVien.Enabled = false;
            btnThongKe.Enabled = false;
            btnKhuyenMai.Enabled = false;
            btnNhapHang.Enabled = false;

            //Bật lại các nút dựa trên vai trò
            switch (vaiTro)
            {
                case "Admin":
                    // Tất cả
                    btnSanPham.Enabled = true;
                    btnNhaCungCap.Enabled = true;
                    btnTaoDonHang.Enabled = true;
                    btnNhanVien.Enabled = true;
                    btnThongKe.Enabled = true;
                    btnKhuyenMai.Enabled = true;
                    btnNhapHang.Enabled = true;
                    break;

                case "Thu ngân":
                    // Thu ngân chỉ bật các chức năng bán hàng
                    btnSanPham.Enabled = true;   
                    btnTaoDonHang.Enabled = true;
                    btnKhuyenMai.Enabled = true; 
                    break;

                case "Quản lý kho":
                    // Quản lý kho chỉ bật các chức năng kho
                    btnSanPham.Enabled = true;    
                    btnNhaCungCap.Enabled = true;  
                    btnNhapHang.Enabled = true;    
                    break;

                default:
                    // Nếu vai trò không xác định, vô hiệu hóa tất cả
                    MessageBox.Show("Vai trò không hợp lệ. Vui lòng đăng nhập lại.", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void CapNhatDongHo()
        {
            DateTime now = DateTime.Now;
            string thu = now.ToString("dddd", new System.Globalization.CultureInfo("vi-VN"));
            thu = char.ToUpper(thu[0]) + thu.Substring(1);
            lblDateTime.Text = $"{thu}, {now:dd/MM/yyyy HH:mm:ss}";
        }
        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
        {
            pnContent.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnContent.Controls.Add(childForm);
            childForm.Show();
        }


        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
        }

        
        private void Form_Menu_Load(object sender, EventArgs e)
        {
            lblChucVu.Text = global::QuanLiBanGiay.SessionContext.VaiTro.ToString();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_SanPham());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_NhaCungCap());

        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_TaoHoaDon());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_NhanVien());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_ThongKe());
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_KhuyenMai());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn thoát không?",
               "Xác nhận thoát",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất không?",
            "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                
                this.Hide();
             
                global::QuanLiBanGiay.SessionContext.MaNhanVien = null;
                Form_DangNhap frmLogin = new Form_DangNhap();
                frmLogin.ShowDialog();

                
            }
        }

        private void pnContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TimerDongHo_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form__NhapHang());
        }
    }
}
