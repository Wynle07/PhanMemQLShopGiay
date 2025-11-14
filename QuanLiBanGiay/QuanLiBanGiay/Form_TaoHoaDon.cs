using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iText = iTextSharp.text;
using iTextPdf = iTextSharp.text.pdf;

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
            TaoBangSanPham();
            LoadNhanVien();
        }

        // ============================================================
        // 1. Load danh sách khách hàng
        // ============================================================
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

        // ============================================================
        // 2. Load danh sách sản phẩm
        // ============================================================
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

                // Load mã giày
                cboMaSP.DataSource = dt;
                cboMaSP.DisplayMember = "MAGIAY";
                cboMaSP.ValueMember = "MAGIAY";
                cboMaSP.SelectedIndex = -1;

                // Load tên giày
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

        // ============================================================
        // 3. Tạo bảng sản phẩm
        // ============================================================
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

            double gia = 0;
            DataRowView r = (DataRowView)cboMaSP.SelectedItem;
            gia = double.Parse(r["GIABAN"].ToString());

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

        // ============================================================
        // 4. Lưu hóa đơn
        // ============================================================
        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            if (!LuuHoaDon())
            {
                MessageBox.Show("Lưu hóa đơn thất bại!");
                return;
            }

            MessageBox.Show("Lưu hóa đơn thành công!");

            Form_HoaDon frm = new Form_HoaDon();
            frm.MaHD = txtMaDH.Text;
            frm.MaKH = cboMaKH.Text;
            frm.TenKH = txtTenKH.Text;
            frm.SDT = txtSDT.Text;
            frm.DiaChi = txtDiaChi.Text;
            frm.DiemTL = txtDiemTL.Text;
            frm.MaNV = cboMaNVXL.Text;
            frm.ThoiGian = dtpThoiGian.Text;
            frm.DanhSachSanPham = dtSanPham;

            frm.Show();
        }

        private bool LuuHoaDon()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // ===== HOADON =====
                    string sqlHD = @"INSERT INTO HOADON (MAHD, MAKH, MANV, NGAYLAP, TONGTIEN) 
                                     VALUES (@MAHD, @MAKH, @MANV, @NGAYLAP, @TONGTIEN)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, tran);
                    cmdHD.Parameters.AddWithValue("@MAHD", txtMaDH.Text);
                    cmdHD.Parameters.AddWithValue("@MAKH", cboMaKH.Text);
                    cmdHD.Parameters.AddWithValue("@MANV", cboMaNVXL.Text);
                    cmdHD.Parameters.AddWithValue("@NGAYLAP", DateTime.Now);

                    double tong = 0;
                    foreach (DataRow r in dtSanPham.Rows)
                        tong += int.Parse(r["SOLUONG"].ToString()) * double.Parse(r["GIABAN"].ToString());

                    cmdHD.Parameters.AddWithValue("@TONGTIEN", tong);
                    cmdHD.ExecuteNonQuery();

                    // ===== CTHOADON =====
                    string sqlCT = @"INSERT INTO CTHOADON (MAHD, MAGIAY, SOLUONG, DONGIA, THANHTIEN)
                                     VALUES (@MAHD, @MAGIAY, @SOLUONG, @DONGIA, @THANHTIEN)";
                    foreach (DataRow r in dtSanPham.Rows)
                    {
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, tran);
                        cmdCT.Parameters.AddWithValue("@MAHD", txtMaDH.Text);
                        cmdCT.Parameters.AddWithValue("@MAGIAY", r["MAGIAY"].ToString());
                        cmdCT.Parameters.AddWithValue("@SOLUONG", int.Parse(r["SOLUONG"].ToString()));
                        cmdCT.Parameters.AddWithValue("@DONGIA", double.Parse(r["GIABAN"].ToString()));
                        double thanhTien = int.Parse(r["SOLUONG"].ToString()) * double.Parse(r["GIABAN"].ToString());
                        cmdCT.Parameters.AddWithValue("@THANHTIEN", thanhTien);
                        cmdCT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        // ============================================================
        // 5. Xuất PDF hóa đơn
        // ============================================================
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $@"D:\DoAn\HoaDon_{txtMaDH.Text}.pdf";

                Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                // ===== FONT TIẾNG VIỆT =====
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                iTextSharp.text.Font f20b = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f14b = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f12 = new iTextSharp.text.Font(bf, 12);
                iTextSharp.text.Font f12b = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f8b = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

                // ===== TIÊU ĐỀ =====
                Paragraph title = new Paragraph("PHIẾU HÓA ĐƠN\n\n", f20b);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                // ===== Mã hóa đơn & nhân viên =====
                PdfPTable tInfoTop = new PdfPTable(2);
                tInfoTop.WidthPercentage = 100;

                PdfPCell c1 = new PdfPCell(new Phrase($"Mã hóa đơn: {txtMaDH.Text}", f12));
                c1.Border = iTextSharp.text.Rectangle.NO_BORDER;

                PdfPCell c2 = new PdfPCell(new Phrase($"Mã NV xử lý: {cboMaNVXL.Text}", f12));
                c2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                c2.HorizontalAlignment = Element.ALIGN_RIGHT;

                tInfoTop.AddCell(c1);
                tInfoTop.AddCell(c2);
                doc.Add(tInfoTop);

                doc.Add(new Paragraph("\n"));

                // ===== BOX THÔNG TIN KHÁCH HÀNG =====
                PdfPCell boxTitle = new PdfPCell(new Phrase("Thông tin khách hàng", f12b));
                boxTitle.BackgroundColor = new BaseColor(230, 230, 230);
                boxTitle.Colspan = 2;
                boxTitle.Padding = 5;

                PdfPTable tKH = new PdfPTable(2);
                tKH.WidthPercentage = 100;
                tKH.SetWidths(new float[] { 25f, 75f });
                tKH.AddCell(boxTitle);

                void AddRow(string t, string v)
                {
                    PdfPCell l = new PdfPCell(new Phrase(t, f12));
                    l.Padding = 5;

                    PdfPCell r = new PdfPCell(new Phrase(v, f12));
                    r.Padding = 5;

                    tKH.AddCell(l);
                    tKH.AddCell(r);
                }

                AddRow("Họ và tên:", txtTenKH.Text);
                AddRow("Điện thoại:", txtSDT.Text);
                AddRow("Địa chỉ:", txtDiaChi.Text);
                AddRow("Ngày mua:", dtpThoiGian.Text);

                doc.Add(tKH);

                doc.Add(new Paragraph("\n"));

                // ===== BẢNG SẢN PHẨM =====
                PdfPTable tSP = new PdfPTable(8);
                tSP.WidthPercentage = 100;
                tSP.SetWidths(new float[] { 10f, 25f, 10f, 10f, 10f, 16f, 12f, 15f });

                string[] h = { "MAGIAY", "TENGIAY", "MALOAI", "MASIZE", "MAMAU", "SOLUONG", "GIABAN", "THANHTIEN" };
                foreach (string x in h)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(x, f8b));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.Padding = 5;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.NoWrap = true;
                    tSP.AddCell(cell);
                }

                double tong = 0;

                foreach (DataRow r in dtSanPham.Rows)
                {
                    double sl = Convert.ToDouble(r["SOLUONG"]);
                    double gia = Convert.ToDouble(r["GIABAN"]);
                    double tt = sl * gia;
                    tong += tt;

                    tSP.AddCell(new Phrase(r["MAGIAY"].ToString(), f12));
                    tSP.AddCell(new Phrase(r["TENGIAY"].ToString(), f12));
                    tSP.AddCell(new Phrase(r["MALOAI"].ToString(), f12));
                    tSP.AddCell(new Phrase(r["MASIZE"].ToString(), f12));
                    tSP.AddCell(new Phrase(r["MAMAU"].ToString(), f12));
                    tSP.AddCell(new Phrase(sl.ToString(), f12));
                    tSP.AddCell(new Phrase(gia.ToString("N0"), f12));
                    tSP.AddCell(new Phrase(tt.ToString("N0"), f12));
                }

                doc.Add(tSP);

                doc.Add(new Paragraph("\n"));

                // ===== TÍNH TIỀN =====
                double thue = tong * 0.08;             // VAT 8%
                double thanhTienFinal = tong + thue;

                // ===========================
                //     2 CỘT: CHỮ KÝ - TÍNH TIỀN
                // ===========================
                PdfPTable tBottom = new PdfPTable(2);
                tBottom.WidthPercentage = 100;
                tBottom.SetWidths(new float[] { 50f, 50f });

                // ---- CỘT 1: Chữ ký khách hàng ----
                PdfPTable tSign = new PdfPTable(1);
                PdfPCell signTitle = new PdfPCell(new Phrase("Chữ ký khách hàng", f12b));
                signTitle.Border = iTextSharp.text.Rectangle.NO_BORDER;
                signTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                signTitle.PaddingBottom = 40;
                tSign.AddCell(signTitle);

                PdfPCell leftCell = new PdfPCell(tSign);
                leftCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tBottom.AddCell(leftCell);

                // ---- CỘT 2: Tính tiền ----
                PdfPTable tTien = new PdfPTable(2);

                void AddMoney(string label, string val)
                {
                    PdfPCell l = new PdfPCell(new Phrase(label, f12b));
                    l.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    PdfPCell v = new PdfPCell(new Phrase(val, f12));
                    v.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    v.HorizontalAlignment = Element.ALIGN_RIGHT;

                    tTien.AddCell(l);
                    tTien.AddCell(v);
                }

                AddMoney("Tổng tiền:", $"{tong:N0} VNĐ");
                AddMoney("Thuế (VAT 8%):", $"{thue:N0} VNĐ");
                AddMoney("Thành tiền:", $"{thanhTienFinal:N0} VNĐ");

                PdfPCell rightCell = new PdfPCell(tTien);
                rightCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tBottom.AddCell(rightCell);

                doc.Add(tBottom);

                doc.Close();
                writer.Close();

                MessageBox.Show("Xuất PDF thành công!\n" + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi PDF: " + ex.Message);
            }
        }




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

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            // Reset các ComboBox
            cboMaKH.SelectedIndex = -1;
            cboMaSP.SelectedIndex = -1;
            cboTenSP.SelectedIndex = -1;
            cboMaNVXL.SelectedIndex = -1;

            // Reset các TextBox
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtDiemTL.Clear();
            txtMaLoai.Clear();
            txtSoLuongMua.Clear();
            txtMaDH.Clear();

            // Xóa DataGridView
            dtSanPham.Rows.Clear();

            // Tải lại dữ liệu từ database
            LoadKhachHang();
            LoadSanPham();
            LoadNhanVien();

            MessageBox.Show("Form đã được làm mới!");
        }
    }

}
