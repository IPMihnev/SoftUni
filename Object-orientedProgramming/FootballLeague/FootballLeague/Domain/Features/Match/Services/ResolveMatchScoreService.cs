using Domain.Database;
using FootballLeague.Domain.Features.Match.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Domain.Features.Match.Services
{
    public class ResolveMatchScoreService
    {
        private readonly FootballLeagueContext _context;

        public ResolveMatchScoreService(FootballLeagueContext context)
        {
            _context = context;
        }

        public async Task Resolve(MatchEntity match)
        {
            var firstTeam = await _context.Teams.SingleAsync(x => x.Id == match.Teams.First().Id);
            var secondTeam = await _context.Teams.SingleAsync(x => x.Id == match.Teams.Last().Id);

            if (match.FirstTeamPoints > match.SecondTeamPoints)
            {
                firstTeam.AddScore(3);
            }
            else if (match.FirstTeamPoints == match.SecondTeamPoints)
            {
                firstTeam.AddScore(1);
                secondTeam.AddScore(1);
            }
            else
            {
                secondTeam.AddScore(3);
            }
            await _context.SaveChangesAsync();
        }
    }
}
