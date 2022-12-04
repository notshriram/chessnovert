using Chessnovert.Services;
using Chessnovert.Shared;
using Chessnovert.Shared.Chess;
using Chessnovert.Shared.Chess.Enums;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

namespace Chessnovert.Server.Hubs
{
    public class MatchHub : Hub
    {
        private readonly GameService gameService;
        private readonly OpeningBookService openingBookService;

        public MatchHub(GameService gameService, OpeningBookService openingBookService)
        {
            this.gameService = gameService;
            this.openingBookService = openingBookService;
        }
        public async Task JoinGame(Guid gameId)
        {
            try
            {
                var game = gameService.Get(gameId);
                // TODO: Replace with random selection
                // TODO UPDATED: Choose randomly from Client Side
                if (game.PlayerWhite == Guid.Empty)
                {
                    game.PlayerWhite = Guid.NewGuid();
                }
                else if (game.PlayerBlack == Guid.Empty)
                {
                    game.PlayerBlack = Guid.NewGuid();
                }

                await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());
                await Clients.GroupExcept(gameId.ToString(), Context.ConnectionId).SendAsync("GameJoined");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task Move(Guid gameId, Coordinate source, Coordinate destination, Color color)
        {
            try
            {
                var game = gameService.Get(gameId);
                var move = new Shared.Move(source, destination, color);
                // Aggregate the difference between move.At and prevMove.At
                TimeSpan sum = game.Moves.IsNullOrEmpty() ? TimeSpan.Zero : move.At - game.Moves.Last().At;
                for (int i = move.Color == Color.White ? 2 : 1; i < game.Moves.Count; i += 2)
                {
                    sum += game.Moves[i].At - game.Moves[i - 1].At;
                }

                if (sum > game.TimeControl)
                {
                    await Clients.Group(gameId.ToString()).SendAsync("TimedOut", color);
                }
                else
                {
                    game.Moves.Add(move);

                    // search for move in opening database
                    // TODO: Build the string in the class itself (DRY principle)

                    if (game.UCIstring.IsNullOrEmpty())
                        game.UCIstring = move.Source.ToString().ToLower() + move.Destination.ToString().ToLower();
                    else
                        game.UCIstring += " " + move.Source.ToString().ToLower() + move.Destination.ToString().ToLower();
                    
                    //remove trailing spaces
                    Opening? opening = openingBookService.GetFromUCI(game.UCIstring.Trim());
                    if (opening != null)
                    {
                        game.Opening = opening;
                        await Clients.Group(gameId.ToString()).SendAsync("Opening", opening);
                    }
                    // TODO: source and destination parameters to be replaced with Move Class
                    TimeSpan remainingTime = game.TimeControl - sum;
                    await Clients.Client(Context.ConnectionId).SendAsync("Synchronize", remainingTime);
                    await Clients.GroupExcept(gameId.ToString(), Context.ConnectionId).SendAsync("Moved", source, destination, remainingTime);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
