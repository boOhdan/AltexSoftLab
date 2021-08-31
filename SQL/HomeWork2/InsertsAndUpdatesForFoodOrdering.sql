USE FoodOrdering

-- 1. Вставка данних.
-- а)

INSERT INTO Supplier
VALUES 
(1, 'Paulo', 'wkamalk@livegolftv.com', '=?p2:(f`y5BFVtqx'),
(2, 'Layan', '9bsbs@yaungshop.com', 'P4N,,6aWj_kK<CbD'),
(3, 'Anastasia', '5hamzaraha@dunsoi.com', '<>[8\dq=<e/:J8{T');

INSERT INTO Product
VALUES 
(1, 'Cobblestone', 'Baked goods', 20, 23, 1), 
(2, 'Daves Killer Bread', 'Baked goods', 14, 55, 2), 
(3, 'Chicken Tonight', 'Sauces', 35, 34, 3), 
(4, 'Prego', 'Sauces', 57, 28, 1), 
(5, 'Hormel', 'Meats', 125, 14, 2), 
(6, 'Jimmy Dean', 'Meats', 150, 23, 3),
(7, 'Ambrosia', 'Ice cream and frozen desserts', 14, 18, 1), 
(8, 'Magnolia', 'Ice cream and frozen desserts', 23, 33, 2),
(9, 'Borden', 'Cheeses and cheese foods', 142, 66, 3),
(10, 'Alpine Lace', 'Cheeses and cheese foods', 100, 45, 1);

-- б)

INSERT INTO Product (ProductID, Name, Price, Quantity, SupplierID)
VALUES 
(11, 'Entenmanns', 18, 44, 2), 
(12, 'Beerenberg Farm', 62, 77, 1), 
(13, 'Spam', 172, 32, 3), 
(14, 'Selecta', 18, 28, 1), 
(15, 'Velveeta', 220, 28, 2);

-- в)

CREATE TABLE [dbo].[ProductCopy] (
	[ProductID] [int] NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[Price] [smallmoney] NOT NULL,
	[Quantity] [int] NOT NULL,
	[SupplierID] [int] NOT NULL
);

INSERT INTO ProductCopy
SELECT * FROM Product;

-- 2. Редактирование данных.
-- a)

UPDATE Product
SET Price = 120
WHERE Description = 'Meats' AND SupplierID = 2;

-- б)

UPDATE Product
SET Price = (SELECT  AVG(Price) FROM  Product)
WHERE Description = 'Sauces' AND SupplierID = 1;

-- в)

UPDATE Product 
SET Description = 'Meats'
FROM Product p
JOIN Supplier s 
ON p.SupplierID = s.SupplierID 
WHERE p.Description IS NULL AND s.Name = 'Anastasia';
