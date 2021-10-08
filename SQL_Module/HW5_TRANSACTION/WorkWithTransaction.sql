USE ProductDB;
GO;

CREATE PROC usp_Insert_OR_Update_Data(@Request xml)
AS
BEGIN
BEGIN TRY  
	BEGIN TRAN 
		DECLARE @hdoc int
		EXEC sp_xml_preparedocument @hdoc OUTPUT, @Request

		MERGE Product AS tgt
		USING (SELECT * FROM OPENXML(@hdoc, '/Products/Product', 2)
		WITH(
			ProductID varchar(20),
			Name varchar(20),
			Price smallmoney,
			Quantity int
			)) AS src (ProductID, Name, Price, Quantity)
		ON (tgt.ProductID = src.ProductID)
		WHEN MATCHED THEN
			UPDATE SET Name = src.Name, Price = src.Price, Quantity = src.Quantity
		WHEN NOT MATCHED THEN
			INSERT (ProductID, Name, Price, Quantity)  
			VALUES (src.ProductID, src.Name, src.Price, src.Quantity);

		EXEC sp_xml_removedocument @hdoc
	COMMIT TRAN
END TRY
BEGIN CATCH
	EXEC sp_xml_removedocument @hdoc
	ROLLBACK TRAN
END CATCH
END

INSERT INTO Product
VALUES 
('pro-1', 'Burger King', 12, 120),
('pro-2', 'Milky Way', 9, 60),
('pro-3', 'Twix', 35, 80),
('pro-4', 'Lay’s', 32, 90),
('pro-5', 'Dove', 15, 120),
('pro-6', 'Red Bull', 21, 80);

DECLARE @products xml;

SELECT @products = P
FROM OPENROWSET (BULK 'D:\TestDate.xml', SINGLE_BLOB) AS Products(P)

EXEC  usp_Insert_OR_Update_Data @Request =  @products
