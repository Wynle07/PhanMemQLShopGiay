# HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY ĐỒ ÁN QUẢN LÝ CỬA HÀNG GIÀY
==================================================
PHẦN 1: CÀI ĐẶT MÔI TRƯỜNG & THƯ VIỆN
==================================================
1. Cài đặt Crystal Reports (Bắt buộc)
   - Dự án có sử dụng chức năng in phiếu nhập bằng Crystal Reports.
   - Vui lòng cài đặt "SAP Crystal Reports for Visual Studio" (phiên bản phù hợp với VS đang dùng).

2. Cài đặt các thư viện NuGet
   Nếu khi mở project bị báo lỗi thiếu tham chiếu, vui lòng Restore NuGet Packages:
   - Chuột phải vào Solution -> chọn "Manage NuGet Packages for Solution".
   - Nhấn "Restore" các gói sau nếu bị thiếu:
     + iTextSharp (Dùng để xuất PDF hóa đơn).
     + Microsoft.Office.Interop.Excel (Dùng để xuất báo cáo Excel).

==================================================
PHẦN 2: CẤU HÌNH CƠ SỞ DỮ LIỆU (SQL SERVER)
==================================================
1. Chạy file SQL
   - Mở SQL Server Management Studio (SSMS).
   - Thực thi file script: "QL_BANGIAY.sql".
  
2. Cập nhật chuỗi kết nối
   - Mở Visual Studio, tìm đến file: "DBConnection.cs".
   - Tại dòng khai báo `connectionString`, hãy sửa lại phần "Data Source" thành tên Server của máy thầy.

   * Code cần sửa (Dòng 13 trong file DBConnection.cs):
     -----------------------------------------------------------------------
     private static readonly string connectionString = 
     "Data Source=TEN_MAY_CUA_THAY;Initial Catalog=QL_BANGIAY;Integrated Security=True;TrustServerCertificate=True";
     -----------------------------------------------------------------------

==================================================
PHẦN 3: THÔNG TIN ĐĂNG NHẬP (DỮ LIỆU MẪU)
==================================================
Hệ thống đã có sẵn dữ liệu mẫu cho 3 vai trò. Thầy có thể dùng các tài khoản sau để kiểm tra:
1. Quyền ADMIN (Toàn quyền):
   - Tài khoản: admin
   - Mật khẩu:  123456
2. Quyền NHÂN VIÊN BÁN HÀNG (Bán hàng, Khách hàng):
   - Tài khoản: nvbh1
   - Mật khẩu:  123456
3. Quyền QUẢN LÝ KHO (Nhập hàng, Nhà cung cấp):
   - Tài khoản: quanlykho1
   - Mật khẩu:  123456

==================================================
THÔNG TIN NHÓM THỰC HIỆN
==================================================
Nhóm 16 - Lớp 14DHTH10
1. Nguyễn Văn Anh Tuấn (Nhóm trưởng)
2. Lê Thị Như Quỳnh
3. Nguyễn Phạm Duy Luân

Xin chân thành cảm ơn Thầy!
