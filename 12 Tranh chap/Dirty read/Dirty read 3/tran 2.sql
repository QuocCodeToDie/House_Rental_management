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
			declare @maCN nvarchar(50)

			select @maCN = maCN from Nha(nolock) where maN = @maN

			set transaction isolation level read committed
			select * from ChuNha (NOLOCK) where maCN = @maCN


		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 

exec CheckInfoNha2
	@maN = '001'

