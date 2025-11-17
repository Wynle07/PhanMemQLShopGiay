using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace QuanLiBanGiay
{
    public partial class Form_KhuyenMai : Form
    {
        SqlConnection conn;
        DataSet ds_KM = new DataSet();
        SqlDataAdapter da_KM = new SqlDataAdapter();
        SqlCommandBuilder cb;
        public Form_KhuyenMai()
        {
            conn = DBConnection.GetConnection();
            InitializeComponent();
        }
        private void LoadDataKhuyenMai()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "SELECT * FROM KHUYENMAI";
                da_KM = new SqlDataAdapter(sql, conn);
                cb = new SqlCommandBuilder(da_KM);

                ds_KM.Clear();
                da_KM.Fill(ds_KM, "KhuyenMai");
                data_KM.DataSource = ds_KM.Tables["KhuyenMai"];
                


                if (data_KM.Columns["NGAYBATDAU"] != null)
                    data_KM.Columns["NGAYBATDAU"].DefaultCellStyle.Format = "dd/MM/yyyy";
                if (data_KM.Columns["NGAYKETTHUC"] != null)
                    data_KM.Columns["NGAYKETTHUC"].DefaultCellStyle.Format = "dd/MM/yyyy";

                DataBindings_KhuyenMai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        private void DataBindings_KhuyenMai()
        {

            txtMaKM.DataBindings.Clear();
            txtTenKM.DataBindings.Clear();
            txtNgayBatDau.DataBindings.Clear();
            txtNgayKetThuc.DataBindings.Clear();
            txtGiamGia.DataBindings.Clear();

            // Gán DataBindings mới
            txtMaKM.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "MAKM");
            txtTenKM.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "TENKM");
            // Lưu ý: Nếu dùng DateTimePicker, cần binding thuộc tính 'Value'
            txtNgayBatDau.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "NGAYBATDAU");
            txtNgayKetThuc.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "NGAYKETTHUC");
            txtGiamGia.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "GIAMGIA");
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text) || string.IsNullOrWhiteSpace(txtTenKM.Text) ||
                string.IsNullOrWhiteSpace(txtNgayBatDau.Text) || string.IsNullOrWhiteSpace(txtNgayKetThuc.Text) ||
                string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin Khuyến mãi.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!DateTime.TryParse(txtNgayBatDau.Text, out DateTime ngayBD) || !DateTime.TryParse(txtNgayKetThuc.Text, out DateTime ngayKT))
            {
                MessageBox.Show("Định dạng Ngày Bắt Đầu/Kết Thúc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ngayBD > ngayKT)
            {
                MessageBox.Show("Ngày Kết Thúc phải lớn hơn hoặc bằng Ngày Bắt Đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!decimal.TryParse(txtGiamGia.Text, out decimal giamGia) || giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Giảm Giá phải là số từ 0 đến 100.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void lblThongTinSanPham_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKM_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btnReset_Click_1(object sender, EventArgs e)
        {

            txtMaKM.Clear();
            txtTenKM.Clear();
            txtNgayBatDau.Clear();
            txtNgayKetThuc.Clear();
            txtGiamGia.Clear();
            txtTimKiem.Clear();

            data_KM.ClearSelection(); 
            LoadDataKhuyenMai();    
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            try
            {
                DataRow newRow = ds_KM.Tables["KhuyenMai"].NewRow();
                newRow["MAKM"] = txtMaKM.Text;
                newRow["TENKM"] = txtTenKM.Text;
                newRow["NGAYBATDAU"] = DateTime.Parse(txtNgayBatDau.Text);
                newRow["NGAYKETTHUC"] = DateTime.Parse(txtNgayKetThuc.Text);
                newRow["GIAMGIA"] = decimal.Parse(txtGiamGia.Text);

                ds_KM.Tables["KhuyenMai"].Rows.Add(newRow);
                da_KM.Update(ds_KM, "KhuyenMai");
                MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDataKhuyenMai();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (data_KM.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraDuLieu()) return;

            try
            {
                // 1. Lấy DataRowView
                DataRowView drv = (DataRowView)data_KM.CurrentRow.DataBoundItem;

                // 2. Bắt đầu chỉnh sửa (rất quan trọng)
                drv.BeginEdit();

                // 3. Gán giá trị mới
                drv["MAKM"] = txtMaKM.Text;
                drv["TENKM"] = txtTenKM.Text;
                drv["NGAYBATDAU"] = DateTime.Parse(txtNgayBatDau.Text);
                drv["NGAYKETTHUC"] = DateTime.Parse(txtNgayKetThuc.Text);
                drv["GIAMGIA"] = decimal.Parse(txtGiamGia.Text);

                // 4. KẾT THÚC CHỈNH SỬA → COMMIT VÀO DataTable
                drv.EndEdit();

                // 5. Cập nhật CSDL
                da_KM.Update(ds_KM, "KhuyenMai");

                MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDataKhuyenMai(); // Tải lại dữ liệu
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDataKhuyenMai(); // Nếu không có từ khóa, tải lại toàn bộ
                return;
            }

            try
            {
                // Sử dụng RowFilter để lọc dữ liệu trực tiếp trên DataTable
                DataTable dt = ds_KM.Tables["KhuyenMai"];

                // Lọc theo Mã KM hoặc Tên KM
                string filterExpression = $"MAKM LIKE '%{keyword}%' OR TENKM LIKE '%{keyword}%'";

                // Áp dụng bộ lọc
                dt.DefaultView.RowFilter = filterExpression;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (data_KM.CurrentRow != null)
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        // Lấy chỉ mục của hàng đang được chọn
                        int row = data_KM.CurrentRow.Index;
                        // Xóa hàng đó khỏi DataTable
                        ds_KM.Tables["KhuyenMai"].Rows[row].Delete();

                        // Cập nhật lên cơ sở dữ liệu
                        da_KM.Update(ds_KM, "KhuyenMai");
                        MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadDataKhuyenMai(); // Tải lại dữ liệu
            }
        }

        private void data_KM_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataBindings_KhuyenMai();
        }

        private void data_KM_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataBindings_KhuyenMai();
        }

        private void Form_KhuyenMai_Load_1(object sender, EventArgs e)
        {
            LoadDataKhuyenMai();
            data_KM.SelectionChanged += data_KM_SelectionChanged;
        }

        private void data_KM_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
