use qLyCUAHANG
go

drop procedure if exists dbo.UpdateChuNha2
go


create procedure UpdateChuNha2
	@maCN nvarchar(10),
	@sdt nvarchar(10)
as


--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maCN from ChuNha with(nolock) where maCN = @maCN)
		begin
			

			update ChuNha set sDT = @sdt where maCN = @maCN
		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 

exec UpdateChuNha2
	@maCN = '001',
	@sdt = '02135125544'
