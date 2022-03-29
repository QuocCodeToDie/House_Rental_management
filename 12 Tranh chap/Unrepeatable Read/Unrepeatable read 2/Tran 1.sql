use qLyCUAHANG
go

drop procedure if exists dbo.XemNha1
go

create procedure XemNha1
	@maN nvarchar(10)	
as

begin transaction
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maN)
		begin
			
			select * from Nha where maN = @maN

			waitfor delay '00:00:10' -- delay de xay ra loi unrp read

			select * from Nha where maN = @maN

			commit transaction

		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 
exec XemNha1
	@maN = '001'

	