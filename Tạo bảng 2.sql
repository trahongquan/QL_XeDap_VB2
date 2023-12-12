
create table tblTaiKhoan 
(
	username varchar(255) primary key,
	password varchar(255),
	is_admin varchar(1)
);

insert into tblTaiKhoan(username, password, is_admin)
values ('admin','1234',1);


create table tblHoaDon
(
	maHoaDon varchar(255) primary key,
	khachHang varchar(255),
	tongTien decimal
);

create table tblHoaDonChiTiet
(
	maHoaDon varchar(255),
	colMa nvarchar(20),
	colTen nvarchar(50),
	colHang nvarchar(50),
	colXuatXu nvarchar(50),
	colSoLuong int,
	colGia decimal,
	colTien decimal,
	primary key (maHoaDon, colMa)
);