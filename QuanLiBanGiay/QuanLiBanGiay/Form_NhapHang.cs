using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanGiay
{
    public partial class Form__NhapHang : Form
    {
        SqlConnection conn;
        DataSet ds_pn = new DataSet();
        private DataTable dtChiTiet = new DataTable();
        private DataTable dtSanPham;

        public Form__NhapHang()
        {
            InitializeComponent();
            conn = DBConnection.GetConnection();
            KhoiTaoBangChiTiet();
        }

        private void Form__NhapHang_Load(object sender, EventArgs e)
        {
            ThietLapTrangThaiBanDau();
            LoadNhaCC();
            LoadSanPham();
            HienThiMaNhanVienDangNhap();
        }
        private void LoadNhaCC()
        {
            try
            {
                string strsql = @"SELECT MANCC, TENNCC FROM NHACUNGCAP";
                using (SqlDataAdapter da_pn = new SqlDataAdapter(strsql, conn))
                {
                    ds_pn.Tables.Clear();
                    da_pn.Fill(ds_pn, "NHACUNGCAP");
                    cboNCC.DataSource = ds_pn.Tables["NHACUNGCAP"];
                    cboNCC.DisplayMember = "TENNCC";
                    cboNCC.ValueMember = "MANCC";
                    cboNCC.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách nhà cung cấp. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadSanPham()
        {
            try
            {
                string sql = @"SELECT MAGIAY, TENGIAY, GIABAN FROM GIAY";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    dtSanPham = new DataTable();
                    da.Fill(dtSanPham);
                    cboMaSP.DataSource = dtSanPham;
                    cboMaSP.DisplayMember = "TENGIAY";
                    cboMaSP.ValueMember = "MAGIAY";
                    cboMaSP.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sản phẩm. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhoiTaoBangChiTiet()
        {
            dtChiTiet.Columns.Add("MaSP", typeof(string));
            dtChiTiet.Columns.Add("TenSP", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("DonGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvCTPN.AutoGenerateColumns = false;
            if (dgvCTPN.Columns.Count == 0)
            {
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaSP",
                    HeaderText = "Mã sản phẩm",
                    Width = 100
                });
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenSP",
                    HeaderText = "Tên sản phẩm",
                    Width = 200
                });
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SoLuong",
                    HeaderText = "Số lượng",
                    Width = 80
                });
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DonGia",
                    HeaderText = "Đơn giá",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ThanhTien",
                    HeaderText = "Thành tiền",
                    Width = 170,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
            }

            dgvCTPN.DataSource = dtChiTiet;
        }

        private void ThietLapTrangThaiBanDau()
        {
            txtMaPhieuNhap.Clear();
            txtNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTongTien.Text = "0";
            txtThanhTien.Text = "0";
            txtSoLuong.Clear();
            txtDonGia.Clear();
            cboNCC.Enabled = true;
            cboNCC.SelectedIndex = -1;
            cboMaSP.SelectedIndex = -1;
            grpCTPhieuNhap.Enabled = false;
            dgvCTPN.Enabled = false;
            btnLuuPN.Enabled = false;
            btnTaoPN.Enabled = true;
            dtChiTiet.Clear();
        }

        private void HienThiMaNhanVienDangNhap()
        {
            txtMaNV.Text = global::QuanLiBanGiay.SessionContext.MaNhanVien ?? string.Empty;
        }

        private void grpPhieuNhap_Enter(object sender, EventArgs e)
        {

        }

        private void txtMaPhieuNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNgayNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTaoPN_Click(object sender, EventArgs e)
        {
            if (cboNCC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp trước khi tạo phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNCC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Không xác định được mã nhân viên phụ trách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maPN = TaoMaPhieuMoi();
                txtMaPhieuNhap.Text = maPN;
                grpCTPhieuNhap.Enabled = true;
                dgvCTPN.Enabled = true;
                btnLuuPN.Enabled = true;
                btnTaoPN.Enabled = false;
                cboNCC.Enabled = false;
                txtNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
                dtChiTiet.Clear();
                CapNhatTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo mã phiếu nhập mới. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoMaPhieuMoi()
        {
            const string prefix = "PN";
            int nextNumber = 1;
            string sql = "SELECT TOP 1 MAPN FROM PHIEUNHAP ORDER BY MAPN DESC";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                DBConnection.OpenConnection(connection);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string lastCode = result.ToString();
                    if (lastCode.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    {
                        string numericPart = lastCode.Substring(prefix.Length);
                        if (int.TryParse(numericPart, out int currentNumber))
                        {
                            nextNumber = currentNumber + 1;
                        }
                    }
                }
            }
            return $"{prefix}{nextNumber:000}";
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedItem is DataRowView row)
            {
                object value = row["GIABAN"];
                if (value != DBNull.Value)
                {
                    decimal donGia = Convert.ToDecimal(value);
                    txtDonGia.Text = donGia.ToString("0");
                }
                else
                {
                    txtDonGia.Clear();
                }
            }
            else
            {
                txtDonGia.Clear();
            }
            TinhThanhTien();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            if (int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) && decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia))
            {
                if (soLuong > 0 && donGia >= 0)
                {
                    decimal thanhTien = soLuong * donGia;
                    txtThanhTien.Text = thanhTien.ToString("0");
                    return;
                }
            }
            txtThanhTien.Text = "0";
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaSP.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            string maSP = cboMaSP.SelectedValue.ToString();
            string tenSP = cboMaSP.Text;
            decimal thanhTien = soLuong * donGia;

            DataRow existingRow = dtChiTiet.AsEnumerable()
                                           .FirstOrDefault(row => string.Equals(row.Field<string>("MaSP"), maSP, StringComparison.OrdinalIgnoreCase));

            if (existingRow == null)
            {
                dtChiTiet.Rows.Add(maSP, tenSP, soLuong, donGia, thanhTien);
            }
            else
            {
                existingRow["SoLuong"] = soLuong;
                existingRow["DonGia"] = donGia;
                existingRow["ThanhTien"] = thanhTien;
            }

            CapNhatTongTien();
            LamMoiNhapChiTiet();
        }

        private void LamMoiNhapChiTiet()
        {
            cboMaSP.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Text = "0";
            cboMaSP.Focus();
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in dtChiTiet.Rows)
            {
                if (row["ThanhTien"] != DBNull.Value)
                {
                    tong += Convert.ToDecimal(row["ThanhTien"]);
                }
            }
            txtTongTien.Text = tong.ToString("0");
        }

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNCC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPN = txtMaPhieuNhap.Text.Trim();
            string maNV = txtMaNV.Text.Trim();
            string maNCC = cboNCC.SelectedValue.ToString();
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayNhap;
            if (!DateTime.TryParseExact(txtNgayNhap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayNhap))
            {
                ngayNhap = DateTime.Now;
            }

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                DBConnection.OpenConnection(connection);
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand cmdPN = new SqlCommand("INSERT INTO PHIEUNHAP (MAPN, NGAYNHAP, MANV, MANCC) VALUES (@mapn, @ngaynhap, @manv, @mancc)", connection, transaction))
                    {
                        cmdPN.Parameters.AddWithValue("@mapn", maPN);
                        cmdPN.Parameters.AddWithValue("@ngaynhap", ngayNhap);
                        cmdPN.Parameters.AddWithValue("@manv", maNV);
                        cmdPN.Parameters.AddWithValue("@mancc", maNCC);
                        cmdPN.ExecuteNonQuery();
                    }

                    foreach (DataRow row in dtChiTiet.Rows)
                    {
                        using (SqlCommand cmdCT = new SqlCommand("INSERT INTO CTPHIEUNHAP (MAPN, MAGIAY, SOLUONG, GIABAN) VALUES (@mapn, @masp, @soluong, @dongia)", connection, transaction))
                        {
                            cmdCT.Parameters.AddWithValue("@mapn", maPN);
                            cmdCT.Parameters.AddWithValue("@masp", row["MaSP"]);
                            cmdCT.Parameters.AddWithValue("@soluong", row["SoLuong"]);
                            cmdCT.Parameters.AddWithValue("@dongia", row["DonGia"]);
                            cmdCT.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThietLapTrangThaiBanDau();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu phiếu nhập. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
