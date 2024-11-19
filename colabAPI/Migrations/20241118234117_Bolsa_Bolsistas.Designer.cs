﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using colabAPI.Data;

#nullable disable

namespace colabAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118234117_Bolsa_Bolsistas")]
    partial class Bolsa_Bolsistas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Bolsa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<int>("BolsistaId")
                        .HasColumnType("integer");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("BolsistaId")
                        .IsUnique();

                    b.ToTable("Bolsas");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Financiador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Financiadores");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Pesquisador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int[]>("Times")
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.ToTable("Pesquisadores");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Bolsista", b =>
                {
                    b.HasBaseType("colabAPI.Business.Models.Entities.Pesquisador");

                    b.ToTable("Bolsistas", (string)null);
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Bolsa", b =>
                {
                    b.HasOne("colabAPI.Business.Models.Entities.Bolsista", "Bolsista")
                        .WithOne("Bolsa")
                        .HasForeignKey("colabAPI.Business.Models.Entities.Bolsa", "BolsistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolsista");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Bolsista", b =>
                {
                    b.HasOne("colabAPI.Business.Models.Entities.Pesquisador", null)
                        .WithOne()
                        .HasForeignKey("colabAPI.Business.Models.Entities.Bolsista", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Bolsista", b =>
                {
                    b.Navigation("Bolsa");
                });
#pragma warning restore 612, 618
        }
    }
}
