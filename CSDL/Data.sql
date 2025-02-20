CREATE DATABASE QuanLyQuanCafe
GO
USE QuanLyQuanCafe
GO

--Food - thực đơn
--Table- bàn
--FoodCategory - danh mục thực đơn
--Bill - hóa đơn
--Bill Info - chi tiết hóa đơn

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

INSERT dbo.TableFood (name)
VALUES (N'Bàn 4')
INSERT dbo.TableFood (name)
VALUES (N'Bàn 5')
INSERT dbo.TableFood (name)
VALUES (N'Bàn 6')

GO

select * from dbo.TableFood

GO

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO 
update dbo.TableFood set status = N'Có người' Where id =3
EXEC dbo.USP_GetTableList