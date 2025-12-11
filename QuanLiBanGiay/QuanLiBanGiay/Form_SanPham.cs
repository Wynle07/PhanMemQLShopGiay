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
            LoadLoaiGiayVaoComboBox();
            txtMaSP.Enabled = false;
            txtMaSP.Text = TaoMaTuDong();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                
                DataRowView drv = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;

                if (drv == null)
                    return;

               
                txtMaSP.Text = drv["MAGIAY"]?.ToString() ?? "";
                txtTenSP.Text = drv["TENGIAY"]?.ToString() ?? "";
                cbMaLoai.Text = drv["TENLOAI"]?.ToString() ?? "";
                txtGiaBan.Text = drv["GIABAN"]?.ToString() ?? "";
                txtMaNCC.Text = drv["TENNCC"]?.ToString() ?? "";
                txtKichCo.Text = drv["KICHCO"]?.ToString() ?? "";
                txtMauSac.Text = drv["TENMAU"]?.ToString() ?? "";
                txtSoLuongTon.Text = drv["SOLUONGTON"]?.ToString() ?? "";
                txtTH.Text = drv["TENTH"]?.ToString() ?? "";

                
                string fileAnh = drv["HINHANHSP"]?.ToString();

                
                string imageFolder = GetImageFolderPath();

                
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                string pathHienThi = "";

                
                if (!string.IsNullOrEmpty(fileAnh))
                {
                    string checkPath = Path.Combine(imageFolder, fileAnh);
                    if (File.Exists(checkPath))
                    {
                        pathHienThi = checkPath;
                    }
                }

                
                if (string.IsNullOrEmpty(pathHienThi))
                {
                    string noImgPath = Path.Combine(imageFolder, "no_image.jpg");
                    if (File.Exists(noImgPath))
                    {
                        pathHienThi = noImgPath;
                    }
                }

                
                if (!string.IsNullOrEmpty(pathHienThi))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin sản phẩm: " + ex.Message);
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
            try
            {
                
                string maGiay = TaoMaTuDong();
                string tenGiay = txtTenSP.Text.Trim();
                string tenLoai = cbMaLoai.Text.Trim();
                string tenNCC = txtMaNCC.Text.Trim();
                string tenMau = txtMauSac.Text.Trim();
                string kichCo = txtKichCo.Text.Trim();
                string soLuongText = txtSoLuongTon.Text.Trim();
                string giaText = txtGiaBan.Text.Trim();
                string tenTH = txtTH.Text.Trim();

                if (string.IsNullOrEmpty(tenGiay) ||
                    string.IsNullOrEmpty(tenLoai) || string.IsNullOrEmpty(tenNCC) ||
                    string.IsNullOrEmpty(tenTH))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(giaText, out decimal giaBan) || giaBan <= 0)
                {
                    MessageBox.Show("Giá bán không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(soLuongText, out int soLuongTon) || soLuongTon < 0)
                {
                    MessageBox.Show("Số lượng tồn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                string maLoai = GetValueFromDB("SELECT MALOAI FROM LOAIGIAY WHERE TENLOAI = @val", tenLoai);
                string maNCC = GetValueFromDB("SELECT MANCC FROM NHACUNGCAP WHERE TENNCC = @val", tenNCC);
                string maMau = GetValueFromDB("SELECT MAMAU FROM MAUSAC WHERE TENMAU = @val", tenMau);
                string maSize = GetValueFromDB("SELECT MASIZE FROM KICHCO WHERE KICHCO = @val", kichCo);
                string maTH = GetValueFromDB("SELECT MATH FROM THUONGHIEU WHERE TENTH = @val", tenTH); // ✅ thêm thương hiệu

                if (maLoai == "" || maNCC == "" || maMau == "" || maSize == "" || maTH == "")
                {
                    MessageBox.Show("Một trong các thông tin (loại, NCC, màu, size, thương hiệu) không tồn tại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                string checkQuery = "SELECT COUNT(*) FROM GIAY WHERE MAGIAY = @ma";
                using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maGiay);
                    conn.Open();
                    int exists = (int)cmd.ExecuteScalar();
                    conn.Close();

                    if (exists > 0)
                    {
                        MessageBox.Show("Mã giày đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                string fileAnh = "no_image.jpg";

                
                string imageFolder = GetImageFolderPath();

                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    fileAnh = maGiay + Path.GetExtension(selectedImagePath);
                    string savePath = Path.Combine(imageFolder, fileAnh);

                    
                    try
                    {
                        File.Copy(selectedImagePath, savePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu ảnh: " + ex.Message);
                        
                    }
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

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                string insertCT = @"INSERT INTO CHITIETGIAY (MAGIAY, MAMAU, MASIZE, SOLUONGTON)
                            VALUES (@MAGIAY, @MAMAU, @MASIZE, @SOLUONGTON)";
                using (SqlCommand cmd = new SqlCommand(insertCT, conn))
                {
                    cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                    cmd.Parameters.AddWithValue("@MAMAU", maMau);
                    cmd.Parameters.AddWithValue("@MASIZE", maSize);
                    cmd.Parameters.AddWithValue("@SOLUONGTON", soLuongTon);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                loadSP();
                MessageBox.Show("✅ Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thêm sản phẩm: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
        private string GetValueFromDB(string query, string value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@val", value);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();
                    return result?.ToString() ?? "";
                }
            }
            catch
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                return "";
            }
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
            try
            {
                
                string maGiay = txtMaSP.Text.Trim();
                string tenGiay = txtTenSP.Text.Trim();
                string tenLoai = cbMaLoai.Text.Trim();
                string tenNCC = txtMaNCC.Text.Trim();
                string tenMau = txtMauSac.Text.Trim();
                string kichCo = txtKichCo.Text.Trim();
                string soLuongText = txtSoLuongTon.Text.Trim();
                string giaText = txtGiaBan.Text.Trim();
                string tenTH = txtTH.Text.Trim();

                if (string.IsNullOrEmpty(maGiay))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(tenGiay) || string.IsNullOrEmpty(tenLoai) ||
                    string.IsNullOrEmpty(tenNCC) || string.IsNullOrEmpty(tenTH))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(giaText, out decimal giaBan) || giaBan <= 0)
                {
                    MessageBox.Show("Giá bán không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(soLuongText, out int soLuongTon) || soLuongTon < 0)
                {
                    MessageBox.Show("Số lượng tồn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                string maLoai = GetValueFromDB("SELECT MALOAI FROM LOAIGIAY WHERE TENLOAI = @val", tenLoai);
                string maNCC = GetValueFromDB("SELECT MANCC FROM NHACUNGCAP WHERE TENNCC = @val", tenNCC);
                string maMau = GetValueFromDB("SELECT MAMAU FROM MAUSAC WHERE TENMAU = @val", tenMau);
                string maSize = GetValueFromDB("SELECT MASIZE FROM KICHCO WHERE KICHCO = @val", kichCo);
                string maTH = GetValueFromDB("SELECT MATH FROM THUONGHIEU WHERE TENTH = @val", tenTH);

                if (maLoai == "" || maNCC == "" || maMau == "" || maSize == "" || maTH == "")
                {
                    MessageBox.Show("Một trong các thông tin (loại, NCC, màu, size, thương hiệu) không tồn tại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string imageFolder = GetImageFolderPath();
                Directory.CreateDirectory(imageFolder);
                string fileAnh = "no_image.jpg";

                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    fileAnh = maGiay + Path.GetExtension(selectedImagePath);
                    string savePath = Path.Combine(imageFolder, fileAnh);
                    File.Copy(selectedImagePath, savePath, true);
                }
                else
                {
                    
                    string oldImgQuery = "SELECT HINHANHSP FROM GIAY WHERE MAGIAY = @ma";
                    using (SqlCommand cmd = new SqlCommand(oldImgQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maGiay);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        conn.Close();
                        if (result != null)
                            fileAnh = result.ToString();
                    }
                }

                
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

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
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

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                
                loadSP();
                MessageBox.Show("✅ Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi cập nhật sản phẩm: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
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
                
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtGiaBan.Clear();
                txtMaNCC.Clear();
                txtKichCo.Clear();
                txtMauSac.Clear();
                txtSoLuongTon.Clear();
                txtTH.Clear();
                txtTimKiem.Clear();

                
                cbMaLoai.SelectedIndex = -1;
                cbMaLoai.Text = "";

                
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

        private void inHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
    }
}
