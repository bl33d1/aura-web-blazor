using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aura_web_api.Data.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artikulli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sasia = table.Column<int>(type: "int", nullable: false),
                    Nj2 = table.Column<int>(type: "int", nullable: false),
                    Qmimi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kamarieri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tavolina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vlera = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NrPorosise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EshteMbyllur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
