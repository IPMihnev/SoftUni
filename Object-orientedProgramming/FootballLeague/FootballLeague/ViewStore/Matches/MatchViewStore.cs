using FootballLeague.ViewStore.Teams;
using System.Collections.Concurrent;

namespace FootballLeague.ViewStore.Matches
{
    public class MatchViewStore : ConcurrentDictionary<int, MatchViewStoreModel>
    {
    }
}
