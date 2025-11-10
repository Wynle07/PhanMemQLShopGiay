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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLiBanGiay
{
    public partial class Form_NhaCungCap : Form
    {
        SqlConnection conn;
        DataSet ds_NCC = new DataSet();
        SqlDataAdapter da_ncc;
        public Form_NhaCungCap()
        {
            conn = DBConnection.GetConnection();
            InitializeComponent();
        }

        private void Form_NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang hợp tác");
            cboTrangThai.Items.Add("Ngừng hợp tác");
        }
        private void LoadNhaCungCap(string search = "")
        {
            try
            {
                string sql = @"SELECT MANCC, TENNCC, SDT AS Hotline, EMAIL, DIACHI, TRANGTHAI 
                       FROM NHACUNGCAP";

                if (!string.IsNullOrWhiteSpace(search))
                {
                    sql += @" WHERE MANCC LIKE @search 
                   OR TENNCC LIKE @search 
                   OR SDT LIKE @search 
                   OR EMAIL LIKE @search 
                   OR DIACHI LIKE @search";
                }

                da_ncc = new SqlDataAdapter(sql, conn);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    da_ncc.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                }

                ds_NCC.Clear();
                da_ncc.Fill(ds_NCC, "NHACUNGCAP");
                data_ncc.DataSource = ds_NCC.Tables["NHACUNGCAP"];

                // Tiêu đề cột
                data_ncc.Columns["MANCC"].HeaderText = "Mã NCC";
                data_ncc.Columns["TENNCC"].HeaderText = "Tên NCC";
                data_ncc.Columns["Hotline"].HeaderText = "Hotline";
                data_ncc.Columns["EMAIL"].HeaderText = "Email";
                data_ncc.Columns["DIACHI"].HeaderText = "Địa chỉ";
                data_ncc.Columns["TRANGTHAI"].HeaderText = "Trạng thái";

                data_ncc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = data_ncc.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["MANCC"].Value?.ToString();
                cbTenNCC.Text = row.Cells["TENNCC"].Value?.ToString();
                txtHotline.Text = row.Cells["Hotline"].Value?.ToString();
                txtEmail.Text = row.Cells["EMAIL"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value?.ToString();
                cboTrangThai.Text = row.Cells["TRANGTHAI"].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) ||
                string.IsNullOrWhiteSpace(cbTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NCC và Tên NCC!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra trùng mã
                string checkSql = "SELECT COUNT(*) FROM NHACUNGCAP WHERE MANCC = @mancc";
                SqlCommand cmdCheck = new SqlCommand(checkSql, conn);
                cmdCheck.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                conn.Open();
                int count = (int)cmdCheck.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    MessageBox.Show("Mã NCC đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sql = @"INSERT INTO NHACUNGCAP (MANCC, TENNCC, SDT, EMAIL, DIACHI, TRANGTHAI)
                               VALUES (@mancc, @tenncc, @sdt, @email, @diachi, @trangthai)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tenncc", cbTenNCC.Text);
                cmd.Parameters.AddWithValue("@sdt", txtHotline.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@trangthai", cboTrangThai.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap();
                ResetForm();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            txtMaNCC.Clear();
            cbTenNCC.Text = "";
            txtHotline.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            cboTrangThai.SelectedIndex = -1;
            txt_TimKiem.Clear();
            txtMaNCC.Focus();
            data_ncc.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"UPDATE NHACUNGCAP 
                               SET TENNCC = @tenncc, 
                                   SDT = @sdt, 
                                   EMAIL = @email, 
                                   DIACHI = @diachi, 
                                   TRANGTHAI = @trangthai 
                               WHERE MANCC = @mancc";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tenncc", cbTenNCC.Text);
                cmd.Parameters.AddWithValue("@sdt", txtHotline.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@trangthai", cboTrangThai.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Sửa nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?\n(Việc xóa có thể ảnh hưởng đến phiếu nhập!)",
                                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No) return;

            try
            {
                // Kiểm tra ràng buộc khóa ngoại (nếu NCC đang có trong phiếu nhập thì không cho xóa)
                string check = "SELECT COUNT(*) FROM PHIEUNHAP WHERE MANCC = @mancc";
                SqlCommand cmdCheck = new SqlCommand(check, conn);
                cmdCheck.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                conn.Open();
                int count = (int)cmdCheck.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa NCC này vì đang có phiếu nhập liên quan!\nBạn có thể đổi trạng thái thành 'Ngừng hợp tác'.",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string sql = "DELETE FROM NHACUNGCAP WHERE MANCC = @mancc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap();
                ResetForm();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (data_ncc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Workbook|*.xlsx";
            save.Title = "Xuất danh sách nhà cung cấp";
            save.FileName = "DanhSach_NhaCungCap_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add();
                    Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

                    // Tiêu đề
                    ws.Cells[1, 1] = "DANH SÁCH NHÀ CUNG CẤP";
                    ws.Range["A1:F1"].Merge();
                    ws.Range["A1:F1"].Font.Bold = true;
                    ws.Range["A1:F1"].Font.Size = 16;
                    ws.Range["A1:F1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    // Header
                    for (int i = 0; i < data_ncc.Columns.Count; i++)
                    {
                        ws.Cells[3, i + 1] = data_ncc.Columns[i].HeaderText;
                        ws.Cells[3, i + 1].Font.Bold = true;
                        ws.Cells[3, i + 1].Interior.Color = Color.LightGray;
                    }

                    // Dữ liệu
                    for (int i = 0; i < data_ncc.Rows.Count; i++)
                    {
                        for (int j = 0; j < data_ncc.Columns.Count; j++)
                        {
                            ws.Cells[i + 4, j + 1] = data_ncc.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Auto fit cột
                    ws.Columns.AutoFit();

                    // Lưu file
                    wb.SaveAs(save.FileName);
                    wb.Close();
                    app.Quit();

                    MessageBox.Show("Xuất Excel thành công!\nĐường dẫn: " + save.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            LoadNhaCungCap(txt_TimKiem.Text.Trim());
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadNhaCungCap(txt_TimKiem.Text.Trim());
        }
    }
}
