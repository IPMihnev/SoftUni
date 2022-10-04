using FootballLeague.Domain.Features.Team.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Domain.Features.Team.Mappings
{
    public class TeamEntityMapping : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.ToTable("teams");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.Color)
                .HasColumnName("color");

            builder.Property(x => x.Score)
                .HasColumnName("score");
        }
    }
}
