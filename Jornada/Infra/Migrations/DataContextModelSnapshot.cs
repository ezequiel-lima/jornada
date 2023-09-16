﻿// <auto-generated />
using System;
using Jornada.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jornada.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jornada.Models.Declaracao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Depoimento")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeDoAutor")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Declaracao", (string)null);
                });

            modelBuilder.Entity("Jornada.Models.Destino", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0.0m);

                    b.Property<string>("TextoDescritivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Destino", (string)null);
                });

            modelBuilder.Entity("Jornada.Models.Foto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeclaracaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DestinoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeclaracaoId");

                    b.HasIndex("DestinoId");

                    b.ToTable("Foto", (string)null);
                });

            modelBuilder.Entity("Jornada.Models.Foto", b =>
                {
                    b.HasOne("Jornada.Models.Declaracao", null)
                        .WithMany("Fotos")
                        .HasForeignKey("DeclaracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Declaracao_Foto");

                    b.HasOne("Jornada.Models.Destino", null)
                        .WithMany("Fotos")
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Destino_Foto");
                });

            modelBuilder.Entity("Jornada.Models.Declaracao", b =>
                {
                    b.Navigation("Fotos");
                });

            modelBuilder.Entity("Jornada.Models.Destino", b =>
                {
                    b.Navigation("Fotos");
                });
#pragma warning restore 612, 618
        }
    }
}
