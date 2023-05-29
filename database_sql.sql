CREATE DATABASE QuanLyNhaXe
Go


USE QuanLyNhaXe
Go



CREATE TABLE dbo.NhanVien
(
	MaNV int not null,
	HoVaTen nvarchar(255) not null,
	NgaySinh Date not null,
	UserLogin varchar(255) not null,
	PassLogin varchar(255) not null,
	Primary key(MaNV)
)
Insert into Nhanvien Values (1,'Dao Xuan Tri','2002-11-26','1','1');
Insert into Nhanvien Values (2,'Vu Tran Thanh Cong','2002-01-15','user02','123');
Insert into Nhanvien Values (3,'Tran Tan Khoa','2002-07-15','user03','123');
Insert into Nhanvien Values (4,'Kong Her','2002-06-11','user04','123');
Insert into Nhanvien Values (5,'Nguyen Nhu Sam','2002-04-14','user05','123');


CREATE TABLE dbo.MauSac
(
	MaMS int primary key not null,
	MS nvarchar(50) not null
)

Insert into MauSac Values (1,'Vàng');
Insert into MauSac Values (2,'Đen');
Insert into MauSac Values (3,'Trang');
Insert into MauSac Values (4,'Đo');
Insert into MauSac Values (5,'Tím');

CREATE TABLE dbo.BangGia
(
	MaGia int primary key not null,
	LoaiXe nvarchar(100) ,
	Gia int not null
)

Insert into BangGia Values (1,'',100000);
Insert into BangGia Values (2,'Xe May',5000);
Insert into BangGia Values (3,'O To',7000);
Insert into BangGia Values (4,'Xe Dap',3000);
Insert into BangGia Values (5,'Xe Tai',9000);


CREATE TABLE dbo.HangXe
(
	MaHangXe int primary key not null,
	MaLoaiXe int null,
	HangXe nvarchar(50) ,
	foreign key(MaLoaiXe) references BangGia(MaGia)
)

Insert into HangXe values(1,2,'Honda RSX');
Insert into HangXe values(2,2,'Yamaha Exciter');
Insert into HangXe values(3,2,'SYN');
Insert into HangXe values(4,3,'Mecedez');
Insert into HangXe values(5,4,'Matin');
Insert into HangXe values(6,2,'Honda Future');

CREATE TABLE dbo.GioiTinh
(
	MaGT int primary key not null,
	GT nvarchar(255) not null
)
Insert into dbo.GioiTinh Values(1,'Nam');
Insert into dbo.GioiTinh Values(2,'Nu');

CREATE TABLE dbo.TrangThaiTT 
(
	MaTT int primary key not null,
	TrangThai nvarchar(100) not null
)

Insert into dbo.TrangThaiTT Values(1,'Chưa Thanh Toán');
Insert into dbo.TrangThaiTT Values(2,'Đã Thanh Toán');

CREATE TABLE dbo.ThongTinXe
(
	MaBSX nvarchar(50)  not null,
	HoVaTen nvarchar(255)not null,
	NgaySinh Date not null,
	GT int null,
	LoaiMau int null,
	LoaiXe int null,
	HangXe int null,
	Foreign key(LoaiMau) references dbo.MauSac(MaMS),
	Foreign key(GT) references GioiTinh(MaGT),
	Foreign key(LoaiXe) references BangGia(MaGia),
	Foreign key(HangXe) references dbo.HangXe(MaHangXe),
	Primary key(MaBSX)
)

Insert into ThongTinXe Values ('77X5-4308','Vu Thanh Sang','2000-11-08',1,1,2,1);
Insert into ThongTinXe Values ('76X5-10252','Nguyen Thi Trang','2000-11-08',2,2,2,1);
Insert into ThongTinXe Values ('75K8-1111','Nguyen Hoang Duong','1995-11-11',1,3,2,2);
Insert into ThongTinXe Values ('74G8-12345','Nguyen Trong Tan','1977-2-12',1,4,2,2);
Insert into ThongTinXe Values ('73H6-35687','Hoang Van Thu','1995-11-11',2,5,3,4);
Insert into ThongTinXe Values ('71A3-89752','Nguyen Trong Tan','1977-2-12',1,1,3,4);
Insert into ThongTinXe Values ('73I6-35687','Hoang Thi Tai','1993-05-17',2,2,4,5);
Insert into ThongTinXe Values ('71W3-89752','Nguyen Van Nam','1977-2-12',1,5,4,5);


CREATE TABLE dbo.ThongTinLuot
(
	MaLuot int primary key not null,
	MaNV int null,
	ThoiGianGui Datetime not null,
	MaBSX nvarchar(50) null,
	LoaiXe int null,
	GiaLoaiXe int null,
	TrangThai int null,
	Foreign key(MaNV) references NhanVien(MaNV),
	Foreign key(MaBSX) references ThongTinXe(MaBSX),
	Foreign key(GiaLoaiXe) references BangGia(MaGia),
	Foreign key(LoaiXe) references BangGia(MaGia),
	Foreign key(TrangThai) references TrangThaiTT(MaTT)
)

	Insert into ThongTinLuot Values (1,1,'12:55:00','77X5-4308',2,2,1);
	Insert into ThongTinLuot Values (2,3,'09:44:00','76X5-10252',2,2,1);
	Insert into ThongTinLuot Values (3,2,'12:02:53','75K8-1111',2,2,1);
	Insert into ThongTinLuot Values (4,1,'11:08:25','74G8-12345',2,2,1);
	Insert into ThongTinLuot Values (5,4,'07:12:00','73H6-35687',3,3,1);
	Insert into ThongTinLuot Values (6,3,'05:26:14','71A3-89752',4,4,1);
	Insert into ThongTinLuot Values (7,4,'03:14:25','73I6-35687',5,5,1);
	Insert into ThongTinLuot Values (8,4,'02:13:35','71W3-89752',5,5,1);
	Insert into ThongTinLuot Values (9,4,'2022-4-26 02:13:35','71R3-89752',5,5,1);

CREATE PROC USP_UpdateNhanVien
@MaNV int,
@HoTen nvarchar(255),
@NS Date ,
@userLogin nvarchar(255),
@passLogin nvarchar(255)
AS
BEGIN
	DECLARE @KT int = 0
	Select @KT = COUNT(*) from NhanVien where UserLogin = @userLogin
	if(@KT = 0)
	BEGIN
		UPDATE NhanVien set HoVaTen = @HoTen , NgaySinh = @NS, UserLogin = @userLogin , PassLogin = @passLogin where MaNV = @MaNV
	END
END

CREATE PROC USP_InsertNhanVien
@HoVaTen nvarchar(255) ,
@NgaySinh Date ,
@UserLogin varchar(255),
@PassLogin varchar(255) 
AS 
BEGIN
	DECLARE @Count int = 0

	if((Select COUNT(*) from NhanVien) > 0)
	BEGIN
		Select @Count = MAX(MaNV) from NhanVien
	END
	
	Insert into NhanVien values(@Count+1,@HoVaTen,@NgaySinh,@UserLogin,@PassLogin)
END

CREATE PROC USP_InsertMauSac
@MS nvarchar(50)
AS
BEGIN
	DECLARE @Count int = 0
	if((Select COUNT(*) from dbo.MauSac) > 0)
	BEGIN
		Select @Count = MAX(MaMS) from dbo.MauSac
	END
	
	Insert into dbo.MauSac values(@Count+1,@MS)
END

CREATE PROC USP_InsertBangGia
@LoaiXe nvarchar(100),
@Gia int
AS
BEGIN
	DECLARE @Count int = 0
	if((Select COUNT(*) from dbo.BangGia) > 0)
	BEGIN
		Select @Count = MAX(MaGia) from dbo.BangGia
	END
	Insert into dbo.BangGia values(@Count+1,@LoaiXe,@Gia)
END

CREATE PROC USP_InsertHangXe
@MaLoaiXe int,
@HangXe nvarchar(50) 
AS 
BEGIN
	DECLARE @Count int = 0
	if((Select COUNT(*) from dbo.HangXe) > 0)
	BEGIN
		Select @Count = MAX(MaHangXe) from dbo.HangXe
	END
	
	Insert into dbo.HangXe values(@Count+1,@MaLoaiXe,@HangXe)
END

CREATE PROC USP_AddHangXe
@LoaiXe1 int,
@HangXe1 nvarchar(255)
AS
BEGIN
	DECLARE @Count int
	Select @Count = Count(*) from HangXe where MaLoaiXe = @LoaiXe1 and HangXe = @HangXe1

	BEGIN TRANSACTION
		EXEC USP_InsertHangXe @LoaiXe = @LoaiXe1, @HangXe = @HangXe1
		if(@Count > 0)
		BEGIN
			ROLLBACK
		END
		ELSE
		BEGIN
			COMMIT
		END
END

CREATE PROC USP_InsertThongTinXe
@MaBSX nvarchar(50)  ,
@HoVaTen nvarchar(255),
@NgaySinh Date,
@GT int,
@LoaiMau int ,
@LoaiXe int,
@HangXe int 
AS
BEGIN
	insert into dbo.ThongTinXe values(@MaBSX,@HoVaTen,@NgaySinh,@GT,@LoaiMau,@LoaiXe,@HangXe)
END

CREATE PROC USP_InsertThongTinLuot
@MaNV int ,
@ThoiGianGui Datetime ,
@MaBSX nvarchar(50),
@LoaiXe int ,
@GiaLoaiXe int ,
@TrangThai int 
AS
BEGIN
	DECLARE @Count int = 0
	if((Select COUNT(*) from dbo.ThongTinLuot) > 0)
	BEGIN
		Select @Count = MAX(MaLuot) from dbo.ThongTinLuot
	END
	Insert into dbo.ThongTinLuot values(@Count+1,@MaNV,@ThoiGianGui,@MaBSX,@LoaiXe,@GiaLoaiXe,@TrangThai)
END

USE QuanLyNhaXe

CREATE VIEW GiaThanhToan as
Select dbo.ThongTinLuot.MaLuot ,MaBSX , Gia * (
DATEPART(HOUR ,GETDATE()) - DATEPART(HOUR, dbo.ThongTinLuot.ThoiGianGui) + (DATEPART(DAY,GETDATE()) - DATEPART(DAY, dbo.ThongTinLuot.ThoiGianGui))* 24
) as GiaThanh , (
DATEPART(HOUR ,GETDATE()) - DATEPART(HOUR, dbo.ThongTinLuot.ThoiGianGui) + (DATEPART(DAY,GETDATE()) - DATEPART(DAY, dbo.ThongTinLuot.ThoiGianGui))* 24
) as SoGioGui , dbo.BangGia.LoaiXe from dbo.BangGia inner join dbo.ThongTinLuot on dbo.BangGia.MaGia = dbo.ThongTinLuot.GiaLoaiXe 

Select * from ThongTinLuot

Select * from GiaThanhToan

CREATE PROC USP_KTUser
@hoTen nvarchar(255),
@ngaySinh Date,
@userLogin nvarchar(255),
@passLogin nvarchar(255)
AS
BEGIN
	DECLARE @Count int = 0
	Select @Count = COUNT(*) from NhanVien where UserLogin = @userLogin
	if(@Count = 0)
	BEGIN
		EXEC USP_InsertNhanVien @HoVaTen = @hoTen , @NgaySinh = @ngaySinh , @UserLogin = @userLogin , @PassLogin = @passLogin
	END
END


CREATE PROC USP_DeleteNhanVien
@maNV int
AS
BEGIN
	Update ThongTinLuot set MaNV = null where MaNV = @maNV
	Delete from NhanVien where MaNV = @maNV
END

CREATE PROC USP_DeleteThongTinXe
@maBSX nvarchar(255),
@loaiXe int
AS
BEGIN
	
	UPDATE dbo.ThongTinLuot set MaBSX = null where MaBSX = @maBSX and LoaiXe = @loaiXe
	DELETE from dbo.ThongTinXe where MaBSX = @maBSX and LoaiXe = @loaiXe
END


CREATE PROC USP_DeleteHangXe
@maHangXe int
AS
BEGIN
	UPDATE dbo.ThongTinXe set HangXe = null where HangXe = @maHangXe
	DELETE from dbo.HangXe where MaHangXe = @maHangXe
END



CREATE PROC USP_updateNV2 
@User nvarchar(255),
@Name nvarchar(255),
@Date date
AS
BEGIN
	Update NhanVien set HoVaTen = @Name , NgaySinh = @Date where UserLogin = @User
END

CREATE TRIGGER UTG_BangGia ON dbo.BangGia
FOR Insert
AS
BEGIN
	DECLARE @Gia int = 0 ;
	Select @Gia = Gia from inserted
	if(@Gia > 500000)
	BEGIN
		ROLLBACK TRAN
	END
	
END

USE QuanLyNhaXe

CREATE PROC USP_DeleteLoaiXe
@maLoaiXe int
AS
BEGIN
		Update HangXe set MaLoaiXe = null where MaLoaiXe = @maLoaiXe
		Update ThongTinLuot set GiaLoaiXe = null , LoaiXe = null where GiaLoaiXe = @maLoaiXe
		Update ThongTinXe set LoaiXe = null where LoaiXe = @maLoaiXe
		Delete from BangGia where MaGia = @maLoaiXe 
END
use QuanLyNhaXe

CREATE PROC USP_Reset
AS
BEGIN	
	Delete  from ThongTinLuot
	Delete  from ThongTinXe
	
END


USE QuanLyNhaXe

CREATE LOGIN QuanLy WITH PASSWORD = '123'
GO

CREATE LOGIN NhanVien WITH PASSWORD = '123'
GO

CREATE USER CapCao for login QuanLy
GO

CREATE USER CapThap for login NhanVien
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.BangGia TO	CapCao
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.ThongTinXe TO	CapCao
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.GioiTinh TO CapCao
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.HangXe TO	CapCao
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.MauSac TO	CapCao
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.NhanVien TO	CapCao
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.ThongTinLuot TO	CapCao
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.TrangThaiTT TO	CapCao
GO



GRANT SELECT ON dbo.BangGia TO	CapThap
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.ThongTinXe TO	CapThap
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.GioiTinh TO CapThap
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.HangXe TO	CapThap
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.MauSac TO	CapThap
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.ThongTinLuot TO	CapThap
GO

GRANT SELECT,DELETE,INSERT,UPDATE ON dbo.TrangThaiTT TO	CapThap
GO

