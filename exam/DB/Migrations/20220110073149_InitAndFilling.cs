using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DB.Migrations
{
    public partial class InitAndFilling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    AttackModifier = table.Column<int>(type: "integer", nullable: false),
                    AttackPerRound = table.Column<int>(type: "integer", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    CountThrows = table.Column<int>(type: "integer", nullable: false),
                    DamageModifier = table.Column<int>(type: "integer", nullable: false),
                    Weapon = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.CheckConstraint("CK_Monsters_ArmorClass_Range", "\"ArmorClass\" >= 1 AND \"ArmorClass\" <= 100");
                    table.CheckConstraint("CK_Monsters_AttackModifier_Range", "\"AttackModifier\" >= 1 AND \"AttackModifier\" <= 100");
                    table.CheckConstraint("CK_Monsters_AttackPerRound_Range", "\"AttackPerRound\" >= 1 AND \"AttackPerRound\" <= 100");
                    table.CheckConstraint("CK_Monsters_CountThrows_Range", "\"CountThrows\" >= 1 AND \"CountThrows\" <= 100");
                    table.CheckConstraint("CK_Monsters_Damage_Range", "\"Damage\" >= 1 AND \"Damage\" <= 100");
                    table.CheckConstraint("CK_Monsters_DamageModifier_Range", "\"DamageModifier\" >= 1 AND \"DamageModifier\" <= 100");
                    table.CheckConstraint("CK_Monsters_HitPoints_Range", "\"HitPoints\" >= 1 AND \"HitPoints\" <= 100");
                    table.CheckConstraint("CK_Monsters_Weapon_Range", "\"Weapon\" >= 1 AND \"Weapon\" <= 100");
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttackPerRound", "CountThrows", "Damage", "DamageModifier", "HitPoints", "Name", "Weapon" },
                values: new object[,]
                {
                    { 1, 11, 5, 21, 2, 20, 8, 33, "Rhinoceros", 15 },
                    { 2, 18, 2, 14, 2, 10, 3, 45, "Animated armor", 5 },
                    { 3, 12, 3, 2, 2, 1, 3, 2, "Cat", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
