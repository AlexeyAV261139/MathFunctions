﻿// <auto-generated />
using System;
using ISOCI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Formula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FormulaString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Furmulas");
                });

            modelBuilder.Entity("DAL.Entities.History", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("FormulaId")
                        .HasColumnType("bigint");

                    b.Property<double>("Result")
                        .HasColumnType("double precision");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FormulaId");

                    b.HasIndex("UserId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("DAL.Entities.Parametr", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("FormulaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FormulaId");

                    b.ToTable("Parametros");
                });

            modelBuilder.Entity("DAL.Entities.ParametrValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("HistoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParametrId")
                        .HasColumnType("bigint");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.HasIndex("ParametrId");

                    b.ToTable("ParametrValues");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Entities.History", b =>
                {
                    b.HasOne("DAL.Entities.Formula", "Formula")
                        .WithMany()
                        .HasForeignKey("FormulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formula");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Parametr", b =>
                {
                    b.HasOne("DAL.Entities.Formula", null)
                        .WithMany("Parametrs")
                        .HasForeignKey("FormulaId");
                });

            modelBuilder.Entity("DAL.Entities.ParametrValue", b =>
                {
                    b.HasOne("DAL.Entities.History", null)
                        .WithMany("ParametorValues")
                        .HasForeignKey("HistoryId");

                    b.HasOne("DAL.Entities.Parametr", "Parametr")
                        .WithMany()
                        .HasForeignKey("ParametrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parametr");
                });

            modelBuilder.Entity("DAL.Entities.Formula", b =>
                {
                    b.Navigation("Parametrs");
                });

            modelBuilder.Entity("DAL.Entities.History", b =>
                {
                    b.Navigation("ParametorValues");
                });
#pragma warning restore 612, 618
        }
    }
}
