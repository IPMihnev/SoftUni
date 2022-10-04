using FootballLeague.Domain.Features.Match.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Domain.Features.Match.Mappings
{
    public class MatchEntityMapping : IEntityTypeConfiguration<MatchEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity> builder)
        {
            builder.ToTable("match");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.HasMany(x => x.Teams)
                .WithMany(x => x.Matches);


            builder.Property(x => x.FirstTeamPoints)
                .HasColumnName("first_team_points");

            builder.Property(x => x.SecondTeamPoints)
                .HasColumnName("second_team_points");

            builder.Property(x => x.Date)
                .HasColumnName("date");
        }
    }
}
