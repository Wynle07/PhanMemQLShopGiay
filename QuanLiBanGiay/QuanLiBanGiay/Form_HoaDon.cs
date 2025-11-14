using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace QuanLiBanGiay
{
    public partial class Form_HoaDon : Form
    {
        // =============================================
        // Thuộc tính nhận dữ liệu từ Form_TaoHoaDon
        // =============================================
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string DiemTL { get; set; }
        public string MaNV { get; set; }
        public string ThoiGian { get; set; }

        public DataTable DanhSachSanPham { get; set; }

        public Form_HoaDon()
        {
            InitializeComponent();
        }

        // =============================================
        // Khi form load → Gán dữ liệu lên giao diện
        // =============================================
        private void Form_HoaDon_Load(object sender, EventArgs e)
        {
            // Kiểm tra DataTable
            if (DanhSachSanPham == null)
            {
                MessageBox.Show("Nhấn Ok để xem Hóa đơn!!");
                return;
            }

            // Gán thông tin hóa đơn lên label
            lblMaHD.Text = MaHD ?? "";
            lblTenKH.Text = TenKH ?? "";
            lblSDT.Text = SDT ?? "";
            lblDiaChi.Text = DiaChi ?? "";
            lblMaNVXL.Text = MaNV ?? "";
            lblThoiGian.Text = ThoiGian ?? "";

            // Sao chép bảng sản phẩm để tính thành tiền
            DataTable dt = DanhSachSanPham.Copy();

            // Thêm cột THANHTIEN nếu chưa có
            if (!dt.Columns.Contains("THANHTIEN"))
                dt.Columns.Add("THANHTIEN", typeof(double));

            double tongTien = 0;
            foreach (DataRow r in dt.Rows)
            {
                double thanhTien = Convert.ToInt32(r["SOLUONG"]) * Convert.ToDouble(r["GIABAN"]);
                r["THANHTIEN"] = thanhTien;
                tongTien += thanhTien;
            }

            // Thiết lập DataGridView
            dgvDanhSachSP.AutoGenerateColumns = true;
            dgvDanhSachSP.Columns.Clear();
            dgvDanhSachSP.DataSource = dt;

            // Tính VAT và tổng thanh toán
            double vat = tongTien * 0.08;
            double thanhToan = tongTien + vat;

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblVat.Text = vat.ToString("N0") + " VNĐ";
            lblThanhTien.Text = thanhToan.ToString("N0") + " VNĐ";

            // Format DataGridView
            FormatGrid();
        }

        // =============================================
        // Căn chỉnh bảng hóa đơn cho đẹp
        // =============================================

        private void FormatGrid()
        {
            dgvDanhSachSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSP.RowHeadersVisible = false;

            dgvDanhSachSP.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvDanhSachSP.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

        }
       
    }
}
