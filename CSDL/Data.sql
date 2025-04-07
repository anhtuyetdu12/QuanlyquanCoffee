CREATE DATABASE QuanLyQuanCafe
GO
USE QuanLyQuanCafe
GO

--Food - thực đơn
--Table- bàn
--FoodCategory - danh mục thực đơn
--Bill - hóa đơn
--Bill Info - chi tiết hóa đơn
-- Receipt - thanh toán
-- Menu - thực đơn

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' ,
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'    -- trống || có ng
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' 
	
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' ,
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	dateCheckIn DATE NOT NULL DEFAULT GETDATE() ,
	dateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0  --1 : đã thanh toán || 0: chưa thanh toán
	
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

CREATE TABLE Menu  --- thực đơn
(
	id INT IDENTITY PRIMARY KEY,
	idFoodCategory INT NOT NULL,
	addDate DATE,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idFoodCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Receipt --- Biên lai
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	method NVARCHAR(100) NOT NULL DEFAULT N'Chưa chọn phương thức',
	paymentDate DATE,   -- ngày thanh toán
	discount INT NOT NULL DEFAULT 0, -- giảm giá
	totalAmount FLOAT NOT NULL DEFAULT 0,
	changeMoney FLOAT NOT NULL DEFAULT 0, -- tiền thối
	guestMoney FLOAT NOT NULL DEFAULT 0, -- tiền khách đưa
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id)
)
GO

ALTER TABLE Food ADD idMenu INT ;
ALTER TABLE Food ADD CONSTRAINT FK_Food_Menu FOREIGN KEY (idMenu) REFERENCES dbo.Menu(id);

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Food' AND COLUMN_NAME = 'idMenu';


--thêm bàn cách 1: 
INSERT dbo.TableFood (name)
VALUES (N'Bàn 4')
INSERT dbo.TableFood (name)
VALUES (N'Bàn 5')
INSERT dbo.TableFood (name)
VALUES (N'Bàn 6')

-- thêm bàn cách 2:
DECLARE @i INT = 0

WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood (name) VALUES (N'Bàn' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END


GO

select * from dbo.TableFood

GO

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO 
update dbo.TableFood set status = N'Có người' Where id =3
EXEC dbo.USP_GetTableList


-- thêm bàn danh mục - category
INSERT dbo.FoodCategory (name)
VALUES (N'Cafe')
INSERT dbo.FoodCategory (name)
VALUES (N'Trà')
INSERT dbo.FoodCategory (name)
VALUES (N'Matcha')
INSERT dbo.FoodCategory (name)
VALUES (N'Soda')
INSERT dbo.FoodCategory (name)
VALUES (N'Bánh ngọt')

delete from dbo.FoodCategory where id = 10
--Thêm món ăn:
--cafe
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Bạc xỉu', 1, 25000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Cappuccino', 1, 65000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Cafe Latte', 1, 50000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Cafe Mocha', 1, 45000)

-- Trà
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Trà táo', 2, 30000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Trà chanh mật ong', 2, 30000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Trà anh đào', 2, 55000)
--Matcha
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Matcha dâu tây', 3, 75000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Matcha Latte', 3, 40000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Matcha sữa dừa',3, 60000)
-- Soda
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Soda cherry', 4, 65000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Soda dâu tằm',4, 45000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Soda nho', 4, 40000)
-- Bánh ngọt
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Bánh Tiramisu dâu', 5, 75000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Bánh Limburg Pie', 5, 80000)
INSERT dbo.Food (name, idCategory, price)
VALUES (N'Bánh Cheesecake nho', 5, 60000)


-- thêm bill
INSERT dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
VALUES (GETDATE(), null, 1, 0)  --0: chưa checkout
INSERT dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
VALUES (GETDATE(), null, 2, 0)  --0: chưa checkout
INSERT dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
VALUES (GETDATE(), GETDATE(), 2, 1)  --1: checkout rồi


-- Thêm bill info
INSERT dbo.BillInfo(idBill, idFood, count)
VALUES (1, 1, 2)  --count : số lượng
INSERT dbo.BillInfo(idBill, idFood, count)
VALUES (1, 3, 4)  --count : số lượng
INSERT dbo.BillInfo(idBill, idFood, count)
VALUES (1, 5, 1)  --count : số lượng
INSERT dbo.BillInfo(idBill, idFood, count)
VALUES (2, 1, 2)  --count : số lượng
INSERT dbo.BillInfo(idBill, idFood, count)
VALUES (2, 6, 2)  --count : số lượng
INSERT dbo.BillInfo(idBill, idFood, count)
VALUES (3, 5, 2)  --count : số lượng


-- Thêm Menu
INSERT INTO dbo.Menu ( idFoodCategory, addDate, count)
VALUES ( 1, '2025-02-01', 5)  --count : số lượng
INSERT INTO dbo.Menu ( idFoodCategory, addDate, count)
VALUES ( 2, '2025-02-01', 10)
INSERT INTO dbo.Menu (idFoodCategory, addDate, count)
VALUES ( 3, '2025-02-01', 9)
INSERT INTO dbo.Menu ( idFoodCategory, addDate, count)
VALUES ( 4, '2025-02-01', 20)
INSERT INTO dbo.Menu ( idFoodCategory, addDate, count)
VALUES ( 5, '2025-02-01', 15)

GO

select * from dbo.TableFood
GO
select * from dbo.Bill
GO
select * from dbo.BillInfo
GO
select * from dbo.Food
GO
select * from dbo.FoodCategory

select * from dbo.Menu

select * from dbo.Receipt

UPDATE Food
SET idMenu = 5
WHERE id = 16;

-- tạo hàm load bill
CREATE PROCEDURE USP_GetBillTable
    @tableId INT
AS
BEGIN
    SELECT f.name AS TenMon, bi.count AS SoLuong, f.price AS DonGia, (bi.count * f.price) AS ThanhTien
    FROM dbo.Bill b
    INNER JOIN dbo.BillInfo bi ON b.id = bi.idBill
    INNER JOIN dbo.Food f ON bi.idFood = f.id
    WHERE b.idTable = @tableId AND b.status = 0    --satus 1: đã thanh toán || 0: chưa thanh toán
END
GO

select * from dbo.Bill

select * from dbo.BillInfo

select * from dbo.TableFood

GO

-- tạo hàm load category
CREATE PROCEDURE USP_GetCategory
AS
BEGIN
    SELECT * FROM dbo.FoodCategory
END
GO

EXEC USP_GetCategory


-- tạo hàm load food list category id
CREATE PROCEDURE USP_GetFoodListByCategoryId
    @idCategory INT
AS
BEGIN
    SELECT 
        f.id AS IDMonAn,
        f.name AS TenMonAn,
        f.price AS Gia,
        fc.name AS DanhMuc,
        m.addDate AS NgayThemVaoMenu
    FROM dbo.Food f
    INNER JOIN dbo.Menu m ON f.idMenu = m.id
    INNER JOIN dbo.FoodCategory fc ON m.idFoodCategory = fc.id
    WHERE fc.id = @idCategory
END
GO

-- tạo hàm thêm món vào bill info
create proc USP_InsertBillInfo
	@idBill int, @idFood int, @count int
as
begin
	declare @isExitsBillInfo int  -- mon an chua ton tai
	declare @foodCount int = 1  --Nếu món chưa có, @foodCount luôn bằng 1 thay vì NULL

	select @isExitsBillInfo = id, @foodCount = bi.count
	from dbo.BillInfo as bi
	where idBill = @idBill and idFood = @idFood

	if(@isExitsBillInfo > 0)  -- mon an da ton tai
	begin
		declare @newCount int = @foodCount + @count
		if(@newCount > 0)  
			update dbo.BillInfo set count = @newCount where idBill = @idBill and  idFood = @idFood   -- capnhat so luong spham
		else
			delete dbo.BillInfo where idBill = @idBill and idFood = @idFood -- Nếu số lượng mới ≤ 0, nó sẽ xóa món khỏi hóa đơn.
	end
	else
	begin    -- Nếu món ăn chưa có, nó sẽ thêm mới vào BillInfo.
		INSERT dbo.BillInfo(idBill, idFood, count)
		VALUES (@idBill, @idFood, @count)
	end
	  
end
go

-- tạo hàm thêm bill
create proc USP_InsertBill
	@idTable int
as
begin
	INSERT dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
	VALUES (GETDATE(), null, @idTable, 0)  --0: chưa checkout
end
go

-- tạo hàm lấy ra bill chưa thanh toán 
create proc USP_GetUncheckBillIDByTableID
	@idTable INT
as
begin
	select * from dbo.Bill where idTable = @idTable and status = 0
end
go

-- tạo hàm lấy dsach bill inđo
create proc USP_GetListBillInfo
	@idBill int
as
begin
	select * from BillInfo where idBill = @idBill
end
go

-- tạo hàm checkout bill  1: đã thanh toán || 0  : chưa thanh toán
create proc USP_CheckOut
	@id int
as
begin
	update Bill set status = 1 where id = @id
end
go

delete dbo.BillInfo
delete dbo.Bill

-- tạo trigger update billinfo
alter trigger UTG_UpdateBillInfo
on dbo.BillInfo for insert, update
as
begin
	declare @idBill int

	select @idBill = idBill from inserted

	declare @idTable int

	select @idTable = idTable from dbo.Bill where id = @idBill and status = 0

	declare @count int
	select @count = count(*) from dbo.BillInfo where idBill = @idBill

	if(@count > 0)
	begin
		update dbo.TableFood set status = N'Có người' where id = @idTable
	end
	else
	begin
		update dbo.TableFood set status = N'Trống' where id = @idTable
	end
	
end
go

-- tạo trigger update bill
create trigger UTG_UpdateBill
on dbo.Bill for update
as
begin
	
	declare @idBill int

	select @idBill = id from inserted

	declare @idTable int

	select @idTable = idTable from dbo.Bill where id = @idBill

	declare @count int = 0

	select @count = COUNT(*) from dbo.Bill where idTable = @idTable and status = 0

	if (@count = 0 )
		update dbo.TableFood set status = N'Trống' where id = @idTable

end
go

ALTER TABLE Food
ADD CONSTRAINT FK_Food_Menu FOREIGN KEY (idMenu) REFERENCES Menu(id)


-- tạo hàm hiển thị thông tin chi tiết hóa đơn
CREATE PROCEDURE USP_GetReceiptByBillID
    @idBill INT
AS
BEGIN
    SELECT idBill, method, paymentDate, discount, totalAmount, changeMoney, guestMoney
    FROM Receipt
    WHERE idBill = @idBill;
END


-- tạo hàm lấy ra thông tin bill
alter PROCEDURE USP_LoadBill
    @idTable INT -- ID của bàn cần lấy hóa đơn
AS
BEGIN

    -- Kiểm tra xem bàn có hóa đơn chưa thanh toán không
    DECLARE @idBill INT;
    SELECT @idBill = ID FROM Bill WHERE idTable = @idTable AND Status = 0; 

    -- Nếu không có hóa đơn nào chưa thanh toán thì thoát
    IF @idBill IS NULL
    BEGIN
        PRINT 'Không tìm thấy hóa đơn cho bàn này.';
        RETURN;
    END

    -- Lấy danh sách món ăn trong hóa đơn
    SELECT 
        f.Name AS TenMon, 
        bi.Count AS SoLuong, 
        f.Price AS DonGia, 
        (bi.Count * f.Price) AS ThanhTien 
    FROM BillInfo bi
    JOIN Food f ON bi.idFood = f.ID
    WHERE bi.idBill = @idBill;
    
    -- Lấy thông tin tổng hóa đơn
    SELECT 
        b.ID AS MaHoaDon,
        b.idTable AS Ban,
        b.DateCheckIn AS NgayTao,
         COALESCE(b.DateCheckOut, GETDATE()) AS NgayXuat,
        b.Discount AS GiamGia,
        b.TotalPrice AS TongTien
    FROM Bill b
    WHERE b.ID = @idBill;
END;

-- 1. Thêm cột idFoodCategory vào bảng Food
ALTER TABLE dbo.Food ADD idFoodCategory INT;

-- 2. Cập nhật dữ liệu: Sao chép idFoodCategory từ Menu vào Food
UPDATE Food 
SET idFoodCategory = (
    SELECT idFoodCategory FROM Menu WHERE Menu.id = Food.idMenu
);

-- 3. Thiết lập khóa ngoại idFoodCategory trong bảng Food
ALTER TABLE Food ADD CONSTRAINT fk_food_foodcategory 
FOREIGN KEY (idFoodCategory) REFERENCES FoodCategory(id);
ALTER TABLE Menu DROP CONSTRAINT FK__Menu__count__1EA48E88;
-- 4. Xóa cột idFoodCategory khỏi bảng Menu
ALTER TABLE Menu DROP COLUMN idFoodCategory;


SELECT name FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('Food');

-- Tạo bảng trung gian
CREATE TABLE Food_Menu (
    idMenu INT,
    idFood INT,
    PRIMARY KEY (idMenu, idFood), -- Cặp khóa chính
    FOREIGN KEY (idMenu) REFERENCES Menu(id) ON DELETE CASCADE, 
    FOREIGN KEY (idFood) REFERENCES Food(id) ON DELETE CASCADE
);

ALTER TABLE Food_Menu 
ADD CONSTRAINT FK_FoodMenu_Menu FOREIGN KEY (idMenu) REFERENCES Menu(id) ON DELETE CASCADE;

ALTER TABLE Food_Menu 
ADD CONSTRAINT FK_FoodMenu_Food FOREIGN KEY (idFood) REFERENCES Food(id) ON DELETE CASCADE;

SELECT name 
FROM sys.foreign_keys 
WHERE parent_object_id = OBJECT_ID('Food');
ALTER TABLE Food DROP CONSTRAINT FK_Food_Menu;


select * from dbo.Food
select * from dbo.Food_Menu
select * from dbo.FoodCategory
select * from dbo.TableFood
select * from dbo.Bill
select * from dbo.BillInfo
select * from dbo.Menu
select * from dbo.Receipt

update dbo.Bill set totalPrice = 0

-- tạo hàm cập nhật discount và totalprice trong bill
CREATE PROCEDURE USP_UpdateBillTotalPrice
    @idBill INT,
    @totalPrice FLOAT,
    @discount int
AS
BEGIN
    -- Cập nhật giá trị totalPrice và discount của hóa đơn
    UPDATE Bill
    SET 
        totalPrice = @totalPrice,
        discount = @discount
    WHERE id = @idBill;
END;


EXEC USP_UpdateBillTotalPrice @idBill = 1, @totalPrice = 100000, @discount = 10;

SELECT * FROM Bill WHERE id = 1;

ALTER TABLE dbo.Bill ALTER Column discount INT NOT NULL;

-- tạo hàm load danh mục 
create proc LoadCategory
	@timKiem nvarchar(100)
as
begin
	select * from dbo.FoodCategory
	where name like '%'+@timKiem+'%';
end
--hàm thêm mới danh mục
create proc ThemCategory
	@tenDM nvarchar(150)
as
begin
	insert into dbo.FoodCategory values(@tenDM);
	if @@ROWCOUNT > 0 return 1
	else return 0;
	SELECT SCOPE_IDENTITY(); -- Trả về ID mới vừa thêm
end
-- tạo hàm cập nhật danh mục 
create proc CapNhatCategory
	@id int,
	@tenDM nvarchar(150)
as
begin
	update dbo.FoodCategory
	set name = @tenDM
	where id = @id;

	if @@ROWCOUNT > 0 return 1
	else return 0;
end
-- hàm xóa danh mục
create proc XoaCategory
	@id int
as
begin
	delete from dbo.FoodCategory
	where id = @id;

	if @@ROWCOUNT > 0 return 1
	else return 0;
end

SELECT name 
FROM sys.foreign_keys 
WHERE referenced_object_id = OBJECT_ID('FoodCategory');
ALTER TABLE Bill DROP CONSTRAINT FK_Bill_TableFood;
ALTER TABLE Bill ADD CONSTRAINT FK_Bill_TableFood FOREIGN KEY (idTable) 
REFERENCES TableFood(id) ON DELETE CASCADE;

SELECT * FROM Bill WHERE idTable IN (SELECT id FROM FoodCategory);

-- tạo hàm load bàn 
create proc LoadTable
	@timKiem nvarchar(100)
as
begin
	select * from dbo.TableFood
	 WHERE name LIKE '%' + @timKiem + '%'
       OR status LIKE '%' + @timKiem + '%';
end

--hàm thêm mới bàn
create proc ThemTable
	@tenBan nvarchar(100),
	@trangThai nvarchar(100)
as
begin
	insert into dbo.TableFood values(@tenBan, @trangThai);
	if @@ROWCOUNT > 0 return 1
	else return 0;
	SELECT SCOPE_IDENTITY(); -- Trả về ID mới vừa thêm
end
-- tạo hàm cập nhật bàn
create proc CapNhatTable
	@id int,
	@tenBan nvarchar(100),
	@trangThai nvarchar(100)
as
begin
	update dbo.TableFood
	set name = @tenBan,
		status = @trangThai
	where id = @id;

	if @@ROWCOUNT > 0 return 1
	else return 0;
end
-- hàm xóa bàn
create proc XoaTable
	@id int
as
begin
	delete from dbo.TableFood
	where id = @id;

	if @@ROWCOUNT > 0 return 1
	else return 0;
end

--hàm load menu ----
create proc LoadMenu
	@timKiem nvarchar(100)
as
begin
	select * from dbo.Menu
	 WHERE nameFood LIKE '%' + @timKiem + '%'
         OR CONVERT(NVARCHAR, addDate, 103) LIKE '%' + @timKiem + '%'   -- tìm theo ngày
        OR CAST(count AS NVARCHAR) LIKE '%' + @timKiem + '%';   -- tìm theo số lươngk
end
--hàm thêm menu
create proc ThemMenu
	@ngayThem DATE,
    @soLuong INT,
    @tenMon NVARCHAR(100)
as
begin
	insert into dbo.Menu (addDate, count, nameFood)
    VALUES (@ngayThem, @soLuong, @tenMon);
	if @@ROWCOUNT > 0 return 1
	else return 0;
	SELECT SCOPE_IDENTITY(); -- Trả về ID mới vừa thêm
end
-- hàm sửa menu
create proc CapNhatMenu
	@id INT,
    @ngayThem DATE,
    @soLuong INT,
    @tenMon NVARCHAR(100)
as
begin
	update dbo.Menu
	set addDate = @ngayThem,
		count = @soLuong,
        nameFood = @tenMon
	where id = @id;

	if @@ROWCOUNT > 0 return 1
	else return 0;
end
--hàm xóa menu
create proc XoaMenu
	@id int
as
begin
	delete from dbo.Menu
	where id = @id;

	if @@ROWCOUNT > 0 return 1
	else return 0;
end

--hàm load Food ----
create proc LoadFood
	@timKiem nvarchar(100)
as
begin
	 SELECT f.id, f.name, f.price, f.idFoodCategory, 
           SUM(m.count) AS totalCount, 
           MAX(m.addDate) AS lastAddedDate
    FROM dbo.Food f
    LEFT JOIN dbo.Menu m ON f.id = m.idFood
    WHERE f.name LIKE '%' + @timKiem + '%'  -- Lọc tên món ăn trước khi nhóm
    GROUP BY f.id, f.name, f.price, f.idFoodCategory;
end
--hàm thêm Food
create proc ThemFood
	@tenMon nvarchar(100),
    @gia float,
    @idDanhMuc int
as
begin
	insert into dbo.Food (name, price, idFoodCategory)
    VALUES (@tenMon, @gia, @idDanhMuc);
	if @@ROWCOUNT > 0 return 1
	else return 0;
	SELECT SCOPE_IDENTITY(); -- Trả về ID mới vừa thêm
end
-- hàm sửa Food
create proc CapNhatFood
	@id INT,
    @tenMon nvarchar(100),
    @gia float,
    @idDanhMuc int
as
begin
	update dbo.Food
	set name = @tenMon,
		price = @gia,
        idFoodCategory = @idDanhMuc
	where id = @id;

	if @@ROWCOUNT > 0 return 1
	else return 0;
end
--hàm xóa Food
create proc XoaFood
	@id int
as
begin
	delete from dbo.Food
	where id = @id;
	DELETE FROM dbo.Menu WHERE idFood = @id; -- Xóa trong Menu trước
    DELETE FROM dbo.Food WHERE id = @id; -- Xóa trong Food sau
	if @@ROWCOUNT > 0 return 1
	else return 0;
end

select * from dbo.Menu

-- tạo selectDanhMuc để lấy ra tên danh mục
create proc selectDanhMuc

as
begin
    select * from dbo.FoodCategory
end

--- chuyển bàn ----
alter proc USP_SwitchTable
	@idTable1 int,
	@idTable2 int
as
begin
	declare @idFirstBill int
	declare @idSecondBill int

	declare @isFirstTableEmpty int = 1
	declare @isSecondTableEmpty int = 1

	-- Lấy ID bill của 2 bàn
	select @idFirstBill = id from dbo.Bill where idTable = @idTable1 And status = 0
	select @idSecondBill = id from dbo.Bill where idTable = @idTable2 And status = 0

	if(@idFirstBill is NULL)
	begin
		-- tao ra bill moi neu bill1 bi null
		insert into dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
		values (GETDATE(), null, @idTable1 , 0) -- 0: chua checkout | 1 : checkout roi
		select @idFirstBill = max(id) from dbo.Bill where idTable = @idTable1 And status = 0
		
	end

	select @isFirstTableEmpty = count(*) from dbo.BillInfo where idBill = @idFirstBill
	 
	if(@idSecondBill is NULL)
	begin
		-- tao ra bill moi neu bill2 bi null
		insert into dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
		values (GETDATE(), null, @idTable2 , 0) -- 0: chua checkout | 1 : checkout roi
		select @idSecondBill = max(id) from dbo.Bill where idTable = @idTable2 And status = 0
		set @isSecondTableEmpty = 1
	end

	select @isSecondTableEmpty = count(*) from dbo.BillInfo where idBill = @idSecondBill

	 -- Dùng biến để lưu
	select id INTO IDBillInfoTable FROM dbo.BillInfo Where idBill = @idSecondBill

	update dbo.BillInfo set idBill = @idSecondBill where idBill = @idFirstBill   -- chuyen bill1 -> bill 2

	update dbo.BillInfo set idBill = @idFirstBill where id IN (select * from IDBillInfoTable)  -- chuyen bill2 -> sang bill 1 voi dkien id mac dinh 

	drop table IDBillInfoTable -- xoa bang

	if(@isFirstTableEmpty = 0)
		update dbo.TableFood set status = N'Trống' where id = @idTable2

	if(@isSecondTableEmpty = 0)
		update dbo.TableFood set status = N'Trống' where id = @idTable1
end

update dbo.TableFood set status = N'Trống'


select * from dbo.Bill
select * from dbo.BillInfo

-- tạo proc để lấy ra thông tin thống kê hóa đơn
alter proc USP_GetListBillByDate
	@checkIn date,
	@checkOut date
as
begin
	select t.name as [Tên bàn], b.totalPrice as [Tổng tiền] , dateCheckIn as [Ngày vào] , dateCheckOut as [Ngày ra], discount as [Giảm giá]
	from dbo.Bill as b, dbo.TableFood as t
	where dateCheckIn >= @checkIn and dateCheckOut <= @checkOut and b.status = 1
	and t.id = b.idTable
end

-- load món
create proc selectMonAn
as
begin
    select * from dbo.Food
end
-- phân trang cho bill