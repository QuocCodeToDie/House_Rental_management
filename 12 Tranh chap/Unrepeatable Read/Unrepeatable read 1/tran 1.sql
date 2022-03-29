use qLyCUAHANG
go

drop procedure if exists dbo.CheckInfoChuNha1
go
create procedure CheckInfoChuNha1
	@maCN nvarchar(10)	
as
begin transaction
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maCN from ChuNha with(nolock) where maCN = @maCN)
		begin
			
			select * from ChuNha where maCN = @maCN

			waitfor delay '00:00:10' -- delay de xay ra loi unrp read

			select * from ChuNha where maCN = @maCN
			commit transaction
		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 
exec CheckInfoChuNha1
	@maCN = '001'

