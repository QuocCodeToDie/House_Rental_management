use qLyCUAHANG
go

drop procedure if exists dbo.UpdateChuNha1
go


create procedure UpdateChuNha1
	@maN nchar(10),
	@maCN nvarchar(50)
as

begin tran
--- kiem tra nay co ton tai hay con phong hay khong

	if  EXISTS (select maN from Nha with(nolock) where maN = @maN)
		begin
			
			update Nha set maCN = @maCN where maN = @maN

			waitfor delay '00:00:15'

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

exec UpdateChuNha1
	@maN = '001',
	@maCN = '003'
