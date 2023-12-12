delete from tblHoaDon;
delete from tblHoaDonChiTiet;

alter table tblXeDap 
add colTon int;

alter table tblHoaDonChiTiet
add colTon int;

alter table tblHoaDonChiTiet
add colHinhAnh varbinary(max);

alter table tblHoaDon
add ngay varchar(20);

alter table tblHoaDon
add thoigian varchar(20);


