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
                if (conn.State == ConnectionState.Closed) conn.Open();
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

                AddDataBindings(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        //private void DataBindings_KhuyenMai()
        //{

        //    txtMaKM.DataBindings.Clear();
        //    txtTenKM.DataBindings.Clear();
        //    txtNgayBatDau.DataBindings.Clear();
        //    txtNgayKetThuc.DataBindings.Clear();
        //    txtGiamGia.DataBindings.Clear();

            
        //    txtMaKM.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "MAKM");
        //    txtTenKM.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "TENKM");
        //    txtNgayBatDau.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "NGAYBATDAU");
        //    txtNgayKetThuc.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "NGAYKETTHUC");
        //    txtGiamGia.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "GIAMGIA");
        //}

        private bool KiemTraDuLieu()
        {
            if  (string.IsNullOrWhiteSpace(txtTenKM.Text) ||
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

            ClearDataBindings(); 
            txtMaKM.Text = TaoMaTuDong();
            txtTenKM.Clear();
            txtNgayBatDau.Clear();
            txtNgayKetThuc.Clear();
            txtGiamGia.Clear();
            txtTimKiem.Clear();

            txtTenKM.Focus();
        }
        private string TaoMaTuDong()
        {
            string maMoi = "KM01"; 
            try
            {
                string query = "SELECT TOP 1 MAKM FROM KHUYENMAI ORDER BY LEN(MAKM) DESC, MAKM DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (conn.State == ConnectionState.Open) conn.Close();
                    if (result != null)
                    {
                        string maCu = result.ToString(); 
                        string phanSo = "0";
                        if (maCu.Length > 2)
                            phanSo = maCu.Substring(2);
                        if (int.TryParse(phanSo, out int soThuTu))
                        {
                            soThuTu++;
                            maMoi = "KM" + soThuTu.ToString("D2");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã: " + ex.Message);
            }
            return maMoi;
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;
            try
            {
                ClearDataBindings();
                string maMoi = TaoMaTuDong();
                txtMaKM.Text = maMoi;
                DataRow newRow = ds_KM.Tables["KhuyenMai"].NewRow();
                newRow["MAKM"] = maMoi;
                newRow["TENKM"] = txtTenKM.Text;
                if (DateTime.TryParse(txtNgayBatDau.Text, out DateTime bd)) newRow["NGAYBATDAU"] = bd;
                if (DateTime.TryParse(txtNgayKetThuc.Text, out DateTime kt)) newRow["NGAYKETTHUC"] = kt;
                if (decimal.TryParse(txtGiamGia.Text, out decimal gg)) newRow["GIAMGIA"] = gg;
                ds_KM.Tables["KhuyenMai"].Rows.Add(newRow);
                if (cb == null) cb = new SqlCommandBuilder(da_KM);
                da_KM.Update(ds_KM, "KhuyenMai");

                MessageBox.Show($"Thêm thành công mã {maMoi}!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
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
                DataRowView drv = (DataRowView)data_KM.CurrentRow.DataBoundItem;
                drv.BeginEdit();
                drv["TENKM"] = txtTenKM.Text;
                if (DateTime.TryParse(txtNgayBatDau.Text, out DateTime bd)) drv["NGAYBATDAU"] = bd;
                if (DateTime.TryParse(txtNgayKetThuc.Text, out DateTime kt)) drv["NGAYKETTHUC"] = kt;
                if (decimal.TryParse(txtGiamGia.Text, out decimal gg)) drv["GIAMGIA"] = gg;
                drv.EndEdit();
                if (ds_KM.HasChanges())
                {
                    da_KM.Update(ds_KM, "KhuyenMai");
                    MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có thông tin nào thay đổi.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDataKhuyenMai(); 
                return;
            }

            try
            {               
                DataTable dt = ds_KM.Tables["KhuyenMai"];
                string filterExpression = $"MAKM LIKE '%{keyword}%' OR TENKM LIKE '%{keyword}%'";               
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
                        int row = data_KM.CurrentRow.Index;                       
                        ds_KM.Tables["KhuyenMai"].Rows[row].Delete();
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
                LoadDataKhuyenMai();
            }
        }
        private void ClearDataBindings()
        {
            txtMaKM.DataBindings.Clear();
            txtTenKM.DataBindings.Clear();
            txtNgayBatDau.DataBindings.Clear();
            txtNgayKetThuc.DataBindings.Clear();
            txtGiamGia.DataBindings.Clear();
        }
        private void AddDataBindings()
        {
            ClearDataBindings(); 
            txtMaKM.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "MAKM", true, DataSourceUpdateMode.Never);
            txtTenKM.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "TENKM", true, DataSourceUpdateMode.Never);
            txtNgayBatDau.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "NGAYBATDAU", true, DataSourceUpdateMode.Never, "", "dd/MM/yyyy");
            txtNgayKetThuc.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "NGAYKETTHUC", true, DataSourceUpdateMode.Never, "", "dd/MM/yyyy");
            txtGiamGia.DataBindings.Add("Text", ds_KM.Tables["KhuyenMai"], "GIAMGIA", true, DataSourceUpdateMode.Never);
        }
        private void data_KM_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void data_KM_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            AddDataBindings();
        }
        private void Form_KhuyenMai_Load_1(object sender, EventArgs e)
        {
            LoadDataKhuyenMai();
            data_KM.SelectionChanged += data_KM_SelectionChanged;
            txtMaKM.Enabled = false;
        }
        private void data_KM_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
