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
            if (gameService.Games.ContainsKey(gameId.ToString()))
            {
                if (gameService.Games[gameId.ToString()] < 2)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, gameId.ToString());
                    await Clients.GroupExcept(gameId.ToString(), Context.ConnectionId).SendAsync("GameJoined");
                    // Add player count to the game dict entry
                    gameService.Games[gameId.ToString()]++;
                }
            }
        }

        public async Task Move(Guid gameId, Coordinate source, Coordinate destination)
        {
            await Clients.GroupExcept(gameId.ToString(), Context.ConnectionId).SendAsync("Moved",source,destination);
        }
    }
}
