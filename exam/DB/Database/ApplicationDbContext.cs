using DB.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Monster> Monsters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseValidationCheckConstraints();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var monster1 = new Monster
            {
                Id = 1,
                Name = "Rhinoceros",
                HitPoints = 33,
                AttackModifier = 5,
                AttackPerRound = 21,
                Damage = 20,
                CountThrows = 2,
                DamageModifier = 8,
                Weapon = 15,
                ArmorClass = 11
            };

            var monster2 = new Monster
            {
                Id = 2,
                Name = "Animated armor",
                HitPoints = 45,
                AttackModifier = 2,
                AttackPerRound = 14,
                Damage = 10,
                CountThrows = 2,
                DamageModifier = 3,
                Weapon = 5,
                ArmorClass = 18
            };

            var monster3 = new Monster
            {
                Id = 3,
                Name = "Cat",
                HitPoints = 2,
                AttackModifier = 3,
                AttackPerRound = 2,
                Damage = 1,
                CountThrows = 2,
                DamageModifier = 3,
                Weapon = 3,
                ArmorClass = 12
            };

            modelBuilder.Entity<Monster>().HasData(monster1, monster2, monster3);
            base.OnModelCreating(modelBuilder);
        }
    }
}