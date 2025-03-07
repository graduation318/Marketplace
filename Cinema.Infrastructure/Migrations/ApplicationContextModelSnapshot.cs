﻿// <auto-generated />
using System;
using Cinema.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cinema.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cinema.Data.Hall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("Cinema.Data.HallSeats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<Guid>("PriceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("PriceId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Cinema.Data.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Cinema.Data.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SeatType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Cinema.Data.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Cinema.Data.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("HallSeatsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PriceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HallSeatsId");

                    b.HasIndex("PriceId");

                    b.HasIndex("SessionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Cinema.Data.HallSeats", b =>
                {
                    b.HasOne("Cinema.Data.Hall", "Hall")
                        .WithMany("Seats")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Data.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Price");
                });

            modelBuilder.Entity("Cinema.Data.Session", b =>
                {
                    b.HasOne("Cinema.Data.Hall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Data.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Cinema.Data.Ticket", b =>
                {
                    b.HasOne("Cinema.Data.HallSeats", "HallSeats")
                        .WithMany()
                        .HasForeignKey("HallSeatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Data.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Data.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HallSeats");

                    b.Navigation("Price");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Cinema.Data.Hall", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Cinema.Data.Movie", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
