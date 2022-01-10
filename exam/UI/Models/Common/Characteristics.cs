using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UI.Models.Common
{
    public class Characteristics
    {
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Очки здоровья")]
        [JsonPropertyName("hitPoints")]
        public int HitPoints { get; init; }
                
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Модификация атаки")]
        [JsonPropertyName("attackModifier")]
        public int AttackModifier { get; init; }
                
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Атака за раунд")]
        [JsonPropertyName("attackPerRound")]
        public int AttackPerRound { get; init; }
                
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Урон")]
        [JsonPropertyName("damage")]
        public int Damage { get; init; }
        
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Количество бросков")]
        [JsonPropertyName("countThrows")]
        public int CountThrows { get; init; }   
        
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Модификация урона")]
        [JsonPropertyName("damageModifier")]
        public int DamageModifier { get; init; }
                
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Урон от оружия")]
        [JsonPropertyName("weapon")]
        public int Weapon { get; init; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Класс армора")]
        [JsonPropertyName("armorClass")]
        public int ArmorClass { get; init; }
    }
}