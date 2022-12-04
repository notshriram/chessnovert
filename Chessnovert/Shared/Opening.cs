using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Shared
{
    public class Opening
    {
        public int Id { get; set; }
        public string ECO { get; set; }
        public string Name { get; set; }
        public string PGN { get; set; }
        public string UCI { get; set; }
        public string EPD { get; set; }
        public Opening(int id, string eco, string name, string pgn, string uci, string epd)
        {
            Id = id;
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
