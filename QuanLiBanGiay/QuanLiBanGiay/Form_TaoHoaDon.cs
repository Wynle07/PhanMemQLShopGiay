using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace QuanLiBanGiay
{
    public partial class Form_TaoHoaDon : Form
    {
        public Form_TaoHoaDon()
        {
            InitializeComponent();
        }

        DataTable dtSanPham = new DataTable();

        private void Form_TaoHoaDon_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadSanPham();
            LoadNhanVien();
            LoadKhuyenMai();
            TaoBangSanPham();
        }

        // ===== Load khách hàng =====
        private void LoadKhachHang()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = "SELECT MAKH, TENKH, SDT, DIACHI, DIEMTICHLUY FROM KHACHHANG";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaKH.DataSource = dt;
                cboMaKH.DisplayMember = "MAKH";
                cboMaKH.ValueMember = "MAKH";
                cboMaKH.SelectedIndex = -1;
            }
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKH.SelectedIndex == -1) return;
            DataRowView r = cboMaKH.SelectedItem as DataRowView;

            txtTenKH.Text = r["TENKH"].ToString();
            txtSDT.Text = r["SDT"].ToString();
            txtDiaChi.Text = r["DIACHI"].ToString();
            txtDiemTL.Text = r["DIEMTICHLUY"].ToString();
        }

        // ===== Load sản phẩm =====
        private void LoadSanPham()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"
                    SELECT g.MAGIAY, g.TENGIAY, g.MALOAI, g.GIABAN, ct.MASIZE, ct.MAMAU, ct.SOLUONGTON
                    FROM GIAY g
                    INNER JOIN CHITIETGIAY ct ON g.MAGIAY = ct.MAGIAY
                ";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaSP.DataSource = dt;
                cboMaSP.DisplayMember = "MAGIAY";
                cboMaSP.ValueMember = "MAGIAY";
                cboMaSP.SelectedIndex = -1;

                cboTenSP.DataSource = dt.Copy();
                cboTenSP.DisplayMember = "TENGIAY";
                cboTenSP.ValueMember = "MAGIAY";
                cboTenSP.SelectedIndex = -1;
            }
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedIndex == -1) return;

            DataRowView r = (DataRowView)cboMaSP.SelectedItem;
            cboTenSP.Text = r["TENGIAY"].ToString();
            txtMaLoai.Text = r["MALOAI"].ToString();
            cboKichCo.Text = r["MASIZE"].ToString();
            cboMauSac.Text = r["MAMAU"].ToString();
        }

        private void cboTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenSP.SelectedIndex == -1) return;

            DataRowView r = (DataRowView)cboTenSP.SelectedItem;
            cboMaSP.Text = r["MAGIAY"].ToString();
            txtMaLoai.Text = r["MALOAI"].ToString();
            cboKichCo.Text = r["MASIZE"].ToString();
            cboMauSac.Text = r["MAMAU"].ToString();
        }

        // ===== Load nhân viên =====
        private void LoadNhanVien()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = "SELECT MANV, TENNV FROM NHANVIEN";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaNVXL.DataSource = dt;
                cboMaNVXL.DisplayMember = "MANV";
                cboMaNVXL.ValueMember = "MANV";
                cboMaNVXL.SelectedIndex = -1;
            }
        }

        // ===== Load khuyến mãi =====
        private void LoadKhuyenMai()
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string sql = @"
                SELECT MAKM, TENKM, NGAYBATDAU, NGAYKETTHUC, GIAMGIA
                FROM KHUYENMAI
                ORDER BY TENKM";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng "Không áp dụng" ở đầu
                    DataRow rowKhongKM = dt.NewRow();
                    rowKhongKM["MAKM"] = "";
                    rowKhongKM["TENKM"] = "-- Không áp dụng khuyến mãi --";
                    rowKhongKM["GIAMGIA"] = 0;
                    rowKhongKM["NGAYBATDAU"] = DBNull.Value;
                    rowKhongKM["NGAYKETTHUC"] = DBNull.Value;
                    dt.Rows.InsertAt(rowKhongKM, 0);

                    cboKhuyenMai.DisplayMember = "TENKM";
                    cboKhuyenMai.ValueMember = "MAKM";
                    cboKhuyenMai.DataSource = dt;

                    cboKhuyenMai.SelectedIndex = 0; // Mặc định không áp dụng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load khuyến mãi: " + ex.Message);
            }
        }

        // ===== Tạo bảng sản phẩm =====
        private void TaoBangSanPham()
        {
            dtSanPham.Columns.Add("MAGIAY");
            dtSanPham.Columns.Add("TENGIAY");
            dtSanPham.Columns.Add("MALOAI");
            dtSanPham.Columns.Add("MASIZE");
            dtSanPham.Columns.Add("MAMAU");
            dtSanPham.Columns.Add("SOLUONG", typeof(int));
            dtSanPham.Columns.Add("GIABAN", typeof(double));

            dgvSanPham.DataSource = dtSanPham;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cboMaSP.Text == "" || txtSoLuongMua.Text == "")
            {
                MessageBox.Show("Bạn phải chọn sản phẩm và số lượng!");
                return;
            }

            DataRowView r = (DataRowView)cboMaSP.SelectedItem;
            double gia = double.Parse(r["GIABAN"].ToString());

            dtSanPham.Rows.Add(
                cboMaSP.Text,
                cboTenSP.Text,
                txtMaLoai.Text,
                cboKichCo.Text,
                cboMauSac.Text,
                int.Parse(txtSoLuongMua.Text),
                gia
            );
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
                dtSanPham.Rows.RemoveAt(dgvSanPham.CurrentRow.Index);
        }

        // ===== Tính tổng tiền =====
        private double TinhTongTien()
        {
            double tong = 0;
            foreach (DataRow r in dtSanPham.Rows)
            {
                tong += Convert.ToInt32(r["SOLUONG"]) * Convert.ToDouble(r["GIABAN"]);
            }
            return tong;
        }
        //======Kiểm tra khuyến mãi hợp lệ======//
        private bool KiemTraKhuyenMaiHopLeVoiNgay(string maKM, DateTime ngayLap)
        {
            if (string.IsNullOrEmpty(maKM)) return true; // Không chọn KM → luôn hợp lệ

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                SELECT NGAYBATDAU, NGAYKETTHUC 
                FROM KHUYENMAI 
                WHERE MAKM = @MAKM";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAKM", maKM);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime ngayBD = reader.GetDateTime(0);
                                DateTime ngayKT = reader.GetDateTime(1);

                                // So sánh chỉ lấy phần ngày (không tính giờ phút giây)
                                if (ngayLap.Date >= ngayBD.Date && ngayLap.Date <= ngayKT.Date)
                                    return true;
                                else
                                    return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra khuyến mãi: " + ex.Message);
                return false;
            }
            return false;
        }
        // ===== Lưu hóa đơn =====
        private bool LuuHoaDon()
        {
            if (string.IsNullOrWhiteSpace(txtMaDH.Text))
            {
                MessageBox.Show("Mã hóa đơn không được để trống!");
                return false;
            }

            if (cboMaKH.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!");
                return false;
            }

            if (cboMaNVXL.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên xử lý!");
                return false;
            }

            if (dtSanPham == null || dtSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm trống!");
                return false;
            }
            if (cboKhuyenMai.SelectedValue != null && !string.IsNullOrEmpty(cboKhuyenMai.SelectedValue.ToString()))
            {
                string maKM = cboKhuyenMai.SelectedValue.ToString();
                if (!KiemTraKhuyenMaiHopLeVoiNgay(maKM, dtpThoiGian.Value))
                {
                    MessageBox.Show("Không thể lưu hóa đơn!\nKhuyến mãi đã chọn không hợp lệ với ngày lập hóa đơn.",
                                    "Lỗi khuyến mãi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    double tongTienGoc = TinhTongTien();

                    double phanTramGiam = 0;
                    if (cboKhuyenMai.SelectedItem is DataRowView km)
                        phanTramGiam = Convert.ToDouble(km["GIAMGIA"]);

                    double tienGiam = tongTienGoc * phanTramGiam / 100.0;
                    double tongSauGiam = tongTienGoc - tienGiam;
                    double thue = tongSauGiam * 0.08;
                    double tongThanhToan = tongSauGiam + thue;

                    string sqlHD = @"
                        INSERT INTO HOADON (MAHD, MAKH, MANV, NGAYLAP, TONGTIEN)
                        VALUES (@MAHD, @MAKH, @MANV, @NGAYLAP, @TONGTIEN)";
                    using (SqlCommand cmd = new SqlCommand(sqlHD, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MAHD", txtMaDH.Text);
                        cmd.Parameters.AddWithValue("@MAKH", cboMaKH.SelectedValue);
                        cmd.Parameters.AddWithValue("@MANV", cboMaNVXL.SelectedValue);
                        cmd.Parameters.AddWithValue("@NGAYLAP", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TONGTIEN", tongThanhToan);
                        cmd.ExecuteNonQuery();
                    }

                    string sqlCT = @"
                        INSERT INTO CTHOADON (MAHD, MAGIAY, SOLUONG, DONGIA, THANHTIEN)
                        VALUES (@MAHD, @MAGIAY, @SOLUONG, @DONGIA, @THANHTIEN)";
                    foreach (DataRow r in dtSanPham.Rows)
                    {
                        double gia = Convert.ToDouble(r["GIABAN"]);
                        int sl = Convert.ToInt32(r["SOLUONG"]);
                        double thanhTien = gia * sl * (1 - phanTramGiam / 100.0);

                        using (SqlCommand cmd = new SqlCommand(sqlCT, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MAHD", txtMaDH.Text);
                            cmd.Parameters.AddWithValue("@MAGIAY", r["MAGIAY"]);
                            cmd.Parameters.AddWithValue("@SOLUONG", sl);
                            cmd.Parameters.AddWithValue("@DONGIA", gia);
                            cmd.Parameters.AddWithValue("@THANHTIEN", thanhTien);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message);
                    return false;
                }
            }
        }

        // ===== Xuất hóa đơn sang Form_HoaDon =====
        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            if (!LuuHoaDon()) return;

            Form_HoaDon frm = new Form_HoaDon
            {
                MaHD = txtMaDH.Text,
                MaKH = cboMaKH.Text,
                TenKH = txtTenKH.Text,
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                DiemTL = txtDiemTL.Text,
                MaNV = cboMaNVXL.Text,
                ThoiGian = dtpThoiGian.Text,
                DanhSachSanPham = dtSanPham.Copy()
            };

            if (cboKhuyenMai.SelectedItem is DataRowView km)
            {
                frm.KhuyenMai = km["GIAMGIA"].ToString();   // % khuyến mãi
                frm.TenKhuyenMai = km["TENKM"].ToString();
            }
            else
            {
                frm.KhuyenMai = "0";
                frm.TenKhuyenMai = "Không KM";
            }

            frm.Show();
        }

        // ===== Refresh Form =====
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            // Reset combobox lựa chọn
            cboMaKH.SelectedIndex = -1;
            cboMaSP.SelectedIndex = -1;
            cboTenSP.SelectedIndex = -1;
            cboMaNVXL.SelectedIndex = -1;
            cboKhuyenMai.SelectedIndex = -1;

            // Xóa thông tin text
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtDiemTL.Clear();
            txtMaLoai.Clear();
            txtSoLuongMua.Clear();
            txtMaDH.Clear();

            // Reset bảng sản phẩm nhưng GIỮ BINDING
            dtSanPham.Rows.Clear();
            dgvSanPham.DataSource = dtSanPham;

            // Reset thời gian
            dtpThoiGian.Value = DateTime.Now;

            // Load lại dữ liệu gốc
            LoadKhachHang();
            LoadSanPham();
            LoadNhanVien();
            LoadKhuyenMai();
        }


        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã hóa đơn
                string maHD = txtMaDH.Text;
                if (string.IsNullOrEmpty(maHD))
                    maHD = "HD_Default";

                string path = $@"D:\DoAn\HoaDon_{maHD}.pdf";

                Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                // Font tiếng Việt
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font f12 = new iTextSharp.text.Font(bf, 12);
                iTextSharp.text.Font f12b = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f20b = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);

                // ===== TITLE =====
                Paragraph title = new Paragraph("PHIẾU HÓA ĐƠN\n\n", f20b) { Alignment = Element.ALIGN_CENTER };
                doc.Add(title);

                // ===== THÔNG TIN HÓA ĐƠN =====
                PdfPTable tblInfo = new PdfPTable(2) { WidthPercentage = 100 };
                tblInfo.SetWidths(new float[] { 1f, 1f });
                tblInfo.AddCell(new PdfPCell(new Phrase($"Mã hóa đơn: {maHD}", f12)) { Border = PdfPCell.NO_BORDER });
                tblInfo.AddCell(new PdfPCell(new Phrase($"Mã NV xử lý: {cboMaNVXL.Text}", f12)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                tblInfo.SpacingAfter = 10;
                doc.Add(tblInfo);

                // ===== THÔNG TIN KHÁCH HÀNG =====
                PdfPTable tblKH = new PdfPTable(2) { WidthPercentage = 100 };
                tblKH.SetWidths(new float[] { 1f, 2f });
                void KHRow(string label, string value)
                {
                    tblKH.AddCell(new PdfPCell(new Phrase(label, f12b)));
                    tblKH.AddCell(new PdfPCell(new Phrase(value, f12)));
                }
                KHRow("Họ và tên:", txtTenKH.Text);
                KHRow("Điện thoại:", txtSDT.Text);
                KHRow("Địa chỉ:", txtDiaChi.Text);
                KHRow("Ngày mua:", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                tblKH.SpacingAfter = 15;
                doc.Add(tblKH);

                // ===== BẢNG SẢN PHẨM =====
                PdfPTable tblSP = new PdfPTable(8) { WidthPercentage = 100 };
                tblSP.SetWidths(new float[] { 1.2f, 3.5f, 1f, 1f, 1f, 1.2f, 1.5f, 1.5f });
                string[] headers = { "MÃ GIÀY", "TÊN GIÀY", "LOẠI", "SIZE", "MÀU", "SỐ LƯỢNG", "GIÁ BÁN", "THÀNH TIỀN" };
                foreach (var h in headers)
                    tblSP.AddCell(new PdfPCell(new Phrase(h, f12b))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = BaseColor.LIGHT_GRAY
                    });

                // ===== DỮ LIỆU BẢNG =====
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.IsNewRow) continue;
                    double sl = Convert.ToDouble(row.Cells["SOLUONG"].Value);
                    double gia = Convert.ToDouble(row.Cells["GIABAN"].Value);
                    double thanhTien = sl * gia;

                    tblSP.AddCell(new PdfPCell(new Phrase(row.Cells["MAGIAY"].Value.ToString(), f12)));
                    tblSP.AddCell(new PdfPCell(new Phrase(row.Cells["TENGIAY"].Value.ToString(), f12)));
                    tblSP.AddCell(new PdfPCell(new Phrase(row.Cells["MALOAI"].Value.ToString(), f12)));
                    tblSP.AddCell(new PdfPCell(new Phrase(row.Cells["MASIZE"].Value.ToString(), f12)));
                    tblSP.AddCell(new PdfPCell(new Phrase(row.Cells["MAMAU"].Value.ToString(), f12)));
                    tblSP.AddCell(new PdfPCell(new Phrase($"{sl:N0}", f12)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tblSP.AddCell(new PdfPCell(new Phrase($"{gia:N0}", f12)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tblSP.AddCell(new PdfPCell(new Phrase($"{thanhTien:N0}", f12)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }
                tblSP.SpacingAfter = 20;
                doc.Add(tblSP);

                // ===== TÍNH TIỀN =====
                double tong = 0;
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.IsNewRow) continue;
                    tong += Convert.ToDouble(row.Cells["SOLUONG"].Value) * Convert.ToDouble(row.Cells["GIABAN"].Value);
                }

                double phanTramGiam = 0;
                if (cboKhuyenMai.SelectedItem is DataRowView km)
                    phanTramGiam = Convert.ToDouble(km["GIAMGIA"]);

                double giam = tong * phanTramGiam / 100.0;
                double tongSauGiam = tong - giam;
                double thue = tongSauGiam * 0.08;
                double thanhTienFinal = tongSauGiam + thue;

                PdfPTable tTien = new PdfPTable(2) { WidthPercentage = 100 }; // Đặt lại WidthPercentage cho phù hợp khi nhúng vào cell
                void MoneyRow(string label, string value)
                {
                    tTien.AddCell(new PdfPCell(new Phrase(label, f12b)) { Border = PdfPCell.NO_BORDER });
                    tTien.AddCell(new PdfPCell(new Phrase(value, f12)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                }
                MoneyRow("Tổng tiền:", $"{tong:N0} VNĐ");
                MoneyRow($"Khuyến mãi ({phanTramGiam}%):", $"-{giam:N0} VNĐ");
                MoneyRow("Sau giảm:", $"{tongSauGiam:N0} VNĐ");
                MoneyRow("Thuế VAT (8%):", $"{thue:N0} VNĐ");
                MoneyRow("Thành tiền:", $"{thanhTienFinal:N0} VNĐ");

                // ===== BẢNG CHÍNH CHO CHỮ KÝ VÀ TÍNH TIỀN =====
                PdfPTable mainTable = new PdfPTable(2) { WidthPercentage = 100 };
                mainTable.SetWidths(new float[] { 1f, 1f }); // Có thể điều chỉnh tỷ lệ nếu cần, ví dụ { 0.5f, 1.5f } để chữ ký nhỏ hơn

                // Ô bên trái: Chữ ký khách hàng
                PdfPCell leftCell = new PdfPCell();
                leftCell.AddElement(new Paragraph("Chữ ký khách hàng:\n\n____________________", f12));
                leftCell.Border = PdfPCell.NO_BORDER;
                leftCell.VerticalAlignment = Element.ALIGN_BOTTOM; // Căn dưới nếu cần

                // Ô bên phải: Bảng tính tiền
                PdfPCell rightCell = new PdfPCell(tTien);
                rightCell.Border = PdfPCell.NO_BORDER;

                mainTable.AddCell(leftCell);
                mainTable.AddCell(rightCell);

                doc.Add(mainTable);

                doc.Close();
                writer.Close();

                MessageBox.Show("Xuất PDF thành công!\n" + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi PDF: " + ex.Message);
            }
        }
        private void KiemTraVaCanhBaoKhuyenMai()
        {
            if (cboKhuyenMai.SelectedValue == null) return;

            string maKM = cboKhuyenMai.SelectedValue.ToString();
            if (string.IsNullOrEmpty(maKM)) return; // Không chọn KM → bỏ qua

            DateTime ngayLap = dtpThoiGian.Value;

            if (!KiemTraKhuyenMaiHopLeVoiNgay(maKM, ngayLap))
            {
                MessageBox.Show(
                    $"Khuyến mãi \"{cboKhuyenMai.Text}\" không áp dụng vào ngày {ngayLap:dd/MM/yyyy}!\n" +
                    $"Chỉ áp dụng từ ngày có hiệu lực của chương trình.",
                    "Khuyến mãi không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Tự động quay về "Không áp dụng"
                cboKhuyenMai.SelectedIndex = 0;
            }
        }
        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            KiemTraVaCanhBaoKhuyenMai();
        }

        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            KiemTraVaCanhBaoKhuyenMai();
        }

        private void LoadKichCoVaMauSac(string maGiay)
        {
            if (string.IsNullOrEmpty(maGiay)) return;

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // Load Size còn hàng
                    string sqlSize = @"
                SELECT DISTINCT MASIZE 
                FROM CHITIETGIAY 
                WHERE MAGIAY = @MAGIAY AND SOLUONGTON > 0
                ORDER BY MASIZE";

                    using (SqlCommand cmd = new SqlCommand(sqlSize, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        SqlDataReader reader = cmd.ExecuteReader();
                        cboKichCo.Items.Clear();
                        while (reader.Read())
                        {
                            cboKichCo.Items.Add(reader["MASIZE"].ToString());
                        }
                    }

                    conn.Close();
                    conn.Open();

                    // Load Màu còn hàng
                    string sqlMau = @"
                SELECT DISTINCT MAMAU 
                FROM CHITIETGIAY 
                WHERE MAGIAY = @MAGIAY AND SOLUONGTON > 0
                ORDER BY MAMAU";

                    using (SqlCommand cmd = new SqlCommand(sqlMau, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        SqlDataReader reader = cmd.ExecuteReader();
                        cboMauSac.Items.Clear();
                        while (reader.Read())
                        {
                            cboMauSac.Items.Add(reader["MAMAU"].ToString());
                        }
                    }
                }

                // Reset chọn
                cboKichCo.Text = "";
                cboMauSac.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load size/màu: " + ex.Message);
            }
        }

        private void cboKichCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            KiemTraTonKho();
        }

        private void cboMauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            KiemTraTonKho();
        }

        private void cboMaSP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedIndex == -1) return;

            DataRowView r = (DataRowView)cboMaSP.SelectedItem;
            string maGiay = r["MAGIAY"].ToString();

            cboTenSP.Text = r["TENGIAY"].ToString();
            txtMaLoai.Text = r["MALOAI"].ToString();

            // Load size và màu theo mã giày
            LoadKichCoVaMauSac(maGiay);
        }

        private void cboTenSP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTenSP.SelectedIndex == -1) return;

            DataRowView r = (DataRowView)cboTenSP.SelectedItem;
            string maGiay = r["MAGIAY"].ToString();

            cboMaSP.Text = maGiay;
            txtMaLoai.Text = r["MALOAI"].ToString();

            // Load size và màu theo mã giày
            LoadKichCoVaMauSac(maGiay);
        }
        private void KiemTraTonKho()
        {
            if (string.IsNullOrEmpty(cboMaSP.Text)) return;
            if (string.IsNullOrEmpty(cboKichCo.Text) && string.IsNullOrEmpty(cboMauSac.Text)) return;

            string maGiay = cboMaSP.Text.Trim();
            string size = cboKichCo.Text.Trim();
            string mau = cboMauSac.Text.Trim();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                SELECT SOLUONGTON 
                FROM CHITIETGIAY 
                WHERE MAGIAY = @MAGIAY 
                  AND (@MASIZE = '' OR MASIZE = @MASIZE)
                  AND (@MAMAU = '' OR MAMAU = @MAMAU)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        cmd.Parameters.AddWithValue("@MASIZE", size);
                        cmd.Parameters.AddWithValue("@MAMAU", mau);

                        object result = cmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) <= 0)
                        {
                            string loi = "";
                            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(mau))
                                loi = $"Đã hết hàng size {size} - màu {mau}!";
                            else if (!string.IsNullOrEmpty(size))
                                loi = $"Đã hết size {size}!";
                            else if (!string.IsNullOrEmpty(mau))
                                loi = $"Đã hết màu {mau}!";

                            MessageBox.Show(loi, "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            // Tự động xóa chọn sai
                            if (!string.IsNullOrEmpty(size) && string.IsNullOrEmpty(mau))
                                cboKichCo.Text = "";
                            else if (!string.IsNullOrEmpty(mau))
                                cboMauSac.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tồn kho: " + ex.Message);
            }
        }

        // === CLICK CHUỘT PHẢI CHỌN DÒNG CHÍNH XÁC ===
        private void dgvSanPham_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvSanPham.ClearSelection();
                dgvSanPham.Rows[e.RowIndex].Selected = true;
                dgvSanPham.CurrentCell = dgvSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        // === THÊM SẢN PHẨM ===
        private void thêmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cboMaSP.SelectedIndex = -1;
            cboTenSP.SelectedIndex = -1;
            txtMaLoai.Clear();
            txtSoLuongMua.Clear();
            cboMauSac.SelectedIndex = -1;
            cboKichCo.SelectedIndex = -1;
            
            btnThemSP.PerformClick();
        }

        // === XÓA SẢN PHẨM ===
        private void xóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0) return;

            int index = dgvSanPham.SelectedRows[0].Index;

            if (index >= 0 && index < dtSanPham.Rows.Count)
            {
                dtSanPham.Rows.RemoveAt(index);
                dgvSanPham.DataSource = dtSanPham;
            }
        }

        // === XUẤT HÓA ĐƠN ===
        private void xuấtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXuatHD_Click(sender, e);
        }

        // === IN HÓA ĐƠN ===
        private void inHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnInHoaDon_Click(sender, e);
        }

        // === LÀM MỚI ===
        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRefesh.PerformClick();
        }

    }
}
