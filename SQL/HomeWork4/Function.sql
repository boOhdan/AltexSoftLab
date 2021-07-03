USE ProductDB;
GO;

CREATE FUNCTION fn_Generate_UID(@table varchar(20), @number int)
RETURNS VARCHAR(20)
BEGIN
	DECLARE @uniqueID VARCHAR(20);

	SET @uniqueID = LOWER(SUBSTRING(@table, 1, 3)) + '-' + CONVERT(varchar(15), @number);

	RETURN(@uniqueID);
END;

GO;

INSERT INTO Product
VALUES ([dbo].[fn_Generate_UID]('Product', 4), 'Lay’s', 32, 90);

INSERT INTO Product
VALUES ([dbo].[fn_Generate_UID]('Product', 5), 'Dove', 15, 120);

INSERT INTO Product
VALUES ([dbo].[fn_Generate_UID]('Product', 6), 'Red Bull', 21, 80);
