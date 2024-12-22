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
    [Migration("20241222164644_hardCode2")]
    partial class hardCode2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ISOCI.DAL.Entities.AdminParamsEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ExpressionEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("HistoryEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("ParamName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("ParamValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ExpressionEntityId");

                    b.HasIndex("HistoryEntityId");

                    b.ToTable("AdminParams");
                });

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

            modelBuilder.Entity("ISOCI.DAL.Entities.UserParamsEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("HistoryEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("ParamName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("ParamValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("HistoryEntityId");

                    b.ToTable("UserParams");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.AdminParamsEntity", b =>
                {
                    b.HasOne("ISOCI.DAL.Entities.ExpressionEntity", null)
                        .WithMany("Params")
                        .HasForeignKey("ExpressionEntityId");

                    b.HasOne("ISOCI.DAL.Entities.HistoryEntity", null)
                        .WithMany("ApminParams")
                        .HasForeignKey("HistoryEntityId");
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

            modelBuilder.Entity("ISOCI.DAL.Entities.UserParamsEntity", b =>
                {
                    b.HasOne("ISOCI.DAL.Entities.HistoryEntity", null)
                        .WithMany("UserParams")
                        .HasForeignKey("HistoryEntityId");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.ExpressionEntity", b =>
                {
                    b.Navigation("Params");
                });

            modelBuilder.Entity("ISOCI.DAL.Entities.HistoryEntity", b =>
                {
                    b.Navigation("ApminParams");

                    b.Navigation("UserParams");
                });
#pragma warning restore 612, 618
        }
    }
}