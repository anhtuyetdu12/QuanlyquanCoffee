CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

-- Food
-- Table
-- Category
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'  -- Trống hoặc có người
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Nghia',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0
)
GO

CREATE TABLE Category
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT	NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.Category(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0		-- 0: Chưa thanh toán, 1: Đã thanh toán

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

INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES
(   N'nghia23',     -- UserName - nvarchar(100)
    N'nghiaa', -- DisplayName - nvarchar(100)
    N'1', -- PassWord - nvarchar(1000)
    1  -- Type - int
)
INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES
(   N'staff',     -- UserName - nvarchar(100)
    N'staff', -- DisplayName - nvarchar(100)
    N'1', -- PassWord - nvarchar(1000)
    0  -- Type - int
)
GO

INSERT INTO dbo.Category
(
    name
)
VALUES
(N'Trà sữa' -- name - nvarchar(100)
    )
go

INSERT INTO dbo.Food
(
    name,
    idCategory,
    price
)
VALUES
(   N'Trà sữa', -- name - nvarchar(100)
    1,       -- idCategory - int
    25000  -- price - float
    )
GO

SELECT * FROM Food


CREATE PROC USP_GetAccountByUserName
@userName NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'nghia23' -- nvarchar(100)

GO

CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

--------------------------------------------- Thêm bàn ---------------------------------------------
DECLARE @i INT = 1
WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood ( name)VALUES ( N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END--_______________________________________________________________________________________________

SELECT * FROM dbo.TableFood

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO 

UPDATE TableFood SET status = N'Có người' WHERE id = 9

EXEC dbo.USP_GetTableList

--------------------------------------------- Thêm danh mục ---------------------------------------------
INSERT FoodCategory (name) VALUES (N'Cà phê')
INSERT FoodCategory (name) VALUES (N'Trà sữa')
INSERT FoodCategory (name) VALUES (N'Nước ép')
INSERT FoodCategory (name) VALUES (N'Soda')
INSERT FoodCategory (name) VALUES (N'Sinh tố')
INSERT FoodCategory (name) VALUES (N'Bánh')
--_______________________________________________________________________________________________

--------------------------------------------- Thêm món ---------------------------------------------
INSERT Food (name, idCategory, price) VALUES (N'Cà phê sữa', 8, 20000)
INSERT Food (name, idCategory, price) VALUES (N'Bạc xỉu', 8, 30000)

INSERT Food (name, idCategory, price) VALUES (N'Trà sữa trân châu đen', 9, 25000)
INSERT Food (name, idCategory, price) VALUES (N'Trà sữa trân châu trắng', 9, 25000)

INSERT Food (name, idCategory, price) VALUES (N'Nước ép ổi', 10, 30000)
INSERT Food (name, idCategory, price) VALUES (N'Nước ép dưa hấu', 10, 30000)

INSERT Food (name, idCategory, price) VALUES (N'Soda chanh', 11, 20000)
INSERT Food (name, idCategory, price) VALUES (N'Soda việt quất', 11, 20000)

INSERT Food (name, idCategory, price) VALUES (N'Sinh tố bơ', 12, 40000)
INSERT Food (name, idCategory, price) VALUES (N'Sinh tố xoài', 12, 45000)

INSERT Food (name, idCategory, price) VALUES (N'Bánh mỳ que', 13, 15000)
INSERT Food (name, idCategory, price) VALUES (N'Bánh donut socola', 13, 20000)
--_______________________________________________________________________________________________

--------------------------------------------- Thêm hóa đơn ---------------------------------------------
INSERT Bill (DateCheckIn, DateCheckOut, idTable, status) VALUES (GETDATE(), NULL, 2, 0)
INSERT Bill (DateCheckIn, DateCheckOut, idTable, status) VALUES (GETDATE(), NULL, 3, 0)
INSERT Bill (DateCheckIn, DateCheckOut, idTable, status) VALUES (GETDATE(), GETDATE(), 3, 1)
--_______________________________________________________________________________________________

--------------------------------------------- Thêm thông tin hóa đơn ---------------------------------------------
INSERT BillInfo (idBill, idFood, count) VALUES (7, 17, 2)
INSERT BillInfo (idBill, idFood, count) VALUES (7, 18, 2)

INSERT BillInfo (idBill, idFood, count) VALUES (8, 21, 2)
INSERT BillInfo (idBill, idFood, count) VALUES (8, 22, 2)

INSERT BillInfo (idBill, idFood, count) VALUES (9, 24, 2)
INSERT BillInfo (idBill, idFood, count) VALUES (9, 25, 2)

--_______________________________________________________________________________________________

SELECT * FROM Category
SELECT * FROM Food
SELECT * FROM Bill
SELECT * FROM BillInfo
SELECT * FROM TableFood

select Food.name, BillInfo.count, Food.price, Food.price * BillInfo.count from BillInfo, Bill, Food 
WHERE BillInfo.idBill = Bill.id and BillInfo.idFood = Food.id and Bill.idTable = 3