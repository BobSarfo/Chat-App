using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Migrations
{
    public partial class appUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_UserId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_AspNetUsers_UserId",
                table: "PrivateMessage");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PrivateMessage",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateMessage_UserId",
                table: "PrivateMessage",
                newName: "IX_PrivateMessage_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ChatRooms",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_UserId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_AppUserId");

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1001,
                column: "DateCreated",
                value: new DateTime(2022, 9, 6, 15, 11, 37, 524, DateTimeKind.Utc).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1002,
                column: "DateCreated",
                value: new DateTime(2022, 9, 6, 15, 11, 37, 524, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_AppUserId",
                table: "ChatRooms",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_AspNetUsers_AppUserId",
                table: "PrivateMessage",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_AppUserId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_AspNetUsers_AppUserId",
                table: "PrivateMessage");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "PrivateMessage",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateMessage_AppUserId",
                table: "PrivateMessage",
                newName: "IX_PrivateMessage_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ChatRooms",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_AppUserId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_UserId");

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1001,
                column: "DateCreated",
                value: new DateTime(2022, 9, 6, 13, 55, 47, 599, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1002,
                column: "DateCreated",
                value: new DateTime(2022, 9, 6, 13, 55, 47, 599, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_UserId",
                table: "ChatRooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_AspNetUsers_UserId",
                table: "PrivateMessage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
