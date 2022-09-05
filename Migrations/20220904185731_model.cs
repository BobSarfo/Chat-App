using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Migrations
{
    public partial class model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderUserName",
                table: "RoomMessages",
                newName: "SenderUsername");

            migrationBuilder.RenameColumn(
                name: "TimeSent",
                table: "RoomMessages",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "SenderUserName",
                table: "PrivateMessage",
                newName: "SenderUsername");

            migrationBuilder.RenameColumn(
                name: "ReceiverUserName",
                table: "PrivateMessage",
                newName: "ReceiverUsername");

            migrationBuilder.AlterColumn<string>(
                name: "SenderUsername",
                table: "RoomMessages",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "RoomMessages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsStockCode",
                table: "RoomMessages",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "RoomMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 9, 4, 18, 57, 31, 569, DateTimeKind.Utc).AddTicks(4803));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "RoomMessages");

            migrationBuilder.RenameColumn(
                name: "SenderUsername",
                table: "RoomMessages",
                newName: "SenderUserName");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "RoomMessages",
                newName: "TimeSent");

            migrationBuilder.RenameColumn(
                name: "SenderUsername",
                table: "PrivateMessage",
                newName: "SenderUserName");

            migrationBuilder.RenameColumn(
                name: "ReceiverUsername",
                table: "PrivateMessage",
                newName: "ReceiverUserName");

            migrationBuilder.AlterColumn<string>(
                name: "SenderUserName",
                table: "RoomMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "RoomMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IsStockCode",
                table: "RoomMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 9, 4, 16, 5, 51, 116, DateTimeKind.Utc).AddTicks(8099));
        }
    }
}
