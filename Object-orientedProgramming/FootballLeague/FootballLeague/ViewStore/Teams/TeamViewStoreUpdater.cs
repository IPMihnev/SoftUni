using FootballLeague.Domain.Features.Team.Entities;
using NuGet.Packaging;

namespace FootballLeague.ViewStore.Teams
{
    public class TeamViewStoreUpdater
    {
        private readonly TeamViewStore _store;

        public TeamViewStoreUpdater(TeamViewStore store) => _store = store;

        public void AddTeam(TeamEntity team)
        {
            _store[team.Id] = new(
                team.Id,
                team.Name,
                team.Color,
                team.Score
            );
        }

        public void AddTeams(List<TeamEntity> teams)
        {
            _store.AddRange(teams.Select(x => new KeyValuePair<int, TeamViewStoreModel>(x.Id, x.ToTeamViewStoreEntity())));
        }

        public void UpdateTeam(TeamEntity team)
        {
            var product = _store[team.Id];

            product.Name = team.Name;
            product.Color = team.Color;
            product.Score = team.Score;
        }

        public void DeleteTeam(int id)
            => _store.Remove(id, out _);
    }
}
