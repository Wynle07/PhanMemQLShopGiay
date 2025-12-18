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
        WHERE 1=1 ";
            if (string.IsNullOrEmpty(maHD))
            {
                if (rdoTheoNgay.Checked)
                {
                    query += " AND DAY(hd.NGAYLAP) = @Day AND MONTH(hd.NGAYLAP) = @Month AND YEAR(hd.NGAYLAP) = @Year";
                }
                else if (rdoTheoThang.Checked)
                {
                    query += " AND MONTH(hd.NGAYLAP) = @Month AND YEAR(hd.NGAYLAP) = @Year";
                }
                else if (rdoKhoangTG.Checked)
                {
                    query += " AND hd.NGAYLAP BETWEEN @FromDate AND @ToDate";
                }
            }
            else
            {
                query += " AND hd.MAHD LIKE '%' + @MaHD + '%'";
            }
            query += " ORDER BY hd.NGAYLAP DESC";
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maHD))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maHD);
                    }
                    if (string.IsNullOrEmpty(maHD))
                    {
                        if (rdoTheoNgay.Checked)
                        {
                            DateTime d = dtpNgay.Value;
                            cmd.Parameters.AddWithValue("@Day", d.Day);
                            cmd.Parameters.AddWithValue("@Month", d.Month);
                            cmd.Parameters.AddWithValue("@Year", d.Year);
                        }
                        else if (rdoTheoThang.Checked)
                        {
                            if (string.IsNullOrEmpty(txtNam.Text)) { MessageBox.Show("Vui lòng nhập năm!"); return; }
                            cmd.Parameters.AddWithValue("@Month", cboThang.Text);
                            cmd.Parameters.AddWithValue("@Year", txtNam.Text.Trim());
                        }
                        else if (rdoKhoangTG.Checked)
                        {
                            DateTime tuNgay = dtpTuNgay.Value.Date;
                            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                            cmd.Parameters.AddWithValue("@FromDate", tuNgay);
                            cmd.Parameters.AddWithValue("@ToDate", denNgay);
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    dgvSanPham.DataSource = dt;
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
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatGrid()
        {
            if (dgvSanPham.Columns.Count == 0) return;

            dgvSanPham.Columns["MAHD"].HeaderText = "Mã hóa đơn";
            dgvSanPham.Columns["NGAYLAP"].HeaderText = "Ngày lập";
            dgvSanPham.Columns["NhanVien"].HeaderText = "Nhân viên";
            dgvSanPham.Columns["KhachHang"].HeaderText = "Khách hàng";
            dgvSanPham.Columns["TONGTIEN"].HeaderText = "Tổng tiền";

            dgvSanPham.Columns["TONGTIEN"].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.RowHeadersVisible = false;
        }
        private void LoadDataComboBox()
        {
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString());
            }
            cboThang.SelectedIndex = DateTime.Now.Month - 1;
            txtNam.Text = DateTime.Now.Year.ToString();
        }
        private void Form_ThongKe_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadDataComboBox();
            rdoTheoNgay.Checked = true;
            dtpNgay.Value = DateTime.Now;
            UpdateInputState();
            LoadHoaDon();
            LoadTop5SanPham();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            LoadHoaDon();
        }
        private void UpdateInputState()
        {

            dtpNgay.Enabled = rdoTheoNgay.Checked;


            cboThang.Enabled = rdoTheoThang.Checked;
            txtNam.Enabled = rdoTheoThang.Checked;


            dtpTuNgay.Enabled = rdoKhoangTG.Checked;
            dtpDenNgay.Enabled = rdoKhoangTG.Checked;
        }
        private void LoadTop5SanPham()
        {
            
            string query = @"
        SELECT TOP 5 
            g.TENGIAY,
            SUM(ct.SOLUONG) AS SoLuongBan
        FROM CTHOADON ct
        JOIN HOADON hd ON ct.MAHD = hd.MAHD  -- Cần Join thêm bảng Hóa Đơn để lấy ngày
        JOIN GIAY g ON ct.MAGIAY = g.MAGIAY
        WHERE 1=1 ";

            if (rdoTheoNgay.Checked)
                query += " AND DAY(hd.NGAYLAP) = @Day AND MONTH(hd.NGAYLAP) = @Month AND YEAR(hd.NGAYLAP) = @Year";
            else if (rdoTheoThang.Checked)
                query += " AND MONTH(hd.NGAYLAP) = @Month AND YEAR(hd.NGAYLAP) = @Year";
            else if (rdoKhoangTG.Checked)
                query += " AND hd.NGAYLAP BETWEEN @FromDate AND @ToDate";

            query += " GROUP BY g.TENGIAY ORDER BY SUM(ct.SOLUONG) DESC";

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (rdoTheoNgay.Checked)
                    {
                        DateTime d = dtpNgay.Value;
                        cmd.Parameters.AddWithValue("@Day", d.Day);
                        cmd.Parameters.AddWithValue("@Month", d.Month);
                        cmd.Parameters.AddWithValue("@Year", d.Year);
                    }
                    else if (rdoTheoThang.Checked)
                    {
                        if (string.IsNullOrEmpty(txtNam.Text)) return;
                        cmd.Parameters.AddWithValue("@Month", cboThang.Text);
                        cmd.Parameters.AddWithValue("@Year", txtNam.Text.Trim());
                    }
                    else if (rdoKhoangTG.Checked)
                    {
                        DateTime tuNgay = dtpTuNgay.Value.Date;
                        DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                        cmd.Parameters.AddWithValue("@FromDate", tuNgay);
                        cmd.Parameters.AddWithValue("@ToDate", denNgay);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    dt.Columns.Add("STT", typeof(int));
                    for (int i = 0; i < dt.Rows.Count; i++) dt.Rows[i]["STT"] = i + 1;
                    data_top5sp.DataSource = dt;
                    data_top5sp.Columns["STT"].HeaderText = "STT";
                    data_top5sp.Columns["TENGIAY"].HeaderText = "Tên giày";
                    data_top5sp.Columns["TENGIAY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    data_top5sp.Columns["SoLuongBan"].HeaderText = "Số lượng bán";

                    data_top5sp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Top 5: " + ex.Message); }
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

        private void rdoTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInputState();
        }

        private void rdoTheoThang_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInputState();
        }

        private void rdoKhoangTG_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInputState();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
            LoadTop5SanPham();
        }
    }
}
