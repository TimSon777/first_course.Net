using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DB.Database.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Monster
    {
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [Required]
        [JsonPropertyName("hitPoints")]
        [Range(1, 100)]
        public int HitPoints { get; set; }
                
        [Required]
        [JsonPropertyName("attackModifier")]
        [Range(1, 100)]
        public int AttackModifier { get; set; }
                
        [Required]
        [JsonPropertyName("attackPerRound")]
        [Range(1, 100)]
        public int AttackPerRound { get; set; }
                
        [Required]
        [JsonPropertyName("damage")]
        [Range(1, 100)]
        public int Damage { get; set; }
                
        [Required]
        [JsonPropertyName("countThrows")]
        [Range(1, 100)]
        public int CountThrows { get; set; }
        
        [Required]
        [JsonPropertyName("damageModifier")]
        [Range(1, 100)]
        public int DamageModifier { get; set; }
                
        [Required]
        [JsonPropertyName("weapon")]
        [Range(1, 100)]
        public int Weapon { get; set; }
        
        [Required]
        [JsonPropertyName("armorClass")]
        [Range(1, 100)]
        public int ArmorClass { get; set; }
    }
}