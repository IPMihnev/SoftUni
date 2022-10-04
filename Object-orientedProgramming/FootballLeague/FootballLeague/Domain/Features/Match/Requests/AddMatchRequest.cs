namespace FootballLeague.Domain.Features.Match.Requests
{
    public class AddMatchRequest
    {
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        public DateTime Date { get; set; }
    }
}
