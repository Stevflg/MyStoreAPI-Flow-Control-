using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Identification = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DateBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true),
                    PromotionPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producttype",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "screensui",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Route = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    CustomerId = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    PreInvoicing = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "invoices_ibfk_1",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoices_ibfk_2",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Password = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Locked = table.Column<DateTime>(type: "datetime", nullable: true),
                    Counter = table.Column<int>(type: "int", nullable: true),
                    ChangePassword = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "users_ibfk_1",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    UrlImage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Units = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    Price = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Type = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "products_ibfk_1",
                        column: x => x.Price,
                        principalTable: "prices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "products_ibfk_2",
                        column: x => x.Type,
                        principalTable: "producttype",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rolscreenui",
                columns: table => new
                {
                    ScreenUIID = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    RolID = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ScreenUIID, x.RolID });
                    table.ForeignKey(
                        name: "rolscreenui_ibfk_1",
                        column: x => x.ScreenUIID,
                        principalTable: "screensui",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "rolscreenui_ibfk_2",
                        column: x => x.RolID,
                        principalTable: "roles",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userrol",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    RolID = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.UserID, x.RolID });
                    table.ForeignKey(
                        name: "userrol_ibfk_1",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "userrol_ibfk_2",
                        column: x => x.RolID,
                        principalTable: "roles",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invoicedetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    InvoiceId = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    ProductId = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true),
                    State = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    CreatedBy = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedOn = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "invoicedetail_ibfk_1",
                        column: x => x.InvoiceId,
                        principalTable: "invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "invoicedetail_ibfk_2",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "InvoiceId",
                table: "invoicedetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "ProductId",
                table: "invoicedetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "CustomerId",
                table: "invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "EmployeeId",
                table: "invoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "Price",
                table: "products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "Type",
                table: "products",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "RolID",
                table: "rolscreenui",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "RolID1",
                table: "userrol",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "EmployeeId1",
                table: "users",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoicedetail");

            migrationBuilder.DropTable(
                name: "rolscreenui");

            migrationBuilder.DropTable(
                name: "userrol");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "screensui");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "producttype");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
