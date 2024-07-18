using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order_Management_System.Repository.Migrations
{
    public partial class CustomizePaymentMethodEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PayMethod",
                table: "Orders",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayMethod",
                table: "Orders");
        }
    }
}
