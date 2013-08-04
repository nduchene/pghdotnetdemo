using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pghdotnetdemo.Code
{
    public static class GameRepository
    {
        private static Lazy<List<Game>> _games = new Lazy<List<Game>>();

        public static List<Game> Games 
        {
            get
            {
                return _games.Value;
            }
        }
    }
}