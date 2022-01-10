using System.Collections.Generic;
using System.Text.Json.Serialization;
using UI.Pages;

namespace UI.Models.Output
{
    public class ResultFight
    {
        [JsonPropertyName("character")]
        public CharacterModel Character { get; set; }
        
        [JsonPropertyName("monster")]
        public MonsterModel Monster { get; set; }
        
        [JsonPropertyName("motions")]
        public IEnumerable<Motion> Motions { get; set; }
        
        [JsonPropertyName("isUserWin")]
        public bool IsUserWin { get; set; }
    }
}