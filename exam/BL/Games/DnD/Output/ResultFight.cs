using System.Collections.Generic;
using BL.Games.DnD.Creatures;

namespace BL.Games.DnD.Output
{
    public class ResultFight
    {
        public Character Character { get; set; }
        public Monster Monster { get; set; }
        public IEnumerable<Motion> Motions { get; set; }
        public bool IsUserWin { get; set; }
    }
}