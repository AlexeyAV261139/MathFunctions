﻿// <auto-generated />
using System;
using ISOCI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241222143709_ChengeVisability")]
    partial class ChengeVisability
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ISOCI.DAL.Entities.ExpressionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ExpressionString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Expressions");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.HistoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ExpressionId")
                        .HasColumnType("bigint");

                    b.Property<double>("Result")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ExpressionId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.ParamValueEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("HistoryEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParamId")
                        .HasColumnType("bigint");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("HistoryEntityId");

                    b.HasIndex("ParamId");

                    b.ToTable("ParamValues");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.ParamsEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ExpressionEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("ParamName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExpressionEntityId");

                    b.ToTable("Params");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.HistoryEntity", b =>
                {
                    b.HasOne("ISOCI.DAL.Entities.ExpressionEntity", "Expression")
                        .WithMany()
                        .HasForeignKey("ExpressionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expression");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.ParamValueEntity", b =>
                {
                    b.HasOne("ISOCI.DAL.Entities.HistoryEntity", null)
                        .WithMany("ParamValues")
                        .HasForeignKey("HistoryEntityId");

                    b.HasOne("ISOCI.DAL.Entities.ParamsEntity", "Param")
                        .WithMany()
                        .HasForeignKey("ParamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Param");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.ParamsEntity", b =>
                {
                    b.HasOne("ISOCI.DAL.Entities.ExpressionEntity", null)
                        .WithMany("Params")
                        .HasForeignKey("ExpressionEntityId");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.ExpressionEntity", b =>
                {
                    b.Navigation("Params");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.HistoryEntity", b =>
                {
                    b.Navigation("ParamValues");
                });
#pragma warning restore 612, 618
        }
    }
}
