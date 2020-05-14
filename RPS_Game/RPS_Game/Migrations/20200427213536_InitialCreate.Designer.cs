﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPS_Game;

namespace RPS_Game.Migrations
{
    [DbContext(typeof(RPS_DbContext))]
    [Migration("20200427213536_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("RPS_Game.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Player1playerID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Player2playerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId");

                    b.HasIndex("Player1playerID");

                    b.HasIndex("Player2playerID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("RPS_Game.Player", b =>
                {
                    b.Property<int>("playerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nameAccess")
                        .HasColumnType("TEXT");

                    b.Property<int>("winAccess")
                        .HasColumnType("INTEGER");

                    b.HasKey("playerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RPS_Game.Round", b =>
                {
                    b.Property<int>("roundID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WinnerplayerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("p1Choice")
                        .HasColumnType("TEXT");

                    b.Property<string>("p2Choice")
                        .HasColumnType("TEXT");

                    b.HasKey("roundID");

                    b.HasIndex("WinnerplayerID");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("RPS_Game.Game", b =>
                {
                    b.HasOne("RPS_Game.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1playerID");

                    b.HasOne("RPS_Game.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2playerID");
                });

            modelBuilder.Entity("RPS_Game.Round", b =>
                {
                    b.HasOne("RPS_Game.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerplayerID");
                });
#pragma warning restore 612, 618
        }
    }
}
