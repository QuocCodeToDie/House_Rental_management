use qLyCUAHANG
go

drop procedure if exists dbo.CheckInfoNha2
go

create procedure CheckInfoNha2
	@maN nchar(10)
as


--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maN)
		begin
			
			set transaction isolation level read committed
			select * from Nha (NOLOCK) where maN = @maN


		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 

-- update Nha set soLuongPhong = 5 where maN = 'N01'
-- select soLuongPhong from Nha where maN = 'N01'
---- TRAN 1: dat 2 phong trong nha co maN = N1 
exec CheckInfoNha2
	@maN = '001'

