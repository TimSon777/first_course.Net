using System.Text.Json.Serialization;
using BL.Games.DnD.Creatures.Common;

namespace BL.Games.DnD.Creatures
{
    public class Monster : Characteristics
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }
    }
}