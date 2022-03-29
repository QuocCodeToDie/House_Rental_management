use qLyCUAHANG
go

drop procedure if exists dbo.ThueNha2
go

create procedure ThueNha2
	@maNha nchar(10)
as
begin tran
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maNha)
		begin 
			declare @slPhong int
			select @slPhong = soLuongPhong from Nha where maN = @maNha

			waitfor delay '00:00:1'

			set @slPhong = @slPhong - 2;

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
exec ThueNha2
	@maNha = 'N01'

