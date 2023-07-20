using FootballWorldCupScoreBoard.Model;
using Model;

namespace FootballWorldCupScoreBoard
{
    public class ScoreBoard
    {
        public Service service = new Service();

        public void StartGame(string homeTeamName, string awayTeamName)
        {
            service.StartGame(homeTeamName, awayTeamName);
        }

        public void FinishGame(string homeTeamName, string awayTeamName)
        {
            service.FinishGame(homeTeamName, awayTeamName);
        }

        public void UpdateScore(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore)
        {
            service.UpdateScore(homeTeamName, homeTeamScore, awayTeamName, awayTeamScore);
        }

        public List<Game> GetSummaryGamesByTotalScore()
        {
            return service.GetSummaryGamesByTotalScore();
        }
    }
}