using FootballWorldCupScoreBoard.Model;

namespace Model
{
    public class Service
    {
        public List<Game> Games;
        public List<Team> Teams;

        public Service()
        {
            Games = new List<Game>();
            Teams = new List<Team>();
        }

        public void StartGame(string homeTeamName, string awayTeamName)
        {
            if (GetGame(homeTeamName, awayTeamName) != null)
                throw new Exception(string.Format("Already exists game between \"{0}\" and \"{1}\"", homeTeamName, awayTeamName));

            Team homeTeam = GetTeam(homeTeamName);
            Team awayTeam = GetTeam(awayTeamName);

            Games.Add(new Game(homeTeam, awayTeam));
        }

        public void FinishGame(string homeTeamName, string awayTeamName)
        {
            Game game = GetGame(homeTeamName, awayTeamName);
            if (game == null)
                throw new Exception(string.Format("Not exists game between \"{0}\" and \"{1}\"", homeTeamName, awayTeamName));

            game.Finished = true;
        }

        private Team GetTeam(string teamName)
        {
            Team team = Teams.FirstOrDefault(f => f.Name == teamName);

            if (team == null)
                throw new Exception(string.Format("Not exists Team with name: {0}", teamName));

            return team;
        }

        private Game GetGame(string homeTeamName, string awayTeamName)
        {
            Game game = Games.FirstOrDefault(g => g.HomeTeam.Name == homeTeamName && g.AwayTeam.Name == awayTeamName);

            return game;
        }
    }
}