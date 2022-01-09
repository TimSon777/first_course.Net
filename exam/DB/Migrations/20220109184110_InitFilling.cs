using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class InitFilling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "HitPoints", "Name", "Weapon" },
                values: new object[,]
                {
                    { 1, 11, 5, 21, 20, 8, 33, "Rhinoceros", 15 },
                    { 2, 18, 2, 14, 10, 3, 45, "Animated armor", 5 },
                    { 3, 12, 3, 2, 1, 3, 2, "Cat", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
