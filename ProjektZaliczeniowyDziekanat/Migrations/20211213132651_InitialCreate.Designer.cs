﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektZaliczeniowyDziekanat.DAL.Contexts;

namespace ProjektZaliczeniowyDziekanat.Migrations
{
    [DbContext(typeof(DziekanatContext))]
    [Migration("20211213132651_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Finanse", b =>
                {
                    b.Property<int>("PlatnoscID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPlatnosci")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kwota")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("PlatnoscID");

                    b.HasIndex("StudentID");

                    b.ToTable("Finanse");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Grupa", b =>
                {
                    b.Property<string>("GrupaNr")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GrupaNr");

                    b.ToTable("Grupy");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.GrupaZajecia", b =>
                {
                    b.Property<string>("GrupaNr")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("GrupaNr");

                    b.ToTable("GrupaZajecia");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrupaNr")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerIndeksu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PESEL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.HasIndex("GrupaNr");

                    b.ToTable("Studenci");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.StudentLogowanie", b =>
                {
                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasIndex("StudentID");

                    b.ToTable("StudenciLogowanie");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.StudentOceny", b =>
                {
                    b.Property<float>("Ocena")
                        .HasColumnType("real");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("ZajeciaID")
                        .HasColumnType("int");

                    b.HasIndex("StudentID");

                    b.HasIndex("ZajeciaID");

                    b.ToTable("StudentOceny");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Wykladowca", b =>
                {
                    b.Property<int>("WykladowcaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PESEL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StopienNaukowy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WykladowcaID");

                    b.ToTable("Wykladowcy");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.WykladowcaLogowanie", b =>
                {
                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WykladowcaID")
                        .HasColumnType("int");

                    b.HasIndex("WykladowcaID");

                    b.ToTable("WykladowcyLogowanie");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Zajecia", b =>
                {
                    b.Property<int>("ZajeciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazwaZajec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TerminZajec")
                        .HasColumnType("datetime2");

                    b.Property<int>("WykladowcaID")
                        .HasColumnType("int");

                    b.HasKey("ZajeciaID");

                    b.HasIndex("WykladowcaID");

                    b.ToTable("Zajecia");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Finanse", b =>
                {
                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.GrupaZajecia", b =>
                {
                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Grupa", "Grupa")
                        .WithMany()
                        .HasForeignKey("GrupaNr");

                    b.Navigation("Grupa");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Student", b =>
                {
                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Grupa", "Grupa")
                        .WithMany()
                        .HasForeignKey("GrupaNr");

                    b.Navigation("Grupa");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.StudentLogowanie", b =>
                {
                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.StudentOceny", b =>
                {
                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Zajecia", "Zajecia")
                        .WithMany()
                        .HasForeignKey("ZajeciaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Zajecia");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.WykladowcaLogowanie", b =>
                {
                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Wykladowca", "Wykladowca")
                        .WithMany()
                        .HasForeignKey("WykladowcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wykladowca");
                });

            modelBuilder.Entity("ProjektZaliczeniowyDziekanat.DAL.Models.Zajecia", b =>
                {
                    b.HasOne("ProjektZaliczeniowyDziekanat.DAL.Models.Wykladowca", "Wykladowca")
                        .WithMany()
                        .HasForeignKey("WykladowcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wykladowca");
                });
#pragma warning restore 612, 618
        }
    }
}
