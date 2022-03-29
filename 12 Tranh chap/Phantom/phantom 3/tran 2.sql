use qLyCUAHANG
go

drop procedure if exists dbo.ThemNha2
go

create procedure ThemNha2
	@maN nvarchar(10),
	@ttNha nvarchar(50),
	@maNVQL nvarchar(10),
	@slPhong int,
	@maCN nvarchar(10),
	@ngayDB date,
	@ngayHH date,
	@luotXem int,
	@loainha nvarchar(10),
	@quan nvarchar(10),
	@duong nvarchar(50),
	@thanhpho nvarchar(20),
	@khuvuc nvarchar(20),
	@giathue int,
	@giaBan int,
	@dieukien nvarchar(50)
as


--- kiem tra nay co ton tai hay con phong hay khong

	
			insert into Nha values(@maN,@ttNha,@maNVQL,@slPhong,@maCN,@ngayDB,@ngayHH,@luotXem,@loainha,
			@quan,@duong,@thanhpho,@khuvuc,@giathue,@giaBan,@dieukien)
		
go 

-- update Nha set soLuongPhong = 5 where maN = 'N01'
-- select soLuongPhong from Nha where maN = 'N01'
---- TRAN 1: dat 2 phong trong nha co maN = N1 
exec ThemNha2
	@maN = '008',
	@ttNha = 'nha dep' ,
	@maNVQL = '001',
	@slPhong = 4,
	@maCN = '003',
	@ngayDB ='2020-02-02',
	@ngayHH = '2021-03-02',
	@luotXem = 60,
	@loainha = 'LN01',
	@quan = 'quann 7',
	@duong = 'huynh tan phat',
	@thanhpho = 'ho chi minh',
	@khuvuc = 'gan truong hoc',
	@giathue = 800,
	@giaBan = 50000,
	@dieukien = 'tra truoc 75%'
