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
        string currentMaMau = ""; // Lưu mã màu cũ
        string currentMaSize = "";
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
                // Đã thêm MS.MAMAU và KC.MASIZE vào câu SELECT
                string strsel = @"
            SELECT 
                G.MAGIAY,
                G.TENGIAY,
                LG.TENLOAI,      
                KC.KICHCO,
                MS.TENMAU,
                CT.SOLUONGTON,
                G.GIABAN,
                G.HINHANHSP,
                NCC.TENNCC, 
                TH.TENTH,
                MS.MAMAU,  -- Thêm cột ẩn để lấy ID
                KC.MASIZE  -- Thêm cột ẩn để lấy ID
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
                dataGridView1.DataSource = ds_QLSP.Tables["GIAY"];

                // Ẩn 2 cột ID đi để giao diện đẹp
                if (dataGridView1.Columns["MAMAU"] != null) dataGridView1.Columns["MAMAU"].Visible = false;
                if (dataGridView1.Columns["MASIZE"] != null) dataGridView1.Columns["MASIZE"].Visible = false;

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
                //txtGiaBan.Text = drv["GIABAN"]?.ToString() ?? "";
                if (decimal.TryParse(drv["GIABAN"]?.ToString(), out decimal giaBan))
                {
                    // "N0" là định dạng số, có dấu phân cách ngàn, không có số thập phân
                    txtGiaBan.Text = giaBan.ToString("N0");
                }
                else
                {
                    txtGiaBan.Text = "0";
                }
                txtSoLuongTon.Text = drv["SOLUONGTON"]?.ToString() ?? "";
                cbMaLoai.Text = drv["TENLOAI"]?.ToString() ?? "";
                cboNCC.Text = drv["TENNCC"]?.ToString() ?? "";
                cboKichCo.Text = drv["KICHCO"]?.ToString() ?? "";
                cboMauSac.Text = drv["TENMAU"]?.ToString() ?? "";
                cboTH.Text = drv["TENTH"]?.ToString() ?? "";

                // --- LẤY ID CŨ ĐỂ DÙNG CHO SỬA/XÓA ---
                currentMaMau = drv["MAMAU"]?.ToString();
                currentMaSize = drv["MASIZE"]?.ToString();
                // --------------------------------------

                // Xử lý ảnh
                string fileAnh = drv["HINHANHSP"]?.ToString();
                string imageFolder = GetImageFolderPath();
                string pathHienThi = "";

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                if (!string.IsNullOrEmpty(fileAnh))
                    pathHienThi = Path.Combine(imageFolder, fileAnh);

                if (!File.Exists(pathHienThi))
                    pathHienThi = Path.Combine(imageFolder, "no_image.jpg");

                if (File.Exists(pathHienThi))
                {
                    using (FileStream fs = new FileStream(pathHienThi, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = Image.FromStream(fs);
                    }
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                    pictureBox1.Image = null;

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

                if (string.IsNullOrEmpty(maGiay) || string.IsNullOrEmpty(currentMaMau) || string.IsNullOrEmpty(currentMaSize))
                {
                    MessageBox.Show("Vui lòng chọn dòng chi tiết sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa chi tiết sản phẩm [{maGiay}] (Màu/Size đang chọn) không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                if (conn.State == ConnectionState.Closed) conn.Open();

                // 1. Xóa dòng chi tiết cụ thể (dựa vào Mã Giày + Màu + Size)
                string deleteCT = "DELETE FROM CHITIETGIAY WHERE MAGIAY = @ma AND MAMAU = @mau AND MASIZE = @size";
                using (SqlCommand cmdCT = new SqlCommand(deleteCT, conn))
                {
                    cmdCT.Parameters.AddWithValue("@ma", maGiay);
                    cmdCT.Parameters.AddWithValue("@mau", currentMaMau);
                    cmdCT.Parameters.AddWithValue("@size", currentMaSize);
                    cmdCT.ExecuteNonQuery();
                }

                // 2. Kiểm tra xem giày này còn chi tiết nào không?
                string countQuery = "SELECT COUNT(*) FROM CHITIETGIAY WHERE MAGIAY = @ma";
                using (SqlCommand cmdCount = new SqlCommand(countQuery, conn))
                {
                    cmdCount.Parameters.AddWithValue("@ma", maGiay);
                    int conLai = (int)cmdCount.ExecuteScalar();

                    // Nếu không còn chi tiết nào (count = 0), xóa luôn sản phẩm cha trong bảng GIAY
                    if (conLai == 0)
                    {
                        string deleteGiay = "DELETE FROM GIAY WHERE MAGIAY = @ma";
                        using (SqlCommand cmdG = new SqlCommand(deleteGiay, conn))
                        {
                            cmdG.Parameters.AddWithValue("@ma", maGiay);
                            cmdG.ExecuteNonQuery();
                        }

                        // Xóa file ảnh cũ
                        string imageFolder = GetImageFolderPath();
                        string oldImg = Path.Combine(imageFolder, maGiay + ".jpg");
                        if (File.Exists(oldImg)) try { File.Delete(oldImg); } catch { }

                        MessageBox.Show("Đã xóa hoàn toàn sản phẩm vì không còn chi tiết nào!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Đã xóa chi tiết màu/size đã chọn!", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                loadSP();
                ResetForm();
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

            // --- (Phần kiểm tra nhập liệu đầu vào GIỮ NGUYÊN như cũ) ---
            if (string.IsNullOrWhiteSpace(txtTenSP.Text)) { MessageBox.Show("Nhập tên SP!"); txtTenSP.Focus(); return; }
            if (cbMaLoai.SelectedIndex == -1 || cboNCC.SelectedIndex == -1 || cboMauSac.SelectedIndex == -1 || cboKichCo.SelectedIndex == -1 || cboTH.SelectedIndex == -1) { MessageBox.Show("Chọn đủ thông tin!"); return; }
            if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan) || giaBan <= 0) { MessageBox.Show("Giá bán sai!"); return; }
            if (!int.TryParse(txtSoLuongTon.Text, out int soLuongTon) || soLuongTon < 0) { MessageBox.Show("Số lượng sai!"); return; }

            string maGiay = txtMaSP.Text.Trim();
            string tenGiay = txtTenSP.Text.Trim();
            string maLoai = cbMaLoai.SelectedValue.ToString();
            string maNCC = cboNCC.SelectedValue.ToString();
            string maMau = cboMauSac.SelectedValue.ToString(); // Mã màu MỚI user chọn trên combobox
            string maSize = cboKichCo.SelectedValue.ToString(); // Mã size MỚI user chọn trên combobox
            string maTH = cboTH.SelectedValue.ToString();

            // --- (Phần xử lý ảnh GIỮ NGUYÊN như cũ) ---
            string imageFolder = GetImageFolderPath();
            string fileAnh = "no_image.jpg";
            // ... Copy đoạn xử lý ảnh của bạn vào đây (giống hệt code cũ) ...
            // Để ngắn gọn mình giả sử bạn đã copy đoạn xử lý ảnh vào đây.
            if (isEditing && string.IsNullOrEmpty(selectedImagePath))
            {
                // Logic lấy lại tên ảnh cũ nếu không chọn ảnh mới (như code cũ)
                // ...
                // Đặt tạm để code chạy được nếu bạn copy paste
                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmdGetImg = new SqlCommand("SELECT HINHANHSP FROM GIAY WHERE MAGIAY = @ma", conn);
                    cmdGetImg.Parameters.AddWithValue("@ma", maGiay);
                    object res = cmdGetImg.ExecuteScalar();
                    if (res != null) fileAnh = res.ToString();
                }
                catch { }
            }
            else if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                // Logic copy ảnh mới (như code cũ)
                string ext = Path.GetExtension(selectedImagePath);
                fileAnh = maGiay + ext;
                try { File.Copy(selectedImagePath, Path.Combine(imageFolder, fileAnh), true); } catch { }
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                if (isAdding)
                {
                    // --- (Phần Thêm Mới GIỮ NGUYÊN NHƯ CŨ) ---
                    // Bạn copy nguyên xi phần isAdding cũ vào đây
                    // ...
                    // Code mẫu vắn tắt cho phần Adding:
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM GIAY WHERE MAGIAY = @ma", conn);
                    cmdCheck.Parameters.AddWithValue("@ma", maGiay);
                    if ((int)cmdCheck.ExecuteScalar() > 0) { MessageBox.Show("Trùng mã!"); return; }

                    string insertGiay = "INSERT INTO GIAY (MAGIAY, TENGIAY, MALOAI, MATH, MANCC, GIABAN, HINHANHSP) VALUES (@MAGIAY, @TENGIAY, @MALOAI, @MATH, @MANCC, @GIABAN, @HINHANHSP)";
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
                    string insertCT = "INSERT INTO CHITIETGIAY (MAGIAY, MAMAU, MASIZE, SOLUONGTON) VALUES (@MAGIAY, @MAMAU, @MASIZE, @SOLUONGTON)";
                    using (SqlCommand cmd = new SqlCommand(insertCT, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        cmd.Parameters.AddWithValue("@MAMAU", maMau);
                        cmd.Parameters.AddWithValue("@MASIZE", maSize);
                        cmd.Parameters.AddWithValue("@SOLUONGTON", soLuongTon);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("✅ Thêm thành công!");
                }
                else if (isEditing)
                {
                    // --- ĐÂY LÀ PHẦN SỬA LẠI LOGIC UPDATE ---

                    // 1. Cập nhật thông tin chung ở bảng GIAY (Giữ nguyên)
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

                    // 2. Cập nhật bảng CHITIETGIAY (SỬA LẠI: Kiểm tra trùng trước khi sửa)

                    // Nếu người dùng thay đổi Màu hoặc Size so với lúc mới click vào
                    if (maMau != currentMaMau || maSize != currentMaSize)
                    {
                        // Kiểm tra xem tổ hợp (Giày + Màu Mới + Size Mới) đã có trong database chưa?
                        string checkExist = "SELECT COUNT(*) FROM CHITIETGIAY WHERE MAGIAY=@ma AND MAMAU=@newMau AND MASIZE=@newSize";
                        using (SqlCommand cmdCheck = new SqlCommand(checkExist, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@ma", maGiay);
                            cmdCheck.Parameters.AddWithValue("@newMau", maMau);
                            cmdCheck.Parameters.AddWithValue("@newSize", maSize);
                            int count = (int)cmdCheck.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show($"Sản phẩm này đã có sẵn phiên bản (Màu: {cboMauSac.Text}, Size: {cboKichCo.Text})!\nKhông thể sửa thành trùng lặp.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Dừng lại, không cho update chi tiết
                            }
                        }
                    }

                    // Nếu không trùng, thực hiện Update dựa vào ID CŨ (currentMaMau, currentMaSize)
                    string updateCT = @"UPDATE CHITIETGIAY 
                                SET MAMAU = @MAMAU, MASIZE = @MASIZE, SOLUONGTON = @SOLUONGTON
                                WHERE MAGIAY = @MAGIAY AND MAMAU = @OLDMAU AND MASIZE = @OLDSIZE";
                    using (SqlCommand cmd = new SqlCommand(updateCT, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                        cmd.Parameters.AddWithValue("@MAMAU", maMau); // Update thành cái mới
                        cmd.Parameters.AddWithValue("@MASIZE", maSize); // Update thành cái mới
                        cmd.Parameters.AddWithValue("@SOLUONGTON", soLuongTon);

                        // Điều kiện WHERE phải dùng cái CŨ
                        cmd.Parameters.AddWithValue("@OLDMAU", currentMaMau);
                        cmd.Parameters.AddWithValue("@OLDSIZE", currentMaSize);

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
