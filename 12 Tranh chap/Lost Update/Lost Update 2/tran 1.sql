use qLyCUAHANG
go

drop procedure if exists dbo.PhanCong1
go

create procedure PhanCong1
	@maNV nchar(10),
	@maCN nvarchar(10)
as

begin tran
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maNV from NhanVien with(nolock) where maNV = @maNV)
		begin
			declare @maCN_current nvarchar(10)
			select @maCN_current = maCN from NhanVien where maNV = @maNV

					waitfor delay '00:00:10'
					update NhanVien set maCN = @maCN where maNV = @maNV

					select maCN from NhanVien where maNV = @maNV

					commit tran
		end
	else
		begin
			print 'nhan vien khong ton tai'
			rollback tran
			return
		end
go 
exec PhanCong1
	@maNV = '001',
	@maCN = '001'

