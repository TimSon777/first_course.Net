using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UI.Models.Common;

namespace UI.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MonsterModel : Characteristics
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Имя монстра")]
        [JsonPropertyName("name")]
        public string Name { get; init; }
    }
}