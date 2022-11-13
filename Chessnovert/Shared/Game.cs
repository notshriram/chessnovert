using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Shared
{
    public class Game
    {
        public Guid Guid { get; set; }
        public Guid PlayerWhite { get; set; }

        public Guid PlayerBlack { get; set; }

    }
}
