﻿// <auto-generated />
using System;
using BlogCleanArch.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogCleanArch.Persistence.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20230816210716_fixed_structure")]
    partial class fixed_structure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2712),
                            PostId = 1,
                            Text = "Test Comment 1",
                            UpdatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2716)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2718),
                            PostId = 1,
                            Text = "Test Comment 2",
                            UpdatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2718)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2719),
                            PostId = 2,
                            Text = "Test Comment 3",
                            UpdatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2720)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2721),
                            PostId = 2,
                            Text = "Test Comment 4",
                            UpdatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(2720)
                        });
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Test Content 1",
                            CreatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(4217),
                            Title = "Test Post 1",
                            UpdatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(4218)
                        },
                        new
                        {
                            Id = 2,
                            Content = "Test Content 2",
                            CreatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(4221),
                            Title = "Test Post 2",
                            UpdatedAt = new DateTime(2023, 8, 16, 21, 7, 16, 518, DateTimeKind.Utc).AddTicks(4221)
                        });
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
