using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;
using System.Data.SqlClient;

using System.IO;


namespace QuanLiBanGiay
{
    public partial class Form_NhanVien : Form
    {
        string connectionString = @"Data Source=A101PC26;Initial Catalog =QLSV;Integrated Security=True;TrustServerCertificate=True";
        public Form_NhanVien()
        {
            InitializeComponent();
        }

        private void grpDanhSach_Enter(object sender, EventArgs e)
        {

        }
        private void LoadSanPham()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM NHANVIEN"; // 👈 đổi lại tên bảng của bạn nếu khác
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSanPham.DataSource = dt;
                    MessageBox.Show("Kết nối thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel File (*.xlsx)|*.xlsx";
            save.Title = "Chọn nơi lưu file Excel";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Dữ liệu");

                    // Ghi tiêu đề cột
                    for (int i = 0; i < dgvSanPham.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dgvSanPham.Columns[i].HeaderText;
                        worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                        worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                    }

                    // Ghi dữ liệu
                    for (int i = 0; i < dgvSanPham  .Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvSanPham.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dgvSanPham .Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents(); // Tự căn chỉnh độ rộng

                    workbook.SaveAs(save.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                }
            }
        }

        private void Form_NhanVien_Load(object sender, EventArgs e)
        {
            LoadSanPham();
        }
    }
}
