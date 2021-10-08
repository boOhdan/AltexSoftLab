USE ProductDB;
GO;

Create Procedure usp_Generate_UID(
	@table varchar(20),
	@uniqueID varchar(20) OUTPUT
) 
AS
BEGIN
	EXEC ('SELECT * FROM ' + @table);
	SET @uniqueID = LOWER(SUBSTRING(@table, 1, 3)) + '-' + CONVERT(varchar(15), @@ROWCOUNT + 1);
END;

GO;

DECLARE @uniqueID varchar(20);

EXEC usp_Generate_UID 
	@table = 'Product', 
	@uniqueID = @uniqueID OUTPUT;

INSERT INTO Product
VALUES (@uniqueID, 'Burger King', 12, 120);

EXEC usp_Generate_UID 
	@table = 'Product', 
	@uniqueID = @uniqueID OUTPUT;

INSERT INTO Product
VALUES (@uniqueID, 'Milky Way', 9, 60);

EXEC usp_Generate_UID 
	@table = 'Product', 
	@uniqueID = @uniqueID OUTPUT;

INSERT INTO Product
VALUES (@uniqueID, 'Twix', 35, 80);
