using System.Collections.Generic;

namespace BL.Games.DnD.Output
{
    public class Motion
    {
        public bool IsUserMotion { get; set; }
        public IEnumerable<Attack> Attacks { get; set; }
    }
}