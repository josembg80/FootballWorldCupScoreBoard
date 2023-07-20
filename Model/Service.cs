using FootballWorldCupScoreBoard.Model;

namespace Model
{
    public class Service
    {
        private List<Game> Games;
        private List<Team> Teams;

        public Service()
        {
            Games = new List<Game>();
            Teams = new List<Team>();
        }

        public void StartGame(string homeTeamName, string awayTeamName)
        {
            if (GetGame(homeTeamName, awayTeamName, false) != null)
                throw new Exception(string.Format("Already exists game between \"{0}\" and \"{1}\"", homeTeamName, awayTeamName));

            Team homeTeam = GetTeam(homeTeamName);
            Team awayTeam = GetTeam(awayTeamName);

            Games.Add(new Game(homeTeam, awayTeam));
        }

        public void FinishGame(string homeTeamName, string awayTeamName)
        {
            Game game = GetGame(homeTeamName, awayTeamName, true);

            game.Finished = true;
        }

        public void UpdateScore(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore)
        {
            Game game = GetGame(homeTeamName, awayTeamName, true);

            game.HomeScore = homeTeamScore;
            game.AwayScore = awayTeamScore;
        }

        public List<Game> GetSummaryGamesByTotalScore()
        {
            return Games.Where(f => !f.Finished).OrderByDescending(o => o.TotalScore).ThenByDescending(o => o.LoadDate).ToList();
        }

        private Team GetTeam(string teamName)
        {
            if (string.IsNullOrEmpty(teamName))
                throw new Exception("Team name can not be null");

            Team team = Teams.FirstOrDefault(f => f.Name.ToUpper() == teamName.ToUpper());

            if (team == null)
            {
                team = new Team()
                {
                    Id = Guid.NewGuid(),
                    Name = teamName
                };
                Teams.Add(team);
            }

            return team;
        }

        private Game GetGame(string homeTeamName, string awayTeamName, bool throwExceptionWhenGameNull)
        {
            if (string.IsNullOrEmpty(homeTeamName))
                throw new Exception("Home team name can not be null");
            if (string.IsNullOrEmpty(awayTeamName))
                throw new Exception("Away team name can not be null");

            Game game = Games.FirstOrDefault(g => g.HomeTeam.Name.ToUpper() == homeTeamName.ToUpper() && g.AwayTeam.Name.ToUpper() == awayTeamName.ToUpper() && !g.Finished);

            if (throwExceptionWhenGameNull && game == null)
                throw new Exception(string.Format("Not exists game between \"{0}\" and \"{1}\"", homeTeamName, awayTeamName));

            return game;
        }
    }
}