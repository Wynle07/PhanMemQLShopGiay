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
                ds_QLSP.Clear(); // tránh nhân bản dữ liệu
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
            // không cần làm gì
        }

        private void cbMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // không cần làm gì
        }

        private void grbThongtin_Enter(object sender, EventArgs e)
        {
            // không cần làm gì
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // không cần làm gì
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                // ✅ Cách an toàn nhất: lấy dữ liệu trực tiếp từ DataTable qua DataRowView
                DataRowView drv = dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;

                if (drv == null)
                    return;

                // --- Gán dữ liệu lên các textbox ---
                txtMaSP.Text = drv["MAGIAY"]?.ToString() ?? "";
                txtTenSP.Text = drv["TENGIAY"]?.ToString() ?? "";
                cbMaLoai.Text = drv["TENLOAI"]?.ToString() ?? "";
                txtGiaBan.Text = drv["GIABAN"]?.ToString() ?? "";
                txtMaNCC.Text = drv["TENNCC"]?.ToString() ?? "";
                txtKichCo.Text = drv["KICHCO"]?.ToString() ?? "";
                txtMauSac.Text = drv["TENMAU"]?.ToString() ?? "";
                txtSoLuongTon.Text = drv["SOLUONGTON"]?.ToString() ?? "";
                txtTH.Text = drv["TENTH"]?.ToString() ?? "";

                // --- Xử lý ảnh ---
                string fileAnh = drv["HINHANHSP"]?.ToString();

                if (!string.IsNullOrEmpty(fileAnh))
                {
                    // --- Đường dẫn tuyệt đối tới thư mục chứa ảnh ---
                    string imageFolder = @"C:\Users\Admin\OneDrive\Máy tính\CN.NET\ĐỒ ÁN\ảnh\ảnh giày";
                    string duongDan = Path.Combine(imageFolder, fileAnh);


                    if (File.Exists(duongDan))
                    {
                        using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                        {
                            pictureBox1.Image = Image.FromStream(fs);
                        }
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        string defaultImg = Path.Combine(imageFolder, "no_image.jpg");
                        if (File.Exists(defaultImg))
                        {
                            using (FileStream fs = new FileStream(defaultImg, FileMode.Open, FileAccess.Read))
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
                    // Nếu ô tìm kiếm trống, load lại toàn bộ dữ liệu
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // --- 1️⃣ Lấy dữ liệu từ form ---
                string maGiay = txtMaSP.Text.Trim();
                string tenGiay = txtTenSP.Text.Trim();
                string tenLoai = cbMaLoai.Text.Trim();
                string tenNCC = txtMaNCC.Text.Trim();
                string tenMau = txtMauSac.Text.Trim();
                string kichCo = txtKichCo.Text.Trim();
                string soLuongText = txtSoLuongTon.Text.Trim();
                string giaText = txtGiaBan.Text.Trim();
                string tenTH = txtTH.Text.Trim();

                if (string.IsNullOrEmpty(maGiay) || string.IsNullOrEmpty(tenGiay) ||
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

                // --- 2️⃣ Lấy mã loại, mã NCC, mã màu, mã size, mã thương hiệu ---
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

                // --- 3️⃣ Kiểm tra trùng mã giày ---
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

                // --- 4️⃣ Xử lý ảnh ---
                string fileAnh = "no_image.jpg";
                string imageFolder = Path.Combine(Application.StartupPath, "Images", "SanPham");
                Directory.CreateDirectory(imageFolder);

                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    fileAnh = maGiay + Path.GetExtension(selectedImagePath);
                    string savePath = Path.Combine(imageFolder, fileAnh);
                    File.Copy(selectedImagePath, savePath, true);
                }

                // --- 5️⃣ Thêm vào bảng GIAY ---
                string insertGiay = @"INSERT INTO GIAY (MAGIAY, TENGIAY, MALOAI, MATH, MANCC, GIABAN, HINHANHSP)
                              VALUES (@MAGIAY, @TENGIAY, @MALOAI, @MATH, @MANCC, @GIABAN, @HINHANHSP)";
                using (SqlCommand cmd = new SqlCommand(insertGiay, conn))
                {
                    cmd.Parameters.AddWithValue("@MAGIAY", maGiay);
                    cmd.Parameters.AddWithValue("@TENGIAY", tenGiay);
                    cmd.Parameters.AddWithValue("@MALOAI", maLoai);
                    cmd.Parameters.AddWithValue("@MATH", maTH); // ✅ gán mã thương hiệu
                    cmd.Parameters.AddWithValue("@MANCC", maNCC);
                    cmd.Parameters.AddWithValue("@GIABAN", giaBan);
                    cmd.Parameters.AddWithValue("@HINHANHSP", fileAnh);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                // --- 6️⃣ Thêm chi tiết giày ---
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
                // --- 1️⃣ Lấy dữ liệu từ form ---
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

                // --- 2️⃣ Lấy mã các khóa ngoại ---
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

                // --- 3️⃣ Xử lý ảnh ---
                string imageFolder = Path.Combine(Application.StartupPath, "Images", "SanPham");
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
                    // Giữ nguyên ảnh cũ nếu không chọn ảnh mới
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

                // --- 4️⃣ Cập nhật bảng GIAY ---
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

                // --- 5️⃣ Cập nhật bảng CHITIETGIAY ---
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

                // --- 6️⃣ Refresh lại dữ liệu ---
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

                // Xác nhận xóa
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm [{maGiay}] không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                    return;

                conn.Open();

                // --- 1️⃣ Xóa chi tiết giày trước (vì có ràng buộc khóa ngoại) ---
                string deleteCT = "DELETE FROM CHITIETGIAY WHERE MAGIAY = @ma";
                using (SqlCommand cmdCT = new SqlCommand(deleteCT, conn))
                {
                    cmdCT.Parameters.AddWithValue("@ma", maGiay);
                    cmdCT.ExecuteNonQuery();
                }

                // --- 2️⃣ Xóa sản phẩm trong bảng GIAY ---
                string deleteGiay = "DELETE FROM GIAY WHERE MAGIAY = @ma";
                using (SqlCommand cmdG = new SqlCommand(deleteGiay, conn))
                {
                    cmdG.Parameters.AddWithValue("@ma", maGiay);
                    cmdG.ExecuteNonQuery();
                }

                conn.Close();

                // --- 3️⃣ Làm mới dữ liệu ---
                loadSP();

                // --- 4️⃣ Xóa ảnh trong thư mục (nếu có) ---
                string imageFolder = Path.Combine(Application.StartupPath, "Images", "SanPham");
                string oldImg = Path.Combine(imageFolder, maGiay + ".jpg");
                if (File.Exists(oldImg))
                {
                    try
                    {
                        File.Delete(oldImg);
                    }
                    catch { /* bỏ qua nếu file đang được dùng */ }
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
                // Xóa toàn bộ nội dung trong các TextBox
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtGiaBan.Clear();
                txtMaNCC.Clear();
                txtKichCo.Clear();
                txtMauSac.Clear();
                txtSoLuongTon.Clear();
                txtTH.Clear();
                txtTimKiem.Clear();

                // Reset combobox về rỗng
                cbMaLoai.SelectedIndex = -1;
                cbMaLoai.Text = "";

                // Xóa ảnh hiển thị
                pictureBox1.Image = null;
                selectedImagePath = "";

                // Làm mới lại DataGridView
                loadSP();

                // Thông báo hoặc focus lại ô đầu tiên
                txtMaSP.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi reset form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
