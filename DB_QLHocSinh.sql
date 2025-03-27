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
        MaNH NVARCHAR(10) NOT NULL PRIMARY KEY,
        NamBatDau INT NOT NULL,
		NamKetThuc INT NOT NULL
    );
END
GO
-- BẢNG HỌC KỲ
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'HOCKY' AND type = 'U')
BEGIN
    CREATE TABLE dbo.HOCKY (
        MaHK NVARCHAR(10) NOT NULL PRIMARY KEY,
        SoHocKy INT NOT NULL,
        NamHoc NVARCHAR(10) NOT NULL,
		TrangThai BIT DEFAULT 1,
        FOREIGN KEY (NamHoc) REFERENCES dbo.NAMHOC (MaNH)
    );
END
GO
-- BẢNG HỌC SINH
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'HOCSINH' AND type = 'U')
BEGIN
    CREATE TABLE dbo.HOCSINH (
        MaHocSinh NVARCHAR(10) NOT NULL PRIMARY KEY,
        TenHocSinh NVARCHAR(100) NOT NULL,
        NgaySinh DATE NOT NULL CHECK (NgaySinh <= GETDATE()),
        GioiTinh NVARCHAR(3) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
        DienThoai NVARCHAR(15) NULL,
        TinhTrang NVARCHAR(50) NOT NULL DEFAULT N'Đang học'
    );
END
GO
-- BẢNG GIÁO VIÊN
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'GIAOVIEN' AND type = 'U')
BEGIN
    CREATE TABLE dbo.GIAOVIEN (
        MaGiaoVien NVARCHAR(10) NOT NULL PRIMARY KEY,
        TenGiaoVien NVARCHAR(100) NOT NULL,
        NgaySinh DATE NOT NULL CHECK (NgaySinh <= GETDATE()),
        GioiTinh NVARCHAR(3) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ')),
        DienThoai NVARCHAR(15) NULL,
        TaiKhoan INT NOT NULL,
		FOREIGN KEY (TaiKhoan) REFERENCES dbo.TAIKHOAN(MaTK)
    );
END
GO
-- BẢNG LỚP HỌC
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LOPHOC' AND type = 'U')
BEGIN
    CREATE TABLE dbo.LOPHOC (
        MaLop NVARCHAR(10) NOT NULL PRIMARY KEY,
        TenLop NVARCHAR(100) NOT NULL,
        NamHoc NVARCHAR(10) NOT NULL,
        GVQuanLi NVARCHAR(10) NOT NULL,
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
        MaMonHoc NVARCHAR(10) PRIMARY KEY, 
        TenMonHoc NVARCHAR(100) NOT NULL
    );
END
-- BẢNG GIÁO VIÊN DẠY MÔN HỌC
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'GIAOVIEN_DAY_MONHOC' AND xtype = 'U')
BEGIN
    CREATE TABLE GIAOVIEN_DAY_MONHOC (
        MaGV NVARCHAR(10) NOT NULL,  
        MaMH NVARCHAR(10) NOT NULL,  
        PRIMARY KEY (MaGV, MaMH), 
        CONSTRAINT FK_GIAOVIEN FOREIGN KEY (MaGV) REFERENCES GIAOVIEN(MaGiaoVien),
        CONSTRAINT FK_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMonHoc)
    );
END
-- BẢNG HỌC SINH HỌC LỚP HỌC
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'HOCSINH_LOP' AND xtype = 'U')
BEGIN
    CREATE TABLE HOCSINH_LOP (
        MaHS NVARCHAR(10) NOT NULL,  
        MaLop NVARCHAR(10) NOT NULL,
        PRIMARY KEY (MaHS, MaLop), 
        CONSTRAINT FK_HOCSINH FOREIGN KEY (MaHS) REFERENCES HOCSINH(MaHocSinh),
        CONSTRAINT FK_LOP FOREIGN KEY (MaLop) REFERENCES LOPHOC(MaLop)
    );
END
-- BẢNG BẢNG ĐIỂM
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'BANGDIEM' AND xtype = 'U')
BEGIN
    CREATE TABLE BANGDIEM (
        MaBD INT IDENTITY(1,1) PRIMARY KEY,
		MaGV NVARCHAR(10) NOT NULL, 
        MaLop NVARCHAR(10) NOT NULL, 
        MaMH NVARCHAR(10) NOT NULL, 
        HocKy NVARCHAR(10) NOT NULL,
		SoCot15P INT DEFAULT 1,
		SoCot1T INT DEFAULT 1,
		CONSTRAINT FK_BD_GIAOVIEN FOREIGN KEY (MaGV) REFERENCES GIAOVIEN(MaGiaoVien),
        CONSTRAINT FK_BD_LOP FOREIGN KEY (MaLop) REFERENCES LOPHOC(MaLop),
        CONSTRAINT FK_BD_MONHOC FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMonHoc),
        CONSTRAINT FK_BD_HOCKY FOREIGN KEY (HocKy) REFERENCES HOCKY(MaHK)
    );
END
-- BẢNG ĐIỂM
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'DIEM' AND xtype = 'U')
BEGIN
    CREATE TABLE DIEM (
        MaDiem INT IDENTITY(1,1) PRIMARY KEY,
		MaBD INT NOT NULL, 
        MaHS NVARCHAR(10) NOT NULL,  
		Diem FLOAT CHECK (Diem BETWEEN 0 AND 10),
		LoaiDiem NVARCHAR(20) NOT NULL CHECK (LoaiDiem IN (N'15P', N'1T','Thi')), 
		SoCot INT DEFAULT 1,
        CONSTRAINT FK_DIEM_HOCSINH FOREIGN KEY (MaHS) REFERENCES HOCSINH(MaHocSinh),
        CONSTRAINT FK_DIEM_LOP FOREIGN KEY (MaBD) REFERENCES BANGDIEM(MaBD),
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
INSERT INTO NAMHOC (MaNH,NamBatDau,NamKetThuc) VALUES ('NH2024',2024,2025)
INSERT INTO HOCKY (MaHK,SoHocKy,NamHoc,TrangThai) VALUES ('HK241',1,'NH2024',0)
INSERT INTO HOCKY (MaHK,SoHocKy,NamHoc) VALUES  ('HK242',2,'NH2024')
INSERT [dbo].[MONHOC] ([MaMonHoc], [TenMonHoc]) 
VALUES 
	(N'MH001', N'Toán'),
	(N'MH002', N'Ngoại Ngữ'),
	(N'MH003', N'Ngữ Văn')
GO
-- HỌC SINH
INSERT INTO HOCSINH (MaHocSinh, TenHocSinh, NgaySinh, GioiTinh, DienThoai)
VALUES 
	(N'HS001', N'Huỳnh Thị Thanh Thuý', '2006-09-02', N'Nữ','0721234555'),
    (N'HS002', N'Phạm Minh Khang', '2006-05-15', N'Nam', '0721234001'),
    (N'HS003', N'Lê Thanh Hằng', '2006-11-20', N'Nữ', '0721234002'),
	(N'HS004', N'Trần Anh Thư', '2007-01-01', N'Nữ','0721234567'),
    (N'HS005', N'Đỗ Hoài Nam', '2007-03-10', N'Nam', '0721234003'),
    (N'HS006', N'Võ Ngọc Diệp', '2007-07-25', N'Nữ', '0721234004'),
	(N'HS007', N'Nguyễn Hữu Tài', '2008-08-24', N'Nam','0721236789'),
    (N'HS008', N'Bùi Quốc Bảo', '2008-02-18', N'Nam', '0721234005'),
	(N'HS009', N'Trần Quỳnh Hương', '2008-08-20', N'Nữ','0727894567')
GO
-- GIÁO VIÊN
INSERT INTO GIAOVIEN (MaGiaoVien, TenGiaoVien, NgaySinh, GioiTinh, DienThoai, TaiKhoan)
VALUES 
('GV001', N'Nguyễn Văn An', '1985-06-15', N'Nam', '0987654321', 1),
('GV002', N'Trần Thị Hồng', '1990-09-22', N'Nữ', '0976543210', 2),
('GV003', N'Lê Văn Khoa', '1982-12-30', N'Nam', '0965432109', 3);
GO
-- GIÁO VIÊN DẠY MÔN HỌC
INSERT INTO GIAOVIEN_DAY_MONHOC (MaGV, MaMH) 
VALUES (N'GV001', N'MH001'), (N'GV002', N'MH002'), (N'GV003', N'MH003')
-- LỚP
INSERT LOPHOC (MaLop, TenLop, SiSo, GVQuanLi, NamHoc) 
VALUES 
	(N'LH001', N'10A1', 1, N'GV001',N'NH2024'),
	(N'LH002', N'11A1', 1, N'GV002',N'NH2024'),
	(N'LH003', N'12A1', 1, N'GV003',N'NH2024')
GO
-- HỌC SINH HỌC LỚP
INSERT HOCSINH_LOP(MaHS, MaLop) 
VALUES 
	(N'HS001', N'LH003'),(N'HS002', N'LH003'),(N'HS003', N'LH003'),
	(N'HS004', N'LH002'),(N'HS005', N'LH002'),(N'HS006', N'LH002'),
	(N'HS007', N'LH001'),(N'HS008', N'LH001'),(N'HS009', N'LH001')
GO
UPDATE LOPHOC 
SET SiSo = 3 
WHERE MaLop = 'LH001';
UPDATE LOPHOC 
SET SiSo = 3
WHERE MaLop = 'LH002';
UPDATE LOPHOC 
SET SiSo = 3
WHERE MaLop = 'LH003';
GO
-- BẢNG ĐIỂM
-- Lớp 12C1
INSERT INTO BANGDIEM (MaGV, MaLop, MaMH, HocKy) VALUES 
( N'GV001',N'LH003', N'MH001', N'HK241'), 
( N'GV002',N'LH003', N'MH002', N'HK241'), 
( N'GV003',N'LH003', N'MH003', N'HK241');
-- Lớp 11B1
INSERT INTO BANGDIEM (MaGV, MaLop, MaMH, HocKy) VALUES 
( N'GV001',N'LH002', N'MH001', N'HK241'), 
( N'GV002',N'LH002', N'MH002', N'HK241'), 
( N'GV003',N'LH002', N'MH003', N'HK241');
-- Lớp 10A1
INSERT INTO BANGDIEM (MaGV, MaLop, MaMH, HocKy) VALUES 
( N'GV001',N'LH001', N'MH001', N'HK241'), 
( N'GV002',N'LH001', N'MH002', N'HK241'), 
( N'GV003',N'LH001', N'MH003', N'HK241');
GO
-- ĐIỂM
INSERT INTO DIEM (MaBD, MaHS, Diem, LoaiDiem, SoCot)
VALUES 
      -- HS001 - Lớp 12A1
    (1, N'HS001', 7.5, N'15P', 1),(1, N'HS001', 8.5, N'1T', 1), (1, N'HS001', 8.5, N'Thi', 1),
    (2, N'HS001', 6.5, N'15P', 1),(2, N'HS001', 7.5, N'1T', 1), (2, N'HS001', 8.5, N'Thi', 1),
    (3, N'HS001', 9.0, N'15P', 1),(3, N'HS001', 9.0, N'1T', 1),(3, N'HS001', 8.5, N'Thi', 1),

    -- HS002 - Lớp 12A1
    (1, N'HS002', 8.0, N'15P', 1),(1, N'HS002', 8.0, N'1T', 1),(1, N'HS002', 7.0, N'Thi', 1),
    (2, N'HS002', 7.5, N'15P', 1),(2, N'HS002', 7.5, N'1T', 1),(2, N'HS002', 6.5, N'Thi', 1),
    (3, N'HS002', 9.5, N'15P', 1),(3, N'HS002', 9.0, N'1T', 1),(3, N'HS002', 8.0, N'Thi', 1),

    -- HS003 - Lớp 12A1
    (1, N'HS003', 6.5, N'15P', 1),(1, N'HS003', 7.5, N'1T', 1),(1, N'HS003', 7.5, N'Thi', 1),
    (2, N'HS003', 8.0, N'15P', 1), (2, N'HS003', 8.0, N'1T', 1),(2, N'HS003', 8.0, N'Thi', 1),
    (3, N'HS003', 9.0, N'15P', 1),(3, N'HS003', 9.5, N'1T', 1),(3, N'HS003', 9.5, N'Thi', 1),

    -- HS004 - Lớp 11A1
    (4, N'HS004', 7.0, N'15P', 1),(4, N'HS004', 8.0, N'1T', 1),(4, N'HS004', 9.0, N'Thi', 1),
    (5, N'HS004', 6.0, N'15P', 1),(5, N'HS004', 7.0, N'1T', 1), (5, N'HS004', 5.0, N'Thi', 1),
    (6, N'HS004', 8.5, N'15P', 1),(6, N'HS004', 9.0, N'1T', 1),(6, N'HS004', 10.0, N'Thi', 1),

    -- HS005 - Lớp 11A1
    (4, N'HS005', 6.5, N'15P', 1),(4, N'HS005', 7.5, N'1T', 1),(4, N'HS005', 7.5, N'Thi', 1),
    (5, N'HS005', 7.5, N'15P', 1),(5, N'HS005', 8.5, N'1T', 1),(5, N'HS005', 8.5, N'Thi', 1),
    (6, N'HS005', 9.0, N'15P', 1),(6, N'HS005', 9.5, N'1T', 1),(6, N'HS005', 9.0, N'Thi', 1),

	-- HS006 - Lớp 11A1
    (4, N'HS006', 8, N'15P', 1),(4, N'HS005', 7.5, N'1T', 1),(4, N'HS005', 8.5, N'Thi', 1),
    (5, N'HS006', 7.5, N'15P', 1),(5, N'HS005', 9, N'1T', 1),(5, N'HS005', 8.5, N'Thi', 1),
    (6, N'HS006', 9.0, N'15P', 1),(6, N'HS005', 9.5, N'1T', 1),(6, N'HS005', 8.0, N'Thi', 1),

    -- HS007 - Lớp 10A1
    (7, N'HS007', 8.5, N'15P', 1),(7, N'HS007', 9.5, N'1T', 1),(7, N'HS007', 8.0, N'Thi', 1),
    (8, N'HS007', 7.0, N'15P', 1),(8, N'HS007', 8.0, N'1T', 1), (8, N'HS007', 6.0, N'Thi', 1),
    (9, N'HS007', 8.5, N'15P', 1),(9, N'HS007', 9.5, N'1T', 1),(9, N'HS007', 8.0, N'Thi', 1),

    -- HS008 - Lớp 10A1
    (7, N'HS008', 5.5, N'15P', 1),(7, N'HS008', 7.5, N'1T', 1),(7, N'HS008', 5.0, N'Thi', 1),
    (8, N'HS008', 8.0, N'15P', 1),(8, N'HS008', 9.0, N'1T', 1),(8, N'HS008', 9.0, N'Thi', 1),
    (9, N'HS008', 9.5, N'15P', 1),(9, N'HS008', 8.5, N'1T', 1),(9, N'HS008', 6.0, N'Thi', 1),

    -- HS009 - Lớp 10A1
    (7, N'HS009', 7.0, N'15P', 1),(7, N'HS009', 8.0, N'1T', 1), (7, N'HS009', 8.0, N'Thi', 1),
    (8, N'HS009', 6.5, N'15P', 1), (8, N'HS009', 7.5, N'1T', 1),(8, N'HS009', 7.5, N'Thi', 1),
    (9, N'HS009', 9.0, N'15P', 1), (9, N'HS009', 9.5, N'1T', 1),(9, N'HS009', 9.5, N'Thi', 1)
GO

