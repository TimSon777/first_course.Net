using System.Text.Json.Serialization;

namespace BL.Games.DnD.Creatures.Common
{
    public class Characteristics
    {
        [JsonPropertyName("hitPoints")]
        public int HitPoints { get; set; }
                
        [JsonPropertyName("attackModifier")]
        public int AttackModifier { get; init; }
                
        [JsonPropertyName("attackPerRound")]
        public int AttackPerRound { get; init; }
                
        [JsonPropertyName("damage")]
        public int Damage { get; init; }
                
        [JsonPropertyName("countThrows")]
        public int CountThrows { get; init; }
        
        [JsonPropertyName("damageModifier")]
        public int DamageModifier { get; init; }
                
        [JsonPropertyName("weapon")]
        public int Weapon { get; init; }

        [JsonPropertyName("armorClass")]
        public int ArmorClass { get; init; }
        
        [JsonIgnore]
        public bool IsUser { get; set; }
    }
}