
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
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using DocumentFormat.OpenXml.Office2010.Drawing;

namespace QuanLiBanGiay
{
    public partial class Form_NhanVien : Form
    {
        SqlConnection conn;
        DataSet ds_NhanVien = new DataSet();
        SqlDataAdapter da_nv;
        bool isEditing = false; 
        bool isAdding = false;  

        public Form_NhanVien()
        {
            conn = DBConnection.GetConnection();
            InitializeComponent();
        }

        private void grpDanhSach_Enter(object sender, EventArgs e)
        {
          
        }

        private void Form_NhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            InitializeComboBoxes();
            SetInitialState(); 
        }

        private void InitializeComboBoxes()
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("Thu ngân");
            cboVaiTro.Items.Add("Quản lý kho");

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Vô hiệu hóa");
        }

        private void SetInitialState()
        {
            
            SetInputsEnabled(false);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            isEditing = false;
            isAdding = false;
        }

        private void SetInputsEnabled(bool enabled)
        {
            
            txtMaNV.Enabled = enabled;
            txtTenNV.Enabled = enabled;
            cbGioiTinh.Enabled = enabled;
            dtNgaySinh.Enabled = enabled;
            txtSDT.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            dtNgayVaoLam.Enabled = enabled;
            txtTaiKhoan.Enabled = enabled;
            txtMatKhau.Enabled = enabled;
            cboVaiTro.Enabled = enabled;
            cboTrangThai.Enabled = enabled;
        }

        private void LoadNhanVien()
        {
            try
            {
                
                string query = @"SELECT NV.MANV, NV.TENNV, NV.GIOITINH, NV.NGAYSINH, NV.SDT, NV.DIACHI, NV.NGAYVAOLAM,
                                 TK.TENDANGNHAP AS TAIKHOAN, TK.MATKHAU, TK.VAITRO, TK.TRANGTHAI
                                 FROM NHANVIEN NV, TAIKHOAN TK
                                 WHERE NV.MANV = TK.MANV";
                da_nv = new SqlDataAdapter(query, conn);
                ds_NhanVien.Clear();
                da_nv.Fill(ds_NhanVien, "NHANVIEN");
                dgvNhanVien.DataSource = ds_NhanVien.Tables["NHANVIEN"];
                if (dgvNhanVien.Columns.Count > 0)
                {
                    dgvNhanVien.Columns["MANV"].HeaderText = "Mã NV";
                    dgvNhanVien.Columns["TENNV"].HeaderText = "Tên NV";
                    dgvNhanVien.Columns["GIOITINH"].HeaderText = "Giới Tính";
                    dgvNhanVien.Columns["NGAYSINH"].HeaderText = "Ngày Sinh";
                    dgvNhanVien.Columns["SDT"].HeaderText = "SĐT";
                    dgvNhanVien.Columns["DIACHI"].HeaderText = "Địa Chỉ";
                    dgvNhanVien.Columns["NGAYVAOLAM"].HeaderText = "Ngày vào làm";
                    if (dgvNhanVien.Columns.Contains("TAIKHOAN"))
                    {
                        dgvNhanVien.Columns["TAIKHOAN"].HeaderText = "Tài Khoản";
                    }
                    if (dgvNhanVien.Columns.Contains("MATKHAU"))
                    {
                        dgvNhanVien.Columns["MATKHAU"].HeaderText = "Mật Khẩu";
                    }
                    if (dgvNhanVien.Columns.Contains("VAITRO"))
                    {
                        dgvNhanVien.Columns["VAITRO"].HeaderText = "Vai Trò";
                    }
                    if (dgvNhanVien.Columns.Contains("TRANGTHAI"))
                    {
                        dgvNhanVien.Columns["TRANGTHAI"].HeaderText = "Trạng Thái";
                    }
                }

                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MANV"].Value?.ToString();
                txtTenNV.Text = row.Cells["TENNV"].Value?.ToString();
                cbGioiTinh.Text = row.Cells["GIOITINH"].Value?.ToString();
                txtTaiKhoan.Text = row.Cells["TAIKHOAN"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MATKHAU"].Value?.ToString();
                cboVaiTro.Text = row.Cells["VAITRO"].Value?.ToString();
                cboTrangThai.Text = row.Cells["TRANGTHAI"].Value?.ToString();
                if (row.Cells["NGAYSINH"].Value != null && row.Cells["NGAYSINH"].Value != DBNull.Value)
                {
                    if (DateTime.TryParse(row.Cells["NGAYSINH"].Value.ToString(), out DateTime ngaySinh))
                    {
                        dtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dtNgaySinh.Text = row.Cells["NGAYSINH"].Value?.ToString();
                    }
                }
                else
                {
                    dtNgaySinh.Text = "";
                }

                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value?.ToString();
                if (row.Cells["NGAYVAOLAM"].Value != null && row.Cells["NGAYVAOLAM"].Value != DBNull.Value)
                {
                    if (DateTime.TryParse(row.Cells["NGAYVAOLAM"].Value.ToString(), out DateTime ngayVaoLam))
                    {
                        dtNgayVaoLam.Text = ngayVaoLam.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dtNgayVaoLam.Text = row.Cells["NGAYVAOLAM"].Value?.ToString();
                    }
                }
                else
                {
                    dtNgayVaoLam.Text = "";
                }
                SetInputsEnabled(false);
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                isEditing = false;
                isAdding = false;
            }
        }
        private void ResetForm()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            cbGioiTinh.SelectedIndex = -1;
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            isEditing = false;
            isAdding = false;
            dgvNhanVien.ClearSelection();
            SetInputsEnabled(false);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Focus();
        }
        private bool ValidateInput(out DateTime? parsedNgaySinh)
        {
            parsedNgaySinh = null;
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbGioiTinh.Text))
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbGioiTinh.Focus();
                return false;
            }


            return true;
        }
        private string TaoMaNVTuDong()
        {
            string maMoi = "NV001";
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT TOP 1 MANV FROM NHANVIEN ORDER BY LEN(MANV) DESC, MANV DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string maCu = result.ToString(); 
                        string phanSo = maCu.Substring(2);
                        if (int.TryParse(phanSo, out int soThuTu))
                        {
                            soThuTu++;
                            maMoi = "NV" + soThuTu.ToString("D3");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã tự động: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return maMoi;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            SetInputsEnabled(true);
            txtMaNV.Text = TaoMaNVTuDong(); 
            txtMaNV.Enabled = false;
            txtTenNV.Focus();         
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNV.Clear();
            txtTenNV.Clear();
            cbGioiTinh.SelectedIndex = -1;
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtNgayVaoLam.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isEditing = true;
            isAdding = false;
            SetInputsEnabled(true);
            txtMaNV.Enabled = false; 
            btnLuu.Enabled = true;
            btnSua.Enabled = false; 
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?\n(Việc xóa có thể ảnh hưởng đến dữ liệu liên quan!)",
                                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No) return;

            try
            {
                string check = "SELECT COUNT(*) FROM HOADON WHERE MANV = @manv";
                SqlCommand cmdCheck = new SqlCommand(check, conn);
                cmdCheck.Parameters.AddWithValue("@manv", txtMaNV.Text.Trim());
                DBConnection.OpenConnection(conn);
                int count = (int)cmdCheck.ExecuteScalar();
                DBConnection.CloseConnection(conn);
                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa nhân viên này vì đang có hóa đơn liên quan!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                DBConnection.OpenConnection(conn);
                string sqlTK = "DELETE FROM TAIKHOAN WHERE MANV = @manv";
                SqlCommand cmdTK = new SqlCommand(sqlTK, conn);
                cmdTK.Parameters.AddWithValue("@manv", txtMaNV.Text.Trim());
                cmdTK.ExecuteNonQuery();
                string sql = "DELETE FROM NHANVIEN WHERE MANV = @manv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", txtMaNV.Text.Trim());
                cmd.ExecuteNonQuery();
                DBConnection.CloseConnection(conn);
                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhanVien();
                ResetForm();
            }
            catch (Exception ex)
            {
                DBConnection.CloseConnection(conn);
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                if (string.IsNullOrEmpty(txtMaNV.Text))
                    txtMaNV.Text = TaoMaNVTuDong();

                if (!ValidateInput(out DateTime? parsedNgaySinh)) return;

                try
                {
                    string checkSql = "SELECT COUNT(*) FROM NHANVIEN WHERE MANV = @manv";
                    SqlCommand cmdCheck = new SqlCommand(checkSql, conn);
                    cmdCheck.Parameters.AddWithValue("@manv", txtMaNV.Text.Trim());
                    DBConnection.OpenConnection(conn);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        DBConnection.CloseConnection(conn);
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaNV.Focus();
                        return;
                    }
                    DateTime ngayVaoLam = DateTime.Now;
                    if (!string.IsNullOrWhiteSpace(dtNgayVaoLam.Text))
                    {
                        if (!DateTime.TryParseExact(dtNgayVaoLam.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tmpNgayVao))
                        {
                            tmpNgayVao = DateTime.Now;
                        }
                        ngayVaoLam = tmpNgayVao;
                    }
                    string sqlNV = @"INSERT INTO NHANVIEN (MANV, TENNV, GIOITINH, NGAYSINH, SDT, DIACHI, NGAYVAOLAM)
                                    VALUES (@manv, @tennv, @gioitinh, @ngaysinh, @sdt, @diachi, @ngayvaolam)";

                    SqlCommand cmdNV = new SqlCommand(sqlNV, conn);
                    cmdNV.Parameters.AddWithValue("@manv", txtMaNV.Text.Trim());
                    cmdNV.Parameters.AddWithValue("@tennv", txtTenNV.Text.Trim());
                    cmdNV.Parameters.AddWithValue("@gioitinh", cbGioiTinh.Text);

                    if (parsedNgaySinh.HasValue)
                        cmdNV.Parameters.AddWithValue("@ngaysinh", parsedNgaySinh.Value);
                    else
                        cmdNV.Parameters.AddWithValue("@ngaysinh", DBNull.Value);

                    cmdNV.Parameters.AddWithValue("@sdt", string.IsNullOrWhiteSpace(txtSDT.Text) ? (object)DBNull.Value : txtSDT.Text.Trim());
                    cmdNV.Parameters.AddWithValue("@diachi", string.IsNullOrWhiteSpace(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim());
                    cmdNV.Parameters.AddWithValue("@ngayvaolam", ngayVaoLam);
                    cmdNV.ExecuteNonQuery();
                    string taiKhoan = txtTaiKhoan.Text.Trim();
                    if (string.IsNullOrWhiteSpace(taiKhoan))
                        taiKhoan = txtMaNV.Text.Trim().ToLower();

                    string matKhau = txtMatKhau.Text.Trim();
                    string vaiTro = cboVaiTro.Text.Trim();
                    string trangThai = cboTrangThai.Text.Trim();
                    string checkTKSql = "SELECT COUNT(*) FROM TAIKHOAN WHERE TENDANGNHAP = @tendangnhap";
                    SqlCommand cmdCheckTK = new SqlCommand(checkTKSql, conn);
                    cmdCheckTK.Parameters.AddWithValue("@tendangnhap", taiKhoan);
                    int countTK = (int)cmdCheckTK.ExecuteScalar();

                    if (countTK == 0)
                    {
                        string sqlTK = @"INSERT INTO TAIKHOAN (TENDANGNHAP, MATKHAU, MANV, VAITRO, TRANGTHAI, NGAYTAO)
                                        VALUES (@tendangnhap, @matkhau, @manv, @vaitro, @trangthai, @ngaytao)";

                        SqlCommand cmdTK = new SqlCommand(sqlTK, conn);
                        cmdTK.Parameters.AddWithValue("@tendangnhap", taiKhoan);
                        cmdTK.Parameters.AddWithValue("@matkhau", matKhau);
                        cmdTK.Parameters.AddWithValue("@manv", txtMaNV.Text.Trim());
                        cmdTK.Parameters.AddWithValue("@vaitro", vaiTro);
                        cmdTK.Parameters.AddWithValue("@trangthai", trangThai);
                        cmdTK.Parameters.AddWithValue("@ngaytao", DateTime.Now);

                        cmdTK.ExecuteNonQuery();
                    }

                    DBConnection.CloseConnection(conn);

                    MessageBox.Show("Thêm nhân viên thành công!\nTài khoản: " + taiKhoan + "\nMật khẩu: " + matKhau,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    DBConnection.CloseConnection(conn);
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (isEditing)
            {
                if (!ValidateInput(out DateTime? parsedNgaySinh))
                    return;

                try
                {

                    string sql = @"UPDATE NHANVIEN 
                                   SET TENNV = @tennv, 
                                       GIOITINH = @gioitinh, 
                                       NGAYSINH = @ngaysinh,
                                       SDT = @sdt, 
                                       DIACHI = @diachi
                                   WHERE MANV = @manv";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text.Trim());
                    cmd.Parameters.AddWithValue("@gioitinh", cbGioiTinh.Text);

                    if (parsedNgaySinh.HasValue)
                        cmd.Parameters.AddWithValue("@ngaysinh", parsedNgaySinh.Value);
                    else
                        cmd.Parameters.AddWithValue("@ngaysinh", DBNull.Value);

                    cmd.Parameters.AddWithValue("@sdt", string.IsNullOrWhiteSpace(txtSDT.Text) ? (object)DBNull.Value : txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@diachi", string.IsNullOrWhiteSpace(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim());

                    DBConnection.OpenConnection(conn);
                    cmd.ExecuteNonQuery();
                    DBConnection.CloseConnection(conn);

                    MessageBox.Show("Sửa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhanVien();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    DBConnection.CloseConnection(conn);
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có thao tác để lưu. Vui lòng chọn Thêm hoặc Sửa trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //private void btnXuatExcel_Click(object sender, EventArgs e)
        //{
        //    if (dgvNhanVien.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    SaveFileDialog save = new SaveFileDialog();
        //    save.Filter = "Excel File (*.xlsx)|*.xlsx";
        //    save.Title = "Chọn nơi lưu file Excel";
        //    save.FileName = "DanhSach_NhanVien_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".xlsx";

        //    if (save.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            var workbook = new XLWorkbook();
        //            var worksheet = workbook.Worksheets.Add("Danh sách nhân viên");

        //            // Tiêu đề
        //            worksheet.Cell(1, 1).Value = "DANH SÁCH NHÂN VIÊN";
        //            worksheet.Range(1, 1, 1, dgvNhanVien.Columns.Count).Merge();
        //            worksheet.Cell(1, 1).Style.Font.Bold = true;
        //            worksheet.Cell(1, 1).Style.Font.FontSize = 16;
        //            worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        //            for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
        //            {
        //                worksheet.Cell(3, i + 1).Value = dgvNhanVien.Columns[i].HeaderText;
        //                worksheet.Cell(3, i + 1).Style.Font.Bold = true;
        //                worksheet.Cell(3, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
        //            }

        //            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
        //            {
        //                for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
        //                {
        //                    worksheet.Cell(i + 4, j + 1).Value = dgvNhanVien.Rows[i].Cells[j].Value?.ToString();
        //                }
        //            }

        //            worksheet.Columns().AdjustToContents(); // Tự căn chỉnh độ rộng

        //            workbook.SaveAs(save.FileName);
        //            MessageBox.Show("Xuất Excel thành công!\nĐường dẫn: " + save.FileName,
        //                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSĐT_Click(object sender, EventArgs e)
        {

        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {

        }
    }
}

