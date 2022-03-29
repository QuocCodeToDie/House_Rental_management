use qLyCUAHANG
go

drop procedure if exists dbo.ThueNha1
go

create procedure ThueNha1
	@maNha nchar(10)
as

begin tran
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maNha)
		begin 

			declare @slPhong int
			select @slPhong = soLuongPhong from Nha where maN = @maNha

			waitfor delay '00:00:10'

			set @slPhong = @slPhong - 1;

			update Nha set soLuongPhong = @slPhong where maN = @maNha

			select * from Nha where maN = @maNha 

			commit tran
		end
	else
		begin
			print 'nha khong ton tai'
			rollback tran
			return
		end
go 

-- update Nha set soLuongPhong = 5 where maN = 'N01'
-- select soLuongPhong from Nha where maN = 'N01'
---- TRAN 1: dat 2 phong trong nha co maN = N1 
exec ThueNha1
	@maNha = 'N01'

