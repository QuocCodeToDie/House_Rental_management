use qLyCUAHANG
go
-- select * from Nha where maN = '001'
-- update Nha set tinhTrangNha = 'nha qua xau' where maN = '001'
drop procedure if exists dbo.UpdateTTrangNha1
go


create procedure UpdateTTrangNha1
	@maN nchar(10),
	@ttNha nvarchar(50)
as

begin tran
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maN)
		begin
			
			update Nha set tinhTrangNha = @ttNha where maN = @maN

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

-- update Nha set soLuongPhong = 5 where maN = 'N01'
-- select soLuongPhong from Nha where maN = 'N01'
---- TRAN 1: dat 2 phong trong nha co maN = N1 
exec UpdateTTrangNha1
	@maN = '001',
	@ttNha = 'Nha rat dep, hoan thien moi vi tri'
