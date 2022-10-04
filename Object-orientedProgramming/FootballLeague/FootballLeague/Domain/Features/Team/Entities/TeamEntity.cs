using FootballLeague.Domain.Features.Match.Entities;
using FootballLeague.ViewStore.Teams;

namespace FootballLeague.Domain.Features.Team.Entities
{
    public class TeamEntity
    {
        public TeamEntity(
            string name,
            string color)
        {
            Name = name;
            Color = color;
            Score = 0;
        }

        private TeamEntity()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Score { get; private set; }

        public List<MatchEntity> Matches { get; set; } = new List<MatchEntity>();

        public void AddScore(int points)
            => this.Score += points;

        public void ResetScore()
            => this.Score = 0;

        public TeamViewStoreModel ToTeamViewStoreEntity()
            => new TeamViewStoreModel(
                this.Id,
                this.Name,
                this.Color,
                this.Score);
    }
}
