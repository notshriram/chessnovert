using Chessnovert.Shared.Chess;
using Chessnovert.Services;
using Microsoft.AspNetCore.SignalR;
using Chessnovert.Shared.Chess.Enums;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace Chessnovert.Server.Hubs
{
    public class MatchHub : Hub
    {
        private readonly GameService gameService;

        public MatchHub(GameService gameService)
        {
            this.gameService = gameService;
        }
        public async Task JoinGame(Guid gameId)
        {
            try
            {
                var game = gameService.Get(gameId);
                // TODO: Replace with random selection
                /*
                 if (game.PlayerWhite == Guid.Empty && game.PlayerBlack == Guid.Empty)
                    {
                        // choose randomly 
                        var rnd = new Random(DateTime.Now.Millisecond);
                        int choice = rnd.Next(0, 2);
                        if(choice == 0)
                            game.PlayerWhite = Guid.NewGuid();
                        else
                            game.PlayerBlack = Guid.NewGuid();

                    }
                else 
                 * 
                */
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
                for (int i = move.Color == Color.White ? 2 : 1; i < game.Moves.Count; i+=2)
                {
                    sum += game.Moves[i].At - game.Moves[i - 1].At;
                }
                
                if (sum > game.TimeControl)
                {
                    await Clients.GroupExcept(gameId.ToString(), Context.ConnectionId).SendAsync("TimedOut", color);
                }
                else
                {
                    game.Moves.Add(move);
                    // TODO: source and destination parameters to be replaced with Move Struct
                    int remainingTime = (int)(game.TimeControl - sum).TotalSeconds;
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
