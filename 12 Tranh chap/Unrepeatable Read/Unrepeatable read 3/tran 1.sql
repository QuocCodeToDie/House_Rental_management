use qLyCUAHANG
go

drop procedure if exists dbo.XemNhaNgoaiO1
go

create procedure XemNhaNgoaiO1
	@maN nvarchar(10),
	@khuvuc nvarchar(20)
as

begin transaction
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maN)
		begin
			
			select * from Nha where maN = @maN and khuVuc = @khuvuc

			waitfor delay '00:00:10' -- delay de xay ra loi unrp read

			select * from Nha where maN = @maN and khuVuc = @khuvuc

			commit transaction

		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 
exec XemNhaNgoaiO1
	@maN = '002',
	@khuvuc = 'ngoai o'