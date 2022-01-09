using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class HasCheckConstrints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_ArmorClass_Range",
                table: "Monsters",
                sql: "\"ArmorClass\" >= 1 AND \"ArmorClass\" <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_AttackModifier_Range",
                table: "Monsters",
                sql: "\"AttackModifier\" >= 1 AND \"AttackModifier\" <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_AttackPerRound_Range",
                table: "Monsters",
                sql: "\"AttackPerRound\" >= 1 AND \"AttackPerRound\" <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_Damage_Range",
                table: "Monsters",
                sql: "\"Damage\" >= 1 AND \"Damage\" <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_DamageModifier_Range",
                table: "Monsters",
                sql: "\"DamageModifier\" >= 1 AND \"DamageModifier\" <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_HitPoints_Range",
                table: "Monsters",
                sql: "\"HitPoints\" >= 1 AND \"HitPoints\" <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Monsters_Weapon_Range",
                table: "Monsters",
                sql: "\"Weapon\" >= 1 AND \"Weapon\" <= 100");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_ArmorClass_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_AttackModifier_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_AttackPerRound_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_Damage_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_DamageModifier_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_HitPoints_Range",
                table: "Monsters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Monsters_Weapon_Range",
                table: "Monsters");
        }
    }
}
