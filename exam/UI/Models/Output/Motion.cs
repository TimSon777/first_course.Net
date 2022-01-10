using System.Collections.Generic;

namespace UI.Models.Output
{
    public class Motion
    {
        public IEnumerable<Attack> Attacks { get; set; }
        public bool IsUserMotion { get; set; }

    }
}