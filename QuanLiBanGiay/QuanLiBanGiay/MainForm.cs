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
            CapNhatDongHo();
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

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_KhoHang());
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
             
                Form1 frmLogin = new Form1();
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
    }
}
