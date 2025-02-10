﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using colab.Data;

#nullable disable

namespace colab.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250210213641_Refactor")]
    partial class Refactor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("colab.Business.Models.Entities.Bolsa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.Property<string>("PlanoTrabalho")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("integer");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.HasIndex("ProjetoId");

                    b.ToTable("Bolsas");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Financiador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Financiadores");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.HistoricoCargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CargoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data_fim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Data_inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("HistoricosCargo");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.HistoricoProjetoStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("HistoricoStatusProjetos");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Pessoa", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FinanciadorId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Orcamento")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FinanciadorId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Bolsa", b =>
                {
                    b.HasOne("colab.Business.Models.Entities.Pessoa", "Pessoa")
                        .WithOne("Bolsa")
                        .HasForeignKey("colab.Business.Models.Entities.Bolsa", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("colab.Business.Models.Entities.Projeto", "Projeto")
                        .WithMany("Bolsas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.HistoricoCargo", b =>
                {
                    b.HasOne("colab.Business.Models.Entities.Cargo", "Cargo")
                        .WithMany("HistoricosCargo")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("colab.Business.Models.Entities.Pessoa", "Pessoa")
                        .WithMany("HistoricosCargo")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.HistoricoProjetoStatus", b =>
                {
                    b.HasOne("colab.Business.Models.Entities.Projeto", "Projeto")
                        .WithMany("HistoricoStatus")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Projeto", b =>
                {
                    b.HasOne("colab.Business.Models.Entities.Financiador", "Financiador")
                        .WithMany("Projetos")
                        .HasForeignKey("FinanciadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Financiador");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Cargo", b =>
                {
                    b.Navigation("HistoricosCargo");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Financiador", b =>
                {
                    b.Navigation("Projetos");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Pessoa", b =>
                {
                    b.Navigation("Bolsa")
                        .IsRequired();

                    b.Navigation("HistoricosCargo");
                });

            modelBuilder.Entity("colab.Business.Models.Entities.Projeto", b =>
                {
                    b.Navigation("Bolsas");

                    b.Navigation("HistoricoStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
