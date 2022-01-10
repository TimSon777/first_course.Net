﻿// <auto-generated />
using DB.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220110073149_InitAndFilling")]
    partial class InitAndFilling
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DB.Database.Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("integer");

                    b.Property<int>("CountThrows")
                        .HasColumnType("integer");

                    b.Property<int>("Damage")
                        .HasColumnType("integer");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Weapon")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasCheckConstraint("CK_Monsters_ArmorClass_Range", "\"ArmorClass\" >= 1 AND \"ArmorClass\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_AttackModifier_Range", "\"AttackModifier\" >= 1 AND \"AttackModifier\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_AttackPerRound_Range", "\"AttackPerRound\" >= 1 AND \"AttackPerRound\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_CountThrows_Range", "\"CountThrows\" >= 1 AND \"CountThrows\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_Damage_Range", "\"Damage\" >= 1 AND \"Damage\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_DamageModifier_Range", "\"DamageModifier\" >= 1 AND \"DamageModifier\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_HitPoints_Range", "\"HitPoints\" >= 1 AND \"HitPoints\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_Weapon_Range", "\"Weapon\" >= 1 AND \"Weapon\" <= 100");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 11,
                            AttackModifier = 5,
                            AttackPerRound = 21,
                            CountThrows = 2,
                            Damage = 20,
                            DamageModifier = 8,
                            HitPoints = 33,
                            Name = "Rhinoceros",
                            Weapon = 15
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 18,
                            AttackModifier = 2,
                            AttackPerRound = 14,
                            CountThrows = 2,
                            Damage = 10,
                            DamageModifier = 3,
                            HitPoints = 45,
                            Name = "Animated armor",
                            Weapon = 5
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 12,
                            AttackModifier = 3,
                            AttackPerRound = 2,
                            CountThrows = 2,
                            Damage = 1,
                            DamageModifier = 3,
                            HitPoints = 2,
                            Name = "Cat",
                            Weapon = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
