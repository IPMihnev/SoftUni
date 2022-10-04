﻿// <auto-generated />
using System;
using Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballLeague.Domain.Database.Migrations
{
    [DbContext(typeof(FootballLeagueContext))]
    [Migration("20220930132635_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FootballLeague.Domain.Features.Match.Entities.MatchEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<int>("FirstTeamPoints")
                        .HasColumnType("int")
                        .HasColumnName("first_team_points");

                    b.Property<int>("SecondTeamPoints")
                        .HasColumnType("int")
                        .HasColumnName("second_team_points");

                    b.HasKey("Id");

                    b.ToTable("match", (string)null);
                });

            modelBuilder.Entity("FootballLeague.Domain.Features.Team.Entities.TeamEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("color");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("score");

                    b.HasKey("Id");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("MatchEntityTeamEntity", b =>
                {
                    b.Property<int>("MatchesId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("MatchesId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("MatchEntityTeamEntity");
                });

            modelBuilder.Entity("MatchEntityTeamEntity", b =>
                {
                    b.HasOne("FootballLeague.Domain.Features.Match.Entities.MatchEntity", null)
                        .WithMany()
                        .HasForeignKey("MatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballLeague.Domain.Features.Team.Entities.TeamEntity", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
