using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Services
{
    public class GameService
    {
        // gameId, num of players who have joined (max 2)
        public Dictionary<string, int> Games = new();
    }
}
