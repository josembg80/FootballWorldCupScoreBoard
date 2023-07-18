using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoard.Model
{
    public class Game
    {
        public Game(Team homeTeam, Team awayTeam)
        {
            Id = Guid.NewGuid();
            LoadDate = DateTime.UtcNow;
            HomeScore = 0;
            AwayScore = 0;
            Finished = false;

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public Guid Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime LoadDate { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

        public bool Finished { get; set; }
    }
}