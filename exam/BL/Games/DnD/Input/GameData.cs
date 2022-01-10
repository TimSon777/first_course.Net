using System.Text.Json.Serialization;
using BL.Games.DnD.Creatures;

namespace BL.Games.DnD.Input
{
    public class GameData
    {
        [JsonPropertyName("character")]
        public Character Character { get; set; }
        
        [JsonPropertyName("monster")]
        public Monster Monster { get; set; }
    }
}