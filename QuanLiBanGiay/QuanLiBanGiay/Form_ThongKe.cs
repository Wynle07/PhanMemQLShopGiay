using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QuanLiBanGiay
{
    public partial class Form_ThongKe : Form
    {
       SqlConnection conn;
        public Form_ThongKe()
        {
            conn = DBConnection.GetConnection();
            InitializeComponent();
        }
        private void LoadHoaDon()
        {
            string maHD = txtTimkiem.Text.Trim();

            string query = @"
                SELECT 
                    hd.MAHD,
                    hd.NGAYLAP,
                    nv.TENNV AS NhanVien,
                    kh.TENKH AS KhachHang,
                    hd.TONGTIEN
                FROM HOADON hd
                LEFT JOIN NHANVIEN nv ON hd.MANV = nv.MANV
                LEFT JOIN KHACHHANG kh ON hd.MAKH = kh.MAKH
                WHERE (@MaHD IS NULL OR @MaHD = '' OR hd.MAHD LIKE '%' + @MaHD + '%')
                ORDER BY hd.NGAYLAP DESC";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", string.IsNullOrEmpty(maHD) ? (object)DBNull.Value : maHD);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);

                    dgvSanPham.DataSource = dt; // giả sử DataGridView tên là dgvHoaDon

                    // Tính tổng doanh thu
                    double tong = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (double.TryParse(row["TONGTIEN"].ToString(), out double tien))
                            tong += tien;
                    }

                    lblTongTien.Text = tong.ToString("N0") + " VNĐ";

                    FormatGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatGrid()
        {
            if (dgvSanPham.Columns["TONGTIEN"] != null)
                dgvSanPham.Columns["TONGTIEN"].DefaultCellStyle.Format = "N0";

            if (dgvSanPham.Columns["NGAYLAP"] != null)
                dgvSanPham.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.RowHeadersVisible = false;
        }

        private void Form_ThongKe_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadHoaDon();
            LoadTop5SanPham();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void LoadTop5SanPham()
        {
            string query = @"
        SELECT TOP 5 
            g.TENGIAY,
            SUM(ct.SOLUONG) AS SoLuongBan
        FROM CTHOADON ct
        JOIN GIAY g ON ct.MAGIAY = g.MAGIAY
        GROUP BY g.TENGIAY
        ORDER BY SUM(ct.SOLUONG) DESC";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);

                    // Thêm cột STT
                    dt.Columns.Add("STT", typeof(int));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["STT"] = i + 1;
                    }

                    // Gán dữ liệu
                    data_top5sp.DataSource = dt;

                    // SẮP XẾP CỘT: STT | TÊN GIÀY | SỐ LƯỢNG
                    data_top5sp.Columns["STT"].DisplayIndex = 0;
                    data_top5sp.Columns["TENGIAY"].DisplayIndex = 1;
                    data_top5sp.Columns["SoLuongBan"].DisplayIndex = 2;

                    // ĐỔI TIÊU ĐỀ
                    data_top5sp.Columns["STT"].HeaderText = "Top";
                    data_top5sp.Columns["TENGIAY"].HeaderText = "Tên sản phẩm";
                    data_top5sp.Columns["SoLuongBan"].HeaderText = "Số lượng";

                    // ẨN CỘT KHÔNG CẦN
                    // (không ẩn TENGIAY nữa)

                    // ĐỊNH DẠNG
                    data_top5sp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    data_top5sp.RowHeadersVisible = false;
                    data_top5sp.AllowUserToAddRows = false;
                    data_top5sp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    data_top5sp.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    data_top5sp.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    data_top5sp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // TÔ MÀU TOP 1,2,3
                    foreach (DataGridViewRow row in data_top5sp.Rows)
                    {
                        int stt = Convert.ToInt32(row.Cells["STT"].Value);
                        switch (stt)
                        {
                            case 1: row.DefaultCellStyle.BackColor = Color.Gold; row.DefaultCellStyle.ForeColor = Color.Black; break;
                            case 2: row.DefaultCellStyle.BackColor = Color.Silver; break;
                            case 3: row.DefaultCellStyle.BackColor = Color.FromArgb(205, 127, 50); break;
                        }
                    }

                    // Căn giữa cột Top và Số lượng
                    data_top5sp.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    data_top5sp.Columns["SoLuongBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Top 5: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Xuất thống kê hóa đơn",
                FileName = $"ThongKe_HoaDon_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add();
                    Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

                    // Tiêu đề
                    ws.Cells[1, 1] = "BÁO CÁO DOANH THU";
                    ws.Cells[1, 1].Font.Size = 16;
                    ws.Cells[1, 1].Font.Bold = true;
                    ws.Range["A1:E1"].Merge();
                    ws.Range["A1:E1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    ws.Cells[2, 1] = $"Từ ngày: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    ws.Range["A2:E2"].Merge();

                    // Header
                    for (int i = 0; i < dgvSanPham.Columns.Count; i++)
                    {
                        ws.Cells[4, i + 1] = dgvSanPham.Columns[i].HeaderText;
                        ws.Cells[4, i + 1].Font.Bold = true;
                        ws.Cells[4, i + 1].Interior.Color = Color.LightGray;
                    }

                    // Dữ liệu
                    for (int i = 0; i < dgvSanPham.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvSanPham.Columns.Count; j++)
                        {
                            ws.Cells[i + 5, j + 1] = dgvSanPham.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Tổng tiền
                    int lastRow = dgvSanPham.Rows.Count + 5;
                    ws.Cells[lastRow, 4] = "TỔNG DOANH THU:";
                    ws.Cells[lastRow, 5] = lblTongTien.Text;
                    ws.Cells[lastRow, 4].Font.Bold = true;
                    ws.Cells[lastRow, 5].Font.Bold = true;
                    ws.Cells[lastRow, 5].Font.Color = Color.Red;

                    // Format cột tiền
                    ws.Columns[5].NumberFormat = "#,##0";

                    // Auto fit
                    ws.Columns.AutoFit();

                    // Lưu
                    wb.SaveAs(save.FileName);
                    wb.Close();
                    app.Quit();

                    // Giải phóng
                    ReleaseObject(ws);
                    ReleaseObject(wb);
                    ReleaseObject(app);

                    MessageBox.Show($"Xuất Excel thành công!\n{save.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
                }
            }
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch { obj = null; }
            finally { GC.Collect(); }
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void lblTongDT_Click(object sender, EventArgs e)
        {

        }
    }
}
