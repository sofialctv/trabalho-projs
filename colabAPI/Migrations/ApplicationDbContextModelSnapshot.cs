﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using colabAPI.Data;

#nullable disable

namespace colabAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Categoria")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Bolsa");
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

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Orientador", b =>
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

                    b.Property<int>("bolsaid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("bolsaid");

                    b.ToTable("Orientadores");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PesquisadorId")
                        .HasColumnType("integer");

                    b.Property<double>("Valor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("PesquisadorId")
                        .IsUnique();

                    b.ToTable("Bolsas");
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

                    b.HasIndex("FinanciadorId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Orientador", b =>
            modelBuilder.Entity("colabAPI.Business.Models.Entities.Orientador", b =>
                {
                    b.HasOne("colabAPI.Business.Models.Entities.Bolsa", "bolsa")
                        .WithMany()
                        .HasForeignKey("bolsaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bolsa");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Projeto", b =>
                {
                    b.HasBaseType("colabAPI.Business.Models.Entities.Pesquisador");

                    b.Property<int?>("OrientadorId")
                        .HasColumnType("integer");

                    b.HasIndex("OrientadorId");

                    b.ToTable("Bolsistas", (string)null);
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Orientador", b =>
                {
                    b.HasBaseType("colabAPI.Business.Models.Entities.Pesquisador");

                    b.ToTable("Orientador");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Bolsa", b =>
                {
                    b.HasOne("colabAPI.Business.Models.Entities.Pesquisador", "Pesquisador")
                        .WithOne("Bolsa")
                        .HasForeignKey("colabAPI.Business.Models.Entities.Bolsa", "PesquisadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pesquisador");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Bolsista", b =>
                {
                    b.HasOne("colabAPI.Business.Models.Entities.Pesquisador", null)
                        .WithOne()
                        .HasForeignKey("colabAPI.Business.Models.Entities.Bolsista", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("colabAPI.Business.Models.Entities.Orientador", "Orientador")
                        .WithMany("Bolsistas")
                        .HasForeignKey("OrientadorId");

                    b.Navigation("Orientador");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Orientador", b =>
                {
                    b.HasOne("colabAPI.Business.Models.Entities.Pesquisador", null)
                        .WithOne()
                        .HasForeignKey("colabAPI.Business.Models.Entities.Orientador", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Pesquisador", b =>
                {
                    b.Navigation("Bolsa");
                });

            modelBuilder.Entity("colabAPI.Business.Models.Entities.Orientador", b =>
                {
                    b.Navigation("Bolsistas");
                });
#pragma warning restore 612, 618
        }
    }
}
