use qLyCUAHANG
go

drop procedure if exists dbo.XoaNhaNgoaiO2
go


create procedure XoaNhaNgoaiO2
	@maN nvarchar(10)
as


--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maCN = @maN)
		begin
			

			update  Nha set khuVuc = 'gan cho' where maN = @maN
		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 

exec XoaNhaNgoaiO2
	@maN = '002'
