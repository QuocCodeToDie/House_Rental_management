use qLyCUAHANG
go

drop procedure if exists dbo.YeuCauNha1
go

create procedure YeuCauNha1
	@slPhong int
as

begin transaction
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where soLuongPhong >= @slPhong )
		begin
			
			select * from Nha where soLuongPhong >= @slPhong

			waitfor delay '00:00:10' -- delay de xay ra loi unrp read

			select * from Nha where soLuongPhong >= @slPhong

			commit transaction
		end
	else
		begin
			print 'Nha khong ton tai'
			return
		end
go 

exec YeuCauNha1
	@slPhong = 2