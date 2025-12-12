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

        private void LoadKichCoVaMauSac(string maGiay, bool resetSelection = true)
        {
            if (string.IsNullOrEmpty(maGiay)) return;

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    DBConnection.OpenConnection(connection);

                    // Load tất cả Size có trong CHITIETGIAY cho sản phẩm này
                    string sqlSize = @"SELECT DISTINCT ct.MASIZE, kc.KICHCO 
                                      FROM CHITIETGIAY ct 
                                      INNER JOIN KICHCO kc ON ct.MASIZE = kc.MASIZE
                                      WHERE ct.MAGIAY = @MAGIAY
                                      ORDER BY ct.MASIZE";

                    using (SqlCommand cmd = new SqlCommand(sqlSize, connection))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtSize = new DataTable();
                        da.Fill(dtSize);
                        
                        cboKichCo.DataSource = dtSize;
                        cboKichCo.DisplayMember = "KICHCO";
                        cboKichCo.ValueMember = "MASIZE";
                        if (resetSelection)
                            cboKichCo.SelectedIndex = -1;
                    }

                    // Load tất cả Màu có trong CHITIETGIAY cho sản phẩm này
                    string sqlMau = @"SELECT DISTINCT ct.MAMAU, ms.TENMAU 
                                     FROM CHITIETGIAY ct 
                                     INNER JOIN MAUSAC ms ON ct.MAMAU = ms.MAMAU
                                     WHERE ct.MAGIAY = @MAGIAY
                                     ORDER BY ct.MAMAU";

                    using (SqlCommand cmd = new SqlCommand(sqlMau, connection))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtMau = new DataTable();
                        da.Fill(dtMau);
                        
                        cboMauSac.DataSource = dtMau;
                        cboMauSac.DisplayMember = "TENMAU";
                        cboMauSac.ValueMember = "MAMAU";
                        if (resetSelection)
                            cboMauSac.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load size/màu: " + ex.Message);
            }
        }

        private void KhoiTaoBangChiTiet()
        {
            dtChiTiet.Columns.Add("MaSP", typeof(string));
            dtChiTiet.Columns.Add("TenSP", typeof(string));
            dtChiTiet.Columns.Add("MaSize", typeof(string));      // Mã size (để lưu vào DB)
            dtChiTiet.Columns.Add("TenSize", typeof(string));     // Tên size (để hiển thị)
            dtChiTiet.Columns.Add("MaMau", typeof(string));       // Mã màu (để lưu vào DB)
            dtChiTiet.Columns.Add("TenMau", typeof(string));      // Tên màu (để hiển thị)
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
                    Width = 150
                });
                // Cột MaSize - ẨN (để lấy dữ liệu khi click)
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaSize",
                    HeaderText = "MaSize",
                    Visible = false  // Ẩn cột này
                });
                // Cột TenSize - HIỂN THỊ
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenSize",
                    HeaderText = "Size",
                    Width = 80
                });
                // Cột MaMau - ẨN (để lấy dữ liệu khi click)
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaMau",
                    HeaderText = "MaMau",
                    Visible = false  // Ẩn cột này
                });
                // Cột TenMau - HIỂN THỊ
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenMau",
                    HeaderText = "Màu sắc",
                    Width = 100
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
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvCTPN.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ThanhTien",
                    HeaderText = "Thành tiền",
                    Width = 130,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
            }

            dgvCTPN.DataSource = dtChiTiet;
        }

        // Phương thức xóa dòng đang chọn trong DataGridView
        private void XoaDongChiTiet()
        {
            if (dgvCTPN.CurrentRow == null || dgvCTPN.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa dòng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                int rowIndex = dgvCTPN.CurrentRow.Index;
                
                // Xóa dòng
                dtChiTiet.Rows.RemoveAt(rowIndex);

                // Cập nhật tổng tiền
                CapNhatTongTien();

                MessageBox.Show("Đã xóa dòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThietLapTrangThaiBanDau()
        {
            txtMaPhieuNhap.Clear();
            txtMaPhieuNhap.ReadOnly = true;
            txtNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTongTien.Text = "0";
            txtThanhTien.Text = "0";
            txtSoLuong.Clear();
            txtDonGia.Clear();
            cboNCC.Enabled = true;
            cboNCC.SelectedIndex = -1;
            cboMaSP.SelectedIndex = -1;
            cboKichCo.SelectedIndex = -1;
            cboMauSac.SelectedIndex = -1;
            grpCTPhieuNhap.Enabled = false;
            dgvCTPN.Enabled = false;
            btnLuuPN.Enabled = false;
            btnTaoPN.Enabled = true;
            dtChiTiet.Clear();

            // Đặt lại DataSource cho DataGridView
            dgvCTPN.DataSource = dtChiTiet;
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

                // Load kích cỡ và màu sắc theo sản phẩm được chọn
                string maGiay = row["MAGIAY"].ToString();
                LoadKichCoVaMauSac(maGiay);
            }
            else
            {
                txtDonGia.Clear();
                cboKichCo.DataSource = null;
                cboMauSac.DataSource = null;
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

            if (cboKichCo.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn kích cỡ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKichCo.Focus();
                return;
            }

            if (cboMauSac.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn màu sắc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMauSac.Focus();
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
            string maSize = cboKichCo.SelectedValue.ToString();
            string tenSize = cboKichCo.Text;  // Lấy tên size để hiển thị
            string maMau = cboMauSac.SelectedValue.ToString();
            string tenMau = cboMauSac.Text;   // Lấy tên màu để hiển thị
            decimal thanhTien = soLuong * donGia;

            // Kiểm tra nếu đã có sản phẩm với cùng mã, size và màu
            DataRow existingRow = dtChiTiet.AsEnumerable()
                                           .FirstOrDefault(row => 
                                               string.Equals(row.Field<string>("MaSP"), maSP, StringComparison.OrdinalIgnoreCase) &&
                                               string.Equals(row.Field<string>("MaSize"), maSize, StringComparison.OrdinalIgnoreCase) &&
                                               string.Equals(row.Field<string>("MaMau"), maMau, StringComparison.OrdinalIgnoreCase));

            if (existingRow == null)
            {
                // Thêm mới: MaSP, TenSP, MaSize, TenSize, MaMau, TenMau, SoLuong, DonGia, ThanhTien
                dtChiTiet.Rows.Add(maSP, tenSP, maSize, tenSize, maMau, tenMau, soLuong, donGia, thanhTien);
            }
            else
            {
                // Nếu đã tồn tại, cộng dồn số lượng
                int soLuongCu = Convert.ToInt32(existingRow["SoLuong"]);
                int soLuongMoi = soLuongCu + soLuong;
                existingRow["SoLuong"] = soLuongMoi;
                existingRow["ThanhTien"] = soLuongMoi * donGia;
            }

            CapNhatTongTien();
            LamMoiNhapChiTiet();
        }

        private void LamMoiNhapChiTiet()
        {
            // Reset các control để nhập sản phẩm mới
            cboMaSP.SelectedIndex = -1;
            cboKichCo.SelectedIndex = -1;
            cboMauSac.SelectedIndex = -1;
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
            string tongtien = txtTongTien.Text.ToString();

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
                    // 1. Lưu phiếu nhập
                    using (SqlCommand cmdPN = new SqlCommand("INSERT INTO PHIEUNHAP (MAPN, NGAYNHAP, MANV, MANCC, TONGTIEN) VALUES (@mapn, @ngaynhap, @manv, @mancc, @tongtien)", connection, transaction))
                    {
                        cmdPN.Parameters.AddWithValue("@mapn", maPN);
                        cmdPN.Parameters.AddWithValue("@ngaynhap", ngayNhap);
                        cmdPN.Parameters.AddWithValue("@manv", maNV);
                        cmdPN.Parameters.AddWithValue("@mancc", maNCC);
                        cmdPN.Parameters.AddWithValue("@tongtien", tongtien);
                        cmdPN.ExecuteNonQuery();
                    }

                    // 2. Lưu chi tiết phiếu nhập (KHÔNG cập nhật tồn kho nếu database đã có trigger)
                    foreach (DataRow row in dtChiTiet.Rows)
                    {
                        string maGiay = row["MaSP"].ToString();
                        string maSize = row["MaSize"].ToString();
                        string maMau = row["MaMau"].ToString();
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(row["DonGia"]);

                        // Lưu chi tiết phiếu nhập với size và màu
                        using (SqlCommand cmdCT = new SqlCommand("INSERT INTO CTPHIEUNHAP (MAPN, MAGIAY, MASIZE, MAMAU, SOLUONG, DONGIA) VALUES (@mapn, @masp, @masize, @mamau, @soluong, @dongia)", connection, transaction))
                        {
                            cmdCT.Parameters.AddWithValue("@mapn", maPN);
                            cmdCT.Parameters.AddWithValue("@masp", maGiay);
                            cmdCT.Parameters.AddWithValue("@masize", maSize);
                            cmdCT.Parameters.AddWithValue("@mamau", maMau);
                            cmdCT.Parameters.AddWithValue("@soluong", soLuong);
                            cmdCT.Parameters.AddWithValue("@dongia", donGia);
                            cmdCT.ExecuteNonQuery();
                        }

                       
                        
                        // Cập nhật tồn kho trong CHITIETGIAY
                        string checkSql = "SELECT COUNT(*) FROM CHITIETGIAY WHERE MAGIAY = @magiay AND MASIZE = @masize AND MAMAU = @mamau";
                        using (SqlCommand cmdCheck = new SqlCommand(checkSql, connection, transaction))
                        {
                            cmdCheck.Parameters.AddWithValue("@magiay", maGiay);
                            cmdCheck.Parameters.AddWithValue("@masize", maSize);
                            cmdCheck.Parameters.AddWithValue("@mamau", maMau);
                            int count = (int)cmdCheck.ExecuteScalar();

                            if (count > 0)
                            {
                                // Nếu đã tồn tại, cập nhật số lượng tồn
                                string updateSql = "UPDATE CHITIETGIAY SET SOLUONGTON = SOLUONGTON + @soluong WHERE MAGIAY = @magiay AND MASIZE = @masize AND MAMAU = @mamau";
                                using (SqlCommand cmdUpdate = new SqlCommand(updateSql, connection, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@soluong", soLuong);
                                    cmdUpdate.Parameters.AddWithValue("@magiay", maGiay);
                                    cmdUpdate.Parameters.AddWithValue("@masize", maSize);
                                    cmdUpdate.Parameters.AddWithValue("@mamau", maMau);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Nếu chưa tồn tại, thêm mới
                                string insertSql = "INSERT INTO CHITIETGIAY (MAGIAY, MASIZE, MAMAU, SOLUONGTON) VALUES (@magiay, @masize, @mamau, @soluong)";
                                using (SqlCommand cmdInsert = new SqlCommand(insertSql, connection, transaction))
                                {
                                    cmdInsert.Parameters.AddWithValue("@magiay", maGiay);
                                    cmdInsert.Parameters.AddWithValue("@masize", maSize);
                                    cmdInsert.Parameters.AddWithValue("@mamau", maMau);
                                    cmdInsert.Parameters.AddWithValue("@soluong", soLuong);
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Lưu phiếu nhập và cập nhật tồn kho thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThietLapTrangThaiBanDau();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu phiếu nhập. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInPN_Click(object sender, EventArgs e)
        {

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaDongChiTiet();
        }
    }
}
