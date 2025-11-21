using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLiBanGiay
{
    public partial class Form_KhachHang : Form
    {
        SqlConnection conn;
        SqlDataAdapter da_kh;
        DataTable dt_kh;

        public Form_KhachHang()
        {
            InitializeComponent();
            conn = DBConnection.GetConnection();
        }

        private void Form_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKH();
         
        }

        private void LoadKH()
        {
            try
            {
                string sql = "SELECT * FROM KHACHHANG";
                da_kh = new SqlDataAdapter(sql, conn);
                dt_kh = new DataTable();
                da_kh.Fill(dt_kh);
                dgvKhachHang.DataSource = dt_kh;

                // Thiết lập header
                dgvKhachHang.Columns["MAKH"].HeaderText = "Mã KH";
                dgvKhachHang.Columns["TENKH"].HeaderText = "Tên khách hàng";
                dgvKhachHang.Columns["SDT"].HeaderText = "SĐT";
                dgvKhachHang.Columns["EMAIL"].HeaderText = "Email";
                dgvKhachHang.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgvKhachHang.Columns["DIEMTICHLUY"].HeaderText = "Điểm TL";
                dgvKhachHang.Columns["NGAYTAO"].HeaderText = "Ngày tạo";

                // Nếu có dữ liệu thì hiển thị dòng đầu tiên
                if (dt_kh.Rows.Count > 0)
                {
                    dgvKhachHang.ClearSelection();
                    dgvKhachHang.Rows[0].Selected = true;
                    ShowCurrentRowToTextbox(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void ShowCurrentRowToTextbox(int index)
        {
            if (index < 0 || index >= dgvKhachHang.Rows.Count)
                return;

            DataGridViewRow row = dgvKhachHang.Rows[index];
            txtMaKH.Text = row.Cells["MAKH"].Value?.ToString() ?? "";
            txtTenKH.Text = row.Cells["TENKH"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["EMAIL"].Value?.ToString() ?? "";
            txtDiaChi.Text = row.Cells["DIACHI"].Value?.ToString() ?? "";
            txtDiemTL.Text = row.Cells["DIEMTICHLUY"].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["NGAYTAO"].Value?.ToString(), out DateTime ngay))
                dtpNgayTao.Value = ngay;
            else
                dtpNgayTao.Value = DateTime.Now;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                ShowCurrentRowToTextbox(e.RowIndex);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string makh = txtMaKH.Text.Trim();
                string tenkh = txtTenKH.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diachi = txtDiaChi.Text.Trim();
                string diemText = txtDiemTL.Text.Trim();

                if (string.IsNullOrEmpty(makh) || string.IsNullOrEmpty(tenkh) ||
                    string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                if (!int.TryParse(diemText, out int diemTL) || diemTL < 0)
                {
                    MessageBox.Show("Điểm tích lũy không hợp lệ!");
                    return;
                }

                // Kiểm tra trùng mã
                using (SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG WHERE MAKH=@ma", conn))
                {
                    check.Parameters.AddWithValue("@ma", makh);
                    conn.Open();
                    int exists = (int)check.ExecuteScalar();
                    conn.Close();
                    if (exists > 0)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại!");
                        return;
                    }
                }

                // Thêm mới
                string sql = @"INSERT INTO KHACHHANG(MAKH, TENKH, SDT, EMAIL, DIACHI, DIEMTICHLUY, NGAYTAO)
                               VALUES(@MAKH, @TENKH, @SDT, @EMAIL, @DIACHI, @DIEMTICHLUY, @NGAYTAO)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MAKH", makh);
                    cmd.Parameters.AddWithValue("@TENKH", tenkh);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@DIACHI", diachi);
                    cmd.Parameters.AddWithValue("@DIEMTICHLUY", diemTL);
                    cmd.Parameters.AddWithValue("@NGAYTAO", dtpNgayTao.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadKH();
                // Focus lại vào dòng vừa thêm
                int newIndex = dgvKhachHang.Rows.Count - 1;
                dgvKhachHang.ClearSelection();
                dgvKhachHang.Rows[newIndex].Selected = true;
                ShowCurrentRowToTextbox(newIndex);

                MessageBox.Show("✅ Thêm khách hàng thành công!");
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("❌ Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cho phép sửa các textbox
            txtTenKH.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtDiemTL.ReadOnly = false;
            dtpNgayTao.Enabled = true;

            // Hiện nút Lưu
            btnLuu.Visible = true;
            btnLuu.Enabled = true;

            // Ẩn nút Sửa để tránh nhấn lại
            btnSua.Enabled = false;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string makh = txtMaKH.Text.Trim();
                if (string.IsNullOrEmpty(makh))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
                    return;
                }

                DialogResult r = MessageBox.Show($"Bạn có chắc muốn xóa [{makh}] không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;

                using (SqlCommand cmd = new SqlCommand("DELETE FROM KHACHHANG WHERE MAKH=@ma", conn))
                {
                    cmd.Parameters.AddWithValue("@ma", makh);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadKH();
                MessageBox.Show("🗑️ Xóa thành công!");
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("❌ Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string kw = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(kw))
                {
                    LoadKH();
                    return;
                }

                string sql = @"SELECT * FROM KHACHHANG
                               WHERE MAKH LIKE @kw OR TENKH LIKE @kw OR SDT LIKE @kw OR EMAIL LIKE @kw";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", "%" + kw + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKhachHang.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    dgvKhachHang.ClearSelection();
                    dgvKhachHang.Rows[0].Selected = true;
                    ShowCurrentRowToTextbox(0);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtDiemTL.Clear();
            txtTimKiem.Clear();
            dtpNgayTao.Value = DateTime.Now;
            LoadKH();
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKhachHang.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở Excel
                Excel.Application app = new Excel.Application();
                app.Visible = false;
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel.Worksheet ws = wb.ActiveSheet;
                ws.Name = "Danh sách khách hàng";

                // Ghi tiêu đề cột
                for (int i = 0; i < dgvKhachHang.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1] = dgvKhachHang.Columns[i].HeaderText;
                    ws.Cells[1, i + 1].Font.Bold = true;
                }

                // Ghi dữ liệu
                for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKhachHang.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] = dgvKhachHang.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                // Tự động chỉnh độ rộng
                ws.Columns.AutoFit();

                // Chọn nơi lưu
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File (*.xlsx)|*.xlsx";
                sfd.FileName = "DanhSachKhachHang.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfd.FileName);
                    wb.Close();
                    app.Quit();
                    MessageBox.Show("✅ Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    wb.Close(false);
                    app.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xóaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoa.PerformClick();

        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXemIn.PerformClick();

        }

        private void sửaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui vòng điền thông tin cần sửa!!!", "Thông báo", MessageBoxButtons.OK);
            txtTenKH.Focus();
            btnSua.PerformClick();
        }

        private void thêmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtDiemTL.Clear();
            dtpNgayTao.Value = DateTime.Now;

            txtMaKH.Focus();
        }


        private void dgvKhachHang_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvKhachHang.ClearSelection();
                dgvKhachHang.Rows[e.RowIndex].Selected = true;
                ShowCurrentRowToTextbox(e.RowIndex);
            }
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRefesh.PerformClick();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            try
            {
                string makh = txtMaKH.Text.Trim();
                string tenkh = txtTenKH.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diachi = txtDiaChi.Text.Trim();
                string diemText = txtDiemTL.Text.Trim();

                if (string.IsNullOrEmpty(tenkh) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(diemText, out int diemTL) || diemTL < 0)
                {
                    MessageBox.Show("Điểm tích lũy không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = @"UPDATE KHACHHANG 
                       SET TENKH=@TENKH, SDT=@SDT, EMAIL=@EMAIL, DIACHI=@DIACHI,
                           DIEMTICHLUY=@DIEMTICHLUY, NGAYTAO=@NGAYTAO 
                       WHERE MAKH=@MAKH";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MAKH", makh);
                    cmd.Parameters.AddWithValue("@TENKH", tenkh);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@DIACHI", diachi);
                    cmd.Parameters.AddWithValue("@DIEMTICHLUY", diemTL);
                    cmd.Parameters.AddWithValue("@NGAYTAO", dtpNgayTao.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("✅ Cập nhật thành công!");

                // Load lại dữ liệu
                LoadKH();

                // Reset giao diện
                txtTenKH.ReadOnly = true;
                txtSDT.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtDiemTL.ReadOnly = true;
                dtpNgayTao.Enabled = false;

                btnLuu.Visible = false;
                btnSua.Enabled = true;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("❌ Lỗi khi lưu: " + ex.Message);
            }
        }

        
    }
}
