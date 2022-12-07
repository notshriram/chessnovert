using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Shared
{
    public class Opening
    {
        public string ECO { get; set; }
        public string Name { get; set; }
        public string PGN { get; set; }
        public string UCI { get; set; }
        public string EPD { get; set; }
        public Opening(string eco, string name, string pgn, string uci, string epd)
        {
            ECO = eco;
            Name = name;
            PGN = pgn;
            UCI = uci;
            EPD = epd;
        }
        public Opening()
        {

        }

    }
}
