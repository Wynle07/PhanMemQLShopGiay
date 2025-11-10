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
    public partial class Form_NhaCungCap : Form
    {
        SqlConnection conn;
        DataSet ds_NCC = new DataSet();
        SqlDataAdapter da_ncc;
        public Form_NhaCungCap()
        {
            conn = new SqlConnection("Data Source=.;Initial Catalog=QL_BANGIAY;Integrated Security=True;TrustServerCertificate=True");
            InitializeComponent();
        }

        private void Form_NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang hợp tác");
            cboTrangThai.Items.Add("Ngừng hợp tác");
        }
        private void LoadNhaCungCap()
        {
            try
            {
                string sql = "SELECT MANCC, TENNCC, SDT AS Hotline, EMAIL, DIACHI, TRANGTHAI FROM NHACUNGCAP";
                da_ncc = new SqlDataAdapter(sql, conn);

                ds_NCC.Clear(); // Xóa dữ liệu cũ nếu có
                da_ncc.Fill(ds_NCC, "NHACUNGCAP");

                dataGridView1.DataSource = ds_NCC.Tables["NHACUNGCAP"];

                // Tùy chỉnh hiển thị
                dataGridView1.Columns["MANCC"].HeaderText = "Mã NCC";
                dataGridView1.Columns["TENNCC"].HeaderText = "Tên NCC";
                dataGridView1.Columns["Hotline"].HeaderText = "Hotline";
                dataGridView1.Columns["EMAIL"].HeaderText = "Email";
                dataGridView1.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dataGridView1.Columns["TRANGTHAI"].HeaderText = "Trạng thái";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["MANCC"].Value?.ToString();
                cbTenNCC.Text = row.Cells["TENNCC"].Value?.ToString();   
                txtHotline.Text = row.Cells["Hotline"].Value?.ToString();
                txtEmail.Text = row.Cells["EMAIL"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value?.ToString();
                cboTrangThai.Text = row.Cells["TRANGTHAI"].Value?.ToString();
            }
        }
    }
}
