using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSpotterWeb.Migrations
{
    /// <inheritdoc />
    public partial class testfase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Events_EventID",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Events_EventID",
                table: "Reservations",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Events_EventID",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationID",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2024, 10, 7, 19, 40, 23, 417, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2024, 10, 7, 19, 40, 23, 417, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Events_EventID",
                table: "Reservations",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID");
        }
    }
}
