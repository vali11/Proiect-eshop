using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_eshop.Migrations
{
    public partial class Suppliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierID",
                table: "Product",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierID",
                table: "Product",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "Product");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
