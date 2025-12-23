using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalTicket.TicketManagment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderToral = table.Column<int>(type: "int", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreateDate", "CreatedBy", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("7d4e4b6c-2a1f-4f3e-9f8e-3c2b1a0d9e8f"), new DateTime(2025, 12, 22, 13, 57, 42, 145, DateTimeKind.Local).AddTicks(3478), "System", null, null, "Plays" },
                    { new Guid("a1b2c3d4-e5f6-4789-abcd-1234567890ab"), new DateTime(2025, 12, 22, 13, 57, 42, 145, DateTimeKind.Local).AddTicks(3523), "System", null, null, "Conferences" },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(2025, 12, 22, 13, 57, 42, 145, DateTimeKind.Local).AddTicks(3224), "System", null, null, "Concerts" },
                    { new Guid("fe9a5e7d-5d6c-4f3b-8d9e-8e1c2d5c8bce"), new DateTime(2025, 12, 22, 13, 57, 42, 145, DateTimeKind.Local).AddTicks(3429), "System", null, null, "Musicals" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Artist", "CategoryId", "CreateDate", "CreatedBy", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("a1c2e3f4-5678-4b9a-bcde-1234567890ab"), "Nick Sailor", new Guid("fe9a5e7d-5d6c-4f3b-8d9e-8e1c2d5c8bce"), new DateTime(2025, 12, 22, 13, 57, 42, 145, DateTimeKind.Local).AddTicks(3710), "System", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The critics are raving about this new musical production that takes you on an emotional ride through the universe.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical1.png", null, null, "To the Moon and Back", "135" },
                    { new Guid("d28888e9-2ba9-473a-a40f-ef8a7875835c"), "John Egbert", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(2025, 12, 22, 13, 57, 42, 145, DateTimeKind.Local).AddTicks(3601), "System", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already sold over 25 million albums worldwide.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/concert1.png", null, null, "John Egbert Live", "65" },
                    { new Guid("d7b4f2e2-5d3c-4a8c-9a6f-8d9e7c6b5a4f"), "Michael Johnson", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(2025, 12, 22, 13, 57, 42, 145, DateTimeKind.Local).AddTicks(3663), "System", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Johnson doesn't need an introduction either. His 25th album is coming out this fall and we are going to celebrate the launch with a big concert.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/concert2.png", null, null, "The State of Affairs: Michael Live!", "85" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
