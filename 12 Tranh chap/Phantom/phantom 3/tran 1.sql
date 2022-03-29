use qLyCUAHANG
go

drop procedure if exists dbo.YeuCauKhuVuc1
go

create procedure YeuCauKhuVuc1
	@thanhpho nvarchar(20)
as

begin transaction
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where thanhPho = @thanhpho )
		begin
			
			select * from Nha where thanhPho = @thanhpho 

			waitfor delay '00:00:10' -- delay de xay ra loi unrp read

			select * from Nha where thanhPho = @thanhpho 

			commit transaction

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
exec YeuCauKhuVuc1
	@thanhpho = 'ho chi minh'
	