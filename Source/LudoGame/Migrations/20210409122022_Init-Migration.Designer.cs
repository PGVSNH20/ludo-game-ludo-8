﻿// <auto-generated />
using System;
using LudoGame.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LudoGame.Migrations
{
    [DbContext(typeof(LudoDbContext))]
    [Migration("20210409122022_Init-Migration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("LudoGame.Board", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("GameEnded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("GameStarted")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("LudoGame.Move", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BoardID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiceValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PieceID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("BoardID");

                    b.ToTable("Move");
                });

            modelBuilder.Entity("LudoGame.Piece", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentPositionID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EnterFinalTrackPositionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoveDirectionX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoveDirectionY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Moves")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NestPositionID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SixthPositionID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StartPositionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CurrentPositionID");

                    b.HasIndex("EnterFinalTrackPositionID");

                    b.HasIndex("NestPositionID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("SixthPositionID");

                    b.HasIndex("StartPositionID");

                    b.ToTable("Piece");
                });

            modelBuilder.Entity("LudoGame.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("LudoGame.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("X")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Y")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("LudoGame.Move", b =>
                {
                    b.HasOne("LudoGame.Board", null)
                        .WithMany("Moves")
                        .HasForeignKey("BoardID");
                });

            modelBuilder.Entity("LudoGame.Piece", b =>
                {
                    b.HasOne("LudoGame.Position", "CurrentPosition")
                        .WithMany()
                        .HasForeignKey("CurrentPositionID");

                    b.HasOne("LudoGame.Position", "EnterFinalTrackPosition")
                        .WithMany()
                        .HasForeignKey("EnterFinalTrackPositionID");

                    b.HasOne("LudoGame.Position", "NestPosition")
                        .WithMany()
                        .HasForeignKey("NestPositionID");

                    b.HasOne("LudoGame.Player", null)
                        .WithMany("Pieces")
                        .HasForeignKey("PlayerID");

                    b.HasOne("LudoGame.Position", "SixthPosition")
                        .WithMany()
                        .HasForeignKey("SixthPositionID");

                    b.HasOne("LudoGame.Position", "StartPosition")
                        .WithMany()
                        .HasForeignKey("StartPositionID");

                    b.Navigation("CurrentPosition");

                    b.Navigation("EnterFinalTrackPosition");

                    b.Navigation("NestPosition");

                    b.Navigation("SixthPosition");

                    b.Navigation("StartPosition");
                });

            modelBuilder.Entity("LudoGame.Board", b =>
                {
                    b.Navigation("Moves");
                });

            modelBuilder.Entity("LudoGame.Player", b =>
                {
                    b.Navigation("Pieces");
                });
#pragma warning restore 612, 618
        }
    }
}
