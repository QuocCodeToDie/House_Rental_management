use qLyCUAHANG
go

drop procedure if exists dbo.CapNhatNha1
go

create procedure CapNhatNha1
	@maN nchar(10),
	@tinhTrangNha nvarchar(50),
	@giaThue int,
	@giaBan int
as
begin tran
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maN)
		begin
			
			select tinhTrangNha,giaThue1T,giaBan from Nha where maN = @maN

			waitfor delay '00:00:10'
			update Nha set tinhTrangNha = @tinhTrangNha where maN = @maN
			update Nha set giaThue1T = @giaThue where maN = @maN
			update Nha set giaBan = @giaBan where maN = @maN

			select tinhTrangNha,giaThue1T,giaBan from Nha where maN = @maN
			commit tran
		end
	else
		begin
			print 'Nha khong ton tai'
			rollback tran
			return
		end
go 
exec CapNhatNha1
	@maN = '001',
	@tinhTrangNha = 'nha sua chua duoc 100% - rat dep',
	@giaThue = 750,
	@giaBan = 45000
