using System.Collections.Concurrent;

namespace FootballLeague.ViewStore.Teams
{
    public class TeamViewStore : ConcurrentDictionary<int, TeamViewStoreModel>
    {
    }
}
