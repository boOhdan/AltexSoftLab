USE [master]
GO
/****** Object:  Database [ProductDB]    Script Date: 7/5/2021 5:08:23 PM ******/
CREATE DATABASE [ProductDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProductDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProductDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductDB] SET QUERY_STORE = OFF
GO
USE [ProductDB]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Generate_UID]    Script Date: 7/5/2021 5:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Generate_UID](@table varchar(20), @number int)
RETURNS VARCHAR(20)
BEGIN
	DECLARE @uniqueID VARCHAR(20);

	SET @uniqueID = LOWER(SUBSTRING(@table, 1, 3)) + '-' + CONVERT(varchar(15), @number);

	RETURN(@uniqueID);
END;
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/5/2021 5:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [varchar](20) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_Generate_UID]    Script Date: 7/5/2021 5:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[usp_Generate_UID](
	@table varchar(20),
	@uniqueID varchar(20) OUTPUT
) 
AS
BEGIN
	EXEC ('SELECT * FROM ' + @table);
	SET @uniqueID = LOWER(SUBSTRING(@table, 1, 3)) + '-' + CONVERT(varchar(15), @@ROWCOUNT + 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_OR_Update_Data]    Script Date: 7/5/2021 5:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Insert_OR_Update_Data](@Request xml)
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
GO
USE [master]
GO
ALTER DATABASE [ProductDB] SET  READ_WRITE 
GO
