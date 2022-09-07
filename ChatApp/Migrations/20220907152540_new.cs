using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_AppUserEntityId",
                table: "ChatRooms");

            migrationBuilder.RenameColumn(
                name: "AppUserEntityId",
                table: "ChatRooms",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_AppUserEntityId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_AppUserId");

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1001,
                column: "DateCreated",
                value: new DateTime(2022, 9, 7, 15, 25, 40, 681, DateTimeKind.Utc).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1002,
                column: "DateCreated",
                value: new DateTime(2022, 9, 7, 15, 25, 40, 681, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_AppUserId",
                table: "ChatRooms",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_AppUserId",
                table: "ChatRooms");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ChatRooms",
                newName: "AppUserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_AppUserId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_AppUserEntityId");

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1001,
                column: "DateCreated",
                value: new DateTime(2022, 9, 7, 14, 25, 54, 563, DateTimeKind.Utc).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1002,
                column: "DateCreated",
                value: new DateTime(2022, 9, 7, 14, 25, 54, 563, DateTimeKind.Utc).AddTicks(1845));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_AppUserEntityId",
                table: "ChatRooms",
                column: "AppUserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
