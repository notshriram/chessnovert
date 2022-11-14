using Chessnovert.Shared.Chess;
using Chessnovert.Services;
using Microsoft.AspNetCore.SignalR;

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
                else if (game.PlayerWhite == Guid.Empty)
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

        public async Task Move(Guid gameId, Coordinate source, Coordinate destination)
        {
            try
            {
                var game = gameService.Get(gameId);
                game.Moves.Add(new Shared.Move(source, destination));
                // TODO: source and destination parameters to be replaced with Move Struct
                await Clients.GroupExcept(gameId.ToString(), Context.ConnectionId).SendAsync("Moved", source, destination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
