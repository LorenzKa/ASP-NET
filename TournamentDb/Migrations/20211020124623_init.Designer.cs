﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentDb;

namespace TournamentDb.Migrations
{
    [DbContext(typeof(TournamentContext))]
    [Migration("20211020124623_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("TournamentDb.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Player1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Player2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Winner")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TournamentDb.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Firstname = "Violet",
                            Gender = "Female",
                            Lastname = "Landor"
                        },
                        new
                        {
                            Id = 2,
                            Firstname = "Levi",
                            Gender = "Female",
                            Lastname = "Humbatch"
                        },
                        new
                        {
                            Id = 3,
                            Firstname = "Myrtice",
                            Gender = "Female",
                            Lastname = "Weinham"
                        },
                        new
                        {
                            Id = 4,
                            Firstname = "Elaine",
                            Gender = "Female",
                            Lastname = "Rastall"
                        },
                        new
                        {
                            Id = 5,
                            Firstname = "Marc",
                            Gender = "Male",
                            Lastname = "Clashe"
                        },
                        new
                        {
                            Id = 6,
                            Firstname = "Leena",
                            Gender = "Female",
                            Lastname = "Cheetham"
                        },
                        new
                        {
                            Id = 7,
                            Firstname = "Ennis",
                            Gender = "Male",
                            Lastname = "Bottlestone"
                        },
                        new
                        {
                            Id = 8,
                            Firstname = "Lester",
                            Gender = "Female",
                            Lastname = "Palatino"
                        },
                        new
                        {
                            Id = 9,
                            Firstname = "Margareta",
                            Gender = "Male",
                            Lastname = "Feasey"
                        },
                        new
                        {
                            Id = 10,
                            Firstname = "Pavlov",
                            Gender = "Male",
                            Lastname = "Stealfox"
                        },
                        new
                        {
                            Id = 11,
                            Firstname = "Brinna",
                            Gender = "Male",
                            Lastname = "Le feuvre"
                        },
                        new
                        {
                            Id = 12,
                            Firstname = "Karlie",
                            Gender = "Female",
                            Lastname = "Iskow"
                        },
                        new
                        {
                            Id = 13,
                            Firstname = "Albert",
                            Gender = "Male",
                            Lastname = "Syncke"
                        },
                        new
                        {
                            Id = 14,
                            Firstname = "Luella",
                            Gender = "Female",
                            Lastname = "Foat"
                        },
                        new
                        {
                            Id = 15,
                            Firstname = "Curtice",
                            Gender = "Male",
                            Lastname = "Pepper"
                        },
                        new
                        {
                            Id = 16,
                            Firstname = "Kendell",
                            Gender = "Female",
                            Lastname = "Dawber"
                        },
                        new
                        {
                            Id = 17,
                            Firstname = "Imogen",
                            Gender = "Female",
                            Lastname = "MacDuff"
                        },
                        new
                        {
                            Id = 18,
                            Firstname = "Hunfredo",
                            Gender = "Male",
                            Lastname = "Stanyon"
                        },
                        new
                        {
                            Id = 19,
                            Firstname = "Maurizio",
                            Gender = "Female",
                            Lastname = "Tapscott"
                        },
                        new
                        {
                            Id = 20,
                            Firstname = "Norris",
                            Gender = "Male",
                            Lastname = "Demkowicz"
                        },
                        new
                        {
                            Id = 21,
                            Firstname = "Zacharia",
                            Gender = "Male",
                            Lastname = "Brundall"
                        },
                        new
                        {
                            Id = 22,
                            Firstname = "Stephani",
                            Gender = "Female",
                            Lastname = "Beecraft"
                        },
                        new
                        {
                            Id = 23,
                            Firstname = "Mervin",
                            Gender = "Male",
                            Lastname = "Sondon"
                        },
                        new
                        {
                            Id = 24,
                            Firstname = "Leena",
                            Gender = "Female",
                            Lastname = "Divisek"
                        },
                        new
                        {
                            Id = 25,
                            Firstname = "Goran",
                            Gender = "Female",
                            Lastname = "Henric"
                        },
                        new
                        {
                            Id = 26,
                            Firstname = "Othilie",
                            Gender = "Female",
                            Lastname = "Knight"
                        },
                        new
                        {
                            Id = 27,
                            Firstname = "Morena",
                            Gender = "Male",
                            Lastname = "Mault"
                        },
                        new
                        {
                            Id = 28,
                            Firstname = "Corina",
                            Gender = "Male",
                            Lastname = "Simmens"
                        },
                        new
                        {
                            Id = 29,
                            Firstname = "Roanna",
                            Gender = "Male",
                            Lastname = "Caulfield"
                        },
                        new
                        {
                            Id = 30,
                            Firstname = "Berenice",
                            Gender = "Female",
                            Lastname = "Sturzaker"
                        },
                        new
                        {
                            Id = 31,
                            Firstname = "Raynard",
                            Gender = "Male",
                            Lastname = "Leport"
                        },
                        new
                        {
                            Id = 32,
                            Firstname = "Xerxes",
                            Gender = "Male",
                            Lastname = "Sully"
                        });
                });

            modelBuilder.Entity("TournamentDb.Match", b =>
                {
                    b.HasOne("TournamentDb.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id");

                    b.HasOne("TournamentDb.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");

                    b.Navigation("Player1");

                    b.Navigation("Player2");
                });
#pragma warning restore 612, 618
        }
    }
}
