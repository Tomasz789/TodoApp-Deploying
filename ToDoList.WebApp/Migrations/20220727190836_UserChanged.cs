using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.WebApp.Migrations
{
    public partial class UserChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_User_UserId",
                table: "TodoLists");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_IdentityUser_UserId",
                table: "TodoLists",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_IdentityUser_UserId",
                table: "TodoLists");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "Email", "Password", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("bfd363c6-ab4b-4346-8125-71d339d5a67a"), new DateTime(2022, 7, 27, 5, 54, 22, 464, DateTimeKind.Local).AddTicks(4566), "user1@gmail.com", "aaabb1C#", new DateTime(2022, 7, 27, 5, 54, 22, 466, DateTimeKind.Local).AddTicks(7638), "Firstuser1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "Email", "Password", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("306e112e-02b7-4fd1-8113-ae0c4f716869"), new DateTime(2022, 7, 27, 5, 54, 22, 466, DateTimeKind.Local).AddTicks(8463), "userno2@wp.pl", "bbbAFF##C1", new DateTime(2022, 7, 27, 5, 54, 22, 466, DateTimeKind.Local).AddTicks(8478), "SecondUser22" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "Email", "Password", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("09038191-1a4d-4014-810b-62718049a84e"), new DateTime(2022, 7, 27, 5, 54, 22, 466, DateTimeKind.Local).AddTicks(8768), "testUser3@gmail.com", "test#PassworD!", new DateTime(2022, 7, 27, 5, 54, 22, 466, DateTimeKind.Local).AddTicks(8774), "thirdtestUser3" });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "CreatedDate", "Description", "Title", "Updated", "UserId" },
                values: new object[] { 1, new DateTime(2022, 7, 27, 5, 54, 22, 467, DateTimeKind.Local).AddTicks(9511), "test list", "My list", new DateTime(2022, 7, 27, 5, 54, 22, 467, DateTimeKind.Local).AddTicks(9709), new Guid("bfd363c6-ab4b-4346-8125-71d339d5a67a") });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "CreatedDate", "Description", "Title", "Updated", "UserId" },
                values: new object[] { 2, new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(200), "test list", "My list2", new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(214), new Guid("bfd363c6-ab4b-4346-8125-71d339d5a67a") });

            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "CreatedDate", "Description", "Title", "Updated", "UserId" },
                values: new object[] { 3, new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(236), "test list", "My list 3", new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(239), new Guid("306e112e-02b7-4fd1-8113-ae0c4f716869") });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "EndDate", "Priority", "Status", "TaskListId", "Title", "Updated" },
                values: new object[] { 1, new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(2831), "test", new DateTime(2022, 7, 27, 6, 54, 22, 468, DateTimeKind.Local).AddTicks(453), 0, 0, 1, "Buy milk", new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(2982) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "EndDate", "Priority", "Status", "TaskListId", "Title", "Updated" },
                values: new object[] { 3, new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(3549), "test", new DateTime(2022, 7, 27, 6, 54, 22, 468, DateTimeKind.Local).AddTicks(3542), 2, 0, 1, "Do nothing", new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(3552) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "EndDate", "Priority", "Status", "TaskListId", "Title", "Updated" },
                values: new object[] { 2, new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(3513), "test", new DateTime(2022, 7, 27, 6, 54, 22, 468, DateTimeKind.Local).AddTicks(3454), 1, 0, 2, "Buy coffee", new DateTime(2022, 7, 27, 5, 54, 22, 468, DateTimeKind.Local).AddTicks(3520) });

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_User_UserId",
                table: "TodoLists",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
