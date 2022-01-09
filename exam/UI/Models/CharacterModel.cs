using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UI.Models.Common;

namespace UI.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CharacterModel : Characteristics
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Никнейм")]
        public string Name { get; init; }
    }
}