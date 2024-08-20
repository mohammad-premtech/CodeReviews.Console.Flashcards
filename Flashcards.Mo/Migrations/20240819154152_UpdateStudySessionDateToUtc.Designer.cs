﻿// <auto-generated />
using System;
using Flashcards.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Flashcards.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240819154152_UpdateStudySessionDateToUtc")]
    partial class UpdateStudySessionDateToUtc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Flashcards.Domain.Entities.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StackId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StackId");

                    b.ToTable("Flashcards", (string)null);
                });

            modelBuilder.Entity("Flashcards.Domain.Entities.Stack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stacks", (string)null);
                });

            modelBuilder.Entity("Flashcards.Domain.Entities.StudySession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<int>("StackId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StackId");

                    b.ToTable("StudySessions", (string)null);
                });

            modelBuilder.Entity("Flashcards.Domain.Entities.Flashcard", b =>
                {
                    b.HasOne("Flashcards.Domain.Entities.Stack", "Stack")
                        .WithMany("Flashcards")
                        .HasForeignKey("StackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stack");
                });

            modelBuilder.Entity("Flashcards.Domain.Entities.StudySession", b =>
                {
                    b.HasOne("Flashcards.Domain.Entities.Stack", "Stack")
                        .WithMany("StudySessions")
                        .HasForeignKey("StackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stack");
                });

            modelBuilder.Entity("Flashcards.Domain.Entities.Stack", b =>
                {
                    b.Navigation("Flashcards");

                    b.Navigation("StudySessions");
                });
#pragma warning restore 612, 618
        }
    }
}
