using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanGiay
{
    public partial class Form_DangNhap : Form
    {
        SqlConnection conn;
        public Form_DangNhap()
        {
            InitializeComponent();
            conn = DBConnection.GetConnection();
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
            string tenDangNhap = txtDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            string query = "SELECT MANV, VAITRO FROM TAIKHOAN " +
                           "WHERE TENDANGNHAP = @User AND MATKHAU = @Pass AND TRANGTHAI = N'Hoạt động'";
            try
            {
                using (conn)
                {
                    DBConnection.OpenConnection(conn);
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", tenDangNhap);
                        cmd.Parameters.AddWithValue("@Pass", matKhau);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu tìm thấy một dòng (đăng nhập thành công)
                            {
                                string maNhanVien = reader["MANV"].ToString();
                                string vaiTro = reader["VAITRO"].ToString();

                                global::QuanLiBanGiay.SessionContext.MaNhanVien = maNhanVien;
                                global::QuanLiBanGiay.SessionContext.VaiTro = vaiTro;

                                //Mở MainForm
                                this.Hide();
                                MainForm mainForm = new MainForm();
                                mainForm.ShowDialog();
                                this.Close();
                            }
                            else // Nếu không tìm thấy dòng nào 
                            {
                                MessageBox.Show("Sai tài khoản, mật khẩu hoặc tài khoản đã bị vô hiệu hóa!",
                                                "Thông báo",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                                "Lỗi nghiêm trọng",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn thoát không?",
               "Xác nhận thoát",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                 Close();
            }
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

