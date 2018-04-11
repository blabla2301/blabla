create database QuanLyGara

create table KHACHHANG
(
	ID_KhachHang varchar(10) primary key,
	HoTen ntext,
	SDT ntext,
	Email ntext,
	DiaChi ntext
)

create table HANGXE
(
	ID_HangXe varchar(10) primary key,
	HangXe ntext
)

create table THONGTINXE
(
	ID_Xe varchar(10) primary key,
	ID_HangXe varchar(10) references HANGXE(ID_HangXe),
	BienSoXe ntext,
	DoiXe ntext,
	SoKhung ntext,
	SoMay ntext,
	SoKM int
)

create table PHIEUKHAOSAT
(
	ID_PhieuKhaoSat varchar(10) primary key,
	ID_KhachHang varchar(10) references KHACHHANG(ID_KhachHang),
	ID_Xe varchar(10) references THONGTINXE(ID_Xe),
	YeuCau ntext,
)

create table PHIEUDANHGIA
(
	ID_PhieuDanhGia varchar(10) primary key,
	ID_PhieuKhaoSat varchar(10) references PHIEUKHAOSAT(ID_PhieuKhaoSat),
	TinhTrangXe ntext,
	MaBaoHiem ntext,
	ThongBaoGiaSua float,
)

create table NHACUNGCAP
(
	ID_NhaCungCap varchar(10) primary key,
	TenNCC ntext,
	DiaChi ntext,
	SDT ntext,
	Email ntext,
	Website ntext
)

create table VATTU
(
	ID_VatTu varchar(10) primary key,
	TenVatTu ntext,
	TheLoai ntext,
	SoTien float,
	ID_NhaCungCap varchar(10) references NHACUNGCAP(ID_NhaCungCap)
)

create table PHIEUVATTU
(
	ID_PhieuVatTu varchar(10) primary key,
	MaNguoiPhuTrach varchar(10),
	ThoiGian date,
)

create table HOADON_PHIEUVATTU
(
	ID_HoaDonVatTu varchar(10) primary key,
	ID_PhieuVatTu varchar(10) references PHIEUVATTU(ID_PhieuVatTu),
	ID_VatTu varchar(10) references VATTU(ID_VatTu),
	SoLuong int,
	TongTien float,
)

create table LENHSUACHUA
(
	ID_LenhSuaChua varchar(10) primary key,
	ID_PhieuDanhGia varchar(10) references PHIEUDANHGIA(ID_PhieuDanhGia),
	ID_PhieuVatTu varchar(10) references PHIEUVATTU(ID_PhieuVatTu),

)

create table QUYENHAN
(
	ID_QuyenHan varchar(10) primary key,
	Them bit,
	Sua bit,
	Xoa bit,
	Ad bit
)

create table NGUOIDUNG
(
	TaiKhoan varchar(50) primary key,
	MatKhau varchar(50),
	ID_QuyenHan varchar(10) references QUYENHAN(ID_QuyenHan)
)

create table NHANVIEN
(
	ID_NhanVien varchar(10) primary key,
	HoTen ntext,
	SDT ntext,
	NgaySinh date,
	GioiTinh ntext,
	DiaChi ntext,
	TaiKhoan varchar(50) references NGUOIDUNG(TaiKhoan)
)


create table PHANCONG
(
	ID_PhanCong varchar(10) primary key,
	ID_LenhSuaChua varchar(10) references LENHSUACHUA(ID_LenhSuaChua),
	ID_NhanVien varchar(10) references NHANVIEN(ID_NhanVien),
	NgayBatDau date,
)


create table HOADON_THANHTOAN
(
	ID_HoaDonThanhToan varchar(10) primary key,
	ID_LenhSuaChua varchar(10) references LENHSUACHUA(ID_LenhSuaChua),
	TenHoaDon ntext,
	MaNguoiPhuTrach varchar(10),
	TienDichVu  float,
	TongTienThanhToan float
)


go

--Thủ tục----

--Thêm khách hàng
create proc ThemKH(@ID_KhachHang varchar(10), @HoTen ntext, @SDT varchar(12), @Email ntext, @DiaChi ntext)
as
	begin
		if exists (select ID_KhachHang from KHACHHANG where ID_KhachHang = @ID_KhachHang)
		begin
			print 'Ma khach hang da ton tai ==> ' + @ID_KhachHang 
		end

		else
		begin
			if ISNUMERIC(@SDT) = 1 and LEN(@SDT) > 7 and LEN(@SDT) < 12
			begin
				insert into KHACHHANG(ID_KhachHang, HoTen, SDT, Email, DiaChi) values (@ID_KhachHang, @HoTen, @SDT, @Email, @DiaChi)
			end
			else
			begin
				
				print 'So dien thoai khong hop le'
			end
		end
	end
go
select * from KHACHHANG
delete from KHACHHANG
where ID_KhachHang = '1'
go
ThemKH 'KH1', 'Nguyen Van Long', '01654320189', 'nvlong@gmail.com', 'Ha Noi'
go
ThemKH 'KH2', 'Nguyen Tien Dung', '01644521089', 'ntdung@gmail.com', 'Ho CHi Minh'
go
ThemKH 'KH3', 'Le Ba Quan', '0986654321', 'lbquan@gmail.com', 'Thai Binh'
go
ThemKH 'KH4', 'Pham Hong Thai', '01652430187', 'phthai@gmail.com', 'Ha Noi'
go
ThemKH 'KH5', 'Bui Huy Hoang', '01624625232', 'bhhoang@gmail.com', 'Hung Yen'
go
ThemKH 'KH6', 'Truong Thi Trang', '0163576425', 'tttrang@gmail.com', 'Ha Nam'
go

--Hãng xe
create proc ThemHangXe(@ID_HangXe varchar(10), @HangXe ntext)
as
	begin
		if exists (select ID_HangXe from HANGXE where ID_HangXe = @ID_HangXe)
		begin
			print 'ID da ton tai ==> ' + @ID_HangXe
		end
		else
		begin
			insert into HANGXE(ID_HangXe, HangXe) values (@ID_HangXe, @HangXe)
		end
	end
go
ThemHangXe 'H1', 'Toyota'
go
ThemHangXe 'H2', 'Lexus'
go
ThemHangXe 'H3', 'Audi'
go
ThemHangXe 'H4', 'Hyundai'
go
ThemHangXe 'H5', 'BMW'
go
ThemHangXe 'H6', 'Ford'
go
ThemHangXe 'H7', 'Honda'
go
select * from HANGXE
go
--Thêm Xe
create proc ThemXe(@ID_Xe varchar(10),@ID_hangXe varchar(10), @BienSo ntext, @DoiXe ntext, @SoKhung ntext, @SoMay ntext, @SoKm int)
as
	begin
		if exists (select ID_Xe from THONGTINXE where ID_Xe = @ID_Xe)
		begin
			print 'ID xe da ton tai ==> ' + @ID_Xe
		end
		else
		begin
			insert into THONGTINXE(ID_Xe, ID_HangXe, BienSoXe, DoiXe, SoKhung, SoMay, SoKM) values (@ID_Xe, @ID_HangXe, @BienSo, @DoiXe, @SoKhung, @SoMay, @SoKm)
		end
		
	end
go
select * from THONGTINXE
go
ThemXe 'X1', 'H1', '89B-532.12', 'Toyota Vios 1.5E 2018', 'ZXLGG3HX7EV007862', 'ZZL2814925', 1320
go
ThemXe 'X2', 'H2', '87B-243.22', 'Lexus ES 250', 'BXLGG3HX7EV002836', 'ABL2814925', 1020
go
ThemXe 'X3', 'H3', '78A-915.23', 'Toyota Altis 1.8G CVT', 'XLWT3HD2TV873629', 'AXH28349382', 3012
go
ThemXe 'X4', 'H4', '89b-621.76', 'Toyota Fortuner 2.7 V 4x2', 'HDGXB3DF6YV283749', 'HBL1927364', 1200
go
ThemXe 'X5', 'H5', '89b-332.56', 'Audi Q3 2.0L 7AT', 'HDXT2TX7EV007862', 'LKD2839183', 4512
go
ThemXe 'X6', 'H6', '72b-551.34', 'Hyundai Grand I10 sedan 1.2 MT', 'BRTX4TY3XV007862', 'KHJ1827391', 3018
go
ThemXe 'X7', 'H7', '29b-325.14', 'BMW 320i', 'NBTX4TY3XV293849', 'KLA9304827', 2917
go

--Khảo sát
create proc ThemPKS(@ID_PhieuKhaoSat varchar(10), @ID_KhachHang varchar(10), @ID_Xe varchar(10), @YeuCau ntext)
as
	begin
		if exists (select ID_PhieuKhaoSat from PHIEUKHAOSAT where ID_PhieuKhaoSat = @ID_PhieuKhaoSat )
		begin
			print 'Ma phieu khao sat da ton tai ==> ' + @ID_PhieuKhaoSat
		end
		else
		begin
			if exists (select ID_KhachHang from KHACHHANG where ID_KhachHang = @ID_KhachHang)
			begin
				if exists (select ID_Xe from THONGTINXE where ID_Xe = @ID_Xe)
				begin
					insert into PHIEUKHAOSAT(ID_PhieuKhaoSat, ID_KhachHang, ID_Xe, YeuCau) values (@ID_PhieuKhaoSat, @ID_KhachHang, @ID_Xe, @YeuCau)
				end
				else
				begin
					print 'ID xe khong ton tai ' + @ID_Xe
				end
			end
			else
			begin
				print 'ID khach han khong ton tai ' + @ID_KhachHang
			end
		end
	end
go
select * from PHIEUKHAOSAT
go
ThemPKS 'PKS1', 'KH1', 'X1', 'Sua chua'
go
ThemPKS 'PKS2', 'KH2', 'X2', 'Sua chua'
go
ThemPKS 'PKS3', 'KH3', 'X3', 'Bao duong'
go
ThemPKS 'PKS4', 'KH4', 'X4', 'Bao duong'
go
ThemPKS 'PKS5', 'KH5', 'X5', 'Sua chua'
go
ThemPKS 'PKS6', 'KH6', 'X6', 'Mua trang thiet bi'
go
ThemPKS 'PKS7', 'KH6', 'X7', 'Sua chua'
go

--Phiếu đánh giá

create proc ThemPDG(@ID_PhieuDanhGia varchar(10), @ID_PhieuKhaoSat varchar(10), @TinhTrangXe ntext, @MaBaoHiem ntext, @ThongBaoGiaSua float)
as
	begin
		if exists(select ID_PhieuDanhGia from PHIEUDANHGIA where ID_PhieuDanhGia = @ID_PhieuDanhGia)
		begin
			print 'Ma phieu danh gia da ton tai ==> ' + @ID_PhieuDanhGia
		end

		else
		begin
			if exists(select ID_PhieuKhaoSat from PHIEUKHAOSAT where ID_PhieuKhaoSat = @ID_PhieuKhaoSat)
			begin
				insert into PHIEUDANHGIA (ID_PhieuDanhGia, ID_PhieuKhaoSat, TinhTrangXe, MaBaoHiem, ThongBaoGiaSua) values (@ID_PhieuDanhGia, @ID_PhieuKhaoSat, @TinhTrangXe, @MaBaoHiem, @ThongBaoGiaSua)
			end

			else
			begin
				print 'Khong ton tai ma phieu khao sat ==> ' + @ID_PhieuKhaoSat
			end
		end
	end
go
select * from PHIEUDANHGIA
go
exec ThemPDG 'PDG1','PKS1','Hong',' ', '1000000'
go
exec ThemPDG 'PDG2','PKS2','Bao Duong',null , '15000000'
go
exec ThemPDG 'PDG3','PKS3','Bao Duong',' ', '10000000'
go
exec ThemPDG 'PDG4','PKS4','Thay the phu kien', ' ','12000000'
go
exec ThemPDG 'PDG5','PKS5','Hong', '', '16000000'
go
exec ThemPDG 'PDG6','PKS6','Hong', '', '15000000'
go


--Nhà cung cấp
create proc ThemNCC(@ID_NhaCungCap varchar(10), @TenNCC nvarchar(50), @DC ntext, @SDT varchar(12), @Email ntext, @Web ntext)
as
	begin
		if exists (select ID_NhaCungCap from NHACUNGCAP where ID_NhaCungCap = @ID_NhaCungCap)
		begin
			print 'ID nha cung ca da ton tai ==> ' + @ID_NhaCungCap
		end

		else
		begin
			if ISNUMERIC(@SDT) = 1 and LEN(@SDT) > 7 and LEN(@SDT) < 12 
			begin
				insert into NHACUNGCAP (ID_NhaCungCap, TenNCC, DiaChi, SDT, Email, Website) values (@ID_NhaCungCap, @TenNCC, @DC, @SDT, @Email, @Web)
			end
			else
			begin
				print 'So dien thoai khong hop le'
			end
		end
	end
go
select * from NHACUNGCAP
go
ThemNCC 'NCC1', 'Nha cung cap 1', 'Ha Noi', '0968686868', 'NCC1@gmail.com', 'ncc1.com.vn'
go
ThemNCC 'NCC2', 'Nha cung cap 2', 'Da Nang', '01688866668', 'NCC2@gmail.com','ncc2.com.vn'
go
ThemNCC 'NCC3', 'Nha cung cap 3', 'TP. Ho Chi Minh', '01622694888', 'NCC3@gmail.com','ncc3.com.vn'
go
ThemNCC 'NCC4', 'Nha cung cap 4', 'Bac Ninh', '01666159333', 'NCC4@gmail.com','ncc4.com.vn'
go
ThemNCC 'NCC5', 'Nha cung cap 5', 'Ha Noi', '0866668968', 'NCC5@gmail.com','ncc5.com.vn'
go
ThemNCC 'NCC6', 'Nha cung cap 6', 'Bac Giang', '026666888', 'NCC6@gmail.com','ncc6.com.vn'
go

--Vật tư
create proc ThemVT(@ID_VatTu varchar(10), @TenVT nvarchar(50), @TheLoai ntext, @SoTien float, @ID_NhaCungCap varchar(10))
as
	begin
		if exists (select ID_VatTu from VATTU where ID_VatTu = @ID_VatTu)
		begin
			print 'ID vat tu da ton tai tong kho ==> ' + @ID_VatTu
		end
		else
		begin
			insert into VATTU(ID_VatTu, TenVatTu, TheLoai, SoTien, ID_NhaCungCap) values (@ID_VatTu, @TenVT, @TheLoai, @SoTien, @ID_NhaCungCap)
		end
	end
go
select * from VATTU
delete from VATTU
where TenVatTu = 'Den'
go
ThemVT 'VT1', 'Dau nhot', '', 10000, 'NCC1'
go
ThemVT 'VT2', 'Vanh xe', '', 60000, 'NCC2'
go
ThemVT 'VT3', 'Lop', '', 120000, 'NCC3'
go
ThemVT 'VT4', 'Kinh chan gio', '', 150000, 'NCC4'
go
ThemVT 'VT5', 'Bugi', '', 160000, 'NCC5'
go
ThemVT 'VT6', 'Den', '', 190000, 'NCC6'
go


--Phiếu vật tư
create proc ThemPVT(@ID_PhieuVatTu varchar(10), @MaNguoiPhuTrach varchar(10), @ThoiGian date)
as
	begin
		if exists (select ID_PhieuVatTu from PHIEUVATTU where ID_PhieuVatTu = @ID_PhieuVatTu)
		begin
			print 'ID phieu vat tu da ton tai ==> ' + @ID_PhieuVatTu
		end
		else
		begin
			declare @kt  nvarchar(50)
			select @kt = @ThoiGian
			if ISDATE(@kt) = 1
			begin
				insert into PHIEUVATTU (ID_PhieuVatTu, MaNguoiPhuTrach, ThoiGian) values (@ID_PhieuVatTu, @MaNguoiPhuTrach, @ThoiGian)
			end

			else
			begin
				print 'Khong dung dinh dang thoi gian'
			end
		end
		
	end
go
select * from PHIEUVATTU
go
ThemPVT 'PVT1', '1', '12-12-1997'
go
ThemPVT 'PVT2', '2','7-6-2017'
go
ThemPVT 'PVT3', '3', '2-4-2017'
go
ThemPVT 'PVT4', '4', '4-3-2016'
go
ThemPVT 'PVT5', '5', '2-10-1999'
go
ThemPVT 'PVT6', '6', '5-6-2011'
go

--Hóa đơn phiếu vật tư
create proc ThemHD_PVT(@ID_HoaDonVatTu varchar(10), @ID_PhieuVatTu varchar(10), @ID_VatTu nvarchar(50), @SoLuong int)
as
	begin
		if exists (select ID_HoaDonVatTu from HOADON_PHIEUVATTU where ID_HoaDonVatTu = @ID_HoaDonVatTu )
		begin
			print 'ID da ton tai ==> ' + @ID_HoaDonVatTu
		end
		else
		begin
			declare @temp float, @TongTien float
			select @temp = SoTien
			from VATTU
			set @TongTien = @temp * @SoLuong
			insert into HOADON_PHIEUVATTU(ID_HoaDonVatTu, ID_PhieuVatTu, ID_VatTu, SoLuong, TongTien) values (@ID_HoaDonVatTu, @ID_PhieuVatTu,@ID_VatTu, @SoLuong, @TongTien)
		end
	end
go
select * from HOADON_PHIEUVATTU
where ID_HoaDonVatTu = '1'
select * from VATTU
go
ThemHD_PVT 'HDVT1', 'PVT1', 'VT1', 1
go
ThemHD_PVT 'HDVT1','PVT1', 'VT2', 2
go
ThemHD_PVT 'HDVT2','PVT2', 'VT3', 2
go
ThemHD_PVT 'HDVT3','PVT3', 'VT4', 3
go
ThemHD_PVT 'HDVT4','PVT4', 'VT5', 4
go
ThemHD_PVT 'HDVT5','PVT5', 'VT6', 5
go
ThemHD_PVT 'HDVT6','PVT6', 'VT3', 6
go


--Lệnh sửa chữa
create proc ThemLSC(@ID_lenhSuaChua varchar(10), @ID_PhieuDanhGia varchar(10), @ID_PhieuVatTu varchar(10))
as
	begin
		if exists (select ID_lenhSuaChua from LENHSUACHUA where ID_lenhSuaChua = @ID_lenhSuaChua)
		begin
			print 'Ma lenh sua chua da ton tai ==> ' + @ID_lenhSuaChua
		end
		else
		begin
			insert into LENHSUACHUA(ID_lenhSuaChua, ID_PhieuDanhGia, ID_PhieuVatTu) values (@ID_lenhSuaChua, @ID_PhieuDanhGia, @ID_PhieuVatTu)
		end
	end
go
select * from LENHSUACHUA
go
ThemLSC 'LSC1', 'PDG1', 'PVT1'
go
ThemLSC 'LSC2', 'PDG2', 'PVT2'
go
ThemLSC 'LSC3', 'PDG3', 'PVT3'
go
ThemLSC 'LSC4', 'PDG4', 'PVT4'
go
ThemLSC 'LSC5', 'PDG5', 'PVT5'
go


--Quyền hạn
create proc ThemQH(@ID_QuyenHan varchar(10), @Them bit, @Sua bit, @Xoa bit, @Ad bit)
as
	begin
		if exists (select ID_QuyenHan from QUYENHAN where ID_QuyenHan = @ID_QuyenHan)
		begin
			print 'Ma quyen da ton tai ==> ' + @ID_QuyenHan
		end
		else
		begin
			insert into QUYENHAN(ID_QuyenHan, Them, Sua, Xoa, Ad) values (@ID_QuyenHan, @Them, @Sua, @Xoa, @AD)
		end
	end
go
select * from QUYENHAN
go
ThemQH 'admin', 1, 1, 1, 1
go
ThemQH 'user', 1, 1, 1, 0
go
ThemQH 'read_only', 0, 0, 0, 0
go


--Người dùng
create proc ThemTaiKhoan(@TaiKhoan varchar(50), @MatKhau varchar(50), @ID_QuyenHan varchar(10))
as
	begin
		if exists (select TaiKhoan from NGUOIDUNG where TaiKhoan = @TaiKhoan)
		begin
			print 'Ten tai khoan da ton tai ==> ' + @TaiKhoan
		end
		else
		begin
			
			if exists (select ID_QuyenHan from QUYENHAN where ID_QuyenHan = @ID_QuyenHan)
			begin
				declare @tk int, @mk int
				select @tk = LEN(@TaiKhoan)
				select @mk = LEN(@MatKhau)
				if @tk < 5 
				begin
					print 'Tai khoan phai co do dai tu 5 -> 50 ky tu '
				end
				if @tk > 49
				begin
					print 'Tai khoan phai co do dai tu 5 -> 50 ky tu '
				end
				if @mk < 5
				begin
					print 'Mat khau phai co do dai tu 5 -> 50 ky tu '
				end
				if @mk > 49
				begin
					print 'Mat khau phai co do dai tu 5 -> 50 ky tu '
				end
				if @tk > 5 and @tk < 49 and @mk > 5 and @mk < 49
				begin
					insert into NGUOIDUNG(TaiKhoan, MatKhau, ID_QuyenHan) values (@TaiKhoan, @MatKhau, @ID_QuyenHan)
				end
			end
			else
			begin
				print 'Ma quyen khong ton tai '
			end
			
		end
	end
go
select * from NGUOIDUNG
delete NGUOIDUNG
go
ThemTaiKhoan 'admin01', 'admin01', 'admin'
go
ThemTaiKhoan 'user01', 'user01', 'user'
go
ThemTaiKhoan 'user02', 'user02', 'user'
go
ThemTaiKhoan 'read_only', 'readonly', 'read_only'
go


--them nhan vien
create proc ThemNV(@ID_NhanVien varchar(10),@HoTen ntext,@SDT varchar(12),@NgaySinh date,@GT ntext,@DiaChi ntext,@TaiKhoan varchar(50))
as
	begin 
		if exists (select ID_NhanVien from NHANVIEN where ID_NhanVien = @ID_NhanVien)
		begin
			print 'Ma nhan vien da ton tai ==> ' + @ID_NhanVien
		end
		else
		begin
			if exists (select TaiKhoan from NGUOIDUNG where TaiKhoan = @TaiKhoan)
			begin
				if ISNUMERIC(@SDT) = 1 and LEN(@SDT) > 7 and LEN(@SDT) < 12
				begin
					insert into NHANVIEN(ID_NhanVien ,HoTen,SDT,NgaySinh,GioiTinh,DiaChi,TaiKhoan)values(@ID_NhanVien,@HoTen,@SDT,@NgaySinh,@GT,@DiaChi,@TaiKhoan)
				end
				else
				begin
					print 'So dien thoai khong hop le'
				end
			end
			else
			begin
				print 'Khong ton tai ten tai khoan ==> ' + @TaiKhoan
			end
		end
	end
go
select * from NHANVIEN
select * from NGUOIDUNG
go
exec ThemNV 'NV1', 'Nguyen Van Thai','0949438001','1997-12-01','Nam','Bac Giang','admin01'
go
exec ThemNV 'NV2', 'Bui Huy Nam','0949438002','1997-10-21','Nam','Bac Ninh','user01'
go
exec ThemNV 'NV3', 'Phan Van Tai','0949438003','1995-2-01','Nam','Ha noi','user02'
go
exec ThemNV 'NV4', 'Do Thi Lan','0949438004','1997-7-01','Nam','Ha Nam','read_only'
go

--Phan cong
create proc ThemPC(@ID_PhanCong varchar(10), @ID_LenhSuaChua varchar(10), @ID_NhanVien  varchar(10), @NgayBatDau date)
as
	begin
		if exists (select ID_PhanCong from PHANCONG where ID_PhanCong = @ID_PhanCong)
		begin
			print 'ID da ton tai'
		end
		else
		begin
			insert into PHANCONG(ID_PhanCong, ID_LenhSuaChua, ID_NhanVien, NgayBatDau) values (@ID_PhanCong, @ID_LenhSuaChua, @ID_NhanVien, @NgayBatDau)
		end
	end
go
select * from PHANCONG
go
ThemPC 'PC1', 'LSC1', 'NV1', '12-2-2017'
go
ThemPC 'PC2', 'LSC2', 'NV2', '3-2-2018'
go
ThemPC 'PC3', 'LSC3', 'NV3', '4-5-2017'
go
ThemPC 'PC4', 'LSC4', 'NV4', '12-2-2017'
go

create proc ThemHD_TT(@ID_HoaDonThanhToan varchar(10), @ID_LenhSuaChua varchar(10), @TenHoaDon ntext, @MaNguoiPhuTrach varchar(10), @TienDichVu float)
as
	begin
		if exists (select ID_HoaDonThanhToan from HOADON_THANHTOAN where ID_HoaDonThanhToan = @ID_HoaDonThanhToan)
		begin
			print 'Da ton tai ma hoa don ==> ' + @ID_HoaDonThanhToan
		end

		else
		begin
			declare @TienThanhToan float, @temp float
				select @temp = SUM(hd.TongTien)
				from HOADON_PHIEUVATTU hd, PHIEUVATTU p, LENHSUACHUA l
				where l.ID_LenhSuaChua = @ID_LenhSuaChua and hd.ID_PhieuVatTu = p.ID_PhieuVatTu and l.ID_PhieuVatTu = p.ID_PhieuVatTu
				select @TienThanhToan = @TienDichVu + @temp
				insert into HOADON_THANHTOAN (ID_HoaDonThanhToan, ID_LenhSuaChua, TenHoaDon, MaNguoiPhuTrach, TienDichVu, TongTienThanhToan) values (@ID_HoaDonThanhToan, @ID_LenhSuaChua, @TenHoaDon, @MaNguoiPhuTrach, @TienDichVu, @TienThanhToan)
		end
	end
go
select * from HOADON_THANHTOAN
select * from HOADON_PHIEUVATTU
delete HOADON_THANHTOAN
go
ThemHD_TT 'HDTT1', 'LSC1', 'Hoa don 1', '1', 120000
go
ThemHD_TT 'HDTT2', 'LSC2', 'Hoa don 2', '2', 220000
go

--Thủ tục sửa

create proc SuaHangXe(@ID_hangXe varchar(10), @HangXe ntext)
as
	begin
		update HANGXE
		set HangXe = @HangXe
		where ID_HangXe = @ID_hangXe
	end
go

--Sửa quyền hạn
create proc SuaQH(@ID_QuyenHan varchar(10), @Them bit, @Sua bit, @Xoa bit, @Ad bit)
as
	begin
		update QUYENHAN
		set Them = @Them,
			Sua = @Sua,
			Xoa = @Xoa,
			Ad = @Ad
		where ID_QuyenHan = @ID_QuyenHan
	end
go

create proc SuaND(@TaiKhoan varchar(50), @MatKhau varchar(50), @ID_QuyenHan varchar(50))
as
	begin
		if exists(select ID_QuyenHan from QUYENHAN where ID_QuyenHan = @ID_QuyenHan)
		begin
			update NGUOIDUNG
			set MatKhau = @MatKhau,
				ID_QuyenHan = @ID_QuyenHan
			where TaiKhoan = @TaiKhoan
		end
		else
		begin
			print 'Loi........'
		end
	end
go

create proc SuaNV(@ID_NhanVien varchar(10), @HoTen ntext, @SDT ntext, @NgaySinh date, @GioiTinh ntext, @DiaChi ntext, @TaiKhoan varchar(50))
as
	begin
		update NHANVIEN
		set HoTen = @HoTen,
			SDT = @SDT,
			NgaySinh = @NgaySinh,
			GioiTinh = @GioiTinh,
			DiaChi = @DiaChi,
			TaiKhoan = @TaiKhoan
		where ID_NhanVien = @ID_NhanVien
	end
go

--Sửa phân công
create proc SuaPC(@ID_PhanCong varchar(10), @ID_LenhSuaChua varchar(10), @ID_NhanVien varchar(10), @NgayBD date)
as
	begin
		update PHANCONG
		set ID_LenhSuaChua = @ID_LenhSuaChua,
			ID_NhanVien = @ID_NhanVien,
			NgayBatDau = @NgayBD
		where ID_PhanCong = @ID_PhanCong
	end
go

--Sửa nhà cung cấp
create proc SuaNCC(@ID_NhaCungCap varchar(10), @TenNCC nvarchar(50), @DiaChi ntext, @SDT ntext, @Email ntext, @Website ntext)
as
	begin
		update NHACUNGCAP
		set TenNCC = @TenNCC,
			DiaChi = @DiaChi,
			SDT = @SDT,
			Email = @Email,
			Website = @Website
		where ID_NhaCungCap = @ID_NhaCungCap
	end
go

--Sửa thông tin xe
create proc SuaXe(@ID_Xe varchar(10), @ID_HangXe varchar(10), @BienSoXe varchar(10), @DoiXe ntext, @SoKhung ntext, @SoMay ntext, @SoKM int)
as
	begin
		update THONGTINXE
		set ID_HangXe = @ID_HangXe,
			BienSoXe = @BienSoXe,
			DoiXe = @DoiXe,
			SoKhung = @SoKhung,
			SoMay = @SoMay,
			SoKM = @SoKM
		where ID_Xe = @ID_Xe
	end
go

--Sửa thông tin khách hàng
create proc SuaKH(@ID_KhachHang varchar(10), @HoTen ntext, @SDT ntext, @Email ntext, @DiaChi ntext)
as
	begin
		update KHACHHANG
		set HoTen = @HoTen,
			SDT = @SDT,
			Email = @Email,
			DiaChi = @DiaChi
		where ID_KhachHang = @ID_KhachHang
	end
go

--Sửa phiếu khảo sát
create proc SuaPKS(@ID_PhieuKhaoSat varchar(10), @ID_KhachHang varchar(10), @ID_Xe varchar(10), @YeuCau ntext)
as
	begin
		update PHIEUKHAOSAT
		set ID_KhachHang = @ID_KhachHang,
			ID_Xe = @ID_Xe,
			YeuCau = @YeuCau
		where ID_PhieuKhaoSat = @ID_PhieuKhaoSat
	end
go

--Sửa phiếu đánh giá
create proc SuaPDG(@ID_PhieuDanhGia varchar(10), @ID_PhieuKhaoSat varchar(10), @TinhTrangXe ntext, @MaBaoHiem ntext, @ThongBaoGia float)
as
	begin
		update PHIEUDANHGIA
		set ID_PhieuKhaoSat = @ID_PhieuKhaoSat,
			TinhTrangXe = @TinhTrangXe,
			MaBaoHiem = @MaBaoHiem,
			ThongBaoGiaSua = @ThongBaoGia
		where ID_PhieuDanhGia = @ID_PhieuDanhGia
	end
go

--Sửa bảng lệnh sửa chữa
create proc SuaLSC(@ID_LenhSuaChua varchar(10), @ID_PhieuDanhGia varchar(10), @ID_PhieuVatTu varchar(10))
as
	begin
		update LENHSUACHUA
		set ID_PhieuDanhGia = @ID_PhieuDanhGia,
			ID_PhieuVatTu = @ID_PhieuVatTu
		where ID_LenhSuaChua = @ID_LenhSuaChua
	end
go

create proc SuaVT(@ID_VatTu varchar(10), @TenVT nvarchar(50), @TheLoai ntext, @SoTien float, @ID_NhaCungCap varchar(10))
as
	begin
		update VATTU
		set TenVatTu = @TenVT,
			TheLoai = @TheLoai,
			SoTien = @SoTien,
			ID_NhaCungCap = @ID_NhaCungCap
		where ID_VatTu = @ID_VatTu
	end
go

--Sửa phiếu vật tư
create proc SuaPVT(@ID_PhieuVatTu varchar(10), @MaNPT varchar(10), @ThoiGian date)
as
	begin
		update PHIEUVATTU
		set MaNguoiPhuTrach = @MaNPT,
			ThoiGian = @ThoiGian
		where ID_PhieuVatTu = @ID_PhieuVatTu
	end
go


--Sửa hóa đơn phiếu vật tư
create proc SuaHD_PVT(@ID_HoaDonVatTu varchar(10), @ID_PhieuVatTu varchar(10), @ID_VatTu nvarchar(50), @SoLuong int)
as
	begin
		declare @temp float, @TongTien float
		select @temp = vt.SoTien
		from VATTU vt
		where ID_VatTu = @ID_VatTu
		set @TongTien = @temp * @SoLuong

		if exists(select ID_PhieuVatTu from PHIEUVATTU where ID_PhieuVatTu = @ID_PhieuVatTu)
		begin
			if exists(select ID_VatTu from VATTU where ID_VatTu = @ID_VatTu)
			begin
				update HOADON_PHIEUVATTU
				set ID_PhieuVatTu = @ID_PhieuVatTu,
					ID_VatTu = @ID_VatTu,
					SoLuong = @SoLuong,
					TongTien = @TongTien
				where ID_HoaDonVatTu = @ID_HoaDonVatTu

			end
			else
			begin
				print 'Khong ton tai ID vat tu ' + @ID_VatTu
			end
		end
		else
		begin
			print 'Khong ton tai ma phieu vat tu ' + @ID_PhieuVatTu
		end
		
	end
go


--Sửa hóa đơn thanh toán
create proc SuaHD_TT(@ID_HoaDonThanhToan varchar(10), @ID_LenhSuaChua varchar(10), @TenHD ntext, @MaNPT varchar(10), @TienDichVu float)
as
	begin
		if exists(select ID_LenhSuaChua from LENHSUACHUA where ID_LenhSuaChua = @ID_LenhSuaChua)
		begin
			declare @ThanhToan float, @temp float
			select @temp = SUM(hd.TongTien)
			from HOADON_PHIEUVATTU hd, PHIEUVATTU p, LENHSUACHUA l
			where l.ID_LenhSuaChua = @ID_LenhSuaChua and l.ID_PhieuVatTu = p.ID_PhieuVatTu and p.ID_PhieuVatTu = hd.ID_PhieuVatTu
			select @ThanhToan = @temp + @TienDichVu

			update HOADON_THANHTOAN
			set ID_LenhSuaChua = @ID_LenhSuaChua,
				TenHoaDon = @TenHD,
				MaNguoiPhuTrach = @MaNPT,
				TienDichVu = @TienDichVu,
				TongTienThanhToan = @ThanhToan
			where ID_HoaDonThanhToan = @ID_HoaDonThanhToan
		end

		else
		begin
			print 'Loi....'
		end
	end
go



----Thủ tục xóa

--Xóa hóa đơn phiếu vật tư
create proc XoaHD_PVT(@ID_HoaDonVatTu varchar(10))
as
	begin
		delete from HOADON_PHIEUVATTU
		where ID_HoaDonVatTu = @ID_HoaDonVatTu
	end
go
--Xóa hóa đơn thanh toán
create proc XoaHD_TT(@ID_HoaDonThanhToan varchar(10))
as
	begin
		delete from HOADON_THANHTOAN
		where ID_HoaDonThanhToan = @ID_HoaDonThanhToan
	end
go
--Xóa khách hàng
create proc XoaKH(@ID_KhachHang varchar(10))
as
	begin
		delete from KHACHHANG
		where ID_KhachHang = @ID_KhachHang
	end
go
--Xóa lệnh sửa chữa
create proc XoaLSC(@ID_LenhSuaChua varchar(10))
as
	begin
		delete from LENHSUACHUA
		where ID_LenhSuaChua = @ID_LenhSuaChua
	end
go
--Xóa nhà cung cấp
create proc XoaNCC(@ID_NhaCungCap nvarchar(50))
as
	begin
		delete from NHACUNGCAP
		where ID_NhaCungCap = @ID_NhaCungCap
	end
go
--Xóa nhân viên
create proc XoaNV(@ID_NhanVien varchar(10))
as
	begin
		delete from NHANVIEN
		where ID_NhanVien = @ID_NhanVien
	end
go
--Xóa phân công
create proc XoaPC(@ID_PhanCong varchar(10))
as
	begin
		delete from PHANCONG
		where ID_PhanCong = @ID_PhanCong
	end
go
--Xóa phiếu đánh giá
create proc XoaPDG(@ID_PhieuDanhGia varchar(10))
as
	begin
		delete from PHIEUDANHGIA
		where ID_PhieuDanhGia = @ID_PhieuDanhGia
	end
go
--Xóa phiếu khảo sát
create proc XoaPKS(@ID_PhieuKhaoSat varchar(10))
as
	begin
		delete from PHIEUKHAOSAT
		where ID_PhieuKhaoSat = @ID_PhieuKhaoSat
	end
go
--Xóa phiếu vật tư
create proc XoaPVT(@ID_PhieuVatTu varchar(10))
as
	begin
		delete from PHIEUVATTU
		where ID_PhieuVatTu = @ID_PhieuVatTu
	end
go
--Xóa quyền
create proc XoaQH(@ID_QuyenHan varchar(10))
as
	begin
		delete from QUYENHAN
		where ID_QuyenHan = @ID_QuyenHan
	end
go
--Xóa tài khoản
create proc XoaTK(@TenTK varchar(50))
as
	begin
		delete from NGUOIDUNG
		where TaiKhoan = @TenTK
	end
go
--Xóa vật tư
create proc XoaVT(@ID_VatTu nvarchar(50))
as
	begin
		delete from VATTU
		where ID_VatTu = @ID_VatTu
	end
go
--Xóa xe
create proc XoaXe(@ID_Xe varchar(10))
as
	begin
		delete from THONGTINXE
		where ID_Xe = @ID_Xe
	end
go
--
create proc XoaHangXe(@ID_HangXe varchar(10))
as
	begin
		delete from HANGXE
		where ID_HangXe = @ID_HangXe
	end
go




------trigger xóa dữ liệu liên quan đến nhiều bảng---

create trigger trig_XoaHangXe on HANGXE instead of delete
as
	declare @Ma varchar(10)
	begin
		select @Ma = ID_HangXe from deleted

		update THONGTINXE
		set ID_HangXe = null
		where ID_HangXe = @Ma

		delete from HANGXE
		where ID_HangXe = @Ma

	end
go

--Xóa thông tin xe
create trigger trig_XoaThongTinXe on THONGTINXE instead of delete
as
	declare @Ma varchar(10)
	begin
		select @Ma = ID_Xe from deleted

		delete from PHIEUKHAOSAT
		where ID_Xe = @Ma

		delete from THONGTINXE
		where ID_Xe = @Ma

		print 'Xe vua xoa co ID la: ' + @Ma
	end
go

--Xóa khách hàng
create trigger trig_XoaKhachHang on KHACHHANG instead of delete
as
	declare @Ma varchar(10)
	begin
		select @Ma = ID_KhachHang from deleted

		delete from PHIEUKHAOSAT
		where ID_KhachHang = @Ma

		delete from KHACHHANG
		where ID_KhachHang = @Ma

		print 'Ma khach hang vua xoa la: ' + @Ma
	end
go

--Xóa phiếu khảo sát
create trigger trig_XoaPhieuKhaoSat on PHIEUKHAOSAT instead of delete
as
	declare @MaPKS varchar(10)
	begin
		select @MaPKS = ID_PhieuKhaoSat from deleted

		delete from PHIEUDANHGIA
		where ID_PhieuKhaoSat = @MaPKS

		delete from PHIEUKHAOSAT
		where ID_PhieuKhaoSat = @MaPKS

		print 'Ma phieu khao sat vua xoa la: ' + @MaPKS
	end
go

--Xóa phiếu đánh giá
create trigger trig_XoaPhieuDanhGia on PHIEUDANHGIA instead of delete
as
	declare @MaPDG varchar(10)
	begin
		select @MaPDG = ID_PhieuDanhGia from deleted

		delete from LENHSUACHUA
		where ID_PhieuDanhGia = @MaPDG

		delete from PHIEUDANHGIA
		where ID_PhieuDanhGia = @MaPDG

		print 'Ma phieu danh gia vua xoa la: ' + @MaPDG
	end
go

--Xóa lệnh sửa chữa
create trigger trig_XoaLenhSuaChua on LENHSUACHUA instead of delete
as
	declare @MaLenh varchar(10)
	begin
		select @MaLenh = ID_LenhSuaChua from deleted

		delete from PHANCONG
		where ID_LenhSuaChua = @MaLenh

		delete from HOADON_THANHTOAN
		where ID_LenhSuaChua = @MaLenh

		delete from LENHSUACHUA
		where ID_LenhSuaChua = @MaLenh

		print 'Ma lenh sua chua vua xoa la: ' + @MaLenh
	end
go

--Xóa Nhà cung cấp
create trigger trig_XoaNhaCungCap on NHACUNGCAP instead of delete
as
	declare @ID_NhaCungCap varchar(10)
	begin
		select @ID_NhaCungCap = ID_NhaCungCap from deleted

		delete from VATTU
		where ID_NhaCungCap = @ID_NhaCungCap

		delete from NHACUNGCAP
		where ID_NhaCungCap = @ID_NhaCungCap

		print 'ID nha cung cap vua xoa la: ' + @ID_NhaCungCap
	end
go

--Xóa vật tư
create trigger trig_XoaVatTu on VATTU instead of delete
as
	declare @ID_VatTu varchar(10)
	begin
		select @ID_VatTu = ID_VatTu from deleted

		delete from HOADON_PHIEUVATTU
		where ID_VatTu = @ID_VatTu

		delete from VATTU
		where ID_VatTu = @ID_VatTu
		
		print 'ID vat tu vua xoa la: ' + @ID_VatTu
	end
go

--Xóa hóa đơn phiếu vât tư
create trigger trig_XoaHD_PVT on HOADON_PHIEUVATTU instead of delete
as
	declare @MaHDVT varchar(10)
	begin
		select @MaHDVT = ID_HoaDonVatTu from deleted

		delete from HOADON_PHIEUVATTU
		where ID_HoaDonVatTu = @MaHDVT

		print 'Hoa don vua xoa co ma la: ' + @MaHDVT
	end
go

--Xóa phiếu vật tư
create trigger trig_XoaPVT on PHIEUVATTU instead of delete
as
	declare @MaPVT varchar(10)
	begin
		select @MaPVT = ID_PhieuVatTu from deleted

		delete from HOADON_PHIEUVATTU
		where ID_PhieuVatTu = @MaPVT

		delete from LENHSUACHUA
		where ID_PhieuVatTu = @MaPVT

		delete from PHIEUVATTU
		where ID_PhieuVatTu = @MaPVT

		print 'Phieu vat tu vua xoa co ma la: ' + @MaPVT
	end
go

--Xóa hóa đơn thanh toán
create trigger trig_XoaHD_TT on HOADON_THANHTOAN instead of delete
as
	declare @MaHD varchar(10)
	begin
		select @MaHD = ID_HoaDonThanhToan from deleted

		delete from HOADON_THANHTOAN
		where ID_HoaDonThanhToan = @MaHD

		print 'Hoa don vua xoa co ma la: ' + @MaHD
	end
go

--Xóa quyền hạn
create trigger trig_XoaQH on QUYENHAN instead of delete
as
	declare @MaQH varchar(10)
	begin
		select @MaQH = ID_QuyenHan from deleted

		delete from NGUOIDUNG
		where ID_QuyenHan = @MaQH

		delete from QUYENHAN
		where ID_QuyenHan = @MaQH

		print 'Quyen vua xoa co ma la: ' + @MaQH
	end
go

--Xóa người dùng
create trigger trig_XoaTK on NGUOIDUNG instead of delete
as
	declare @TK varchar(50)
	begin
		select @TK = TaiKhoan from deleted

		update NHANVIEN
		set TaiKhoan = null
		where TaiKhoan = @TK

		delete from NGUOIDUNG
		where TaiKhoan = @TK

		print 'Nguoi dung vua xoa co tai khoan la: ' + @TK
	end
go

--Xóa nhân viên
create trigger trig_XoaNV on NHANVIEN instead of delete
as
	declare @MaNV varchar(10)
	begin
		select @MaNV=ID_NhanVien from deleted

		delete from PHANCONG
		where ID_NhanVien = @MaNV

		delete from NHANVIEN 
		where ID_NhanVien=@MaNV

		print 'Ma nhan vien vua xoa la: ' + @MaNV
	end
go

--Xóa phân công
create trigger trig_XoaPC on PHANCONG instead of delete
as
	declare @MaPC varchar(10)
	begin
		select @MaPC = ID_PhanCong from deleted

		delete from PHANCONG
		where ID_PhanCong = @MaPC

		print 'Vua xoa phan cong co ma la ' + @MaPC
	end
go








--Xem thông tin khách hàng và xe của người đó
create proc XemKH(@MaKH varchar(10) = null, @TenKH ntext = null)
as
	begin
		if (@MaKH is null) or (@MaKh = '')
		begin
			if (@TenKH is null)
			begin
				print 'Loi.....'
			end

			else
			begin
				select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
				from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
				where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe and kh.HoTen like @TenKH
			end
		end

		else
		begin
			if (@TenKH is null)
			begin
				select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
				from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
				where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe and kh.MaKH = @MaKH
			end

			else
			begin
				select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
				from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
				where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe and kh.MaKH = @MaKH and kh.HoTen like @TenKH
			end
		end
	end
go
exec XemKH '', 'Truong Thi Trang'
go

--Xem thông tin xe và người sở hữu xe đó
create proc XemXe(@BienSoXe char(10) = null, @HangXe ntext = null)
as
	begin
		if (@BienSoXe is null) or (@BienSoXe = '')
		begin
			if (@HangXe is null)
			begin
				print 'Loi.....'
			end

			else
			begin
				select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
				from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
				where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe and xe.HangXe like @HangXe
			end
		end

		else
		begin
			if (@HangXe is null)
			begin
				select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
				from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
				where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe and xe.BienSoXe = @BienSoXe
			end

			else
			begin
				select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
				from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
				where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe and xe.BienSoXe = @BienSoXe and xe.HangXe like @HangXe
			end
		end
	end
go
exec XemXe '', 'Audi'
go


--XEM DANH SACH NHAN VIEN DUOC PHAN CONG SUA XE
create  proc XemNV_BSXE(@BienSoXe char(10))
as
	begin
		select n.MaNV, n.HoTen, xe.BienSoXe, xe.HangXe
		from THONGTINXE xe, PHIEUKHAOSAT pks, PHIEUDANHGIA pdg, LENHSUACHUA lsc, PHANCONG pc, NHANVIEN n 
		where xe.BienSoXe = @BienSoXe and xe.BienSoXe = pks.BienSoXe and pks.MaPhieuKhaoSat = pdg.MaPhieuKhaoSat and pdg.MaPhieuDanhGia = lsc.MaPhieuDanhGia and lsc.MaLenhSuaChua = pc.MaLenhSuaChua and pc.MaNV = n.MaNV
end
go
exec XemNV_BSXe '89B-532.12'
go


--Hàm thống kê số lượng xe của 1 khách hàng mang đến sửa
create function Xe_KH(@MaKH char(10)) 
returns @BangThongKe table
(
	MaKH char(10),
	SoXe int
)as
begin
	if(@MaKH is null) or (@MaKH = '')
	insert into @BangThongKe
		select MaKH, count(BienSoXe)
		from PHIEUKHAOSAT
		group by MaKH
	else
	insert into @BangThongKe
		select MaKH, count(BienSoXe)
		from PHIEUKHAOSAT
		where MaKH = @MaKH
		group by MaKH
	return
end
go
select * from Xe_KH('')
go

--Hàm hiển thị thông tin xe của từng khách hàng
create function Hienthi_Xe(@MaKH char(10))
returns @HienThi table
(
	MaKH char(10),
	HoTen ntext,
	BienSoXe char(10),
	HangXe ntext,
	DoiXe ntext
)as
begin
	if(@MaKH is null) or (@MaKH = '')
	insert into @HienThi
		select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
		from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
		where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe
	else
	insert into @HienThi
		select kh.MaKH, kh.HoTen, xe.BienSoXe, xe.HangXe, xe.DoiXe
		from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
		where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe and kh.MaKH = @MaKH
	return
end
go
select * from Hienthi_Xe('6')
go








---triger them du lieu---
--nhanvien
create trigger trig_ThemNV on NHANVIEN for insert
as
	declare @MaNV int
	begin
		select @MaNV = MaNV from inserted
		print 'Ma nhan vien vua them la:' + convert(varchar(50), @MaNV)
	end
go
--xuong
create trigger trig_ThemXuong on XUONG for insert
as
	declare @TenXuong varchar(50)
	begin
		select @TenXuong = TenXuong from inserted
		print 'Ten Xuong vua them la: ' + @TenXuong
	end
go
--PhieuDanhGia
create trigger trig_ThemPDG on PHIEUDANHGIA for insert
as
	declare @MaPhieuDanhGia INT
	begin
		select @MaPhieuDanhGia = MaPhieuDanhGia from inserted
		print 'Ma phieu danh gia vua them la: ' +convert(varchar(50) ,@MaPhieuDanhGia)
	end
go
--Khách hàng
create trigger trig_ThemKH on KHACHHANG for insert
as
	declare @MaKH int
	begin
		select @MaKH = MaKH from inserted
		print 'Ma khach hang vua them la:' + convert(varchar(50), @MaKH)
	end
go

--Xe
create trigger trig_ThemXe on THONGTINXE for insert
as
	declare @BienSoXe varchar(50)
	begin
		select @BienSoXe = BienSoXe from inserted
		print 'Bien so xe vua them la: ' + @BienSoXe
	end
go

--Phiếu khảo sat
create trigger trig_ThongTin on PHIEUKHAOSAT for insert
as
	declare @Ma int
	begin
		select @Ma = MaPhieuKhaoSat from inserted
		print 'Ma phieu khao sat vua them la: ' + convert(varchar(50), @Ma)
	end
go

--phieu vat tu
create trigger trig_ThemPVT on PHIEUVATTU for insert
as
	declare @MaPhieuVatTu INT
	begin
		select @MaPhieuVatTu = MaPhieuVatTu from inserted
		print 'Ma phieu vat tu vua them la: ' +convert(varchar(50) ,@MaPhieuVatTu)
	end
go
--them nha cung cap
create trigger trig_ThemNCC on NHACUNGCAP for insert
as
	declare @TenNhaCungCap varchar(50)
	begin
		select @TenNhaCungCap=TenNhaCungCap from inserted
		print 'Ten nha cung cap vua them la:' +@TenNhaCungCap
	end
go
--them hoa don
create trigger trig_ThemHoaDon on HOADON for insert
as
	declare @MaHD int
	begin
		select @MaHD=Ma from inserted
		print 'Ma hoa don vua them vao la:' +convert(varchar(50),@MaHD)
	end
go





select * from HOADON
select * from KHACHHANG
select * from NHACUNGCAP
select * from NHANVIEN
select * from PHIEUDANHGIA
select * from PHIEUKHAOSAT
select * from PHIEUVATTU
select * from THONGTINXE
select * from XUONG

delete from PHIEUKHAOSAT
where MaPhieuKhaoSat = 1



--Hiển thị mã và họ tên khách hàng cùng với thông tin xe của họ
select kh.MaKH, kh.HoTen, xe.*
from KHACHHANG kh, THONGTINXE xe, PHIEUKHAOSAT ks
where kh.MaKH = ks.MaKH and xe.BienSoXe = ks.BienSoXe

--Thống kê số lượng xe của mỗi khách hàng
select MaKH, count(BienSoXe)
from PHIEUKHAOSAT
group by MaKH

--Hiển thị thông tin và xe khách hàng có số lượng xe nhiều hơn 2
select MaKH, count(BienSoXe)
from PHIEUKHAOSAT
group by MaKH
having count(BienSoXe) > 1

--Thống kê số nhân viên trong từng xưởng
select TenXuong, count(MaNV)
from NHANVIEN
group by TenXuong

--đếm số lượng nhân viên hiện tại đang làm từng xưởng hiển thị trong view sao cho số lượng nhân viên trong phòng >1
create view Xuong_SoLuong as
	(select TenXuong, count (MaNV) as soluong
	from NHANVIEN n, XUONG x
	where n.TenXuong = x.TenXuong
	group by TenXuong
	having count(MaNV)>1
	)
go 
select *from Xuong_SoLuong
order by Xuong_SoLuong.soluong

--Đếm số lượng khách hàng
select MaKH, count (MaKH) as SoLuong
from PHIEUKHAOSAT
group by MaKH

--
select h.MaPhieuVatTu, TenHoaDon , count(Ma) soluonghd
from HOADON h, PHIEUVATTU p
where h.MaPhieuVatTu = p.MaPhieuVatTu
group by TenHoaDon, h.MaPhieuVatTu
--
select TenXuong, count(MaNV) as soluong
from NHANVIEN
group by TenXuong
having count(MaNV) >=1
--
select n.TenNhaCungCap,Website, count(TenNhaCungCap) as soluong
from PHIEUVATTU p, NHACUNGCAP n
where p.NhaCungCap = n.TenNhaCungCap
group by n.TenNhaCungCap, Website











