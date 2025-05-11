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
        TrangThai BIT DEFAULT 0,
		Email NVARCHAR(100) NULL
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
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'DIEMDANH' AND type = 'U')
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
		Khoi int NOT NULL,
        NamHoc INT NOT NULL,
        GVQuanLi INT NULL,
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
		PRIMARY KEY (MaGV, MaLop, MaMH),
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
		PRIMARY KEY (MaHS, MaLop, MaMH, HocKy),
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
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, Email)
VALUES 
    (N'admin', '123456', N'Admin','quynhhuongtran314@gmail.com'),
    (N'gv001', '123456', N'Giáo viên','sheisthy29@gmail.com'),
    (N'gv002', '123456', N'Giáo viên',NULL),
    (N'gv003', '123456', N'Giáo viên',NULL);
GO
-- NĂM HỌC, HỌC KỲ, MÔN HỌC
INSERT INTO NAMHOC (NamBatDau,NamKetThuc,TrangThai) VALUES (2024,2025,1)
INSERT INTO HOCKY (SoHocKy,NamHoc,TrangThai) VALUES (1,1,0)
INSERT INTO HOCKY (SoHocKy,NamHoc,TrangThai) VALUES (2,1,1)
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
(N'Nguyễn Văn An', '1985-06-15', N'Nam', '0987654321', 2),
( N'Trần Thị Hồng', '1990-09-22', N'Nữ', '0976543210', 3),
( N'Lê Văn Khoa', '1982-12-30', N'Nam', '0965432109', 4);
GO
-- GIÁO VIÊN DẠY MÔN HỌC
INSERT INTO GIAOVIEN_DAY_MONHOC (MaGV, MaMH) 
VALUES (1, 1), (2, 2), (3, 3)
-- LỚP
INSERT LOPHOC (TenLop, Khoi, SiSo, GVQuanLi, NamHoc) 
VALUES 
	(N'10A1',10, 0, 1,1),
	(N'11B1',11, 0, 2,1),
	(N'12C1',12, 0, 3,1)
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
    (3, 2, 3)
GO
--Điểm
INSERT INTO DIEM (MaLop, MaHS, MaMH, HocKy, Diem15P, Diem1T, DiemThi)
VALUES
-- Lớp 12C1 - Học kỳ 1
(3, 1, 1, 1, 7.0, 7.5, 8.0), (3, 1, 2, 1, 7.0, 7.0, 8.0), (3, 1, 3, 1, 6.5, 6.5, 7.0),
(3, 2, 1, 1, 9.0, 9.5, 9.0), (3, 2, 2, 1, 9.5, 9.0, 9.5), (3, 2, 3, 1, 10.0, 9.5, 10.0),
(3, 3, 1, 1, 2.0, 2.5, 3.0), (3, 3, 2, 1, 3.0, 2.5, 3.0), (3, 3, 3, 1, 2.5, 3.0, 3.5),
-- Lớp 11B1 - Học kỳ 1
(2, 4, 1, 1, 6.0, 6.0, 6.5), (2, 4, 2, 1, 5.5, 6.0, 5.5), (2, 4, 3, 1, 6.0, 6.5, 6.5),
(2, 5, 1, 1, 8.0, 7.5, 9.0), (2, 5, 2, 1, 8.0, 8.0, 8.5), (2, 5, 3, 1, 8.0, 9.0, 8.0),
(2, 6, 1, 1, 3.0, 3.5, 4.0), (2, 6, 2, 1, 4.0, 3.5, 3.0), (2, 6, 3, 1, 4.5, 3.5, 4.0),
-- Lớp 10A1 - Học kỳ 1
(1, 7, 1, 1, 6.0, 6.5, 6.5), (1, 7, 2, 1, 6.0, 6.0, 6.0), (1, 7, 3, 1, 6.5, 7.0, 6.0),
(1, 8, 1, 1, 7.5, 7.0, 7.5), (1, 8, 2, 1, 6.5, 7.0, 7.0), (1, 8, 3, 1, 7.0, 6.5, 6.5),
(1, 9, 1, 1, 7.0, 8.0, 8.5), (1, 9, 2, 1, 9.0, 9.5, 8.0), (1, 9, 3, 1, 8.5, 9.0, 9.5),
-- Lớp 12C1 - Học kỳ 2
(3, 1, 1, 2, 5.5, 6.0, 6.5), (3, 1, 2, 2, 7.0, 6.0, 6.5), (3, 1, 3, 2, 6.0, 7.5, 7.0),
(3, 2, 1, 2, 8.5, 8.0, 9.0), (3, 2, 2, 2, 9.5, 9.0, 10.0), (3, 2, 3, 2, 9.0, 9.5, 9.5),
(3, 3, 1, 2, 2.0, 3.0, 3.0), (3, 3, 2, 2, 2.5, 2.0, 3.0), (3, 3, 3, 2, 3.5, 3.0, 4.0),
-- Lớp 11B1 - Học kỳ 2
(2, 4, 1, 2, 6.5, 5.5, 6.0), (2, 4, 2, 2, 6.0, 6.0, 5.5), (2, 4, 3, 2, 6.5, 7.0, 6.5),
(2, 5, 1, 2, 8.0, 8.5, 9.0), (2, 5, 2, 2, 7.5, 7.0, 8.0), (2, 5, 3, 2, 8.0, 8.5, 8.0),
(2, 6, 1, 2, 8.0, 8.5, 9.0), (2, 6, 2, 2, 7.0, 7.5, 8.0), (2, 6, 3, 2, 9.5, 9.5, 10.0),
-- Lớp 10A1 - Học kỳ 2
(1, 7, 1, 2, 6.0, 6.0, 6.0), (1, 7, 2, 2, 6.5, 6.0, 7.0), (1, 7, 3, 2, 6.0, 6.5, 6.5),
(1, 8, 1, 2, 7.0, 7.5, 8.0), (1, 8, 2, 2, 7.5, 6.5, 6.0), (1, 8, 3, 2, 7.0, 6.5, 8.5),
(1, 9, 1, 2, 7.0, 8.0, 8.5), (1, 9, 2, 2, 9.0, 9.5, 8.0), (1, 9, 3, 2, 8.5, 9.0, 9.5)
GO
--Điểm Danh
INSERT INTO dbo.ĐIEMDANH (MaHS, NgayDiemDanh, TrangThai)
VALUES 
    (3, '2025-05-11', N'Vắng mặt'),
    (2, '2025-05-10', N'Vắng mặt'),
    (3, '2025-05-10', N'Vắng mặt'),
    (2, '2025-05-11', N'Vắng mặt');
GO
--Stored Procedure: 
-- lấy mã giáo viên đang đăng nhập
CREATE PROCEDURE sp_GetTeacherActive
AS
BEGIN
    SELECT MaGiaoVien
    FROM GIAOVIEN
    WHERE TaiKhoan IN (
        SELECT MaTK
        FROM TAIKHOAN
        WHERE TrangThai = 1
    )
END
GO
-- Lấy môn học giáo viên đang dạy
CREATE PROCEDURE sp_GetAssignmentSubject
    @MaGV INT
AS
BEGIN
    SELECT * 
    FROM dbo.MONHOC
    WHERE MaMonHoc IN (
        SELECT MaMH 
        FROM dbo.PHANCONG 
        WHERE MaGV = @MaGV
    );
END
GO
--Lấy các lớp giáo viên đang dạy môn học này
CREATE PROCEDURE sp_GetAssignmentClass
    @MaGV INT,
    @MaMH INT
AS
BEGIN
    SELECT * 
    FROM LOPHOC 
    WHERE MaLop IN (
        SELECT p.MaLop 
        FROM PHANCONG p
        JOIN LOPHOC l ON p.MaLop = l.MaLop
        JOIN NAMHOC m ON l.NamHoc = m.MaNH
        WHERE p.MaGV = @MaGV 
          AND p.MaMH = @MaMH 
          AND m.TrangThai = 1
    );
END
GO
-- Xuất điểm
CREATE PROCEDURE sp_ExportScore
    @MaLop INT,
    @MaMH  INT
AS
BEGIN
    SELECT 
        hs.MaHocSinh,
        -- Điểm trung bình học kỳ 1
        ROUND(AVG(
            CASE WHEN hk.SoHocKy = 1 THEN 
                (ISNULL(d.Diem15P,0) + ISNULL(d.Diem1T,0) * 2+ ISNULL(d.DiemThi,0)  * 3) / 6.0
            END
        ), 1) AS DiemTBHK1,
        -- Điểm trung bình học kỳ 2
        ROUND(AVG(
            CASE WHEN hk.SoHocKy = 2 THEN 
                (ISNULL(d.Diem15P,0) + ISNULL(d.Diem1T,0) * 2 + ISNULL(d.DiemThi,0)  * 3) / 6.0
            END
        ), 1) AS DiemTBHK2
    FROM DIEM d
    INNER JOIN HOCSINH hs ON d.MaHS   = hs.MaHocSinh
    INNER JOIN MONHOC  mh ON d.MaMH   = mh.MaMonHoc
    INNER JOIN LOPHOC  l  ON d.MaLop = l.MaLop
    INNER JOIN HOCKY   hk ON d.HocKy  = hk.MaHK
    WHERE d.MaLop = @MaLop
      AND d.MaMH  = @MaMH
    GROUP BY hs.MaHocSinh;
END
GO
--Tính thống kê
CREATE PROCEDURE sp_ThongKeTyLeDat
    @maMon INT,
    @hocKy INT,
    @namHoc INT
AS
BEGIN
    SELECT 
        l.MaLop, 
        l.TenLop,
        COUNT(DISTINCT d.MaHS) AS SiSo,
        SUM(CASE WHEN 
                ((ISNULL(d.Diem15P, 0) + ISNULL(d.Diem1T, 0) * 2 + ISNULL(d.DiemThi, 0) * 3) / 6.0) >= 5 
            THEN 1 ELSE 0 
        END) AS SoLuongDat
    FROM LOPHOC l
    INNER JOIN DIEM d ON l.MaLop = d.MaLop
    INNER JOIN MONHOC mh ON d.MaMH = mh.MaMonHoc
    INNER JOIN HOCKY hk ON d.HocKy = hk.MaHK
    WHERE mh.MaMonHoc = @maMon 
      AND d.HocKy = @hocKy 
      AND hk.NamHoc = @namHoc
    GROUP BY l.MaLop, l.TenLop
    ORDER BY l.MaLop;
END
GO
--
--Lấy hs bằng ID
CREATE PROCEDURE sp_GetHocSinhById
    @MaHocSinh INT
AS
BEGIN
    SELECT hs.MaHocSinh, 
           hs.TenHocSinh, 
           hs.NgaySinh, 
           hs.GioiTinh, 
           hs.TinhTrang, 
           hs.QRCodePath, 
           l.TenLop
    FROM HOCSINH hs
    INNER JOIN HOCSINH_LOP hs_l ON hs.MaHocSinh = hs_l.MaHS
    INNER JOIN LOPHOC l ON hs_l.MaLop = l.MaLop
    WHERE hs.MaHocSinh = @MaHocSinh
END
GO
-- tính điểm trung bình 
CREATE PROCEDURE sp_FinalScore
    @MaHS INT,
    @MaLop INT
AS
BEGIN
    SELECT 
        mh.TenMonHoc,
        ROUND((
            ISNULL(AVG(CASE WHEN hk.SoHocKy = 1 THEN 
                (ISNULL(d.Diem15P, 0) + ISNULL(d.Diem1T, 0)*2 + ISNULL(d.DiemThi, 0)*3)/6.0
            END), 0)
            +
            ISNULL(AVG(CASE WHEN hk.SoHocKy = 2 THEN 
                (ISNULL(d.Diem15P, 0) + ISNULL(d.Diem1T, 0)*2 + ISNULL(d.DiemThi, 0)*3)/6.0
            END), 0) * 2
        ) / 3.0, 1) AS DiemTBCaNam

    FROM DIEM d
    INNER JOIN MONHOC mh ON d.MaMH = mh.MaMonHoc
    INNER JOIN HOCKY hk ON d.HocKy = hk.MaHK
    WHERE d.MaHS = @MaHS
      AND d.MaLop = @MaLop
    GROUP BY mh.TenMonHoc;
END
GO
--lấy khối lớn nhất của học sinh chưa có lớp
CREATE PROCEDURE sp_GetMaxKhoi
AS
BEGIN
	SELECT 
		hs.MaHocSinh, 
		hs.TenHocSinh,
		hs.GioiTinh,
		hs.NgaySinh,
		MAX(l.Khoi) AS KhoiLonNhat
	FROM HOCSINH hs
	JOIN HOCSINH_LOP hl ON hs.MaHocSinh = hl.MaHS
	JOIN LOPHOC l ON hl.MaLop = l.MaLop
	WHERE NOT EXISTS (
		SELECT 1 
		FROM HOCSINH_LOP hl2
		JOIN LOPHOC l2 ON hl2.MaLop = l2.MaLop
		JOIN NAMHOC n2 ON l2.NamHoc = n2.MaNH
		WHERE hl2.MaHS = hs.MaHocSinh AND n2.TrangThai = 1
	)
	GROUP BY hs.MaHocSinh, hs.TenHocSinh, hs.GioiTinh, hs.NgaySinh;
END;
GO
--------------------
CREATE PROCEDURE sp_LayHocSinhVang2NgayLienTiep
AS
BEGIN 
    WITH VangMatLienTiep AS ( --dùng CTE để lưu sử dụng bảng tạm thời
        SELECT 
            d1.MaHS,
            d1.NgayDiemDanh AS Ngay1,
            d2.NgayDiemDanh AS Ngay2
        FROM ĐIEMDANH d1
        JOIN ĐIEMDANH d2
            ON d1.MaHS = d2.MaHS
            AND d1.NgayDiemDanh = DATEADD(DAY, -1, d2.NgayDiemDanh) --day 1 là ngày trc day 2 1 ngày
        WHERE d1.TrangThai = N'Vắng mặt'
          AND d2.TrangThai = N'Vắng mặt'
    )
    SELECT 
        hs.MaHocSinh,
        hs.TenHocSinh,
        l.MaLop,
        l.TenLop,
        gv.MaGiaoVien,
        gv.TenGiaoVien,
        tk.Email,
        vml.Ngay1,
        vml.Ngay2
    FROM VangMatLienTiep vml
    JOIN HOCSINH hs ON vml.MaHS = hs.MaHocSinh
    JOIN HOCSINH_LOP hsl ON hs.MaHocSinh = hsl.MaHS
    JOIN LOPHOC l ON hsl.MaLop = l.MaLop
    JOIN GIAOVIEN gv ON l.GVQuanLi = gv.MaGiaoVien
    JOIN TAIKHOAN tk ON gv.TaiKhoan = tk.MaTK
    WHERE vml.Ngay1 = DATEADD(DAY, -1, CAST(GETDATE() AS DATE))
      AND vml.Ngay2 = CAST(GETDATE() AS DATE)
END
GO