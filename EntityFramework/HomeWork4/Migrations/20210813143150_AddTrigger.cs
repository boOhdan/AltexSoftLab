using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrderingSystem.Migrations
{
    public partial class AddTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER TR_ProductCategories_AfterInsert
                    ON ProductCategories
                    AFTER INSERT
                    AS
	                DECLARE @ProductCategory VARCHAR(max);

	                SELECT @ProductCategory = CONCAT('ProductCategoryId : ', C.ProductCategoryId,' Name : ',C.Name)    
                    FROM INSERTED AS C;

	                PRINT N'Inserted Category - ' + @ProductCategory;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER TR_ProductCategories_AfterInsert");
        }
    }
}
