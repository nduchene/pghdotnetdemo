using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace pghdotnetdemo.Code.Hubs
{
    public class GameHub : Hub
    {
        public void AddGame(string homeTeam, string awayTeam)
        {
            Game game = new Game();
            game.HomeTeam = homeTeam;
            game.AwayTeam = awayTeam;

            GameRepository.Games.Add(game);
            Clients.All.AddGame(game);
        }

        public void UpdateGame(int gameID, int homeScore, int awayScore)
        {
            Game game = GameRepository.Games.Where(g => g.ID == gameID).FirstOrDefault();
            game.HomeScore = homeScore;
            game.AwayScore = awayScore;

            Clients.All.UpdateGame(game);
        }
    }
}