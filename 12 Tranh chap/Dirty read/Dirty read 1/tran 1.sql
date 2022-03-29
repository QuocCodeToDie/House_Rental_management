use qLyCUAHANG
go
	-- select * from Nha where maN = '001'
drop procedure if exists dbo.CheckInfoNha1
go

create procedure CheckInfoNha1
	@maN nchar(10)
as

begin tran
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maN)
		begin
			
			declare @giaThue int

			select @giaThue = giaThue1T from Nha where maN = @maN
			SELECT @giaThue
			set @giaThue = @giaThue + 1500
			
			update Nha set giaThue1T = @giaThue where maN = @maN

			waitfor delay '00:00:10'
			-- roll back cho ra lỗi dirty reads	
			rollback transaction	
		end
	else
		begin
			print 'Nha khong ton tai'
			rollback tran
			return
		end
go 
exec CheckInfoNha1
	@maN = '001'
