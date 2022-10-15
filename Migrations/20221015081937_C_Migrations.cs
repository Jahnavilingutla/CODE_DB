using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODE_DB.Migrations
{
    public partial class C_Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IT_Trainees",
                columns: table => new
                {
                    TraineeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeAge = table.Column<int>(type: "int", nullable: false),
                    TraineeDOJ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraineeDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraineeMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IT_Trainees", x => x.TraineeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IT_Trainees");
        }
    }
}
