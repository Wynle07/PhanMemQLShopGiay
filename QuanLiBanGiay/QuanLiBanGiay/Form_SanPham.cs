using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLiBanGiay
{
    public partial class Form_SanPham : Form
    {
        bool isEditing = false;
        bool isAdding = false;
        SqlConnection conn;
        DataSet ds_QLSP = new DataSet();
        SqlDataAdapter da_sp;
        string selectedImagePath = "";
        public Form_SanPham()
        {
            conn = DBConnection.GetConnection();
            InitializeComponent();
        }

        private void Form_SanPham_Load(object sender, EventArgs e)
        {
            loadSP();
            LoadKichCo();       
            LoadMauSac();       
            LoadNhaCungCap();   
            LoadThuongHieu();   
            LoadLoaiGiayVaoComboBox();
            txtMaSP.Enabled = false;
            txtMaSP.Text = TaoMaTuDong();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            ResetForm();
        }
        private void FillComboBox(string query, ComboBox cbo, string display, string value)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbo.DataSource = dt;
                cbo.DisplayMember = display; 
                cbo.ValueMember = value;     
                cbo.SelectedIndex = -1;      
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load combo: " + ex.Message); }
        }
        private void LoadKichCo()
        {
            FillComboBox("SELECT MASIZE, KICHCO FROM KICHCO", cboKichCo, "KICHCO", "MASIZE");
        }
        private void LoadMauSac()
        {
            FillComboBox("SELECT MAMAU, TENMAU FROM MAUSAC", cboMauSac, "TENMAU", "MAMAU");
        }
        private void LoadNhaCungCap()
        {
            FillComboBox("SELECT MANCC, TENNCC FROM NHACUNGCAP", cboNCC, "TENNCC", "MANCC");
        }
        private void LoadThuongHieu()
        {
            FillComboBox("SELECT MATH, TENTH FROM THUONGHIEU", cboTH, "TENTH", "MATH");
        }
        public void loadSP()
        {
            try
            {
                string strsel = @"
                                SELECT 
                                    G.MAGIAY,
                                    G.TENGIAY,
                                    LG.TENLOAI,       
                                    G.GIABAN,
                                    G.HINHANHSP,
                                    MS.TENMAU,
                                    KC.KICHCO,
                                    CT.SOLUONGTON,
                                    NCC.TENNCC, 
                                    TH.TENTH
                                FROM GIAY G
                                LEFT JOIN LOAIGIAY LG ON G.MALOAI = LG.MALOAI
                                LEFT JOIN CHITIETGIAY CT ON G.MAGIAY = CT.MAGIAY
                                LEFT JOIN MAUSAC MS ON CT.MAMAU = MS.MAMAU
                                LEFT JOIN KICHCO KC ON CT.MASIZE = KC.MASIZE
                                LEFT JOIN NHACUNGCAP NCC ON G.MANCC = NCC.MANCC
                                LEFT JOIN THUONGHIEU TH ON G.MATH = TH.MATH
                                ";


                da_sp = new SqlDataAdapter(strsel, conn);
                ds_QLSP.Clear(); 
                da_sp.Fill(ds_QLSP, "GIAY");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds_QLSP.Tables["GIAY"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cbMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void grbThongtin_Enter(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }
        private void SetInputsEnabled(bool enabled)
        {
            txtTenSP.Enabled = enabled;
            txtGiaBan.Enabled = enabled;
            txtSoLuongTon.Enabled = enabled;

            cbMaLoai.Enabled = enabled;
            cboKichCo.Enabled = enabled;
            cboMauSac.Enabled = enabled;
            cboNCC.Enabled = enabled;
            cboTH.Enabled = enabled;

            btnChonAnh.Enabled = enabled;
        }

        private void ResetForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            cbMaLoai.SelectedIndex = -1; cbMaLoai.Text = "";
            cboKichCo.SelectedIndex = -1; cboKichCo.Text = "";
            cboMauSac.SelectedIndex = -1; cboMauSac.Text = "";
            cboNCC.SelectedIndex = -1; cboNCC.Text = "";
            cboTH.SelectedIndex = -1; cboTH.Text = "";
            pictureBox1.Image = null;
            selectedImagePath = "";
            isAdding = false;
            isEditing = false;
            SetInputsEnabled(false); 
            txtMaSP.Enabled = false; 
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataRowView drv = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;
                txtMaSP.Text = drv["MAGIAY"]?.ToString() ?? "";
                txtTenSP.Text = drv["TENGIAY"]?.ToString() ?? "";
                txtGiaBan.Text = drv["GIABAN"]?.ToString() ?? "";
                txtSoLuongTon.Text = drv["SOLUONGTON"]?.ToString() ?? "";
                cbMaLoai.Text = drv["TENLOAI"]?.ToString() ?? "";
                cboNCC.Text = drv["TENNCC"]?.ToString() ?? "";
                cboKichCo.Text = drv["KICHCO"]?.ToString() ?? "";
                cboMauSac.Text = drv["TENMAU"]?.ToString() ?? "";
                cboTH.Text = drv["TENTH"]?.ToString() ?? "";
                string fileAnh = drv["HINHANHSP"]?.ToString();
                string imageFolder = GetImageFolderPath();
                string pathHienThi = "";
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                if (!string.IsNullOrEmpty(fileAnh))
                {
                    pathHienThi = Path.Combine(imageFolder, fileAnh);
                }
                if (!File.Exists(pathHienThi))
                {
                    pathHienThi = Path.Combine(imageFolder, "no_image.jpg");
                }
                if (File.Exists(pathHienThi))
                {
                    using (FileStream fs = new FileStream(pathHienThi, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = Image.FromStream(fs);
                    }
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox1.Image = null;
                }
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
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void LoadLoaiGiayVaoComboBox()
        {
            try
            {
                string query = "SELECT MALOAI, TENLOAI FROM LOAIGIAY ORDER BY TENLOAI";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

              
                cbMaLoai.DisplayMember = "TENLOAI";  
                cbMaLoai.ValueMember = "MALOAI";     
                cbMaLoai.DataSource = dt;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại giày: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblMaNCC_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    
                    loadSP();
                    return;
                }
                string strsel = @"
                        SELECT 
                            G.MAGIAY,
                            G.TENGIAY,
                            LG.TENLOAI,       
                            G.GIABAN,
                            G.HINHANHSP,
                            MS.TENMAU,
                            KC.KICHCO,
                            CT.SOLUONGTON,
                            NCC.TENNCC,
                            TH.TENTH
                        FROM GIAY G
                        LEFT JOIN LOAIGIAY LG ON G.MALOAI = LG.MALOAI
                        LEFT JOIN CHITIETGIAY CT ON G.MAGIAY = CT.MAGIAY
                        LEFT JOIN MAUSAC MS ON CT.MAMAU = MS.MAMAU
                        LEFT JOIN KICHCO KC ON CT.MASIZE = KC.MASIZE
                        LEFT JOIN NHACUNGCAP NCC ON G.MANCC = NCC.MANCC
                        LEFT JOIN THUONGHIEU TH ON G.MATH = TH.MATH
                        WHERE G.MAGIAY LIKE @kw OR G.TENGIAY LIKE @kw
                        ";

                SqlDataAdapter da_search = new SqlDataAdapter(strsel, conn);
                da_search.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                DataTable dtSearch = new DataTable();
                da_search.Fill(dtSearch);

                if (dtSearch.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtSearch;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }
        private string TaoMaTuDong()
        {
            string maMoi = "G001"; 
            try
            {
                
                string query = "SELECT TOP 1 MAGIAY FROM GIAY WHERE MAGIAY LIKE 'G%' ORDER BY LEN(MAGIAY) DESC, MAGIAY DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (conn.State == ConnectionState.Open) conn.Close();

                    if (result != null)
                    {
                        string maCu = result.ToString(); 
                        string phanSo = maCu.Substring(1);
                        int soThuTu = int.Parse(phanSo);
                        soThuTu++;
                        maMoi = "G" + soThuTu.ToString("D3");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã tự động: " + ex.Message);
            }
            return maMoi;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            SetInputsEnabled(true);
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            cbMaLoai.SelectedIndex = -1; cbMaLoai.Text = "";
            pictureBox1.Image = null;
            txtMaSP.Text = TaoMaTuDong();
            txtMaSP.Enabled = false;
            txtTenSP.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true; 
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private string GetImageFolderPath()
        {
            //// Thử nhiều cách để tìm thư mục Images
            //string[] possiblePaths = new string[]
            //{
            //    // Cách 1: Từ thư mục gốc project (nếu chạy từ bin/Debug)
            //    Path.Combine(Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName, "Images", "SanPham"),
            //    // Cách 2: Từ Application.StartupPath trực tiếp
            //    Path.Combine(Application.StartupPath, "Images", "SanPham"),
            //    // Cách 3: Từ thư mục hiện tại của executable
            //    Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Images", "SanPham"),
            //    // Cách 4: Từ thư mục gốc của solution (nếu cần)
            //    Path.Combine(Application.StartupPath, "..", "..", "Images", "SanPham")
            //};

            //foreach (string path in possiblePaths)
            //{
            //    string normalizedPath = Path.GetFullPath(path);
            //    if (Directory.Exists(normalizedPath))
            //    {
            //        return normalizedPath;
            //    }
            //}


            
            string projectFolder = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;

            
            string imageFolder = Path.Combine(projectFolder, "Images", "SanPham");

            
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            return imageFolder;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn ảnh sản phẩm";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                pictureBox1.Image = Image.FromFile(selectedImagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isEditing = true;
            isAdding = false;
            SetInputsEnabled(true);
            txtMaSP.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true; 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maGiay = txtMaSP.Text.Trim();

                if (string.IsNullOrEmpty(maGiay))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm [{maGiay}] không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                    return;

                conn.Open();

                
                string deleteCT = "DELETE FROM CHITIETGIAY WHERE MAGIAY = @ma";
                using (SqlCommand cmdCT = new SqlCommand(deleteCT, conn))
                {
                    cmdCT.Parameters.AddWithValue("@ma", maGiay);
                    cmdCT.ExecuteNonQuery();
                }

                
                string deleteGiay = "DELETE FROM GIAY WHERE MAGIAY = @ma";
                using (SqlCommand cmdG = new SqlCommand(deleteGiay, conn))
                {
                    cmdG.Parameters.AddWithValue("@ma", maGiay);
                    cmdG.ExecuteNonQuery();
                }

                conn.Close();

                
                loadSP();

                
                string imageFolder = Path.Combine(Application.StartupPath, "Images", "SanPham");
                string oldImg = Path.Combine(imageFolder, maGiay + ".jpg");
                if (File.Exists(oldImg))
                {
                    try
                    {
                        File.Delete(oldImg);
                    }
                    catch {  }
                }

                pictureBox1.Image = null;
                MessageBox.Show("🗑️ Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaSP.Text = TaoMaTuDong();
                txtTenSP.Clear();
                txtGiaBan.Clear();
                cboNCC.SelectedIndex = -1; cboNCC.Text = "";
                cboKichCo.SelectedIndex = -1; cboKichCo.Text = "";
                cboMauSac.SelectedIndex = -1; cboMauSac.Text = "";
                cboTH.SelectedIndex = -1; cboTH.Text = "";
                cbMaLoai.SelectedIndex = -1; cbMaLoai.Text = "";
                txtSoLuongTon.Clear();
                txtTimKiem.Clear();
                pictureBox1.Image = null;
                selectedImagePath = "";

                loadSP();
                txtMaSP.Focus(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi reset form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thêmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThem.PerformClick();
        }

        private void xóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoa.PerformClick();
        }

        private void sửaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSua.PerformClick();
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void cboKichCo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMauSac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMaLoai_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            if (cbMaLoai.SelectedIndex == -1 || cboNCC.SelectedIndex == -1 ||
                cboMauSac.SelectedIndex == -1 || cboKichCo.SelectedIndex == -1 || cboTH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin (Loại, NCC, Màu, Size, Thương hiệu)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaBan.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuongTon.Text, out int soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuongTon.Focus();
                return;
            }

            
            string maGiay = txtMaSP.Text.Trim();
            string tenGiay = txtTenSP.Text.Trim();

           
            string maLoai = cbMaLoai.SelectedValue.ToString();
            string maNCC = cboNCC.SelectedValue.ToString();
            string maMau = cboMauSac.SelectedValue.ToString();
            string maSize = cboKichCo.SelectedValue.ToString();
            string maTH = cboTH.SelectedValue.ToString();

           
            string imageFolder = GetImageFolderPath();
            string fileAnh = "no_image.jpg"; 

            
            if (isEditing && string.IsNullOrEmpty(selectedImagePath))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmdGetImg = new SqlCommand("SELECT HINHANHSP FROM GIAY WHERE MAGIAY = @ma", conn);
                    cmdGetImg.Parameters.AddWithValue("@ma", maGiay);
                    object result = cmdGetImg.ExecuteScalar();
                    if (result != null) fileAnh = result.ToString();
                    conn.Close();
                }
                catch { }
            }
           
            else if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                try
                {
                    
                    string extension = Path.GetExtension(selectedImagePath);
                    fileAnh = maGiay + extension;
                    string savePath = Path.Combine(imageFolder, fileAnh);

                    
                    File.Copy(selectedImagePath, savePath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu ảnh: " + ex.Message);
                    return; 
                }
            }

            
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                if (isAdding) 
                {
                    
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM GIAY WHERE MAGIAY = @ma", conn);
                    cmdCheck.Parameters.AddWithValue("@ma", maGiay);
                    if ((int)cmdCheck.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Mã giày đã tồn tại! Vui lòng làm mới và thử lại.");
                        return;
                    }

                    
                    string insertGiay = @"INSERT INTO GIAY (MAGIAY, TENGIAY, MALOAI, MATH, MANCC, GIABAN, HINHANHSP)
                                  VALUES (@MAGIAY, @TENGIAY, @MALOAI, @MATH, @MANCC, @GIABAN, @HINHANHSP)";
                    using (SqlCommand cmd = new SqlCommand(insertGiay, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        cmd.Parameters.AddWithValue("@TENGIAY", tenGiay);
                        cmd.Parameters.AddWithValue("@MALOAI", maLoai);
                        cmd.Parameters.AddWithValue("@MATH", maTH);
                        cmd.Parameters.AddWithValue("@MANCC", maNCC);
                        cmd.Parameters.AddWithValue("@GIABAN", giaBan);
                        cmd.Parameters.AddWithValue("@HINHANHSP", fileAnh);
                        cmd.ExecuteNonQuery();
                    }

                   
                    string insertCT = @"INSERT INTO CHITIETGIAY (MAGIAY, MAMAU, MASIZE, SOLUONGTON)
                                VALUES (@MAGIAY, @MAMAU, @MASIZE, @SOLUONGTON)";
                    using (SqlCommand cmd = new SqlCommand(insertCT, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        cmd.Parameters.AddWithValue("@MAMAU", maMau);
                        cmd.Parameters.AddWithValue("@MASIZE", maSize);
                        cmd.Parameters.AddWithValue("@SOLUONGTON", soLuongTon);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (isEditing) 
                {
                    
                    string updateGiay = @"UPDATE GIAY 
                                  SET TENGIAY = @TENGIAY, MALOAI = @MALOAI, MATH = @MATH, MANCC = @MANCC,
                                      GIABAN = @GIABAN, HINHANHSP = @HINHANHSP
                                  WHERE MAGIAY = @MAGIAY";
                    using (SqlCommand cmd = new SqlCommand(updateGiay, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        cmd.Parameters.AddWithValue("@TENGIAY", tenGiay);
                        cmd.Parameters.AddWithValue("@MALOAI", maLoai);
                        cmd.Parameters.AddWithValue("@MATH", maTH);
                        cmd.Parameters.AddWithValue("@MANCC", maNCC);
                        cmd.Parameters.AddWithValue("@GIABAN", giaBan);
                        cmd.Parameters.AddWithValue("@HINHANHSP", fileAnh);
                        cmd.ExecuteNonQuery();
                    }

                  
                    string updateCT = @"UPDATE CHITIETGIAY 
                                SET MAMAU = @MAMAU, MASIZE = @MASIZE, SOLUONGTON = @SOLUONGTON
                                WHERE MAGIAY = @MAGIAY";
                    using (SqlCommand cmd = new SqlCommand(updateCT, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        cmd.Parameters.AddWithValue("@MAMAU", maMau);
                        cmd.Parameters.AddWithValue("@MASIZE", maSize);
                        cmd.Parameters.AddWithValue("@SOLUONGTON", soLuongTon);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                if (conn.State == ConnectionState.Open) conn.Close();

                loadSP();     
                ResetForm();  
            }
        }
    }
}
