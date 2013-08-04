using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pghdotnetdemo.Code
{
    public class Game
    {
        public int ID { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public Game()
        {
            this.HomeScore = 0;
            this.AwayScore = 0;
        }
    }
}