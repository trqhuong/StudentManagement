USE master;
GO
IF DB_ID('QLHocSinh') IS NOT NULL
BEGIN
    ALTER DATABASE QLHocSinh SET SINGLE_USER WITH ROLLBACK IMMEDIATE; 
    DROP DATABASE QLHocSinh;
END
GO
CREATE DATABASE QLHocSinh;
GO
USE QLHocSinh;
GO
-- BẢNG TÀI KHOẢN
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'TAIKHOAN' AND xtype = 'U')
BEGIN
    CREATE TABLE TAIKHOAN (
		MaTK INT IDENTITY(1,1) PRIMARY KEY,
        TenDangNhap NVARCHAR(50) , 
        MatKhau NVARCHAR(255) NOT NULL,      
        LoaiTaiKhoan NVARCHAR(20) NOT NULL CHECK (LoaiTaiKhoan IN (N'Admin', N'Giáo viên')), 
        TrangThai BIT DEFAULT 0     
    );
END
-- BẢNG NĂM HỌC
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'NAMHOC' AND type = 'U')
BEGIN
    CREATE TABLE dbo.NAMHOC (
        MaNH INT IDENTITY(1,1) PRIMARY KEY,
        NamBatDau INT NOT NULL,
		NamKetThuc INT NOT NULL,
		TrangThai BIT DEFAULT 1
    );
END
GO
-- BẢNG HỌC KỲ
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'HOCKY' AND type = 'U')
BEGIN
    CREATE TABLE dbo.HOCKY (
        MaHK INT IDENTITY(1,1) PRIMARY KEY,
        SoHocKy INT NOT NULL,
        NamHoc INT NOT NULL,
		TrangThai BIT DEFAULT 1,
        FOREIGN KEY (NamHoc) REFERENCES dbo.NAMHOC (MaNH)
    );
END
GO
-- BẢNG HỌC SINH
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'HOCSINH' AND type = 'U')
BEGIN
    CREATE TABLE dbo.HOCSINH (
        MaHocSinh INT IDENTITY(1,1) PRIMARY KEY,
        TenHocSinh NVARCHAR(100) NOT NULL,
        NgaySinh DATE NOT NULL CHECK (NgaySinh <= GETDATE()),
        GioiTinh NVARCHAR(3) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
        DienThoai NVARCHAR(15) NULL,
        TinhTrang NVARCHAR(50) NOT NULL DEFAULT N'Đang học',
		QRCodePath NVARCHAR(100)
    );
END
GO
--Bảng điểm danh 
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'ĐIEMDANH' AND type = 'U')
BEGIN
    CREATE TABLE dbo.ĐIEMDANH (
        MaDiemdanh INT IDENTITY(1,1) PRIMARY KEY,
		NgayDiemDanh Date  DEFAULT CAST(GETDATE() AS DATE),
		TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Vắng mặt',
		MaHS INT NOT NULL,
		FOREIGN KEY (MaHS) REFERENCES dbo.HOCSINH(MaHocSinh)
    );
END
-- BẢNG GIÁO VIÊN
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'GIAOVIEN' AND type = 'U')
BEGIN
    CREATE TABLE dbo.GIAOVIEN (
        MaGiaoVien INT IDENTITY(1,1) PRIMARY KEY,
        TenGiaoVien NVARCHAR(100) NOT NULL,
        NgaySinh DATE NOT NULL CHECK (NgaySinh <= GETDATE()),
        GioiTinh NVARCHAR(3) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
        DienThoai NVARCHAR(15) NULL,
        TaiKhoan INT NULL,
		TinhTrang NVARCHAR(50) NOT NULL DEFAULT N'Đang dạy',
		FOREIGN KEY (TaiKhoan) REFERENCES dbo.TAIKHOAN(MaTK)
    );
END
GO
-- BẢNG LỚP HỌC
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LOPHOC' AND type = 'U')
BEGIN
    CREATE TABLE dbo.LOPHOC (
        MaLop INT IDENTITY(1,1) PRIMARY KEY,
        TenLop NVARCHAR(100) NOT NULL,
        NamHoc INT NOT NULL,
        GVQuanLi INT NOT NULL,
        SiSo INT CHECK (SiSo >= 0) DEFAULT 0,
        FOREIGN KEY (NamHoc) REFERENCES dbo.NAMHOC (MaNH),
        FOREIGN KEY (GVQuanLi) REFERENCES dbo.GIAOVIEN (MaGiaoVien)
    );
END
GO
-- BẢNG MÔN HỌC
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'MONHOC' AND xtype = 'U')
BEGIN
    CREATE TABLE MONHOC (
        MaMonHoc INT IDENTITY(1,1) PRIMARY KEY,
        TenMonHoc NVARCHAR(100) NOT NULL
    );
END
-- BẢNG GIÁO VIÊN DẠY MÔN HỌC
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'GIAOVIEN_DAY_MONHOC' AND xtype = 'U')
BEGIN
    CREATE TABLE GIAOVIEN_DAY_MONHOC (
        MaGV INT  NOT NULL,
        MaMH INT  NOT NULL,  
        PRIMARY KEY (MaGV, MaMH), 
        CONSTRAINT FK_GIAOVIEN FOREIGN KEY (MaGV) REFERENCES GIAOVIEN(MaGiaoVien),
        CONSTRAINT FK_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMonHoc)
    );
END
-- BẢNG HỌC SINH HỌC LỚP HỌC
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'HOCSINH_LOP' AND xtype = 'U')
BEGIN
    CREATE TABLE HOCSINH_LOP (
        MaHS INT  NOT NULL,  
        MaLop INT  NOT NULL,
        PRIMARY KEY (MaHS, MaLop), 
        CONSTRAINT FK_HOCSINH FOREIGN KEY (MaHS) REFERENCES HOCSINH(MaHocSinh),
        CONSTRAINT FK_LOP FOREIGN KEY (MaLop) REFERENCES LOPHOC(MaLop)
    );
END
-- PHÂN CÔNG
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'PHANCONG' AND xtype = 'U')
BEGIN
    CREATE TABLE PHANCONG (
		MaGV INT NOT NULL, 
        MaLop INT NOT NULL, 
        MaMH INT NOT NULL,  
		CONSTRAINT FK_PC_GIAOVIEN FOREIGN KEY (MaGV) REFERENCES GIAOVIEN(MaGiaoVien),
        CONSTRAINT FK_PC_LOP FOREIGN KEY (MaLop) REFERENCES LOPHOC(MaLop),
        CONSTRAINT FK_PC_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMonHoc)
    );
END
-- ĐIỂM
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'DIEM' AND xtype = 'U')
BEGIN
    CREATE TABLE DIEM (
		MaLop INT NOT NULL, 
		MaHS INT NOT NULL,
		MaMH INT NOT NULL,
        HocKy INT NOT NULL,
		Diem15P FLOAT CHECK (Diem15P BETWEEN 0 AND 10) DEFAULT 0,
		Diem1T FLOAT CHECK (Diem1T BETWEEN 0 AND 10) DEFAULT 0,
		DiemThi FLOAT CHECK (DiemThi BETWEEN 0 AND 10) DEFAULT 0,
		CONSTRAINT FK_DIEM_MALOP FOREIGN KEY (MaLop) REFERENCES LOPHOC(MaLop),
		CONSTRAINT FK_DIEM_HOCSINH FOREIGN KEY (MaHS) REFERENCES HOCSINH(MaHocSinh),
		CONSTRAINT FK_DIEM_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMonHoc),
        CONSTRAINT FK_DIEM_HOCKY FOREIGN KEY (HocKy) REFERENCES HOCKY(MaHK),
    );
END
-- THÊM DỮ LIỆU BAN ĐẦU
-- TÀI KHOẢN
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan)
VALUES 
    (N'admin', '123456', N'Admin'),
    (N'gv001', '123456', N'Giáo viên'),
    (N'gv002', '123456', N'Giáo viên'),
    (N'gv003', '123456', N'Giáo viên');
GO
-- NĂM HỌC, HỌC KỲ, MÔN HỌC
INSERT INTO NAMHOC (NamBatDau,NamKetThuc,TrangThai) VALUES (2024,2025,1)
INSERT INTO HOCKY (SoHocKy,NamHoc,TrangThai) VALUES (1,1,1)
INSERT INTO HOCKY (SoHocKy,NamHoc,TrangThai) VALUES  (2,1,0)
INSERT INTO MONHOC ([TenMonHoc]) 
VALUES 
	(N'Toán'),
	(N'Ngoại Ngữ'),
	(N'Ngữ Văn')
GO
-- HỌC SINH
INSERT INTO HOCSINH (TenHocSinh, NgaySinh, GioiTinh, DienThoai)
VALUES 
	(N'Huỳnh Thị Thanh Thuý', '2006-09-02', N'Nữ','0721234555'),
    (N'Phạm Minh Kha', '2006-05-15', N'Nam', '0721234001'),
    (N'Lê Thanh Hằng', '2006-11-20', N'Nữ', '0721234002'),
	(N'Trần Anh Thư', '2007-06-30', N'Nữ','0721234567'),
    (N'Đỗ Hoài Nam', '2007-03-10', N'Nam', '0721234003'),
    (N'Võ Ngọc Diệp', '2007-07-25', N'Nữ', '0721234004'),
	(N'Nguyễn Hữu Tài', '2008-08-24', N'Nam','0721236789'),
    (N'Bùi Quốc Bảo', '2008-02-18', N'Nam', '0721234005'),
	(N'Trần Quỳnh Hương', '2008-08-20', N'Nữ','0727894567')
GO
-- GIÁO VIÊN
INSERT INTO GIAOVIEN (TenGiaoVien, NgaySinh, GioiTinh, DienThoai, TaiKhoan)
VALUES 
(N'Nguyễn Văn An', '1985-06-15', N'Nam', '0987654321', 1),
( N'Trần Thị Hồng', '1990-09-22', N'Nữ', '0976543210', 2),
( N'Lê Văn Khoa', '1982-12-30', N'Nam', '0965432109', 3);
GO
-- GIÁO VIÊN DẠY MÔN HỌC
INSERT INTO GIAOVIEN_DAY_MONHOC (MaGV, MaMH) 
VALUES (1, 1), (2, 2), (3, 3)
-- LỚP
INSERT LOPHOC (TenLop, SiSo, GVQuanLi, NamHoc) 
VALUES 
	(N'10A1', 0, 1,1),
	(N'11A1', 0, 2,1),
	(N'12A1', 0, 3,1)
GO
-- HỌC SINH HỌC LỚP
INSERT HOCSINH_LOP(MaHS, MaLop) 
VALUES 
	(1, 3), (2, 3), (3, 3),
	(4, 2), (5, 2), (6, 2),
	(7, 1), (8, 1), (9, 1)
GO
UPDATE LOPHOC 
SET SiSo = 3 
WHERE MaLop = 1;
UPDATE LOPHOC 
SET SiSo = 3
WHERE MaLop = 2;
UPDATE LOPHOC 
SET SiSo = 3
WHERE MaLop = 3;
GO
-- PHÂN CÔNG 
INSERT INTO PHANCONG (MaGV, MaLop, MaMH)
VALUES 
    -- Lớp 10A1 (MaLop = 1)
    (1, 1, 1), 
    (2, 1, 2), 
    (3, 1, 3), 
    -- Lớp 11A1 (MaLop = 2)
    (1, 2, 1),
    (2, 2, 2),
    (3, 2, 3),
    -- Lớp 12A1 (MaLop = 3)
    (1, 3, 1),
    (2, 3, 2),
    (3, 3, 3)
/*-- BẢNG ĐIỂM
-- Lớp 12C1
INSERT INTO BANGDIEM (MaGV, MaLop, MaMH, HocKy) VALUES 
(1, 3, 1, 1),  
(2, 3, 2, 1),  
(3, 3, 3, 1);
-- Lớp 11B1
INSERT INTO BANGDIEM (MaGV, MaLop, MaMH, HocKy) VALUES 
(1, 2, 1, 1),  
(2, 2, 2, 1),  
(3, 2, 3, 1);
-- Lớp 10A1
INSERT INTO BANGDIEM (MaGV, MaLop, MaMH, HocKy) VALUES 
(1, 1, 1, 1),  
(2, 1, 2, 1),  
(3, 1, 3, 1);
GO
-- ĐIỂM
INSERT INTO DIEM (MaBD, MaHS, Diem, LoaiDiem, SoCot)
VALUES 
      -- HS001 - Lớp 12A1
	(1, 1, 7.5, N'15P', 1),(1, 1, 8.5, N'1T', 1), (1, 1, 8.5, N'Thi', 1),
	(2, 1, 6.5, N'15P', 1),(2, 1, 7.5, N'1T', 1), (2, 1, 8.5, N'Thi', 1),
	(3, 1, 9.0, N'15P', 1),(3, 1, 9.0, N'1T', 1),(3, 1, 8.5, N'Thi', 1),

    -- HS002 - Lớp 12A1
	(1, 2, 8.0, N'15P', 1),(1, 2, 8.0, N'1T', 1),(1, 2, 7.0, N'Thi', 1),
	(2, 2, 7.5, N'15P', 1),(2, 2, 7.5, N'1T', 1),(2, 2, 6.5, N'Thi', 1),
	(3, 2, 9.5, N'15P', 1),(3, 2, 9.0, N'1T', 1),(3, 2, 8.0, N'Thi', 1),

    -- HS003 - Lớp 12A1
	(1, 3, 6.5, N'15P', 1),(1, 3, 7.5, N'1T', 1),(1, 3, 7.5, N'Thi', 1),
	(2, 3, 8.0, N'15P', 1), (2, 3, 8.0, N'1T', 1),(2, 3, 8.0, N'Thi', 1),
	(3, 3, 9.0, N'15P', 1),(3, 3, 9.5, N'1T', 1),(3, 3, 9.5, N'Thi', 1),

    -- HS004 - Lớp 11A1
	(4, 4, 7.0, N'15P', 1),(4, 4, 8.0, N'1T', 1),(4, 4, 9.0, N'Thi', 1),
	(5, 4, 6.0, N'15P', 1),(5, 4, 7.0, N'1T', 1), (5, 4, 5.0, N'Thi', 1),
	(6, 4, 8.5, N'15P', 1),(6, 4, 9.0, N'1T', 1),(6, 4, 10.0, N'Thi', 1),

    -- HS005 - Lớp 11A1
	(4, 5, 6.5, N'15P', 1),(4, 5, 7.5, N'1T', 1),(4, 5, 7.5, N'Thi', 1),
	(5, 5, 7.5, N'15P', 1),(5, 5, 8.5, N'1T', 1),(5, 5, 8.5, N'Thi', 1),
	(6, 5, 9.0, N'15P', 1),(6, 5, 9.5, N'1T', 1),(6, 5, 9.0, N'Thi', 1),

	-- HS006 - Lớp 11A1
	(4, 6, 8, N'15P', 1),(4, 6, 7.5, N'1T', 1),(4, 6, 8.5, N'Thi', 1),
	(5, 6, 7.5, N'15P', 1),(5, 6, 9, N'1T', 1),(5, 6, 8.5, N'Thi', 1),
	(6, 6, 9.0, N'15P', 1),(6, 6, 9.5, N'1T', 1),(6, 6, 8.0, N'Thi', 1),

    -- HS007 - Lớp 10A1
	(7, 7, 8.5, N'15P', 1),(7, 7, 9.5, N'1T', 1),(7, 7, 8.0, N'Thi', 1),
	(8, 7, 7.0, N'15P', 1),(8, 7, 8.0, N'1T', 1), (8, 7, 6.0, N'Thi', 1),
	(9, 7, 8.5, N'15P', 1),(9, 7, 9.5, N'1T', 1),(9, 7, 8.0, N'Thi', 1),

    -- HS008 - Lớp 10A1
	(7, 8, 5.5, N'15P', 1),(7, 8, 7.5, N'1T', 1),(7, 8, 5.0, N'Thi', 1),
	(8, 8, 8.0, N'15P', 1),(8, 8, 9.0, N'1T', 1),(8, 8, 9.0, N'Thi', 1),
	(9, 8, 9.5, N'15P', 1),(9, 8, 8.5, N'1T', 1),(9, 8, 6.0, N'Thi', 1),

    -- HS009 - Lớp 10A1
	(7, 9, 7.0, N'15P', 1),(7, 9, 8.0, N'1T', 1), (7, 9, 8.0, N'Thi', 1),
	(8, 9, 6.5, N'15P', 1), (8, 9, 7.5, N'1T', 1),(8, 9, 7.5, N'Thi', 1),
	(9, 9, 9.0, N'15P', 1), (9, 9, 9.5, N'1T', 1),(9, 9, 9.5, N'Thi', 1)
GO*/