use qLyCUAHANG
go

drop procedure if exists dbo.XoaNha2
go


create procedure XoaNha2
	@maN nvarchar(10)
as


--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maCN = @maN)
		begin
			

			delete from Nha  where maN = @maN
		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 

exec XoaNha2
	@maN = '001'
