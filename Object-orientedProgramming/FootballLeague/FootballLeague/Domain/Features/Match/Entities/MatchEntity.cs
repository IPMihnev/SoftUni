using FootballLeague.Domain.Features.Team.Entities;
using FootballLeague.ViewStore.Matches;

namespace FootballLeague.Domain.Features.Match.Entities
{
    public class MatchEntity
    {
        public MatchEntity(List<TeamEntity> teams, DateTime date)
        {
            this.Teams = teams;
            this.Date = date;
            this.FirstTeamPoints = 0;
            this.SecondTeamPoints = 0;
        }

        private MatchEntity()
        {
        }

        public int Id { get; set; }
        public List<TeamEntity> Teams { get; set; }
        public int FirstTeamPoints { get; set; }
        public int SecondTeamPoints { get; set; }
        public DateTime Date { get; set; }

        public MatchViewStoreModel ToMatchViewStoreEntity()
            => new MatchViewStoreModel(
                this.Teams.First().Id,
                this.Teams.First().Name,
                this.Teams.Last().Id,
                this.Teams.Last().Name,
                this.Date);
    }
}
