using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanGiay
{
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "admin" && txtMatKhau.Text == "123")
            {
                global::QuanLiBanGiay.SessionContext.MaNhanVien = txtDangNhap.Text.Trim();
                // Ẩn form login
                this.Hide();

                // Mở form chính (Form_Menu)
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();

                // Khi form chính đóng, thì thoát luôn
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }    
            else
            {
                txtMatKhau.UseSystemPasswordChar=true;
            }    
        }
    }
}

