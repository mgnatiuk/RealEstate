using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations.Postgres.Migrations
{
    public partial class MG_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    OfferType = table.Column<int>(type: "integer", nullable: false),
                    HasProvision = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    AdditionalArea = table.Column<double>(type: "double precision", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    AgreementType = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Rooms = table.Column<int>(type: "integer", nullable: true),
                    BuildingLevel = table.Column<int>(type: "integer", nullable: true),
                    AvailableFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    YearOfBuilding = table.Column<int>(type: "integer", nullable: true),
                    CautionPrice = table.Column<double>(type: "double precision", nullable: true),
                    BuildingType = table.Column<int>(type: "integer", nullable: true),
                    BuildingMaterial = table.Column<int>(type: "integer", nullable: true),
                    HeatingType = table.Column<int>(type: "integer", nullable: true),
                    FinishingType = table.Column<int>(type: "integer", nullable: true),
                    ApartmentLevel = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    AddressNumber = table.Column<string>(type: "text", nullable: true),
                    FlatNumber = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    EstateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EstateId",
                table: "Addresses",
                column: "EstateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Estates");
        }
    }
}
