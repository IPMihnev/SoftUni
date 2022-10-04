using FootballLeague.Domain.Features.Match.Entities;
using FootballLeague.Domain.Features.Match.Mappings;
using FootballLeague.Domain.Features.Team.Entities;
using FootballLeague.Domain.Features.Team.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Domain.Database
{
    public class FootballLeagueContext : DbContext
    {
        public FootballLeagueContext(DbContextOptions<FootballLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<MatchEntity> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamEntityMapping());
            modelBuilder.ApplyConfiguration(new MatchEntityMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("FLConnectionString"));
        }
    }
}
