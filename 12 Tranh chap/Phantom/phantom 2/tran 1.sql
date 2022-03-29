use qLyCUAHANG
go

drop procedure if exists dbo.YeuCauGiaThue1
go

create procedure YeuCauGiaThue1
	@min int,
	@max int
as

begin transaction
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where giaThue1T between @min and @max )
		begin
			
			select * from Nha where giaThue1T between @min and @max

			waitfor delay '00:00:10' -- delay de xay ra loi unrp read

			select * from Nha where giaThue1T between @min and @max

			commit transaction

		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 

exec YeuCauGiaThue1
	@min = 300,
	@max = 1000
	