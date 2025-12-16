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
        bool isAdding = false;
        bool isEditing = false;
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


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        private void SetInputsEnabled(bool enabled)
        {
            txtTenKM.Enabled = enabled;
            txtNgayBatDau.Enabled = enabled;
            txtNgayKetThuc.Enabled = enabled;
            txtGiamGia.Enabled = enabled;
        }

        private void ResetForm()
        {
            txtMaKM.Clear();
            txtTenKM.Clear();
            txtNgayBatDau.Clear();
            txtNgayKetThuc.Clear();
            txtGiamGia.Clear();
            txtTimKiem.Clear();
            isAdding = false;
            isEditing = false;
            SetInputsEnabled(false);
            txtMaKM.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            data_KM.ClearSelection();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenKM.Text) ||
        string.IsNullOrWhiteSpace(txtNgayBatDau.Text) ||
        string.IsNullOrWhiteSpace(txtNgayKetThuc.Text) ||
        string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin Khuyến mãi.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            DateTime ngayBD, ngayKT;
            if (!DateTime.TryParseExact(txtNgayBatDau.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngayBD))
            {
                MessageBox.Show("Ngày Bắt Đầu không hợp lệ (Định dạng đúng: dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgayBatDau.Focus();
                return false;
            }

            if (!DateTime.TryParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ngayKT))
            {
                MessageBox.Show("Ngày Kết Thúc không hợp lệ (Định dạng đúng: dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgayKetThuc.Focus();
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
            isAdding = true;
            isEditing = false;
            SetInputsEnabled(true); 
            txtTenKM.Clear();
            txtNgayBatDau.Clear();
            txtNgayKetThuc.Clear();
            txtGiamGia.Clear();
            txtMaKM.Text = TaoMaTuDong();
            txtMaKM.Enabled = false;
            txtTenKM.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true; 
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKM.Text))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa!");
                return;
            }

            isEditing = true;
            isAdding = false;

            SetInputsEnabled(true);
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true; 
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
        private void data_KM_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void data_KM_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= data_KM.Rows.Count) return;

            try
            {
                DataRowView drv = data_KM.Rows[e.RowIndex].DataBoundItem as DataRowView;

                if (drv == null) return;
                txtMaKM.Text = drv["MAKM"].ToString();
                txtTenKM.Text = drv["TENKM"].ToString();
                txtGiamGia.Text = drv["GIAMGIA"].ToString();
                if (drv["NGAYBATDAU"] != DBNull.Value)
                {
                    txtNgayBatDau.Text = Convert.ToDateTime(drv["NGAYBATDAU"]).ToString("dd/MM/yyyy");
                }
                else txtNgayBatDau.Clear();

                if (drv["NGAYKETTHUC"] != DBNull.Value)
                {
                    txtNgayKetThuc.Text = Convert.ToDateTime(drv["NGAYKETTHUC"]).ToString("dd/MM/yyyy");
                }
                else txtNgayKetThuc.Clear();                
                SetInputsEnabled(false); 
                btnThem.Enabled = true;
                btnSua.Enabled = true;   
                btnXoa.Enabled = true;   
                btnLuu.Enabled = false;
                isAdding = false;
                isEditing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dòng: " + ex.Message);
            }
        }
        private void Form_KhuyenMai_Load_1(object sender, EventArgs e)
        {
            LoadDataKhuyenMai();
            data_KM.SelectionChanged += data_KM_SelectionChanged;
            txtMaKM.Enabled = false;
            ResetForm();
        }
        private void data_KM_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

           
            string ma = txtMaKM.Text.Trim();
            string ten = txtTenKM.Text.Trim();
            decimal giam = decimal.Parse(txtGiamGia.Text.Trim());

            
            DateTime bd, kt;
            try
            {
                bd = DateTime.ParseExact(txtNgayBatDau.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                kt = DateTime.ParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Ngày tháng không đúng định dạng dd/MM/yyyy"); return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                if (isAdding) 
                {
                    
                    string sqlInsert = "INSERT INTO KHUYENMAI (MAKM, TENKM, NGAYBATDAU, NGAYKETTHUC, GIAMGIA) VALUES (@ma, @ten, @bd, @kt, @giam)";
                    using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@bd", bd);
                        cmd.Parameters.AddWithValue("@kt", kt);
                        cmd.Parameters.AddWithValue("@giam", giam);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm thành công!");
                }
                else if (isEditing)
                {
                    string sqlUpdate = "UPDATE KHUYENMAI SET TENKM=@ten, NGAYBATDAU=@bd, NGAYKETTHUC=@kt, GIAMGIA=@giam WHERE MAKM=@ma";
                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@bd", bd);
                        cmd.Parameters.AddWithValue("@kt", kt);
                        cmd.Parameters.AddWithValue("@giam", giam);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                LoadDataKhuyenMai();
                ResetForm();
            }
        }
    }
}
