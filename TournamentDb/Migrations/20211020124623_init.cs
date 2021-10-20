using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentDb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoundNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Player1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Player2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Winner = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 1, "Violet", "Female", "Landor" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 30, "Berenice", "Female", "Sturzaker" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 29, "Roanna", "Male", "Caulfield" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 28, "Corina", "Male", "Simmens" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 27, "Morena", "Male", "Mault" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 26, "Othilie", "Female", "Knight" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 25, "Goran", "Female", "Henric" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 24, "Leena", "Female", "Divisek" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 23, "Mervin", "Male", "Sondon" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 22, "Stephani", "Female", "Beecraft" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 21, "Zacharia", "Male", "Brundall" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 20, "Norris", "Male", "Demkowicz" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 19, "Maurizio", "Female", "Tapscott" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 18, "Hunfredo", "Male", "Stanyon" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 17, "Imogen", "Female", "MacDuff" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 16, "Kendell", "Female", "Dawber" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 15, "Curtice", "Male", "Pepper" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 14, "Luella", "Female", "Foat" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 13, "Albert", "Male", "Syncke" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 12, "Karlie", "Female", "Iskow" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 11, "Brinna", "Male", "Le feuvre" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 10, "Pavlov", "Male", "Stealfox" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 9, "Margareta", "Male", "Feasey" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 8, "Lester", "Female", "Palatino" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 7, "Ennis", "Male", "Bottlestone" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 6, "Leena", "Female", "Cheetham" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 5, "Marc", "Male", "Clashe" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 4, "Elaine", "Female", "Rastall" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 3, "Myrtice", "Female", "Weinham" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 2, "Levi", "Female", "Humbatch" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 31, "Raynard", "Male", "Leport" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Firstname", "Gender", "Lastname" },
                values: new object[] { 32, "Xerxes", "Male", "Sully" });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1Id",
                table: "Matches",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2Id",
                table: "Matches",
                column: "Player2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
