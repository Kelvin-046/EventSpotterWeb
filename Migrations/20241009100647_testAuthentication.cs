using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventSpotterWeb.Migrations
{
    /// <inheritdoc />
    public partial class testAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "johnvanhetkamp@example.com", "password123", "Organizer", "johnvanhetkamp" },
                    { 2, "sarahpieters@example.com", "password456", "Participant", "sarahpieters" }
                });

            migrationBuilder.UpdateData(
                table: "Organizers",
                keyColumn: "OrganizerID",
                keyValue: 1,
                column: "AccountID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "ParticipantID",
                keyValue: 1,
                column: "AccountID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 10, 9, 12, 6, 46, 852, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2024, 10, 9, 12, 6, 46, 852, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.CreateIndex(
                name: "IX_Participants_AccountID",
                table: "Participants",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_AccountID",
                table: "Organizers",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Account_AccountID",
                table: "Organizers",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Account_AccountID",
                table: "Participants",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Account_AccountID",
                table: "Organizers");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Account_AccountID",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Participants_AccountID",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_AccountID",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Organizers");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 10, 9, 10, 17, 59, 785, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2024, 10, 9, 10, 17, 59, 785, DateTimeKind.Local).AddTicks(9801));
        }
    }
}
