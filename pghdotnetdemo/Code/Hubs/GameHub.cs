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
            game.ID = GameRepository.Games.Count() + 1;

            GameRepository.Games.Add(game);
            Clients.All.AddGame(game);
        }

        public void UpdateGame(int gameID, int homeScore, int awayScore)
        {
            Game game = GameRepository.Games.Where(g => g.ID == gameID).FirstOrDefault();
            game.HomeScore = homeScore;
            game.AwayScore = awayScore;

            Clients.Group(gameID.ToString()).UpdateGame(game);
        }

        public void LockGame(int gameID)
        {
            Game game = GameRepository.Games.Where(g => g.ID == gameID).FirstOrDefault();
            game.GameLocked = true;

            Clients.Others.LockGame(gameID);
        }

        public void UnlockGame(int gameID)
        {
            Game game = GameRepository.Games.Where(g => g.ID == gameID).FirstOrDefault();
            game.GameLocked = false;

            Clients.Others.UnlockGame(gameID);
        }

        public void SubscribeGame(int gameID)
        {
            Groups.Add(Context.ConnectionId, gameID.ToString());

            Game game = GameRepository.Games.Where(g => g.ID == gameID).FirstOrDefault();
            Clients.Caller.UpdateGame(game);
        }

        public void UnsubscribeGame(int gameID)
        {
            Groups.Remove(Context.ConnectionId, gameID.ToString());
        }
    }
}