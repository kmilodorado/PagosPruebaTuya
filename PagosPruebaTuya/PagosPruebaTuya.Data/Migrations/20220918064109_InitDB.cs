using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagosPruebaTuya.Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false, defaultValueSql: "(0)"),
                    created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('SystemTuyaPagos')"),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    userName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    pass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    city = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    quarter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    streetType = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numberExt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    numberInt = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)"),
                    fkUser_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('SystemTuyaPagos')"),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_User_fkUser_id",
                        column: x => x.fkUser_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    price = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false, defaultValueSql: "(0)"),
                    fkUser_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fkAddress_id = table.Column<int>(type: "int", nullable: false),
                    fkPaymentMethod_id = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('SystemTuyaPagos')"),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Address_fkAddress_id",
                        column: x => x.fkAddress_id,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_PaymentMethod_fkPaymentMethod_id",
                        column: x => x.fkPaymentMethod_id,
                        principalTable: "PaymentMethod",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_User_fkUser_id",
                        column: x => x.fkUser_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DetailOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false, defaultValueSql: "(0)"),
                    fkOrder_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fkProduct_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('SystemTuyaPagos')"),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    lastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetailOrder_OrderProduct_fkOrder_id",
                        column: x => x.fkOrder_id,
                        principalTable: "OrderProduct",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOrder_Product_fkProduct_id",
                        column: x => x.fkProduct_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_fkUser_id",
                table: "Address",
                column: "fkUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrder_fkOrder_id",
                table: "DetailOrder",
                column: "fkOrder_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrder_fkProduct_id",
                table: "DetailOrder",
                column: "fkProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_fkAddress_id",
                table: "OrderProduct",
                column: "fkAddress_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_fkPaymentMethod_id",
                table: "OrderProduct",
                column: "fkPaymentMethod_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_fkUser_id",
                table: "OrderProduct",
                column: "fkUser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailOrder");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
