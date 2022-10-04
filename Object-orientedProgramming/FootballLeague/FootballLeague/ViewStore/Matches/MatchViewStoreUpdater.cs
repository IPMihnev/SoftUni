using FootballLeague.Domain.Features.Match.Entities;
using NuGet.Packaging;

namespace FootballLeague.ViewStore.Matches
{
    public class MatchViewStoreUpdater
    {
        private readonly MatchViewStore _store;

        public MatchViewStoreUpdater(MatchViewStore store) => _store = store;

        public void AddMatch(MatchEntity match)
        {
            _store[match.Id] = new(
               match.Teams.First().Id,
               match.Teams.First().Name,
               match.Teams.Last().Id,
               match.Teams.Last().Name,
               match.Date
           );
        }

        public void AddMatches(List<MatchEntity> matches)
        {
            _store.AddRange(matches.Select(x => new KeyValuePair<int, MatchViewStoreModel>(x.Id, x.ToMatchViewStoreEntity())));
        }

        public void UpdateMatchScore(
            int id,
            int firstTeamPoints,
            int secondTeamPoints)
        {
            _store[id].FirstTeamPoints = firstTeamPoints;
            _store[id].SecondTeamPoints = secondTeamPoints;
        }
    }
}
