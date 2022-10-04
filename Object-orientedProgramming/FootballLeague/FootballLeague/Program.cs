using Domain.Database;
using Microsoft.EntityFrameworkCore;
using FootballLeague.Domain.Features.Team.Mappings;
using FootballLeague.ViewStore.Teams;
using FootballLeague.Domain.Features.Match.Services;
using FootballLeague.Domain.Features.Match.Mappings;
using FootballLeague.ViewStore.Matches;
using System.Text.Json.Serialization;

namespace FootballLeague
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("FLConnectionString");
            builder.Services.AddDbContext<FootballLeagueContext>(x => x.UseSqlServer(connectionString));
            builder.Services.AddSingleton<TeamViewStore>();
            builder.Services.AddTransient<TeamViewStoreUpdater>();
            builder.Services.AddSingleton<MatchViewStore>();
            builder.Services.AddTransient<MatchViewStoreUpdater>();
            builder.Services.AddTransient<ResolveMatchScoreService>();

            builder.Services
                .AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            };

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapTeamEntityEndpoints();
            app.MapMatchEntityEndpoints();

            app.Run();
        }
    }
}