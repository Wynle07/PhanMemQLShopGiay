using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
namespace QuanLiBanGiay
{
    public partial class Form_NhaCungCap : Form
    {
        SqlConnection conn;
        DataSet ds_NCC = new DataSet();
        SqlDataAdapter da_ncc;
        bool isAdding = false;
        bool isEditing = false;
        public Form_NhaCungCap()
        {
            conn = DBConnection.GetConnection();
            InitializeComponent();
        }
        private void SetInputsEnabled(bool enabled)
        {
            cbTenNCC.Enabled = enabled;
            txtHotline.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            cboTrangThai.Enabled = enabled;
        }

        private void ResetForm()
        {
            XoaTrangChiTiet(); 
            isAdding = false;
            isEditing = false;
            SetInputsEnabled(false);
            txtMaNCC.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            data_ncc.ClearSelection();
        }
        private void XoaTrangChiTiet()
        {
            txtMaNCC.Clear();
            cbTenNCC.Text = "";
            txtHotline.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            cboTrangThai.SelectedIndex = -1;
            txt_TimKiem.Clear();
        }
        private void Form_NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang hợp tác");
            cboTrangThai.Items.Add("Ngừng hợp tác");
            LoadTeNCCC();
            txtMaNCC.Enabled = false;
            ResetForm();
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Kiểm tra số điện thoại đúng 10 chữ số
        private bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }
        private void LoadNhaCungCap(string search = "")
        {
            try
            {
                string sql = @"SELECT MANCC, TENNCC, SDT AS Hotline, EMAIL, DIACHI, TRANGTHAI 
                       FROM NHACUNGCAP";

                if (!string.IsNullOrWhiteSpace(search))
                {
                    sql += @" WHERE MANCC LIKE @search 
                   OR TENNCC LIKE @search 
                   OR SDT LIKE @search 
                   OR EMAIL LIKE @search 
                   OR DIACHI LIKE @search";
                }

                da_ncc = new SqlDataAdapter(sql, conn);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    da_ncc.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                }

                ds_NCC.Clear();
                da_ncc.Fill(ds_NCC, "NHACUNGCAP");
                data_ncc.DataSource = ds_NCC.Tables["NHACUNGCAP"];
                data_ncc.Columns["MANCC"].HeaderText = "Mã NCC";
                data_ncc.Columns["TENNCC"].HeaderText = "Tên NCC";
                data_ncc.Columns["Hotline"].HeaderText = "Hotline";
                data_ncc.Columns["EMAIL"].HeaderText = "Email";
                data_ncc.Columns["DIACHI"].HeaderText = "Địa chỉ";
                data_ncc.Columns["TRANGTHAI"].HeaderText = "Trạng thái";
                data_ncc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
       private void LoadTeNCCC()
        {
            try
            {
                string querry = "SELECT MANCC, TENNCC FROM NHACUNGCAP ORDER BY TENNCC";
                SqlDataAdapter da = new SqlDataAdapter(querry, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbTenNCC.ValueMember = "MANCC";
                cbTenNCC.DisplayMember = "TENNCC";
                cbTenNCC.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load tên nhà cung cấp: " + ex.Message);
            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = data_ncc.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells["MANCC"].Value?.ToString();
                cbTenNCC.Text = row.Cells["TENNCC"].Value?.ToString();
                txtHotline.Text = row.Cells["Hotline"].Value?.ToString();
                txtEmail.Text = row.Cells["EMAIL"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value?.ToString();
                cboTrangThai.Text = row.Cells["TRANGTHAI"].Value?.ToString();
                btnThem.Enabled = true;  
                btnSua.Enabled = true;   
                btnXoa.Enabled = true;  
                btnLuu.Enabled = false;  
                SetInputsEnabled(false);
                isAdding = false;
                isEditing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dòng: " + ex.Message);
            }
        }
        private string TaoMaTuDong()
        {
            string maMoi = "NCC01";
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT TOP 1 MANCC FROM NHACUNGCAP ORDER BY LEN(MANCC) DESC, MANCC DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string maCu = result.ToString(); 
                        string phanSo = maCu.Substring(3);
                        if (int.TryParse(phanSo, out int soThuTu))
                        {
                            soThuTu++;                         
                            maMoi = "NCC" + soThuTu.ToString("D2");
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
            XoaTrangChiTiet();
            txtMaNCC.Text = TaoMaTuDong();
            cbTenNCC.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true; 
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text)) return;
            isEditing = true;
            isAdding = false;
            SetInputsEnabled(true);
            txtMaNCC.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false; 
            btnXoa.Enabled = false;
            btnLuu.Enabled = true; 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?\n(Việc xóa có thể ảnh hưởng đến phiếu nhập!)",
                                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No) return;

            try
            {
                string check = "SELECT COUNT(*) FROM PHIEUNHAP WHERE MANCC = @mancc";
                SqlCommand cmdCheck = new SqlCommand(check, conn);
                cmdCheck.Parameters.AddWithValue("@mancc", txtMaNCC.Text);
                conn.Open();
                int count = (int)cmdCheck.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa NCC này vì đang có phiếu nhập liên quan!\nBạn có thể đổi trạng thái thành 'Ngừng hợp tác'.",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string sql = "DELETE FROM NHACUNGCAP WHERE MANCC = @mancc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mancc", txtMaNCC.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap();
                ResetForm();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (data_ncc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Workbook|*.xlsx";
            save.Title = "Xuất danh sách nhà cung cấp";
            save.FileName = "DanhSach_NhaCungCap_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Add();
                    Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

                    
                    ws.Cells[1, 1] = "DANH SÁCH NHÀ CUNG CẤP";
                    ws.Range["A1:F1"].Merge();
                    ws.Range["A1:F1"].Font.Bold = true;
                    ws.Range["A1:F1"].Font.Size = 16;
                    ws.Range["A1:F1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;                    
                    for (int i = 0; i < data_ncc.Columns.Count; i++)
                    {
                        ws.Cells[3, i + 1] = data_ncc.Columns[i].HeaderText;
                        ws.Cells[3, i + 1].Font.Bold = true;
                        ws.Cells[3, i + 1].Interior.Color = Color.LightGray;
                    }
                    for (int i = 0; i < data_ncc.Rows.Count; i++)
                    {
                        for (int j = 0; j < data_ncc.Columns.Count; j++)
                        {
                            ws.Cells[i + 4, j + 1] = data_ncc.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                    ws.Columns.AutoFit();
                    wb.SaveAs(save.FileName);
                    wb.Close();
                    app.Quit();

                    MessageBox.Show("Xuất Excel thành công!\nĐường dẫn: " + save.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            LoadNhaCungCap(txt_TimKiem.Text.Trim());
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadNhaCungCap(txt_TimKiem.Text.Trim());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Nhà Cung Cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTenNCC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHotline.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại (Hotline)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHotline.Focus();
                return;
            }
           
            string ma = txtMaNCC.Text.Trim();
            string ten = cbTenNCC.Text.Trim();
            string sdt = txtHotline.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string trangthai = string.IsNullOrEmpty(cboTrangThai.Text) ? "Đang hợp tác" : cboTrangThai.Text;
            if (!IsValidPhone(sdt))
            {
                MessageBox.Show("Hotline phải gồm đúng 10 chữ số!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHotline.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                if (isAdding) 
                {
                    string sqlCheck = "SELECT COUNT(*) FROM NHACUNGCAP WHERE MANCC = @ma";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@ma", ma);
                        int count = (int)cmdCheck.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã nhà cung cấp này đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    string sqlInsert = @"INSERT INTO NHACUNGCAP (MANCC, TENNCC, SDT, EMAIL, DIACHI, TRANGTHAI)
                                 VALUES (@ma, @ten, @sdt, @email, @diachi, @tt)";

                    using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@diachi", diachi);
                        cmd.Parameters.AddWithValue("@tt", trangthai);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (isEditing) 
                {
                  
                    string sqlUpdate = @"UPDATE NHACUNGCAP 
                                 SET TENNCC = @ten, 
                                     SDT = @sdt, 
                                     EMAIL = @email, 
                                     DIACHI = @diachi, 
                                     TRANGTHAI = @tt 
                                 WHERE MANCC = @ma";

                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma);
                        cmd.Parameters.AddWithValue("@ten", ten);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@diachi", diachi);
                        cmd.Parameters.AddWithValue("@tt", trangthai);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                if (conn.State == ConnectionState.Open) conn.Close();

                LoadNhaCungCap(); 
                ResetForm();      
            }
        }
    }
}
