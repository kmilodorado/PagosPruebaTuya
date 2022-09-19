using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagosPruebaTuya.Data.Migrations
{
    public partial class InitDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_PaymentMethod_fkPaymentMethod_id",
                table: "OrderProduct");

            migrationBuilder.AlterColumn<int>(
                name: "fkPaymentMethod_id",
                table: "OrderProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "stateOrden",
                table: "OrderProduct",
                type: "int",
                nullable: false,
                defaultValueSql: "(0)");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_PaymentMethod_fkPaymentMethod_id",
                table: "OrderProduct",
                column: "fkPaymentMethod_id",
                principalTable: "PaymentMethod",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_PaymentMethod_fkPaymentMethod_id",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "stateOrden",
                table: "OrderProduct");

            migrationBuilder.AlterColumn<int>(
                name: "fkPaymentMethod_id",
                table: "OrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_PaymentMethod_fkPaymentMethod_id",
                table: "OrderProduct",
                column: "fkPaymentMethod_id",
                principalTable: "PaymentMethod",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
