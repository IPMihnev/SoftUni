namespace FootballLeague.ViewStore.Matches
{
    public class MatchViewStoreModel
    {
        public MatchViewStoreModel(
            int firstTeamId,
            string firstTeam,
            int secondTeamId,
            string secondTeam,
            DateTime date)
        {
            this.FirstTeamId = firstTeamId;
            this.FirstTeam = firstTeam;
            this.SecondTeamId = secondTeamId;
            this.SecondTeam = secondTeam;
            this.Date = date;
            this.FirstTeamPoints = 0;
            this.SecondTeamPoints = 0;
        }
        public int FirstTeamId { get; set; }
        public string FirstTeam { get; set; }
        public int FirstTeamPoints { get; set; }
        public int SecondTeamId { get; set; }
        public string SecondTeam { get; set; }
        public int SecondTeamPoints { get; set; }
        public DateTime Date { get; set; }
    }
}
