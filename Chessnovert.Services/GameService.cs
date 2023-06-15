using Chessnovert.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Services
{
    public class GameService
    {
        //public Dictionary<string, int> Games = new();
        public List<Game> Games = new();

        public Game Create(Game game)
        {
            Games.Add(game);
            return Games.Single(g => g.Id == game.Id);
        }

        public Game Get(Guid Id)
        {
            return Games.Single(g => g.Id == Id);
        }

        public IEnumerable<Game> GetAll()
        {
            return Games;
        }

        public Game Update(Game game)
        {
            var queriedGame = Games.Single(g => g.Id == game.Id);
            queriedGame = game;
            return queriedGame;
        }
        public Game Delete(Guid Id)
        {
            var gameToRemove = Games.Single(g => g.Id == Id);
            Games.Remove(gameToRemove);
            return gameToRemove;
        }

    }
}
