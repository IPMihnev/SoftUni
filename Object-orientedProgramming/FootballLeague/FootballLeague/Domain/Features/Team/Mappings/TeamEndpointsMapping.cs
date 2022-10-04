using Domain.Database;
using FootballLeague.Domain.Features.Team.Entities;
using FootballLeague.Domain.Features.Team.Requests;
using FootballLeague.ViewStore.Teams;

namespace FootballLeague.Domain.Features.Team.Mappings
{
    public static class TeamEndpointsMapping
    {
        public static void MapTeamEntityEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost(
                "/api/team",
                async (
                    AddOrUpdateTeamRequest request,
                    FootballLeagueContext db,
                    TeamViewStoreUpdater updater) =>
            {
                TeamEntity team = new(request.Name, request.Color);
                db.Teams.Add(team);
                await db.SaveChangesAsync();
                updater.AddTeam(team);
                return Results.Created($"/team/ok", request);
            })
            .WithName("CreateTeam")
            .Produces<AddOrUpdateTeamRequest>(StatusCodes.Status201Created);

            routes.MapGet("/api/team/ranking",
                (TeamViewStore store,
                TeamViewStoreUpdater updater,
                FootballLeagueContext db) =>
            {
                if (store.Values.Any())
                {
                    return Results.Ok(store.Values.OrderByDescending(x => x.Score));
                }
                else if (db.Teams.Any())
                {
                    updater.AddTeams(db.Teams.ToList());
                    return Results.Ok(db.Teams.OrderByDescending(x => x.Score));
                }
                return Results.NotFound();
            })
            .WithName("GetAllTeams")
            .Produces(StatusCodes.Status200OK);

            routes.MapGet("/api/team/{id}",
                (int id,
                TeamViewStore store,
                FootballLeagueContext db,
                TeamViewStoreUpdater updater) =>
                {
                    if (store.ContainsKey(id))
                    {
                        return Results.Ok(store[id]);
                    }
                    else if (db.Teams.Any(x => x.Id == id))
                    {
                        var team = db.Teams.Single(x => x.Id == id);
                        updater.AddTeam(team);
                        return Results.Ok(team);
                    }
                    return Results.NotFound();
                })
            .WithName("GetTeamById")
            .Produces<TeamViewStoreModel>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapPut(
                "/api/team/{id}",
                async (
                    int id,
                    AddOrUpdateTeamRequest request,
                    FootballLeagueContext db,
                    TeamViewStoreUpdater updater) =>
                {
                    var foundModel = await db.Teams.FindAsync(id);

                    if (foundModel is null)
                    {
                        return Results.NotFound();
                    }
                    foundModel.Name = request.Name;
                    foundModel.Color = request.Color;
                    await db.SaveChangesAsync();
                    updater.UpdateTeam(foundModel);
                    return Results.NoContent();
                })
            .WithName("UpdateTeamById")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status204NoContent);


            routes.MapDelete(
                "/api/team/{id}",
                async (
                    int id,
                    FootballLeagueContext db,
                    TeamViewStoreUpdater updater) =>
            {
                if (await db.Teams.FindAsync(id) is TeamEntity teamEntity)
                {
                    db.Teams.Remove(teamEntity);
                    await db.SaveChangesAsync();
                    updater.DeleteTeam(id);
                    return Results.Ok();
                }
                return Results.NotFound();
            })
            .WithName("DeleteTeam")
            .Produces<TeamEntity>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}

