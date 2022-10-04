using Domain.Database;
using FootballLeague.Domain.Features.Match.Requests;
using FootballLeague.Domain.Features.Match.Entities;
using FootballLeague.ViewStore.Matches;
using FootballLeague.Domain.Features.Match.Services;
using Microsoft.EntityFrameworkCore;
using FootballLeague.Domain.Features.Team.Entities;

namespace FootballLeague.Domain.Features.Match.Mappings
{
    public static class MatchEndpointsMapping
    {
        public static void MapMatchEntityEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost(
                "/api/match",
                async (
                    AddMatchRequest request,
                    FootballLeagueContext db,
                    MatchViewStoreUpdater updater) =>
            {
                var firstTeam = await db.Teams.SingleOrDefaultAsync(x => x.Id == request.FirstTeamId);
                var secondTeam = await db.Teams.SingleOrDefaultAsync(x => x.Id == request.SecondTeamId);
                if (firstTeam == null || secondTeam == null)
                {
                    return Results.NotFound();
                }
                var teams = new List<TeamEntity>();
                teams.Add(firstTeam);
                teams.Add(secondTeam);
                MatchEntity match = new(teams, request.Date);
                db.Matches.Add(match);
                await db.SaveChangesAsync();
                var matchNew = await db.Matches.Include(x => x.Teams).SingleAsync(x => x.Id == match.Id);
                updater.AddMatch(matchNew);
                return Results.Created($"/match/ok", request);
            })
            .WithName("CreateMatch")
            .Produces<AddMatchRequest>(StatusCodes.Status201Created);

            routes.MapGet(
                "/api/match",
                (MatchViewStore store,
                    FootballLeagueContext db,
                    MatchViewStoreUpdater updater) =>
                {
                    if (store.Any())
                    {
                        return Results.Ok(store.Values.Where(x => x.Date <= DateTime.UtcNow));
                    }
                    else if (db.Matches.Any())
                    {
                        updater.AddMatches(db.Matches.Include(x => x.Teams).ToList());
                        return Results.Ok(db.Matches
                            .Where(x => x.Date <= DateTime.UtcNow)
                            .Select(x => x.ToMatchViewStoreEntity()));
                    }
                    return Results.NotFound();
                })
            .WithName("GetAllMatches")
            .Produces<List<MatchViewStoreModel>>(StatusCodes.Status200OK);

            routes.MapGet("/api/match/{id}",
            (int id,
                MatchViewStore store,
                MatchViewStoreUpdater updater,
                FootballLeagueContext db) =>
                {
                    if (store.ContainsKey(id) && store[id].Date <= DateTime.UtcNow)
                    {
                        return Results.Ok(store[id]);
                    }
                    else if (db.Matches.Any(x => x.Id == id && x.Date <= DateTime.UtcNow))
                    {
                        var match = db.Matches.Include(x => x.Teams).Single(x => x.Id == id && x.Date <= DateTime.UtcNow);
                        updater.AddMatch(match);
                        return Results.Ok(match);
                    }
                    return Results.NotFound();
                })
            .WithName("GetMatchById")
            .Produces<MatchViewStoreModel>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapPut(
                "/api/match/{id}/score",
                async (
                    int id,
                    UpdateMatchRequest request,
                    FootballLeagueContext db,
                    MatchViewStoreUpdater updater,
                    ResolveMatchScoreService matchService) =>
                {
                    var match = await db.Matches.Include(x => x.Teams).SingleOrDefaultAsync(x => x.Id == id);
                    if (match is null)
                    {
                        return Results.NotFound();
                    }
                    match.FirstTeamPoints = request.FirstTeamPoints;
                    match.SecondTeamPoints = request.SecondTeamPoints;
                    await db.SaveChangesAsync();
                    await matchService.Resolve(match);
                    updater.UpdateMatchScore(
                        id,
                        match.FirstTeamPoints,
                        match.SecondTeamPoints);
                    return Results.Ok(match.ToMatchViewStoreEntity());
                })
            .WithName("UpdateMatchScoreById")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status204NoContent);
        }
    }
}

