using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiBanGiay
{
    public partial class Form_HoaDon : Form
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string DiemTL { get; set; }
        public string MaNV { get; set; }
        public string ThoiGian { get; set; }
        public string KhuyenMai { get; set; }     
        public string TenKhuyenMai { get; set; }  
        public DataTable DanhSachSanPham { get; set; }

        public Form_HoaDon()
        {
            InitializeComponent();
        }

        private void Form_HoaDon_Load(object sender, EventArgs e)
        {
            if (DanhSachSanPham == null)
            {
                MessageBox.Show("Nhấn Ok để xem Hóa đơn!!");
                return;
            }
            lblMaHD.Text = MaHD ?? "";
            lblTenKH.Text = TenKH ?? "";
            lblSDT.Text = SDT ?? "";
            lblDiaChi.Text = DiaChi ?? "";
            lblMaNVXL.Text = MaNV ?? "";
            lblThoiGian.Text = ThoiGian ?? "";
            lblKhuyenMai.Text = TenKhuyenMai ?? "0%";
            DataTable dt = DanhSachSanPham.Copy();
            if (!dt.Columns.Contains("THANHTIEN"))
                dt.Columns.Add("THANHTIEN", typeof(double));

            double tongTien = 0;
            foreach (DataRow r in dt.Rows)
            {
                double thanhTien = Convert.ToInt32(r["SOLUONG"]) * Convert.ToDouble(r["GIABAN"]);
                r["THANHTIEN"] = thanhTien;
                tongTien += thanhTien;
            }

            dgvDanhSachSP.AutoGenerateColumns = true;
            dgvDanhSachSP.Columns.Clear();
            dgvDanhSachSP.DataSource = dt;


            if (dgvDanhSachSP.Columns.Contains("MAGIAY"))
                dgvDanhSachSP.Columns["MAGIAY"].HeaderText = "Mã giày";
            if (dgvDanhSachSP.Columns.Contains("TENGIAY"))
                dgvDanhSachSP.Columns["TENGIAY"].HeaderText = "Tên giày";
            if (dgvDanhSachSP.Columns.Contains("MALOAI"))
                dgvDanhSachSP.Columns["MALOAI"].HeaderText = "Loại";
            if (dgvDanhSachSP.Columns.Contains("MASIZE"))
                dgvDanhSachSP.Columns["MASIZE"].HeaderText = "Size";
            if (dgvDanhSachSP.Columns.Contains("MAMAU"))
                dgvDanhSachSP.Columns["MAMAU"].HeaderText = "Màu";
            if (dgvDanhSachSP.Columns.Contains("SOLUONG"))
                dgvDanhSachSP.Columns["SOLUONG"].HeaderText = "Số lượng";
            if (dgvDanhSachSP.Columns.Contains("GIABAN"))
                dgvDanhSachSP.Columns["GIABAN"].HeaderText = "Giá bán";
            if (dgvDanhSachSP.Columns.Contains("THANHTIEN"))
                dgvDanhSachSP.Columns["THANHTIEN"].HeaderText = "Thành tiền";


            double kmPercent = 0;
            double.TryParse(KhuyenMai, out kmPercent);
            double tienKhuyenMai = tongTien * kmPercent / 100.0;
            double sauGiam = tongTien - tienKhuyenMai;
            double vat = sauGiam * 0.08;
            double thanhToan = sauGiam + vat;


            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblKhuyenMai.Text = "-" + tienKhuyenMai.ToString("N0") + " VNĐ";
            lblSauGiam.Text = sauGiam.ToString("N0") + " VNĐ";
            lblVat.Text = vat.ToString("N0") + " VNĐ";
            lblThanhTien.Text = thanhToan.ToString("N0") + " VNĐ";

            FormatGrid();
        }

        private void FormatGrid()
        {
            dgvDanhSachSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSP.RowHeadersVisible = false;
            dgvDanhSachSP.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDanhSachSP.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form_HoaDon_Load(sender, e);
            MessageBox.Show("Hóa đơn đã được làm mới!");
        }
    }
}
