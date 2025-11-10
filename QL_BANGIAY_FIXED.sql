CREATE DATABASE QL_BANGIAY
USE QL_BANGIAY
GO
drop database QL_BANGIAY
-- 1.TẠO BẢNG KHACHHANG
CREATE TABLE KHACHHANG
(
	MAKH VARCHAR(10) NOT NULL,
	TENKH NVARCHAR(50),
	SDT VARCHAR(12),
	EMAIL VARCHAR(50),
	DIACHI NVARCHAR(50),
	DIEMTICHLUY INT DEFAULT 0,
	NGAYTAO DATE, --
	CONSTRAINT PK_KH PRIMARY KEY(MAKH),
	CONSTRAINT CHK_DIEMTICHLUY CHECK (DIEMTICHLUY >= 0)
)

-- 2.TẠO BẢNG NHANVIEN

CREATE TABLE NHANVIEN
(
    MANV VARCHAR(10) NOT NULL,
    TENNV NVARCHAR(50),
    GIOITINH NVARCHAR(3),
    NGAYSINH DATE,
    SDT VARCHAR(12),
	DIACHI NVARCHAR(100),
	NGAYVAOLAM DATE, --MS THÊM
    CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANV),
	CONSTRAINT CHK_GIOITINH CHECK (GIOITINH IN (N'Nam', N'Nữ'))
);

-- 3.TẠO BẢNG NHACUNGCAP

CREATE TABLE NHACUNGCAP
(
    MANCC VARCHAR(10) NOT NULL,
    TENNCC NVARCHAR(50),
    SDT VARCHAR(12),
    EMAIL VARCHAR(50),
    DIACHI NVARCHAR(100),
	TRANGTHAI NVARCHAR(30) DEFAULT N'Đang hợp tác',
    CONSTRAINT PK_NHACUNGCAP PRIMARY KEY(MANCC),
	CONSTRAINT CHK_TRANGTHAI_NCC CHECK (TRANGTHAI IN (N'Đang hợp tác', N'Ngừng hợp tác'))
);

-- 4.TẠO BẢNG LOAIGIAY

CREATE TABLE LOAIGIAY
(
    MALOAI VARCHAR(10) NOT NULL,
    TENLOAI NVARCHAR(50),
	MOTA NVARCHAR(200),
    CONSTRAINT PK_LOAIGIAY PRIMARY KEY(MALOAI)
);

-- 5.TẠO BẢNG MAUSAC
CREATE TABLE MAUSAC
(
    MAMAU VARCHAR(10) NOT NULL,
    TENMAU NVARCHAR(50),
    CONSTRAINT PK_MAUSAC PRIMARY KEY(MAMAU)
);

-- 6.TẠO BẢNG KICHCO

CREATE TABLE KICHCO
(
    MASIZE VARCHAR(10) NOT NULL,
    KICHCO NVARCHAR(10),
    CONSTRAINT PK_KICHCO PRIMARY KEY(MASIZE),
	CONSTRAINT CHK_KICHCO CHECK (KICHCO IN (N'35', N'36', N'37', N'38', N'39', N'40', N'41', N'42', N'43', N'44', N'45'))
);

-- 7.TẠO BẢNG THƯƠNG HIỆU
CREATE TABLE THUONGHIEU
(
    MATH VARCHAR(10) NOT NULL,
    TENTH NVARCHAR(50),
    LOGO VARCHAR(255) NULL,   
    CONSTRAINT PK_THUONGHIEU PRIMARY KEY(MATH)
);
-- 8.TẠO BẢNG GIAY
CREATE TABLE GIAY
(
    MAGIAY VARCHAR(10) NOT NULL,
    TENGIAY NVARCHAR(100),
    MALOAI VARCHAR(10),
	MATH VARCHAR(10),
	MANCC VARCHAR(10),
	GIABAN DECIMAL(18,2),
	HINHANHSP VARCHAR(255),
    CONSTRAINT PK_GIAY PRIMARY KEY(MAGIAY),
    CONSTRAINT FK_GIAY_LOAIGIAY FOREIGN KEY(MALOAI) REFERENCES LOAIGIAY(MALOAI),
	CONSTRAINT FK_GIAY_THUONGHIEU FOREIGN KEY(MATH) REFERENCES THUONGHIEU(MATH),
    CONSTRAINT FK_GIAY_NHACUNGCAP FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC)
);

-- 9.TÁCH THÀNH BẢNG CHI TIẾT GIÀY
CREATE TABLE CHITIETGIAY
(
	MAGIAY VARCHAR(10) NOT NULL,
	MAMAU VARCHAR(10) NOT NULL,
    MASIZE VARCHAR(10)NOT NULL,
    SOLUONGTON INT,
	CONSTRAINT PK_CHITIETGIAY PRIMARY KEY (MAGIAY,MAMAU,MASIZE),
	CONSTRAINT FK_CTGIAY_GIAY FOREIGN KEY(MAGIAY) REFERENCES GIAY(MAGIAY),
	CONSTRAINT FK_CTGIAY_MAUSAC FOREIGN KEY(MAMAU) REFERENCES MAUSAC(MAMAU),
    CONSTRAINT FK_CTGIAY_KICHCO FOREIGN KEY(MASIZE) REFERENCES KICHCO(MASIZE),
	CONSTRAINT CHK_SOLUONGTON CHECK (SOLUONGTON >= 0)
);
-- 10.TẠO BẢNG KHUYẾN MÃI
CREATE TABLE KHUYENMAI
(
    MAKM VARCHAR(10) NOT NULL,
    TENKM NVARCHAR(100),
    NGAYBATDAU DATE,
    NGAYKETTHUC DATE,
    GIAMGIA DECIMAL(5,2), 
    CONSTRAINT PK_KHUYENMAI PRIMARY KEY(MAKM),
	CONSTRAINT CHK_GIAMGIA CHECK (GIAMGIA BETWEEN 0 AND 100),
	CONSTRAINT CHK_NGAYKM CHECK (NGAYKETTHUC >= NGAYBATDAU)
);

-- 11.TẠO BẢNG HOADON
CREATE TABLE HOADON
(
    MAHD VARCHAR(10) NOT NULL,
    NGAYLAP DATE,
    MANV VARCHAR(10),
    MAKH VARCHAR(10),
	TONGTIEN DECIMAL(18,2),
    CONSTRAINT PK_HOADON PRIMARY KEY(MAHD),
    CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
    CONSTRAINT FK_HOADON_KHACHHANG FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
);

-- 12.TẠO BẢNG CTHOADON
CREATE TABLE CTHOADON
(
    MAHD VARCHAR(10) NOT NULL,
    MAGIAY VARCHAR(10) NOT NULL,
	MAKM VARCHAR(10) NULL,
    SOLUONG INT,
    DONGIA DECIMAL(18,2),
	THANHTIEN DECIMAL(18,2),
	PHUONGTHUCTHANHTOAN NVARCHAR(20) DEFAULT N'Tiền mặt',
    CONSTRAINT PK_CTHOADON PRIMARY KEY(MAHD, MAGIAY),
    CONSTRAINT FK_CTHOADON_HOADON FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD),
    CONSTRAINT FK_CTHOADON_GIAY FOREIGN KEY(MAGIAY) REFERENCES GIAY(MAGIAY),
	CONSTRAINT FK_CTHOADON_KHUYENMAI FOREIGN KEY(MAKM) REFERENCES KHUYENMAI(MAKM)
);

-- 13.TẠO BẢNG PHIEUNHAP
CREATE TABLE PHIEUNHAP
(
    MAPN VARCHAR(10) NOT NULL,
    NGAYNHAP DATE,
    MANV VARCHAR(10),
    MANCC VARCHAR(10),
	TONGTIEN DECIMAL(18,2),
    CONSTRAINT PK_PHIEUNHAP PRIMARY KEY(MAPN),
    CONSTRAINT FK_PHIEUNHAP_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
    CONSTRAINT FK_PHIEUNHAP_NHACUNGCAP FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC)
);

-- 14.TẠO BẢNG CTPHIEUNHAP

CREATE TABLE CTPHIEUNHAP
(
    MAPN VARCHAR(10) NOT NULL,
    MAGIAY VARCHAR(10) NOT NULL,
    SOLUONG INT,
    DONGIA DECIMAL(18,2),
	THANHTIEN DECIMAL(18,2),
    CONSTRAINT PK_CTPHIEUNHAP PRIMARY KEY(MAPN, MAGIAY),
    CONSTRAINT FK_CTPHIEUNHAP_PHIEUNHAP FOREIGN KEY(MAPN) REFERENCES PHIEUNHAP(MAPN),
    CONSTRAINT FK_CTPHIEUNHAP_GIAY FOREIGN KEY(MAGIAY) REFERENCES GIAY(MAGIAY)
);

-- 15.TẠO BẢNG TAIKHOAN		
CREATE TABLE TAIKHOAN
(
    TENDANGNHAP VARCHAR(30) NOT NULL,
    MATKHAU VARCHAR(100) NOT NULL,
    MANV VARCHAR(10),
    VAITRO NVARCHAR(20),  -- Admin, Thu ngân, Quản lý kho
	TRANGTHAI NVARCHAR(20) DEFAULT N'Hoạt động',
	NGAYTAO DATE,
    CONSTRAINT PK_TAIKHOAN PRIMARY KEY(TENDANGNHAP),
    CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
	CONSTRAINT CHK_TRANGTHAI_TK CHECK (TRANGTHAI IN (N'Hoạt động', N'Vô hiệu hóa'))
);

-- 1. TRG_CTHOADON_INSERT
-- Kiểm tra tồn kho, tính thành tiền, giảm tồn kho khi bán
go
CREATE TRIGGER TRG_CTHOADON_INSERT
ON CTHOADON
AFTER INSERT
AS
BEGIN
    -- Kiểm tra tồn kho
    IF EXISTS (
        SELECT 1
        FROM INSERTED i
        JOIN CHITIETGIAY c ON i.MAGIAY = c.MAGIAY
        WHERE i.SOLUONG > c.SOLUONGTON
    )
    BEGIN
        RAISERROR(N'Số lượng bán vượt quá tồn kho!',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Tính thành tiền
    UPDATE CTHOADON
    SET THANHTIEN = i.SOLUONG * i.DONGIA
    FROM CTHOADON c
    JOIN INSERTED i ON c.MAHD = i.MAHD AND c.MAGIAY = i.MAGIAY;

    -- Giảm tồn kho
    UPDATE CHITIETGIAY
    SET SOLUONGTON = SOLUONGTON - i.SOLUONG
    FROM CHITIETGIAY ct
    JOIN INSERTED i ON ct.MAGIAY = i.MAGIAY;
END;
GO

-- 2. TRG_UPDATE_TONGTIEN_HOADON
-- Tự động cập nhật tổng tiền hóa đơn khi có chi tiết
CREATE TRIGGER TRG_UPDATE_TONGTIEN_HOADON
ON CTHOADON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE HOADON
    SET TONGTIEN = (SELECT SUM(THANHTIEN) FROM CTHOADON WHERE MAHD = h.MAHD)
    FROM HOADON h;
END;
GO

-- 3. TRG_UPDATE_DIEMTICHLUY
-- Cộng điểm tích lũy cho khách hàng sau mỗi hóa đơn
CREATE TRIGGER TRG_UPDATE_DIEMTICHLUY
ON HOADON
AFTER INSERT
AS
BEGIN
    UPDATE KHACHHANG
    SET DIEMTICHLUY = DIEMTICHLUY + (i.TONGTIEN/100000) -- ví dụ: 1đ cho mỗi 100k
    FROM KHACHHANG k
    JOIN INSERTED i ON k.MAKH = i.MAKH;
END;
GO

-- 4. TRG_CTPHIEUNHAP_INSERT
-- Tính thành tiền nhập hàng & tăng tồn kho
CREATE TRIGGER TRG_CTPHIEUNHAP_INSERT
ON CTPHIEUNHAP
AFTER INSERT
AS
BEGIN
    -- Tính thành tiền nhập hàng
    UPDATE CTPHIEUNHAP
    SET THANHTIEN = i.SOLUONG * i.DONGIA
    FROM CTPHIEUNHAP c
    JOIN INSERTED i ON c.MAPN = i.MAPN AND c.MAGIAY = i.MAGIAY;

    -- Tăng tồn kho
    UPDATE CHITIETGIAY
    SET SOLUONGTON = SOLUONGTON + i.SOLUONG
    FROM CHITIETGIAY ct
    JOIN INSERTED i ON ct.MAGIAY = i.MAGIAY;
END;
GO

-- 5. TRG_UPDATE_TONGTIEN_PHIEUNHAP
-- Cập nhật tổng tiền phiếu nhập
CREATE TRIGGER TRG_UPDATE_TONGTIEN_PHIEUNHAP
ON CTPHIEUNHAP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE PHIEUNHAP
    SET TONGTIEN = (SELECT SUM(THANHTIEN) FROM CTPHIEUNHAP WHERE MAPN = p.MAPN)
    FROM PHIEUNHAP p;
END;
GO

-- 6. TRG_NHANVIEN_DELETE
-- Khóa tài khoản khi xóa nhân viên
CREATE TRIGGER TRG_NHANVIEN_DELETE
ON NHANVIEN
AFTER DELETE
AS
BEGIN
    UPDATE TAIKHOAN
    SET TRANGTHAI = N'Vô hiệu hóa'
    FROM TAIKHOAN t
    JOIN DELETED d ON t.MANV = d.MANV;
END;
GO

-- 7. TRG_CHECK_KHUYENMAI_DATE
-- Không cho áp dụng khuyến mãi sai thời gian
CREATE TRIGGER TRG_CHECK_KHUYENMAI_DATE
ON CTHOADON
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM INSERTED i
        JOIN KHUYENMAI k ON i.MAKM = k.MAKM
        WHERE GETDATE() NOT BETWEEN k.NGAYBATDAU AND k.NGAYKETTHUC
    )
    BEGIN
        RAISERROR(N'Khuyến mãi không hợp lệ trong thời gian này!',16,1);
        ROLLBACK TRANSACTION;
    END
END;
GO

/* ============================================================
    TRIGGER KIỂM TRA DỮ LIỆU (GIÁ ÂM, NGÀY SAI)
   ============================================================ */

-- 8. TRG_GIAY_CHECK_GIABAN
CREATE TRIGGER TRG_GIAY_CHECK_GIABAN
ON GIAY
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE GIABAN < 0)
    BEGIN
        RAISERROR(N'Giá bán không được âm.',16,1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- 9. TRG_CTHOADON_CHECK_DATA
CREATE TRIGGER TRG_CTHOADON_CHECK_DATA
ON CTHOADON
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE (SOLUONG <= 0 OR DONGIA < 0))
    BEGIN
        RAISERROR(N'Số lượng phải >0 và đơn giá không được âm.',16,1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- 10. TRG_CTPHIEUNHAP_CHECK_DATA
CREATE TRIGGER TRG_CTPHIEUNHAP_CHECK_DATA
ON CTPHIEUNHAP
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE (SOLUONG <= 0 OR DONGIA < 0))
    BEGIN
        RAISERROR(N'Số lượng nhập phải >0 và đơn giá không được âm.',16,1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- 11. TRG_HOADON_CHECK_DATE
CREATE TRIGGER TRG_HOADON_CHECK_DATE
ON HOADON
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE NGAYLAP > GETDATE())
    BEGIN
        RAISERROR(N'Ngày lập hóa đơn không được lớn hơn ngày hiện tại.',16,1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- 12. TRG_PHIEUNHAP_CHECK_DATE
CREATE TRIGGER TRG_PHIEUNHAP_CHECK_DATE
ON PHIEUNHAP
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE NGAYNHAP > GETDATE())
    BEGIN
        RAISERROR(N'Ngày nhập phiếu nhập không được lớn hơn ngày hiện tại.',16,1);
        ROLLBACK TRANSACTION;
    END
END;
GO

--13. TRG_CAPNHAT_TONKHO_KHI_XOA_CTHOADON
CREATE TRIGGER TRG_CAPNHAT_TONKHO_KHI_XOA_CTHOADON
ON CTHOADON
AFTER DELETE
AS
BEGIN
    -- Cộng lại tồn kho khi xóa chi tiết hóa đơn
    UPDATE CHITIETGIAY
    SET SOLUONGTON = SOLUONGTON + d.SOLUONG
    FROM CHITIETGIAY ct
    JOIN DELETED d ON ct.MAGIAY = d.MAGIAY;
END;
GO

--14. TRG_NGAYTAO_KHACHHANG_DEFAULT
CREATE TRIGGER TRG_NGAYTAO_KHACHHANG_DEFAULT
ON KHACHHANG
AFTER INSERT
AS
BEGIN
    UPDATE KHACHHANG
    SET NGAYTAO = GETDATE()
    FROM KHACHHANG k
    JOIN INSERTED i ON k.MAKH = i.MAKH
    WHERE i.NGAYTAO IS NULL;
END;
GO

--15.TRG_CAPNHAT_TONKHO_KHI_XOA_CTPHIEUNHAP
CREATE TRIGGER TRG_CAPNHAT_TONKHO_KHI_XOA_CTPHIEUNHAP
ON CTPHIEUNHAP
AFTER DELETE
AS
BEGIN
    -- Trừ tồn kho khi xóa chi tiết phiếu nhập
    UPDATE CHITIETGIAY
    SET SOLUONGTON = SOLUONGTON - d.SOLUONG
    FROM CHITIETGIAY ct
    JOIN DELETED d ON ct.MAGIAY = d.MAGIAY;
END;
GO

--16.TRG_NGAYVAOLAM_NHANVIEN_DEFAULT
CREATE TRIGGER TRG_NGAYVAOLAM_NHANVIEN_DEFAULT
ON NHANVIEN
AFTER INSERT
AS
BEGIN
    UPDATE NHANVIEN
    SET NGAYVAOLAM = GETDATE()
    FROM NHANVIEN nv
    JOIN INSERTED i ON nv.MANV = i.MANV
    WHERE i.NGAYVAOLAM IS NULL;
END;
GO

--17.TRG_KHUYENMAI_CHECK_GIAMGIA
CREATE TRIGGER TRG_KHUYENMAI_CHECK_GIAMGIA
ON KHUYENMAI
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE GIAMGIA < 0 OR GIAMGIA > 100)
    BEGIN
        RAISERROR(N'Giảm giá phải từ 0 đến 100%.',16,1);
        ROLLBACK TRANSACTION;
    END
END;
GO

USE QL_BANGIAY;
GO

---------------------------------------------------------------
-- 1. KHÁCH HÀNG
---------------------------------------------------------------
INSERT INTO KHACHHANG (MAKH, TENKH, SDT, EMAIL, DIACHI, DIEMTICHLUY)
VALUES
('KH001', N'Nguyễn Văn An', '0912345678', 'an.nguyen@gmail.com', N'Hà Nội', 120),
('KH002', N'Trần Thị Hoa', '0987654321', 'hoa.tran@yahoo.com', N'Hồ Chí Minh', 85),
('KH003', N'Lê Văn Long', '0909888777', 'long.le@gmail.com', N'Đà Nẵng', 45),
('KH004', N'Phạm Thu Trang', '0977123456', 'trang.pham@gmail.com', N'Huế', 0),
('KH005', N'Võ Quốc Khánh', '0933445566', 'khanh.vo@gmail.com', N'Cần Thơ', 30);

---------------------------------------------------------------
-- 2. NHÂN VIÊN
---------------------------------------------------------------
INSERT INTO NHANVIEN (MANV, TENNV, GIOITINH, NGAYSINH, SDT, DIACHI, NGAYVAOLAM)
VALUES
('NV001', N'Nguyễn Hồng Minh', N'Nam', '1990-05-12', '0911111111', N'Hà Nội', '2022-01-10'),
('NV002', N'Lê Thị Mai', N'Nữ', '1995-03-22', '0922222222', N'Hồ Chí Minh', '2023-03-15'),
('NV003', N'Phan Thanh Tùng', N'Nam', '1992-09-10', '0933333333', N'Đà Nẵng', '2022-11-20'),
('NV004', N'Ngô Thị Hạnh', N'Nữ', '1998-07-18', '0944444444', N'Huế', '2024-05-12'),
('NV005', N'Trần Đức Nam', N'Nam', '1988-02-05', '0955555555', N'Hải Phòng', '2021-12-01');

---------------------------------------------------------------
-- 3. NHÀ CUNG CẤP
---------------------------------------------------------------
INSERT INTO NHACUNGCAP (MANCC, TENNCC, SDT, EMAIL, DIACHI)
VALUES
('NCC01', N'Công ty TNHH Adidas Việt Nam', '0281234567', 'contact@adidas.vn', N'HCM'),
('NCC02', N'Công ty Nike Việt Nam', '0282233445', 'support@nike.vn', N'Hà Nội'),
('NCC03', N'Công ty Biti’s', '0288877665', 'info@bitis.vn', N'Cần Thơ'),
('NCC04', N'Công ty Puma Việt Nam', '0289988776', 'sales@puma.vn', N'Hà Nội'),
('NCC05', N'Công ty Vans Official', '0285566778', 'contact@vans.vn', N'Đà Nẵng');

---------------------------------------------------------------
-- 4. LOẠI GIÀY
---------------------------------------------------------------
INSERT INTO LOAIGIAY (MALOAI, TENLOAI, MOTA)
VALUES
('LG01', N'Giày thể thao', N'Giày dành cho vận động, tập luyện, đi lại hàng ngày.'),
('LG02', N'Giày sneaker', N'Giày phong cách trẻ trung, năng động.'),
('LG03', N'Giày da nam', N'Giày công sở, chất liệu da cao cấp.'),
('LG04', N'Sandal', N'Dép quai hậu, phù hợp mùa hè.'),
('LG05', N'Giày boot', N'Giày cổ cao, thời trang mùa đông.');

---------------------------------------------------------------
-- 5. MÀU SẮC
---------------------------------------------------------------
INSERT INTO MAUSAC (MAMAU, TENMAU)
VALUES
('MS01', N'Trắng'),
('MS02', N'Đen'),
('MS03', N'Xanh dương'),
('MS04', N'Đỏ'),
('MS05', N'Nâu'),
('MS06', N'Be'),
('MS07', N'Xám'),
('MS08', N'Xanh lá'),
('MS09', N'Vàng'),
('MS10', N'Hồng');

---------------------------------------------------------------
-- 6. KÍCH CỠ
---------------------------------------------------------------
INSERT INTO KICHCO (MASIZE, KICHCO)
VALUES
('S35', N'35'), ('S36', N'36'), ('S37', N'37'), ('S38', N'38'),
('S39', N'39'), ('S40', N'40'), ('S41', N'41'), ('S42', N'42'),
('S43', N'43'), ('S44', N'44'), ('S45', N'45');

---------------------------------------------------------------
-- 7. THƯƠNG HIỆU
---------------------------------------------------------------
INSERT INTO THUONGHIEU (MATH, TENTH, LOGO)
VALUES
('TH01', N'Adidas', 'adidas.png'),
('TH02', N'Nike', 'nike.png'),
('TH03', N'Biti’s', 'bitis.png'),
('TH04', N'Puma', 'puma.png'),
('TH05', N'Vans', 'vans.png');

---------------------------------------------------------------
-- 8. GIÀY
---------------------------------------------------------------
INSERT INTO GIAY (MAGIAY, TENGIAY, MALOAI, MATH, MANCC, GIABAN, HINHANHSP)
VALUES
-- Adidas
('G001', N'Adidas Ultraboost 22', 'LG01', 'TH01', 'NCC01', 3200000, 'ultraboost22.jpg'),
('G002', N'Adidas Superstar', 'LG02', 'TH01', 'NCC01', 2400000, 'superstar.jpg'),
('G003', N'Adidas Stan Smith', 'LG02', 'TH01', 'NCC01', 2300000, 'stansmith.jpg'),
('G004', N'Adidas Duramo SL', 'LG01', 'TH01', 'NCC01', 2100000, 'duramosl.jpg'),

-- Nike
('G005', N'Nike Air Zoom Pegasus 39', 'LG01', 'TH02', 'NCC02', 2950000, 'pegasus39.jpg'),
('G006', N'Nike Air Force 1', 'LG02', 'TH02', 'NCC02', 2600000, 'airforce1.jpg'),
('G007', N'Nike Revolution 6', 'LG01', 'TH02', 'NCC02', 1900000, 'revolution6.jpg'),
('G008', N'Nike Blazer Mid 77', 'LG02', 'TH02', 'NCC02', 2700000, 'blazermid77.jpg'),

-- Biti’s
('G009', N'Biti’s Hunter Street', 'LG02', 'TH03', 'NCC03', 950000, 'hunterstreet.jpg'),
('G010', N'Biti’s Hunter X', 'LG01', 'TH03', 'NCC03', 1200000, 'hunterx.jpg'),
('G011', N'Biti’s Sandal Men', 'LG03', 'TH03', 'NCC03', 750000, 'sandalm.jpg'),
('G012', N'Biti’s Hunter Core', 'LG01', 'TH03', 'NCC03', 1150000, 'huntercore.jpg'),

-- Puma
('G013', N'Puma Cali Dream', 'LG02', 'TH04', 'NCC04', 2100000, 'calidream.jpg'),
('G014', N'Puma Suede Classic', 'LG02', 'TH04', 'NCC04', 1850000, 'suedeclassic.jpg'),
('G015', N'Puma RS-X3', 'LG01', 'TH04', 'NCC04', 2500000, 'rsx3.jpg'),
('G016', N'Puma Future Rider', 'LG01', 'TH04', 'NCC04', 2300000, 'futurerider.jpg'),

-- Vans
('G017', N'Vans Old Skool Classic', 'LG02', 'TH05', 'NCC05', 1700000, 'oldskool.jpg'),
('G018', N'Vans Slip-On Checkerboard', 'LG02', 'TH05', 'NCC05', 1600000, 'slipon.jpg'),
('G019', N'Vans Sk8-Hi', 'LG02', 'TH05', 'NCC05', 1850000, 'sk8hi.jpg'),
('G020', N'Vans Authentic Classic', 'LG02', 'TH05', 'NCC05', 1550000, 'authentic.jpg');

INSERT INTO GIAY (MAGIAY, TENGIAY, MALOAI, MATH, MANCC, GIABAN, HINHANHSP)
VALUES
('G021', N'Biti’s Sandal Nữ Summer', 'LG04', 'TH03', 'NCC03', 690000, 'sandalfemale.jpg'),
('G022', N'Nike Canyon Sandal', 'LG04', 'TH02', 'NCC02', 1850000, 'canyonsandal.jpg'),
('G023', N'Adidas Adilette Comfort', 'LG04', 'TH01', 'NCC01', 1200000, 'adilette.jpg');

INSERT INTO GIAY (MAGIAY, TENGIAY, MALOAI, MATH, MANCC, GIABAN, HINHANHSP)
VALUES
('G024', N'Puma Ankle Boot Leather', 'LG05', 'TH04', 'NCC04', 2750000, 'pumaboot.jpg'),
('G025', N'Vans Classic Leather Boot', 'LG05', 'TH05', 'NCC05', 2450000, 'vansboot.jpg'),
('G026', N'Biti’s Hunter Boot', 'LG05', 'TH03', 'NCC03', 1650000, 'hunterboot.jpg');

---------------------------------------------------------------
-- 9. CHI TIẾT GIÀY
---------------------------------------------------------------
INSERT INTO CHITIETGIAY VALUES
('G001','MS01','S40',50),
('G002','MS02','S42',60), ('G003','MS04','S39',80),
('G004','MS04','S38',30), ('G005','MS03','S41',55),
('G006','MS08','S42',70), ('G007','MS05','S43',40),
('G008','MS03','S40',65), ('G009','MS06','S39',90),
('G010','MS10','S41',50), ('G011','MS07','S42',35),
('G012','MS01','S40',80), ('G013','MS08','S39',45),
('G014','MS05','S41',70), ('G015','MS09','S42',60),
('G016','MS06','S43',50), ('G017','MS10','S40',75),
('G018','MS07','S41',65), ('G019','MS04','S42',55),
('G020','MS02','S39',40);

INSERT INTO CHITIETGIAY (MAGIAY, MAMAU, MASIZE, SOLUONGTON)
VALUES
-- Sandal (LG04)
('G021','MS03','S38',45),
('G022','MS05','S40',35),
('G023','MS06','S39',50),

-- Boot (LG05)
('G024','MS07','S42',40),
('G025','MS08','S41',55),
('G026','MS09','S43',30);

---------------------------------------------------------------
-- 10. KHUYẾN MÃI
---------------------------------------------------------------
INSERT INTO KHUYENMAI (MAKM, TENKM, NGAYBATDAU, NGAYKETTHUC, GIAMGIA)
VALUES
('KM01', N'Giáng Sinh 2025', '2025-12-01', '2025-12-31', 15),
('KM02', N'Tết Nguyên Đán 2025', '2025-01-10', '2025-02-15', 20),
('KM03', N'Summer Sale', '2025-06-01', '2025-06-30', 10),
('KM04', N'Black Friday', '2025-11-25', '2025-11-30', 40),
('KM05', N'Mừng Khai Trương', '2025-05-01', '2025-05-15', 25);

---------------------------------------------------------------
-- 11. HÓA ĐƠN
---------------------------------------------------------------
INSERT INTO HOADON (MAHD, NGAYLAP, MANV, MAKH, TONGTIEN)
VALUES
('HD001', '2025-10-01', 'NV001', 'KH001', 0),
('HD002', '2025-10-02', 'NV002', 'KH002', 0),
('HD003', '2025-10-03', 'NV003', 'KH003', 0),
('HD004', '2025-10-05', 'NV001', 'KH004', 0),
('HD005', '2025-10-07', 'NV004', 'KH005', 0),
('HD006', '2025-10-09', 'NV005', 'KH001', 0),
('HD007', '2025-10-12', 'NV002', 'KH002', 0),
('HD008', '2025-10-14', 'NV003', 'KH003', 0),
('HD009', '2025-10-16', 'NV001', 'KH004', 0),
('HD010', '2025-10-20', 'NV004', 'KH005', 0);
---------------------------------------------------------------
-- 12. CHI TIẾT HÓA ĐƠN
---------------------------------------------------------------
INSERT INTO CTHOADON (MAHD, MAGIAY, MAKM, SOLUONG, DONGIA, PHUONGTHUCTHANHTOAN)
VALUES
('HD001', 'G001', 'KM01', 2, 3200000, N'Tiền mặt'),
('HD001', 'G002', NULL, 1, 2400000, N'Tiền mặt'),

('HD002', 'G005', 'KM02', 1, 2950000, N'Chuyển khoản'),
('HD002', 'G006', NULL, 2, 2600000, N'Chuyển khoản'),

('HD003', 'G009', NULL, 3, 950000, N'Tiền mặt'),
('HD003', 'G010', NULL, 1, 1200000, N'Tiền mặt'),

('HD004', 'G013', 'KM03', 1, 2100000, N'Chuyển khoản'),
('HD004', 'G014', NULL, 2, 1850000, N'Tiền mặt'),

('HD005', 'G017', NULL, 2, 1700000, N'Tiền mặt'),
('HD005', 'G018', 'KM02', 1, 1600000, N'Tiền mặt'),

('HD006', 'G019', NULL, 1, 1850000, N'Chuyển khoản'),
('HD006', 'G020', 'KM01', 2, 1550000, N'Chuyển khoản'),

('HD007', 'G003', 'KM03', 1, 2300000, N'Tiền mặt'),
('HD007', 'G004', NULL, 1, 2100000, N'Tiền mặt'),

('HD008', 'G007', NULL, 2, 1900000, N'Chuyển khoản'),
('HD008', 'G008', 'KM02', 1, 2700000, N'Tiền mặt'),

('HD009', 'G011', NULL, 1, 750000, N'Tiền mặt'),
('HD009', 'G012', NULL, 2, 1150000, N'Tiền mặt'),

('HD010', 'G015', 'KM03', 1, 2500000, N'Chuyển khoản'),
('HD010', 'G016', NULL, 1, 2300000, N'Tiền mặt');

---------------------------------------------------------------
-- 13. PHIẾU NHẬP
---------------------------------------------------------------
INSERT INTO PHIEUNHAP (MAPN, NGAYNHAP, MANV, MANCC)
VALUES
('PN001', '2025-09-05', 'NV001', 'NCC01'),
('PN002', '2025-09-10', 'NV002', 'NCC02'),
('PN003', '2025-09-15', 'NV003', 'NCC03'),
('PN004', '2025-09-20', 'NV001', 'NCC04'),
('PN005', '2025-09-25', 'NV004', 'NCC05');

---------------------------------------------------------------
-- 14. CHI TIẾT PHIẾU NHẬP
---------------------------------------------------------------
INSERT INTO CTPHIEUNHAP (MAPN, MAGIAY, SOLUONG, DONGIA)
VALUES
('PN001', 'G001', 50, 2500000),
('PN001', 'G002', 30, 2300000),
('PN002', 'G003', 100, 750000),
('PN002', 'G008', 80, 900000),
('PN003', 'G006', 30, 1600000),
('PN003', 'G007', 25, 1400000),
('PN004', 'G008', 15, 1300000),
('PN004', 'G009', 20, 1250000),
('PN004', 'G010', 10, 1550000),
('PN005', 'G011', 25, 1350000),
('PN005', 'G012', 20, 1450000),
('PN005', 'G013', 15, 1600000);


---------------------------------------------------------------
-- 15. TÀI KHOẢN
---------------------------------------------------------------
INSERT INTO TAIKHOAN (TENDANGNHAP, MATKHAU, MANV, VAITRO, TRANGTHAI, NGAYTAO)
VALUES
('admin', '123456', 'NV001', N'Admin', N'Hoạt động', GETDATE()),
('thungan1', '123456', 'NV002', N'Thu ngân', N'Hoạt động', GETDATE()),
('quanlykho', '123456', 'NV005', N'Quản lý kho', N'Hoạt động', GETDATE());
GO
