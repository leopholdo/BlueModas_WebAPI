using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlueModas_WebAPI.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabClient",
                columns: table => new
                {
                    tclID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tclName = table.Column<string>(type: "text", nullable: true),
                    tclEmail = table.Column<string>(type: "text", nullable: true),
                    tclPhone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabClient", x => x.tclID);
                });

            migrationBuilder.CreateTable(
                name: "TabOrder",
                columns: table => new
                {
                    torID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tortclID = table.Column<int>(type: "integer", nullable: false),
                    torDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabOrder", x => x.torID);
                });

            migrationBuilder.CreateTable(
                name: "TabProduct",
                columns: table => new
                {
                    tprID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tprName = table.Column<string>(type: "text", nullable: true),
                    tprPrice = table.Column<double>(type: "double precision", nullable: false),
                    tprImage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabProduct", x => x.tprID);
                });

            migrationBuilder.CreateTable(
                name: "TabProductBasket",
                columns: table => new
                {
                    tpbID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tpbtprID = table.Column<int>(type: "integer", nullable: false),
                    tpbtorID = table.Column<int>(type: "integer", nullable: false),
                    tpbQuantity = table.Column<int>(type: "integer", nullable: false),
                    tpbPriceUnity = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabProductBasket", x => x.tpbID);
                    table.ForeignKey(
                        name: "FK_TabProductBasket_TabProduct_tpbtprID",
                        column: x => x.tpbtprID,
                        principalTable: "TabProduct",
                        principalColumn: "tprID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabClient_tclEmail",
                table: "TabClient",
                column: "tclEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TabProductBasket_tpbtprID",
                table: "TabProductBasket",
                column: "tpbtprID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabClient");

            migrationBuilder.DropTable(
                name: "TabOrder");

            migrationBuilder.DropTable(
                name: "TabProductBasket");

            migrationBuilder.DropTable(
                name: "TabProduct");
        }
    }
}
