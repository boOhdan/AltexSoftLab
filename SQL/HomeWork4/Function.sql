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
VALUES ([dbo].[fn_Generate_UID]('Product', 9), 'Red Bull', 21, 120);
