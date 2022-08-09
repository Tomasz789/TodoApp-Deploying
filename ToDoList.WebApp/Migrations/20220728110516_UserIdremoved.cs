using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.WebApp.Migrations
{
    public partial class UserIdremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_IdentityUser_UserId",
                table: "TodoLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TodoLists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_IdentityUser_UserId",
                table: "TodoLists",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_IdentityUser_UserId",
                table: "TodoLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TodoLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_IdentityUser_UserId",
                table: "TodoLists",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
